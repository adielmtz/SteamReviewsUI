namespace SteamGameReviews
{
    partial class SearchGameDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tb_SearchTerms = new System.Windows.Forms.TextBox();
            btn_DoSearch = new System.Windows.Forms.Button();
            ResultContainer = new System.Windows.Forms.FlowLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            button1 = new System.Windows.Forms.Button();
            gb_SelectedGamesBox = new System.Windows.Forms.GroupBox();
            SelectedAppsContainer = new System.Windows.Forms.FlowLayoutPanel();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            gb_SelectedGamesBox.SuspendLayout();
            SuspendLayout();
            // 
            // tb_SearchTerms
            // 
            tb_SearchTerms.Location = new System.Drawing.Point(12, 27);
            tb_SearchTerms.Name = "tb_SearchTerms";
            tb_SearchTerms.Size = new System.Drawing.Size(373, 23);
            tb_SearchTerms.TabIndex = 1;
            tb_SearchTerms.KeyUp += SearchTerms_KeyUp;
            // 
            // btn_DoSearch
            // 
            btn_DoSearch.Location = new System.Drawing.Point(391, 27);
            btn_DoSearch.Name = "btn_DoSearch";
            btn_DoSearch.Size = new System.Drawing.Size(75, 23);
            btn_DoSearch.TabIndex = 2;
            btn_DoSearch.Text = "Buscar";
            btn_DoSearch.UseVisualStyleBackColor = true;
            btn_DoSearch.Click += DoSearch_Click;
            // 
            // ResultContainer
            // 
            ResultContainer.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ResultContainer.AutoScroll = true;
            ResultContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            ResultContainer.Location = new System.Drawing.Point(6, 22);
            ResultContainer.Name = "ResultContainer";
            ResultContainer.Size = new System.Drawing.Size(734, 585);
            ResultContainer.TabIndex = 3;
            ResultContainer.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(106, 15);
            label1.TabIndex = 4;
            label1.Text = "Nombre del juego:";
            // 
            // groupBox1
            // 
            groupBox1.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(ResultContainer);
            groupBox1.Location = new System.Drawing.Point(12, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(746, 613);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Resultados";
            // 
            // button1
            // 
            button1.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(992, 9);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(260, 41);
            button1.TabIndex = 6;
            button1.Text = "Agregar seleccionados";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AddAndClose_Click;
            // 
            // gb_SelectedGamesBox
            // 
            gb_SelectedGamesBox.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            gb_SelectedGamesBox.Controls.Add(SelectedAppsContainer);
            gb_SelectedGamesBox.Location = new System.Drawing.Point(812, 56);
            gb_SelectedGamesBox.Name = "gb_SelectedGamesBox";
            gb_SelectedGamesBox.Size = new System.Drawing.Size(440, 613);
            gb_SelectedGamesBox.TabIndex = 8;
            gb_SelectedGamesBox.TabStop = false;
            gb_SelectedGamesBox.Text = "0 juegos seleccionados";
            // 
            // SelectedAppsContainer
            // 
            SelectedAppsContainer.Anchor =  System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            SelectedAppsContainer.AutoScroll = true;
            SelectedAppsContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            SelectedAppsContainer.Location = new System.Drawing.Point(6, 22);
            SelectedAppsContainer.Name = "SelectedAppsContainer";
            SelectedAppsContainer.Size = new System.Drawing.Size(428, 585);
            SelectedAppsContainer.TabIndex = 0;
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            button2.Location = new System.Drawing.Point(764, 317);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(42, 42);
            button2.TabIndex = 9;
            button2.Text = ">>";
            button2.UseVisualStyleBackColor = true;
            button2.Click += AddSelectedGame_Click;
            // 
            // button3
            // 
            button3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            button3.Location = new System.Drawing.Point(764, 365);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(42, 42);
            button3.TabIndex = 10;
            button3.Text = "<<";
            button3.UseVisualStyleBackColor = true;
            button3.Click += RemoveSelectedGame_Clock;
            // 
            // SearchGameDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(gb_SelectedGamesBox);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(btn_DoSearch);
            Controls.Add(tb_SearchTerms);
            Name = "SearchGameDialog";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Buscar juegos en Steam";
            FormClosing += SearchGameDialog_FormClosing;
            groupBox1.ResumeLayout(false);
            gb_SelectedGamesBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox tb_SearchTerms;
        private System.Windows.Forms.Button btn_DoSearch;
        private System.Windows.Forms.FlowLayoutPanel ResultContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gb_SelectedGamesBox;
        private System.Windows.Forms.FlowLayoutPanel SelectedAppsContainer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}