using SteamGameReviews.Steam;
using SteamGameReviews.Steam.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SteamGameReviews
{
    public partial class MainWindow : Form
    {
        private Dictionary<long, AppInfo> SelectedApps = new Dictionary<long, AppInfo>();

        public MainWindow()
        {
            InitializeComponent();
            tb_outputDirectory.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void SelectOputDirectory_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                tb_outputDirectory.Text = dialog.SelectedPath;
            }
        }

        private void SelectedGamesCallback(IDictionary<long, AppInfo> selectedApps)
        {
            // Redo grid view
            foreach (KeyValuePair<long, AppInfo> kvp in selectedApps)
            {
                AppInfo app = kvp.Value;

                if (SelectedApps.ContainsKey(kvp.Key))
                {
                    // Skip duplicates
                    continue;
                }

                int row = dgv_AppListView.Rows.Add();
                dgv_AppListView.Rows[row].Tag = app;
                dgv_AppListView.Rows[row].Cells["AppId"].Value = app.Id;
                dgv_AppListView.Rows[row].Cells["AppName"].Value = app.Name;
                dgv_AppListView.Rows[row].Cells["NumReviews"].Value = SteamConstants.MinReviews;
                dgv_AppListView.Rows[row].Cells["Language"].Value = "Inglés";
                dgv_AppListView.Rows[row].Cells["ReviewType"].Value = "Todas";
                dgv_AppListView.Rows[row].Cells["FilterOfftopic"].Value = false;
                SelectedApps.Add(app.Id, app);
            }
        }

        private void AddGame_Click(object sender, EventArgs e)
        {
            var dialog = new SearchGameDialog(SelectedGamesCallback);
            dialog.ShowDialog();
        }

        private void AppListView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            foreach (DataGridViewRow row in dgv_AppListView.SelectedRows)
            {
                long appid = (long) row.Cells["AppId"].Value;
                SelectedApps.Remove(appid);
            }
        }

        private bool IsUserInputValid()
        {
            if (SelectedApps.Count == 0)
            {
                MessageBox.Show(
                    "No hay juegos seleccionados.",
                    "No se pudo iniciar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            string outputPath = tb_outputDirectory.Text;
            if (string.IsNullOrWhiteSpace(outputPath) || !Directory.Exists(outputPath))
            {
                MessageBox.Show(
                    "Debe especificar una carpeta de salida.",
                    "No se pudo iniciar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }


            foreach (DataGridViewRow row in dgv_AppListView.Rows)
            {
                AppInfo app = (AppInfo) row.Tag!;
                int numReviews = ParseAndValidateNumReviews(row.Cells["NumReviews"].Value);
                if (numReviews < SteamConstants.MinReviews || numReviews > SteamConstants.MaxReviews)
                {
                    MessageBox.Show(
                        "Número de reviews contiene un valor incorrecto. " +
                        $"Solo se permiten valores entre {SteamConstants.MinReviews} y {SteamConstants.MaxReviews}. " +
                        $"({app.Name})",
                        "No se puede iniciar.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return false;
                }
            }

            return true;
        }

        private async void Start_Click(object sender, EventArgs e)
        {
            if (!IsUserInputValid())
            {
                return;
            }

            pb_DownloadProgress.Maximum = SelectedApps.Count;
            pb_DownloadProgress.Value = 0;
            pb_DownloadProgress.Visible = true;
            Enabled = false;

            bool success = false;

            foreach (DataGridViewRow row in dgv_AppListView.Rows)
            {
                var payload = new RequestPayload();
                payload.AppInfo = (AppInfo) row.Tag!;
                payload.NumReviews = (int) row.Cells["NumReviews"].Value;
                payload.Language = GetLanguage(row.Cells["Language"].Value.ToString()!);
                payload.ReviewType = GetReviewType(row.Cells["ReviewType"].Value.ToString()!);
                payload.FilterOfftopic = Convert.ToBoolean(row.Cells["FilterOfftopic"].Value);

                try
                {
                    await ReviewFetcher.FetchReviewsAsync(payload);
                    pb_DownloadProgress.PerformStep();
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show(
                        "Ocurrió un error de red. Verifica tu conexión a Internet.",
                        "Error.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    success = false;
                    break;
                }
            }

            if (success)
            {
                string filename = await WriteReviewsToCsvAsync();
                pb_DownloadProgress.Value = pb_DownloadProgress.Maximum;

                MessageBox.Show(
                    "Se ha completado la descarga correctamente." +
                    $"Archivo guardado en: {filename}",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                if (chk_OpenFolder.Checked)
                {
                    Process.Start("explorer.exe", tb_outputDirectory.Text);
                }
            }

            Enabled = true;
            pb_DownloadProgress.Visible = false;
        }

        private async Task<string> WriteReviewsToCsvAsync()
        {
            string filename = Path.Combine(tb_outputDirectory.Text, "SteamReviews.csv");
            await using var writter = new SteamReviewCsvWritter(filename);
            await writter.WriteHeaders();

            foreach (AppInfo app in SelectedApps.Values)
            {
                await writter.WriteAppInfo(app);
            }

            return filename;
        }

        private static int ParseAndValidateNumReviews(object obj)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private static string GetLanguage(string text)
        {
            switch (text)
            {
                case "Inglés":
                    return "english";
                case "Español":
                    return "spanish";
                default:
                    throw new NotImplementedException();
            }
        }

        private static string GetReviewType(string text)
        {
            switch (text)
            {
                case "Todas":
                    return "all";
                case "Solo positivas":
                    return "positive";
                case "Solo negativas":
                    return "negative";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
