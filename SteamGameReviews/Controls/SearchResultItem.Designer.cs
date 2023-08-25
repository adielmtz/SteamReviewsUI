namespace SteamGameReviews.Controls
{
    partial class SearchResultItem
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            pb_ThumbImage = new System.Windows.Forms.PictureBox();
            lbl_AppName = new System.Windows.Forms.Label();
            lbl_AppId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) pb_ThumbImage).BeginInit();
            SuspendLayout();
            // 
            // pb_ThumbImage
            // 
            pb_ThumbImage.Location = new System.Drawing.Point(3, 3);
            pb_ThumbImage.Name = "pb_ThumbImage";
            pb_ThumbImage.Size = new System.Drawing.Size(231, 87);
            pb_ThumbImage.TabIndex = 0;
            pb_ThumbImage.TabStop = false;
            pb_ThumbImage.Click += SearchResultItem_Click;
            pb_ThumbImage.MouseEnter += SearchResultItem_MouseEnter;
            pb_ThumbImage.MouseLeave += SearchResultItem_MouseLeave;
            // 
            // lbl_AppName
            // 
            lbl_AppName.AutoSize = true;
            lbl_AppName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbl_AppName.Location = new System.Drawing.Point(240, 3);
            lbl_AppName.Name = "lbl_AppName";
            lbl_AppName.Size = new System.Drawing.Size(131, 30);
            lbl_AppName.TabIndex = 1;
            lbl_AppName.Text = "{{AppName}}";
            lbl_AppName.Click += SearchResultItem_Click;
            lbl_AppName.MouseEnter += SearchResultItem_MouseEnter;
            lbl_AppName.MouseLeave += SearchResultItem_MouseLeave;
            // 
            // lbl_AppId
            // 
            lbl_AppId.AutoSize = true;
            lbl_AppId.Location = new System.Drawing.Point(240, 43);
            lbl_AppId.Name = "lbl_AppId";
            lbl_AppId.Size = new System.Drawing.Size(93, 15);
            lbl_AppId.TabIndex = 2;
            lbl_AppId.Text = "AppId: {{AppId}}";
            lbl_AppId.Click += SearchResultItem_Click;
            // 
            // SearchResultItem
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            Controls.Add(lbl_AppId);
            Controls.Add(lbl_AppName);
            Controls.Add(pb_ThumbImage);
            Cursor = System.Windows.Forms.Cursors.Hand;
            MinimumSize = new System.Drawing.Size(760, 92);
            Name = "SearchResultItem";
            Size = new System.Drawing.Size(960, 92);
            Click += SearchResultItem_Click;
            MouseEnter += SearchResultItem_MouseEnter;
            MouseLeave += SearchResultItem_MouseLeave;
            ((System.ComponentModel.ISupportInitialize) pb_ThumbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pb_ThumbImage;
        private System.Windows.Forms.Label lbl_AppName;
        private System.Windows.Forms.Label lbl_AppId;
    }
}
