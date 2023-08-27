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
            lbl_SelectedGameCount.Text = "";
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
                    control.SelectionChangedCallback = OnSelectionChange;

                    if (selectedApps.ContainsKey(result.Id))
                    {
                        control.Selected = true;
                    }

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

        private void OnSelectionChange(SearchResultItem item)
        {
            if (item.Selected)
            {
                selectedApps[item.AppInfo.Id] = item.AppInfo;
            }
            else
            {
                selectedApps.Remove(item.AppInfo.Id);
            }

            lbl_SelectedGameCount.Text = $"{selectedApps.Count} seleccionados.";
        }

        private void AddAndClose_Click(object sender, EventArgs e)
        {
            callback?.Invoke(selectedApps);
            Close();
        }
    }
}
