using SteamGameReviews.Controls;
using SteamGameReviews.Steam;
using SteamGameReviews.Steam.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamGameReviews
{
    public partial class SearchGameDialog : Form
    {
        internal IDictionary<long, AppInfo>? apps;

        public SearchGameDialog()
        {
            InitializeComponent();
        }

        internal void SetAppDictionary(IDictionary<long, AppInfo> apps)
        {
            this.apps = apps;
        }

        private async void DoSearch_Click(object sender, EventArgs e)
        {
            await ExecuteSearchAsync();
        }

        private async void SearchTerms_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await ExecuteSearchAsync();
            }
        }

        private async Task ExecuteSearchAsync()
        {
            IList<AppInfo> results = await SteamSearchEngine.SearchAsync(tb_SearchTerms.Text);
            ResultContainer.Controls.Clear();

            foreach (AppInfo result in results)
            {
                var control = new SearchResultItem();
                control.ResultItem = result;
                control.AutoSize = true;
                control.Dock = DockStyle.Fill;
                control.ClickCallback = ClickCallback;
                ResultContainer.Controls.Add(control);
            }
        }

        private void ClickCallback(AppInfo app)
        {
            if (apps != null)
            {
                apps[app.Id] = app;
            }

            Close();
        }
    }
}
