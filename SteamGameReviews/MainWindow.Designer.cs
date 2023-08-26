namespace SteamGameReviews
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_SelectOutputDir = new System.Windows.Forms.Button();
            tb_outputDirectory = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            btn_Start = new System.Windows.Forms.Button();
            dgv_AppListView = new System.Windows.Forms.DataGridView();
            AppId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            AppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            NumReviews = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Language = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ReviewType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            FilterOfftopic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            btn_AddGame = new System.Windows.Forms.Button();
            pb_DownloadProgress = new System.Windows.Forms.ProgressBar();
            chk_OpenFolder = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize) dgv_AppListView).BeginInit();
            SuspendLayout();
            // 
            // btn_SelectOutputDir
            // 
            btn_SelectOutputDir.Location = new System.Drawing.Point(293, 27);
            btn_SelectOutputDir.Name = "btn_SelectOutputDir";
            btn_SelectOutputDir.Size = new System.Drawing.Size(77, 23);
            btn_SelectOutputDir.TabIndex = 1;
            btn_SelectOutputDir.Text = "Seleccionar";
            btn_SelectOutputDir.UseVisualStyleBackColor = true;
            btn_SelectOutputDir.Click += SelectOputDirectory_Click;
            // 
            // tb_outputDirectory
            // 
            tb_outputDirectory.Location = new System.Drawing.Point(12, 27);
            tb_outputDirectory.Name = "tb_outputDirectory";
            tb_outputDirectory.Size = new System.Drawing.Size(275, 23);
            tb_outputDirectory.TabIndex = 1;
            tb_outputDirectory.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 15);
            label1.TabIndex = 0;
            label1.Text = "Carpeta de salida:";
            // 
            // btn_Start
            // 
            btn_Start.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Start.Location = new System.Drawing.Point(991, 5);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new System.Drawing.Size(261, 45);
            btn_Start.TabIndex = 1;
            btn_Start.TabStop = false;
            btn_Start.Text = "Iniciar descarga";
            btn_Start.UseVisualStyleBackColor = true;
            btn_Start.Click += Start_Click;
            // 
            // dgv_AppListView
            // 
            dgv_AppListView.AllowUserToAddRows = false;
            dgv_AppListView.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgv_AppListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_AppListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { AppId, AppName, NumReviews, Language, ReviewType, FilterOfftopic });
            dgv_AppListView.Location = new System.Drawing.Point(12, 56);
            dgv_AppListView.Name = "dgv_AppListView";
            dgv_AppListView.RowTemplate.Height = 25;
            dgv_AppListView.Size = new System.Drawing.Size(1240, 613);
            dgv_AppListView.TabIndex = 2;
            dgv_AppListView.TabStop = false;
            dgv_AppListView.UserDeletingRow += AppListView_UserDeletingRow;
            // 
            // AppId
            // 
            AppId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            AppId.HeaderText = "AppId";
            AppId.Name = "AppId";
            AppId.ReadOnly = true;
            AppId.Width = 64;
            // 
            // AppName
            // 
            AppName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            AppName.HeaderText = "Nombre";
            AppName.Name = "AppName";
            AppName.ReadOnly = true;
            // 
            // NumReviews
            // 
            NumReviews.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            NumReviews.HeaderText = "Número de reviews";
            NumReviews.Name = "NumReviews";
            NumReviews.Width = 88;
            // 
            // Language
            // 
            Language.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Language.HeaderText = "Idioma";
            Language.Items.AddRange(new object[] { "Inglés", "Español" });
            Language.Name = "Language";
            // 
            // ReviewType
            // 
            ReviewType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            ReviewType.HeaderText = "Tipo de reseña";
            ReviewType.Items.AddRange(new object[] { "Todas", "Solo positivas", "Solo negativas" });
            ReviewType.Name = "ReviewType";
            // 
            // FilterOfftopic
            // 
            FilterOfftopic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            FilterOfftopic.HeaderText = "Filtrar reseñas irrelevantes";
            FilterOfftopic.Name = "FilterOfftopic";
            FilterOfftopic.Width = 133;
            // 
            // btn_AddGame
            // 
            btn_AddGame.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_AddGame.Location = new System.Drawing.Point(837, 5);
            btn_AddGame.Name = "btn_AddGame";
            btn_AddGame.Size = new System.Drawing.Size(122, 45);
            btn_AddGame.TabIndex = 2;
            btn_AddGame.Text = "Añadir juego";
            btn_AddGame.UseVisualStyleBackColor = true;
            btn_AddGame.Click += AddGame_Click;
            // 
            // pb_DownloadProgress
            // 
            pb_DownloadProgress.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            pb_DownloadProgress.Location = new System.Drawing.Point(638, 27);
            pb_DownloadProgress.Name = "pb_DownloadProgress";
            pb_DownloadProgress.Size = new System.Drawing.Size(193, 23);
            pb_DownloadProgress.Step = 1;
            pb_DownloadProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            pb_DownloadProgress.TabIndex = 3;
            pb_DownloadProgress.Visible = false;
            // 
            // chk_OpenFolder
            // 
            chk_OpenFolder.AutoSize = true;
            chk_OpenFolder.Checked = true;
            chk_OpenFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_OpenFolder.Location = new System.Drawing.Point(376, 29);
            chk_OpenFolder.Name = "chk_OpenFolder";
            chk_OpenFolder.Size = new System.Drawing.Size(212, 19);
            chk_OpenFolder.TabIndex = 4;
            chk_OpenFolder.Text = "Abrir carpeta al finalizar la descarga";
            chk_OpenFolder.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(chk_OpenFolder);
            Controls.Add(pb_DownloadProgress);
            Controls.Add(btn_AddGame);
            Controls.Add(label1);
            Controls.Add(btn_SelectOutputDir);
            Controls.Add(dgv_AppListView);
            Controls.Add(tb_outputDirectory);
            Controls.Add(btn_Start);
            Name = "MainWindow";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Steam Game Reviews";
            ((System.ComponentModel.ISupportInitialize) dgv_AppListView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox tb_outputDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SelectOutputDir;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.DataGridView dgv_AppListView;
        private System.Windows.Forms.Button btn_AddGame;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumReviews;
        private System.Windows.Forms.DataGridViewComboBoxColumn Language;
        private System.Windows.Forms.DataGridViewComboBoxColumn ReviewType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FilterOfftopic;
        private System.Windows.Forms.ProgressBar pb_DownloadProgress;
        private System.Windows.Forms.CheckBox chk_OpenFolder;
    }
}
