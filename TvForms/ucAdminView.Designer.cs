namespace TvForms
{
    partial class ucAdminView
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
            this.gbUsers = new System.Windows.Forms.GroupBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.tbMoney = new System.Windows.Forms.TextBox();
            this.lbMoney = new System.Windows.Forms.Label();
            this.tcUserContacts = new System.Windows.Forms.TabControl();
            this.tpAddress = new System.Windows.Forms.TabPage();
            this.btEditAddress = new System.Windows.Forms.Button();
            this.btDeleteAddress = new System.Windows.Forms.Button();
            this.lvUserAddress = new System.Windows.Forms.ListView();
            this.colTypeAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNameAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommentAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpEmail = new System.Windows.Forms.TabPage();
            this.btDeleteEmail = new System.Windows.Forms.Button();
            this.btEditEmail = new System.Windows.Forms.Button();
            this.lvUserEmail = new System.Windows.Forms.ListView();
            this.colTypeEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNameEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommentEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpTelephone = new System.Windows.Forms.TabPage();
            this.btDeleteTelephone = new System.Windows.Forms.Button();
            this.btEditTelephone = new System.Windows.Forms.Button();
            this.lvUserTelephone = new System.Windows.Forms.ListView();
            this.colTypeTelephone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNameTelephone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommentTelephone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.colUserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUserLogin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbAdultContent = new System.Windows.Forms.CheckBox();
            this.btViewOrders = new System.Windows.Forms.Button();
            this.btViewServices = new System.Windows.Forms.Button();
            this.btSaveChanges = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.gbUsers.SuspendLayout();
            this.tcUserContacts.SuspendLayout();
            this.tpAddress.SuspendLayout();
            this.tpEmail.SuspendLayout();
            this.tpTelephone.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUsers
            // 
            this.gbUsers.Controls.Add(this.btCancel);
            this.gbUsers.Controls.Add(this.btSaveChanges);
            this.gbUsers.Controls.Add(this.btViewServices);
            this.gbUsers.Controls.Add(this.btViewOrders);
            this.gbUsers.Controls.Add(this.cbAdultContent);
            this.gbUsers.Controls.Add(this.cbStatus);
            this.gbUsers.Controls.Add(this.lbStatus);
            this.gbUsers.Controls.Add(this.tbMoney);
            this.gbUsers.Controls.Add(this.lbMoney);
            this.gbUsers.Controls.Add(this.tcUserContacts);
            this.gbUsers.Controls.Add(this.listView1);
            this.gbUsers.Location = new System.Drawing.Point(3, 3);
            this.gbUsers.Name = "gbUsers";
            this.gbUsers.Size = new System.Drawing.Size(622, 310);
            this.gbUsers.TabIndex = 0;
            this.gbUsers.TabStop = false;
            this.gbUsers.Text = "Users";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(272, 43);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 5;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(226, 46);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(37, 13);
            this.lbStatus.TabIndex = 4;
            this.lbStatus.Text = "Status";
            // 
            // tbMoney
            // 
            this.tbMoney.Location = new System.Drawing.Point(272, 17);
            this.tbMoney.Name = "tbMoney";
            this.tbMoney.ReadOnly = true;
            this.tbMoney.Size = new System.Drawing.Size(121, 20);
            this.tbMoney.TabIndex = 3;
            // 
            // lbMoney
            // 
            this.lbMoney.AutoSize = true;
            this.lbMoney.Location = new System.Drawing.Point(226, 20);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(39, 13);
            this.lbMoney.TabIndex = 2;
            this.lbMoney.Text = "Money";
            // 
            // tcUserContacts
            // 
            this.tcUserContacts.Controls.Add(this.tpAddress);
            this.tcUserContacts.Controls.Add(this.tpEmail);
            this.tcUserContacts.Controls.Add(this.tpTelephone);
            this.tcUserContacts.Location = new System.Drawing.Point(222, 93);
            this.tcUserContacts.Name = "tcUserContacts";
            this.tcUserContacts.SelectedIndex = 0;
            this.tcUserContacts.Size = new System.Drawing.Size(400, 152);
            this.tcUserContacts.TabIndex = 1;
            // 
            // tpAddress
            // 
            this.tpAddress.BackColor = System.Drawing.SystemColors.Control;
            this.tpAddress.Controls.Add(this.btEditAddress);
            this.tpAddress.Controls.Add(this.btDeleteAddress);
            this.tpAddress.Controls.Add(this.lvUserAddress);
            this.tpAddress.Location = new System.Drawing.Point(4, 22);
            this.tpAddress.Name = "tpAddress";
            this.tpAddress.Padding = new System.Windows.Forms.Padding(3);
            this.tpAddress.Size = new System.Drawing.Size(392, 126);
            this.tpAddress.TabIndex = 0;
            this.tpAddress.Text = "Address";
            // 
            // btEditAddress
            // 
            this.btEditAddress.Location = new System.Drawing.Point(169, 100);
            this.btEditAddress.Name = "btEditAddress";
            this.btEditAddress.Size = new System.Drawing.Size(75, 23);
            this.btEditAddress.TabIndex = 2;
            this.btEditAddress.Text = "Edit";
            this.btEditAddress.UseVisualStyleBackColor = true;
            // 
            // btDeleteAddress
            // 
            this.btDeleteAddress.Location = new System.Drawing.Point(266, 100);
            this.btDeleteAddress.Name = "btDeleteAddress";
            this.btDeleteAddress.Size = new System.Drawing.Size(75, 23);
            this.btDeleteAddress.TabIndex = 1;
            this.btDeleteAddress.Text = "Delete";
            this.btDeleteAddress.UseVisualStyleBackColor = true;
            // 
            // lvUserAddress
            // 
            this.lvUserAddress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTypeAddress,
            this.colNameAddress,
            this.colCommentAddress});
            this.lvUserAddress.GridLines = true;
            this.lvUserAddress.Location = new System.Drawing.Point(0, 0);
            this.lvUserAddress.Name = "lvUserAddress";
            this.lvUserAddress.Size = new System.Drawing.Size(392, 95);
            this.lvUserAddress.TabIndex = 0;
            this.lvUserAddress.UseCompatibleStateImageBehavior = false;
            this.lvUserAddress.View = System.Windows.Forms.View.Details;
            // 
            // colTypeAddress
            // 
            this.colTypeAddress.Text = "Type";
            this.colTypeAddress.Width = 74;
            // 
            // colNameAddress
            // 
            this.colNameAddress.Text = "Address";
            this.colNameAddress.Width = 140;
            // 
            // colCommentAddress
            // 
            this.colCommentAddress.Text = "Comment";
            this.colCommentAddress.Width = 173;
            // 
            // tpEmail
            // 
            this.tpEmail.BackColor = System.Drawing.SystemColors.Control;
            this.tpEmail.Controls.Add(this.btDeleteEmail);
            this.tpEmail.Controls.Add(this.btEditEmail);
            this.tpEmail.Controls.Add(this.lvUserEmail);
            this.tpEmail.Location = new System.Drawing.Point(4, 22);
            this.tpEmail.Name = "tpEmail";
            this.tpEmail.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmail.Size = new System.Drawing.Size(392, 126);
            this.tpEmail.TabIndex = 1;
            this.tpEmail.Text = "Email";
            // 
            // btDeleteEmail
            // 
            this.btDeleteEmail.Location = new System.Drawing.Point(266, 100);
            this.btDeleteEmail.Name = "btDeleteEmail";
            this.btDeleteEmail.Size = new System.Drawing.Size(75, 23);
            this.btDeleteEmail.TabIndex = 2;
            this.btDeleteEmail.Text = "Delete";
            this.btDeleteEmail.UseVisualStyleBackColor = true;
            // 
            // btEditEmail
            // 
            this.btEditEmail.Location = new System.Drawing.Point(169, 100);
            this.btEditEmail.Name = "btEditEmail";
            this.btEditEmail.Size = new System.Drawing.Size(75, 23);
            this.btEditEmail.TabIndex = 1;
            this.btEditEmail.Text = "Edit";
            this.btEditEmail.UseVisualStyleBackColor = true;
            // 
            // lvUserEmail
            // 
            this.lvUserEmail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTypeEmail,
            this.colNameEmail,
            this.colCommentEmail});
            this.lvUserEmail.GridLines = true;
            this.lvUserEmail.Location = new System.Drawing.Point(0, 0);
            this.lvUserEmail.Name = "lvUserEmail";
            this.lvUserEmail.Size = new System.Drawing.Size(392, 95);
            this.lvUserEmail.TabIndex = 0;
            this.lvUserEmail.UseCompatibleStateImageBehavior = false;
            this.lvUserEmail.View = System.Windows.Forms.View.Details;
            // 
            // colTypeEmail
            // 
            this.colTypeEmail.Text = "Type";
            this.colTypeEmail.Width = 74;
            // 
            // colNameEmail
            // 
            this.colNameEmail.Text = "Email";
            this.colNameEmail.Width = 140;
            // 
            // colCommentEmail
            // 
            this.colCommentEmail.Text = "Comment";
            this.colCommentEmail.Width = 173;
            // 
            // tpTelephone
            // 
            this.tpTelephone.BackColor = System.Drawing.SystemColors.Control;
            this.tpTelephone.Controls.Add(this.btDeleteTelephone);
            this.tpTelephone.Controls.Add(this.btEditTelephone);
            this.tpTelephone.Controls.Add(this.lvUserTelephone);
            this.tpTelephone.Location = new System.Drawing.Point(4, 22);
            this.tpTelephone.Name = "tpTelephone";
            this.tpTelephone.Padding = new System.Windows.Forms.Padding(3);
            this.tpTelephone.Size = new System.Drawing.Size(392, 126);
            this.tpTelephone.TabIndex = 2;
            this.tpTelephone.Text = "Telephone";
            // 
            // btDeleteTelephone
            // 
            this.btDeleteTelephone.Location = new System.Drawing.Point(266, 100);
            this.btDeleteTelephone.Name = "btDeleteTelephone";
            this.btDeleteTelephone.Size = new System.Drawing.Size(75, 23);
            this.btDeleteTelephone.TabIndex = 2;
            this.btDeleteTelephone.Text = "Delete";
            this.btDeleteTelephone.UseVisualStyleBackColor = true;
            // 
            // btEditTelephone
            // 
            this.btEditTelephone.Location = new System.Drawing.Point(169, 100);
            this.btEditTelephone.Name = "btEditTelephone";
            this.btEditTelephone.Size = new System.Drawing.Size(75, 23);
            this.btEditTelephone.TabIndex = 1;
            this.btEditTelephone.Text = "Edit";
            this.btEditTelephone.UseVisualStyleBackColor = true;
            // 
            // lvUserTelephone
            // 
            this.lvUserTelephone.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTypeTelephone,
            this.colNameTelephone,
            this.colCommentTelephone});
            this.lvUserTelephone.GridLines = true;
            this.lvUserTelephone.Location = new System.Drawing.Point(0, 0);
            this.lvUserTelephone.Name = "lvUserTelephone";
            this.lvUserTelephone.Size = new System.Drawing.Size(392, 95);
            this.lvUserTelephone.TabIndex = 0;
            this.lvUserTelephone.UseCompatibleStateImageBehavior = false;
            this.lvUserTelephone.View = System.Windows.Forms.View.Details;
            // 
            // colTypeTelephone
            // 
            this.colTypeTelephone.Text = "Telephone";
            this.colTypeTelephone.Width = 74;
            // 
            // colNameTelephone
            // 
            this.colNameTelephone.Text = "Telephone";
            this.colNameTelephone.Width = 140;
            // 
            // colCommentTelephone
            // 
            this.colCommentTelephone.Text = "Comment";
            this.colCommentTelephone.Width = 173;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUserID,
            this.colUserLogin,
            this.colUserName});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(6, 17);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(210, 296);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colUserID
            // 
            this.colUserID.Text = "ID";
            this.colUserID.Width = 25;
            // 
            // colUserLogin
            // 
            this.colUserLogin.Text = "Login";
            this.colUserLogin.Width = 55;
            // 
            // colUserName
            // 
            this.colUserName.Text = "Name";
            this.colUserName.Width = 128;
            // 
            // cbAdultContent
            // 
            this.cbAdultContent.AutoSize = true;
            this.cbAdultContent.Location = new System.Drawing.Point(272, 70);
            this.cbAdultContent.Name = "cbAdultContent";
            this.cbAdultContent.Size = new System.Drawing.Size(90, 17);
            this.cbAdultContent.TabIndex = 7;
            this.cbAdultContent.Text = "Adult Content";
            this.cbAdultContent.UseVisualStyleBackColor = true;
            // 
            // btViewOrders
            // 
            this.btViewOrders.Location = new System.Drawing.Point(427, 17);
            this.btViewOrders.Name = "btViewOrders";
            this.btViewOrders.Size = new System.Drawing.Size(75, 23);
            this.btViewOrders.TabIndex = 8;
            this.btViewOrders.Text = "View Orders";
            this.btViewOrders.UseVisualStyleBackColor = true;
            // 
            // btViewServices
            // 
            this.btViewServices.Location = new System.Drawing.Point(523, 17);
            this.btViewServices.Name = "btViewServices";
            this.btViewServices.Size = new System.Drawing.Size(93, 23);
            this.btViewServices.TabIndex = 9;
            this.btViewServices.Text = "View Services";
            this.btViewServices.UseVisualStyleBackColor = true;
            // 
            // btSaveChanges
            // 
            this.btSaveChanges.Location = new System.Drawing.Point(385, 281);
            this.btSaveChanges.Name = "btSaveChanges";
            this.btSaveChanges.Size = new System.Drawing.Size(85, 23);
            this.btSaveChanges.TabIndex = 10;
            this.btSaveChanges.Text = "Save Changes";
            this.btSaveChanges.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(492, 281);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 11;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // ucAdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbUsers);
            this.Name = "ucAdminView";
            this.Size = new System.Drawing.Size(628, 321);
            this.gbUsers.ResumeLayout(false);
            this.gbUsers.PerformLayout();
            this.tcUserContacts.ResumeLayout(false);
            this.tpAddress.ResumeLayout(false);
            this.tpEmail.ResumeLayout(false);
            this.tpTelephone.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUsers;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colUserID;
        private System.Windows.Forms.ColumnHeader colUserLogin;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.TabControl tcUserContacts;
        private System.Windows.Forms.TabPage tpAddress;
        private System.Windows.Forms.TabPage tpEmail;
        private System.Windows.Forms.ListView lvUserAddress;
        private System.Windows.Forms.TabPage tpTelephone;
        private System.Windows.Forms.ColumnHeader colTypeAddress;
        private System.Windows.Forms.ColumnHeader colNameAddress;
        private System.Windows.Forms.ListView lvUserEmail;
        private System.Windows.Forms.ColumnHeader colTypeEmail;
        private System.Windows.Forms.ColumnHeader colNameEmail;
        private System.Windows.Forms.ListView lvUserTelephone;
        private System.Windows.Forms.ColumnHeader colTypeTelephone;
        private System.Windows.Forms.ColumnHeader colNameTelephone;
        private System.Windows.Forms.Button btDeleteTelephone;
        private System.Windows.Forms.Button btEditTelephone;
        private System.Windows.Forms.Button btEditAddress;
        private System.Windows.Forms.Button btDeleteAddress;
        private System.Windows.Forms.Button btDeleteEmail;
        private System.Windows.Forms.Button btEditEmail;
        private System.Windows.Forms.ColumnHeader colCommentAddress;
        private System.Windows.Forms.ColumnHeader colCommentEmail;
        private System.Windows.Forms.ColumnHeader colCommentTelephone;
        private System.Windows.Forms.TextBox tbMoney;
        private System.Windows.Forms.Label lbMoney;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.CheckBox cbAdultContent;
        private System.Windows.Forms.Button btViewOrders;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btSaveChanges;
        private System.Windows.Forms.Button btViewServices;
    }
}
