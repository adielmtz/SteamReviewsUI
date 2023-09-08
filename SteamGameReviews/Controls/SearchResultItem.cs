using SteamGameReviews.Steam.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteamGameReviews.Controls
{
    internal partial class SearchResultItem : UserControl
    {
        private AppInfo? app;
        private bool _selected = false;

        public AppInfo AppInfo
        {
            get => app ?? new AppInfo { Id = 0, Name = string.Empty, ImageUrl = string.Empty };
            set => SetSearchResultItem(value);
        }

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                BackColor = _selected ? SystemColors.ActiveCaption : SystemColors.Control;
            }
        }

        public SearchResultItem()
        {
            InitializeComponent();
        }

        private void SetSearchResultItem(AppInfo app)
        {
            this.app = app;
            lbl_AppName.Text = app.Name;
            lbl_AppId.Text = $"AppId: {app.Id}";
            pb_ThumbImage.Load(app.ImageUrl);
        }

        private void SearchResultItem_MouseEnter(object sender, EventArgs e)
        {
            BackColor = SystemColors.ActiveCaption;
        }

        private void SearchResultItem_MouseLeave(object sender, EventArgs e)
        {
            if (!Selected)
            {
                BackColor = SystemColors.Control;
            }
        }

        private void SearchResultItem_Click(object sender, EventArgs e)
        {
            Selected = !Selected;
        }
    }
}
