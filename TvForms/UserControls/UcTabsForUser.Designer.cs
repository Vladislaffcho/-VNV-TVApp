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
            this.tabForUsers = new System.Windows.Forms.TabControl();
            this.tabPan_AllChannels = new System.Windows.Forms.TabPage();
            this.tabPan_MyChannels = new System.Windows.Forms.TabPage();
            this.tabPan_MyShow = new System.Windows.Forms.TabPage();
            this.tabForUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabForUsers
            // 
            this.tabForUsers.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabForUsers.Controls.Add(this.tabPan_AllChannels);
            this.tabForUsers.Controls.Add(this.tabPan_MyChannels);
            this.tabForUsers.Controls.Add(this.tabPan_MyShow);
            this.tabForUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabForUsers.Location = new System.Drawing.Point(0, 0);
            this.tabForUsers.Name = "tabForUsers";
            this.tabForUsers.SelectedIndex = 0;
            this.tabForUsers.Size = new System.Drawing.Size(641, 352);
            this.tabForUsers.TabIndex = 4;
            //this.tabForUsers.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabForUsers_Selecting);
            this.tabForUsers.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabForUsers_Selected);
            // 
            // tabPan_AllChannels
            // 
            this.tabPan_AllChannels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPan_AllChannels.Location = new System.Drawing.Point(4, 4);
            this.tabPan_AllChannels.Name = "tabPan_AllChannels";
            this.tabPan_AllChannels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPan_AllChannels.Size = new System.Drawing.Size(633, 326);
            this.tabPan_AllChannels.TabIndex = 0;
            this.tabPan_AllChannels.Text = "All Channels";
            this.tabPan_AllChannels.UseVisualStyleBackColor = true;
            // 
            // tabPan_MyChannels
            // 
            this.tabPan_MyChannels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPan_MyChannels.Location = new System.Drawing.Point(4, 4);
            this.tabPan_MyChannels.Name = "tabPan_MyChannels";
            this.tabPan_MyChannels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPan_MyChannels.Size = new System.Drawing.Size(633, 326);
            this.tabPan_MyChannels.TabIndex = 1;
            this.tabPan_MyChannels.Text = "My Channels";
            this.tabPan_MyChannels.UseVisualStyleBackColor = true;
            // 
            // tabPan_MyShow
            // 
            this.tabPan_MyShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPan_MyShow.Location = new System.Drawing.Point(4, 4);
            this.tabPan_MyShow.Name = "tabPan_MyShow";
            this.tabPan_MyShow.Padding = new System.Windows.Forms.Padding(3);
            this.tabPan_MyShow.Size = new System.Drawing.Size(633, 326);
            this.tabPan_MyShow.TabIndex = 2;
            this.tabPan_MyShow.Text = "My Shows";
            this.tabPan_MyShow.UseVisualStyleBackColor = true;
            // 
            // TabsForUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabForUsers);
            this.Name = "TabsForUser";
            this.Size = new System.Drawing.Size(641, 352);
            this.tabForUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabForUsers;
        private System.Windows.Forms.TabPage tabPan_AllChannels;
        private System.Windows.Forms.TabPage tabPan_MyChannels;
        private System.Windows.Forms.TabPage tabPan_MyShow;
    }
}
