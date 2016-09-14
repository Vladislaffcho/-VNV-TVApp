namespace TvForms
{
    partial class UcTabsForUser
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
            this.tabPan_MyFavourite = new System.Windows.Forms.TabPage();
            this.tabPan_AllChannels = new System.Windows.Forms.TabPage();
            this.tabForUsers = new System.Windows.Forms.TabControl();
            this.tabForUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPan_MyFavourite
            // 
            this.tabPan_MyFavourite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPan_MyFavourite.Location = new System.Drawing.Point(4, 4);
            this.tabPan_MyFavourite.Name = "tabPan_MyFavourite";
            this.tabPan_MyFavourite.Padding = new System.Windows.Forms.Padding(3);
            this.tabPan_MyFavourite.Size = new System.Drawing.Size(844, 429);
            this.tabPan_MyFavourite.TabIndex = 1;
            this.tabPan_MyFavourite.Text = "My Favourite";
            this.tabPan_MyFavourite.UseVisualStyleBackColor = true;
            // 
            // tabPan_AllChannels
            // 
            this.tabPan_AllChannels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPan_AllChannels.Location = new System.Drawing.Point(4, 4);
            this.tabPan_AllChannels.Name = "tabPan_AllChannels";
            this.tabPan_AllChannels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPan_AllChannels.Size = new System.Drawing.Size(776, 411);
            this.tabPan_AllChannels.TabIndex = 0;
            this.tabPan_AllChannels.Text = "All Channels";
            this.tabPan_AllChannels.UseVisualStyleBackColor = true;
            // 
            // tabForUsers
            // 
            this.tabForUsers.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabForUsers.Controls.Add(this.tabPan_AllChannels);
            this.tabForUsers.Controls.Add(this.tabPan_MyFavourite);
            this.tabForUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabForUsers.Location = new System.Drawing.Point(0, 0);
            this.tabForUsers.Name = "tabForUsers";
            this.tabForUsers.SelectedIndex = 0;
            this.tabForUsers.Size = new System.Drawing.Size(784, 437);
            this.tabForUsers.TabIndex = 1;
            this.tabForUsers.SelectedIndexChanged += new System.EventHandler(this.tabForUsers_SelectedIndexChanged);
            // 
            // UcTabsForUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.tabForUsers);
            this.Name = "UcTabsForUser";
            this.Size = new System.Drawing.Size(784, 437);
            this.tabForUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPan_MyFavourite;
        private System.Windows.Forms.TabControl tabForUsers;
        public System.Windows.Forms.TabPage tabPan_AllChannels;
    }
}
