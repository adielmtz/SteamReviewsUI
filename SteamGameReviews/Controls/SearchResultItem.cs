using SteamGameReviews.Steam;
using System.Drawing;
using System.Windows.Forms;

namespace SteamGameReviews.Controls
{
    internal partial class SearchResultItem : UserControl
    {
        private SearchResult? item;

        public SearchResult ResultItem
        {
            get => item ?? new() { AppId = 0, AppName = "", ImageUrl = "", };
            set => SetSearchResultItem(value);
        }

        public SearchResultItem()
        {
            InitializeComponent();
        }

        private void SetSearchResultItem(SearchResult item)
        {
            this.item = item;
            lbl_AppName.Text = item.AppName;
            pb_ThumbImage.Load(item.ImageUrl);
        }

        private void SearchResultItem_MouseEnter(object sender, System.EventArgs e)
        {
            BackColor = SystemColors.ActiveCaption;
        }

        private void SearchResultItem_MouseLeave(object sender, System.EventArgs e)
        {
            BackColor = SystemColors.Control;
        }
    }
}
