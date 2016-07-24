namespace TvForms
{
    partial class ucUserView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabUserView = new System.Windows.Forms.TabControl();
            this.tabUsView_AllCh = new System.Windows.Forms.TabPage();
            this.tabUsView_MyCh = new System.Windows.Forms.TabPage();
            this.tabUsView_TvShow = new System.Windows.Forms.TabPage();
            this.tabUserView.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabUserView
            // 
            this.tabUserView.Controls.Add(this.tabUsView_AllCh);
            this.tabUserView.Controls.Add(this.tabUsView_MyCh);
            this.tabUserView.Controls.Add(this.tabUsView_TvShow);
            this.tabUserView.Location = new System.Drawing.Point(0, 0);
            this.tabUserView.Multiline = true;
            this.tabUserView.Name = "tabUserView";
            this.tabUserView.SelectedIndex = 0;
            this.tabUserView.Size = new System.Drawing.Size(642, 353);
            this.tabUserView.TabIndex = 4;
            this.tabUserView.Tag = "";
            // 
            // tabUsView_AllCh
            // 
            this.tabUsView_AllCh.BackColor = System.Drawing.Color.Khaki;
            this.tabUsView_AllCh.Location = new System.Drawing.Point(4, 22);
            this.tabUsView_AllCh.Name = "tabUsView_AllCh";
            this.tabUsView_AllCh.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsView_AllCh.Size = new System.Drawing.Size(634, 327);
            this.tabUsView_AllCh.TabIndex = 0;
            this.tabUsView_AllCh.Text = "All Channels";
            // 
            // tabUsView_MyCh
            // 
            this.tabUsView_MyCh.BackColor = System.Drawing.Color.MistyRose;
            this.tabUsView_MyCh.Location = new System.Drawing.Point(4, 22);
            this.tabUsView_MyCh.Name = "tabUsView_MyCh";
            this.tabUsView_MyCh.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsView_MyCh.Size = new System.Drawing.Size(634, 327);
            this.tabUsView_MyCh.TabIndex = 1;
            this.tabUsView_MyCh.Text = "My Channels";
            // 
            // tabUsView_TvShow
            // 
            this.tabUsView_TvShow.BackColor = System.Drawing.Color.PowderBlue;
            this.tabUsView_TvShow.Location = new System.Drawing.Point(4, 22);
            this.tabUsView_TvShow.Name = "tabUsView_TvShow";
            this.tabUsView_TvShow.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsView_TvShow.Size = new System.Drawing.Size(634, 327);
            this.tabUsView_TvShow.TabIndex = 2;
            this.tabUsView_TvShow.Text = "My TV Show";
            // 
            // ucUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabUserView);
            this.Name = "ucUserView";
            this.Size = new System.Drawing.Size(642, 353);
            this.tabUserView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabUserView;
        private System.Windows.Forms.TabPage tabUsView_AllCh;
        private System.Windows.Forms.TabPage tabUsView_MyCh;
        private System.Windows.Forms.TabPage tabUsView_TvShow;
    }
}
