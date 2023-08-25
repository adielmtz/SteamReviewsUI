using SteamGameReviews.Steam.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteamGameReviews.Controls
{
    internal partial class SearchResultItem : UserControl
    {
        private AppInfo? item;

        public AppInfo ResultItem
        {
            get => item ?? new() { Id = 0, Name = "", ImageUrl = ""};
            set => SetSearchResultItem(value);
        }

        public Action<AppInfo>? ClickCallback { get; set; }

        public SearchResultItem()
        {
            InitializeComponent();
        }

        private void SetSearchResultItem(AppInfo item)
        {
            this.item = item;
            lbl_AppName.Text = item.Name;
            lbl_AppId.Text = $"AppId: {item.Id}";
            pb_ThumbImage.Load(item.ImageUrl);
        }

        private void SearchResultItem_MouseEnter(object sender, EventArgs e)
        {
            BackColor = SystemColors.ActiveCaption;
        }

        private void SearchResultItem_MouseLeave(object sender, EventArgs e)
        {
            BackColor = SystemColors.Control;
        }

        private void SearchResultItem_Click(object sender, EventArgs e)
        {
            ClickCallback?.Invoke(item!);
        }
    }
}
