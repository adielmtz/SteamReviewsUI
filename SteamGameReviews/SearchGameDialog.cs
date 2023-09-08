using SteamGameReviews.Controls;
using SteamGameReviews.Steam;
using SteamGameReviews.Steam.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamGameReviews
{
    public partial class SearchGameDialog : Form
    {
        private IDictionary<long, AppInfo> selectedApps = new Dictionary<long, AppInfo>();
        private Action<IDictionary<long, AppInfo>>? callback;

        public SearchGameDialog()
        {
            InitializeComponent();
        }

        internal SearchGameDialog(Action<IDictionary<long, AppInfo>> callback) : this()
        {
            this.callback = callback;
        }

        private async void DoSearch_Click(object sender, EventArgs e)
        {
            await ExecuteSearchAsync();
        }

        private async void SearchTerms_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                await ExecuteSearchAsync();
            }
        }

        private async Task ExecuteSearchAsync()
        {
            try
            {
                IList<AppInfo> results = await SteamSearchEngine.SearchAsync(tb_SearchTerms.Text);
                ResultContainer.Controls.Clear();

                foreach (AppInfo result in results)
                {
                    var control = new SearchResultItem();
                    control.AppInfo = result;
                    control.AutoSize = true;
                    control.Dock = DockStyle.Fill;
                    ResultContainer.Controls.Add(control);
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show(
                    "Ocurrió un error de red. Verifica tu conexión a Internet.",
                    "Error.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void AddAndClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SearchGameDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            callback?.Invoke(selectedApps);
        }

        private void AddSelectedGame_Click(object sender, EventArgs e)
        {
            foreach (Control control in ResultContainer.Controls)
            {
                if (control is SearchResultItem item)
                {
                    if (item.Selected && !selectedApps.ContainsKey(item.AppInfo.Id))
                    {
                        selectedApps.Add(item.AppInfo.Id, item.AppInfo);
                        SelectedAppsContainer.Controls.Add(control);
                        item.Selected = false;
                    }
                }
            }

            gb_SelectedGamesBox.Text = $"{selectedApps.Count} juegos seleccionados";
        }

        private void RemoveSelectedGame_Clock(object sender, EventArgs e)
        {
            foreach (Control control in SelectedAppsContainer.Controls)
            {
                if (control is SearchResultItem item)
                {
                    if (item.Selected)
                    {
                        selectedApps.Remove(item.AppInfo.Id);
                        ResultContainer.Controls.Add(control);
                        item.Selected = false;
                    }
                }
            }

            gb_SelectedGamesBox.Text = $"{selectedApps.Count} juegos seleccionados";
        }
    }
}
