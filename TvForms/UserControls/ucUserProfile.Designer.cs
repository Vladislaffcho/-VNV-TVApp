namespace TvForms
{
    partial class UcUserProfile
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
            this.gbProfile = new System.Windows.Forms.GroupBox();
            this.btAccountInfo = new System.Windows.Forms.Button();
            this.btChangeDetails = new System.Windows.Forms.Button();
            this.btDeactivateAccount = new System.Windows.Forms.Button();
            this.tcUserContacts = new System.Windows.Forms.TabControl();
            this.tpAddress = new System.Windows.Forms.TabPage();
            this.btAddAddress = new System.Windows.Forms.Button();
            this.btUpdateAddress = new System.Windows.Forms.Button();
            this.btDeleteAddress = new System.Windows.Forms.Button();
            this.lvUserAddress = new System.Windows.Forms.ListView();
            this.colTypeAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNameAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommentAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpEmail = new System.Windows.Forms.TabPage();
            this.btAddEmail = new System.Windows.Forms.Button();
            this.btUpdateEmail = new System.Windows.Forms.Button();
            this.btDeleteEmail = new System.Windows.Forms.Button();
            this.lvUserEmail = new System.Windows.Forms.ListView();
            this.colTypeEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNameEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommentEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpTelephone = new System.Windows.Forms.TabPage();
            this.btAddPhone = new System.Windows.Forms.Button();
            this.btUpdateTelephone = new System.Windows.Forms.Button();
            this.btDeleteTelephone = new System.Windows.Forms.Button();
            this.lvUserTelephone = new System.Windows.Forms.ListView();
            this.colTypeTelephone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNameTelephone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCommentTelephone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btViewPayment = new System.Windows.Forms.Button();
            this.lbSurname = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.btViewOrders = new System.Windows.Forms.Button();
            this.gbProfile.SuspendLayout();
            this.tcUserContacts.SuspendLayout();
            this.tpAddress.SuspendLayout();
            this.tpEmail.SuspendLayout();
            this.tpTelephone.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbProfile
            // 
            this.gbProfile.Controls.Add(this.btAccountInfo);
            this.gbProfile.Controls.Add(this.btChangeDetails);
            this.gbProfile.Controls.Add(this.btDeactivateAccount);
            this.gbProfile.Controls.Add(this.tcUserContacts);
            this.gbProfile.Controls.Add(this.btViewPayment);
            this.gbProfile.Controls.Add(this.lbSurname);
            this.gbProfile.Controls.Add(this.lbName);
            this.gbProfile.Controls.Add(this.tbName);
            this.gbProfile.Controls.Add(this.tbSurname);
            this.gbProfile.Controls.Add(this.btViewOrders);
            this.gbProfile.Location = new System.Drawing.Point(3, 3);
            this.gbProfile.Name = "gbProfile";
            this.gbProfile.Size = new System.Drawing.Size(622, 310);
            this.gbProfile.TabIndex = 0;
            this.gbProfile.TabStop = false;
            this.gbProfile.Text = "Profile";
            // 
            // btAccountInfo
            // 
            this.btAccountInfo.Location = new System.Drawing.Point(298, 56);
            this.btAccountInfo.Name = "btAccountInfo";
            this.btAccountInfo.Size = new System.Drawing.Size(112, 22);
            this.btAccountInfo.TabIndex = 29;
            this.btAccountInfo.Text = "Account info";
            this.btAccountInfo.UseVisualStyleBackColor = true;
            this.btAccountInfo.Click += new System.EventHandler(this.btAccountInfo_Click);
            // 
            // btChangeDetails
            // 
            this.btChangeDetails.Location = new System.Drawing.Point(298, 19);
            this.btChangeDetails.Name = "btChangeDetails";
            this.btChangeDetails.Size = new System.Drawing.Size(112, 23);
            this.btChangeDetails.TabIndex = 7;
            this.btChangeDetails.Text = "Update Details";
            this.btChangeDetails.UseVisualStyleBackColor = true;
            this.btChangeDetails.Click += new System.EventHandler(this.btChangeDetails_Click);
            // 
            // btDeactivateAccount
            // 
            this.btDeactivateAccount.BackColor = System.Drawing.Color.Red;
            this.btDeactivateAccount.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btDeactivateAccount.Location = new System.Drawing.Point(475, 95);
            this.btDeactivateAccount.Name = "btDeactivateAccount";
            this.btDeactivateAccount.Size = new System.Drawing.Size(88, 45);
            this.btDeactivateAccount.TabIndex = 8;
            this.btDeactivateAccount.Text = "Deactivate Account";
            this.btDeactivateAccount.UseVisualStyleBackColor = false;
            this.btDeactivateAccount.Click += new System.EventHandler(this.btDeactivateAccount_Click);
            // 
            // tcUserContacts
            // 
            this.tcUserContacts.Controls.Add(this.tpAddress);
            this.tcUserContacts.Controls.Add(this.tpEmail);
            this.tcUserContacts.Controls.Add(this.tpTelephone);
            this.tcUserContacts.Location = new System.Drawing.Point(6, 132);
            this.tcUserContacts.Name = "tcUserContacts";
            this.tcUserContacts.SelectedIndex = 0;
            this.tcUserContacts.Size = new System.Drawing.Size(610, 172);
            this.tcUserContacts.TabIndex = 26;
            // 
            // tpAddress
            // 
            this.tpAddress.BackColor = System.Drawing.SystemColors.Control;
            this.tpAddress.Controls.Add(this.btAddAddress);
            this.tpAddress.Controls.Add(this.btUpdateAddress);
            this.tpAddress.Controls.Add(this.btDeleteAddress);
            this.tpAddress.Controls.Add(this.lvUserAddress);
            this.tpAddress.Location = new System.Drawing.Point(4, 22);
            this.tpAddress.Name = "tpAddress";
            this.tpAddress.Padding = new System.Windows.Forms.Padding(3);
            this.tpAddress.Size = new System.Drawing.Size(602, 146);
            this.tpAddress.TabIndex = 0;
            this.tpAddress.Text = "Address";
            // 
            // btAddAddress
            // 
            this.btAddAddress.Location = new System.Drawing.Point(295, 116);
            this.btAddAddress.Name = "btAddAddress";
            this.btAddAddress.Size = new System.Drawing.Size(75, 23);
            this.btAddAddress.TabIndex = 1;
            this.btAddAddress.Text = "Add";
            this.btAddAddress.UseVisualStyleBackColor = true;
            this.btAddAddress.Click += new System.EventHandler(this.btAddAddress_Click);
            // 
            // btUpdateAddress
            // 
            this.btUpdateAddress.Location = new System.Drawing.Point(408, 116);
            this.btUpdateAddress.Name = "btUpdateAddress";
            this.btUpdateAddress.Size = new System.Drawing.Size(75, 23);
            this.btUpdateAddress.TabIndex = 2;
            this.btUpdateAddress.Text = "Update";
            this.btUpdateAddress.UseVisualStyleBackColor = true;
            this.btUpdateAddress.Click += new System.EventHandler(this.btUpdateAddress_Click);
            // 
            // btDeleteAddress
            // 
            this.btDeleteAddress.Location = new System.Drawing.Point(521, 116);
            this.btDeleteAddress.Name = "btDeleteAddress";
            this.btDeleteAddress.Size = new System.Drawing.Size(75, 23);
            this.btDeleteAddress.TabIndex = 3;
            this.btDeleteAddress.Text = "Delete";
            this.btDeleteAddress.UseVisualStyleBackColor = true;
            this.btDeleteAddress.Click += new System.EventHandler(this.btDeleteAddress_Click);
            // 
            // lvUserAddress
            // 
            this.lvUserAddress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTypeAddress,
            this.colNameAddress,
            this.colCommentAddress});
            this.lvUserAddress.FullRowSelect = true;
            this.lvUserAddress.GridLines = true;
            this.lvUserAddress.Location = new System.Drawing.Point(0, 0);
            this.lvUserAddress.Name = "lvUserAddress";
            this.lvUserAddress.Size = new System.Drawing.Size(602, 110);
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
            this.colNameAddress.Width = 256;
            // 
            // colCommentAddress
            // 
            this.colCommentAddress.Text = "Comment";
            this.colCommentAddress.Width = 268;
            // 
            // tpEmail
            // 
            this.tpEmail.BackColor = System.Drawing.SystemColors.Control;
            this.tpEmail.Controls.Add(this.btAddEmail);
            this.tpEmail.Controls.Add(this.btUpdateEmail);
            this.tpEmail.Controls.Add(this.btDeleteEmail);
            this.tpEmail.Controls.Add(this.lvUserEmail);
            this.tpEmail.Location = new System.Drawing.Point(4, 22);
            this.tpEmail.Name = "tpEmail";
            this.tpEmail.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmail.Size = new System.Drawing.Size(602, 146);
            this.tpEmail.TabIndex = 1;
            this.tpEmail.Text = "Email";
            // 
            // btAddEmail
            // 
            this.btAddEmail.Location = new System.Drawing.Point(295, 116);
            this.btAddEmail.Name = "btAddEmail";
            this.btAddEmail.Size = new System.Drawing.Size(75, 23);
            this.btAddEmail.TabIndex = 1;
            this.btAddEmail.Text = "Add";
            this.btAddEmail.UseVisualStyleBackColor = true;
            this.btAddEmail.Click += new System.EventHandler(this.btAddEmail_Click);
            // 
            // btUpdateEmail
            // 
            this.btUpdateEmail.Location = new System.Drawing.Point(408, 116);
            this.btUpdateEmail.Name = "btUpdateEmail";
            this.btUpdateEmail.Size = new System.Drawing.Size(75, 23);
            this.btUpdateEmail.TabIndex = 2;
            this.btUpdateEmail.Text = "Update";
            this.btUpdateEmail.UseVisualStyleBackColor = true;
            this.btUpdateEmail.Click += new System.EventHandler(this.btUpdateEmail_Click);
            // 
            // btDeleteEmail
            // 
            this.btDeleteEmail.Location = new System.Drawing.Point(521, 116);
            this.btDeleteEmail.Name = "btDeleteEmail";
            this.btDeleteEmail.Size = new System.Drawing.Size(75, 23);
            this.btDeleteEmail.TabIndex = 3;
            this.btDeleteEmail.Text = "Delete";
            this.btDeleteEmail.UseVisualStyleBackColor = true;
            this.btDeleteEmail.Click += new System.EventHandler(this.btDeleteEmail_Click);
            // 
            // lvUserEmail
            // 
            this.lvUserEmail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTypeEmail,
            this.colNameEmail,
            this.colCommentEmail});
            this.lvUserEmail.FullRowSelect = true;
            this.lvUserEmail.GridLines = true;
            this.lvUserEmail.Location = new System.Drawing.Point(0, 0);
            this.lvUserEmail.Name = "lvUserEmail";
            this.lvUserEmail.Size = new System.Drawing.Size(602, 110);
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
            this.colNameEmail.Width = 256;
            // 
            // colCommentEmail
            // 
            this.colCommentEmail.Text = "Comment";
            this.colCommentEmail.Width = 268;
            // 
            // tpTelephone
            // 
            this.tpTelephone.BackColor = System.Drawing.SystemColors.Control;
            this.tpTelephone.Controls.Add(this.btAddPhone);
            this.tpTelephone.Controls.Add(this.btUpdateTelephone);
            this.tpTelephone.Controls.Add(this.btDeleteTelephone);
            this.tpTelephone.Controls.Add(this.lvUserTelephone);
            this.tpTelephone.Location = new System.Drawing.Point(4, 22);
            this.tpTelephone.Name = "tpTelephone";
            this.tpTelephone.Padding = new System.Windows.Forms.Padding(3);
            this.tpTelephone.Size = new System.Drawing.Size(602, 146);
            this.tpTelephone.TabIndex = 2;
            this.tpTelephone.Text = "Telephone";
            // 
            // btAddPhone
            // 
            this.btAddPhone.Location = new System.Drawing.Point(295, 116);
            this.btAddPhone.Name = "btAddPhone";
            this.btAddPhone.Size = new System.Drawing.Size(75, 23);
            this.btAddPhone.TabIndex = 1;
            this.btAddPhone.Text = "Add";
            this.btAddPhone.UseVisualStyleBackColor = true;
            this.btAddPhone.Click += new System.EventHandler(this.btAddPhone_Click);
            // 
            // btUpdateTelephone
            // 
            this.btUpdateTelephone.Location = new System.Drawing.Point(408, 116);
            this.btUpdateTelephone.Name = "btUpdateTelephone";
            this.btUpdateTelephone.Size = new System.Drawing.Size(75, 23);
            this.btUpdateTelephone.TabIndex = 2;
            this.btUpdateTelephone.Text = "Update";
            this.btUpdateTelephone.UseVisualStyleBackColor = true;
            this.btUpdateTelephone.Click += new System.EventHandler(this.btUpdateTelephone_Click);
            // 
            // btDeleteTelephone
            // 
            this.btDeleteTelephone.Location = new System.Drawing.Point(521, 116);
            this.btDeleteTelephone.Name = "btDeleteTelephone";
            this.btDeleteTelephone.Size = new System.Drawing.Size(75, 23);
            this.btDeleteTelephone.TabIndex = 3;
            this.btDeleteTelephone.Text = "Delete";
            this.btDeleteTelephone.UseVisualStyleBackColor = true;
            this.btDeleteTelephone.Click += new System.EventHandler(this.btDeleteTelephone_Click);
            // 
            // lvUserTelephone
            // 
            this.lvUserTelephone.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTypeTelephone,
            this.colNameTelephone,
            this.colCommentTelephone});
            this.lvUserTelephone.FullRowSelect = true;
            this.lvUserTelephone.GridLines = true;
            this.lvUserTelephone.Location = new System.Drawing.Point(0, 0);
            this.lvUserTelephone.Name = "lvUserTelephone";
            this.lvUserTelephone.Size = new System.Drawing.Size(602, 110);
            this.lvUserTelephone.TabIndex = 0;
            this.lvUserTelephone.UseCompatibleStateImageBehavior = false;
            this.lvUserTelephone.View = System.Windows.Forms.View.Details;
            // 
            // colTypeTelephone
            // 
            this.colTypeTelephone.Text = "Type";
            this.colTypeTelephone.Width = 74;
            // 
            // colNameTelephone
            // 
            this.colNameTelephone.Text = "Telephone";
            this.colNameTelephone.Width = 256;
            // 
            // colCommentTelephone
            // 
            this.colCommentTelephone.Text = "Comment";
            this.colCommentTelephone.Width = 268;
            // 
            // btViewPayment
            // 
            this.btViewPayment.Location = new System.Drawing.Point(475, 56);
            this.btViewPayment.Name = "btViewPayment";
            this.btViewPayment.Size = new System.Drawing.Size(88, 23);
            this.btViewPayment.TabIndex = 10;
            this.btViewPayment.Text = "View Payment";
            this.btViewPayment.UseVisualStyleBackColor = true;
            this.btViewPayment.Click += new System.EventHandler(this.btViewPayment_Click);
            // 
            // lbSurname
            // 
            this.lbSurname.AutoSize = true;
            this.lbSurname.Location = new System.Drawing.Point(49, 59);
            this.lbSurname.Name = "lbSurname";
            this.lbSurname.Size = new System.Drawing.Size(49, 13);
            this.lbSurname.TabIndex = 22;
            this.lbSurname.Text = "Surname";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(49, 22);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 21;
            this.lbName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(107, 19);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(121, 20);
            this.tbName.TabIndex = 4;
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(107, 56);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.ReadOnly = true;
            this.tbSurname.Size = new System.Drawing.Size(121, 20);
            this.tbSurname.TabIndex = 5;
            // 
            // btViewOrders
            // 
            this.btViewOrders.Location = new System.Drawing.Point(475, 19);
            this.btViewOrders.Name = "btViewOrders";
            this.btViewOrders.Size = new System.Drawing.Size(88, 23);
            this.btViewOrders.TabIndex = 9;
            this.btViewOrders.Text = "View Orders";
            this.btViewOrders.UseVisualStyleBackColor = true;
            this.btViewOrders.Click += new System.EventHandler(this.btViewOrders_Click);
            // 
            // UcUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbProfile);
            this.Name = "UcUserProfile";
            this.Size = new System.Drawing.Size(628, 321);
            this.gbProfile.ResumeLayout(false);
            this.gbProfile.PerformLayout();
            this.tcUserContacts.ResumeLayout(false);
            this.tpAddress.ResumeLayout(false);
            this.tpEmail.ResumeLayout(false);
            this.tpTelephone.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbProfile;
        private System.Windows.Forms.Label lbSurname;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Button btViewOrders;
        private System.Windows.Forms.Button btViewPayment;
        private System.Windows.Forms.TabControl tcUserContacts;
        private System.Windows.Forms.TabPage tpAddress;
        private System.Windows.Forms.Button btAddAddress;
        private System.Windows.Forms.Button btUpdateAddress;
        private System.Windows.Forms.Button btDeleteAddress;
        private System.Windows.Forms.ListView lvUserAddress;
        private System.Windows.Forms.ColumnHeader colTypeAddress;
        private System.Windows.Forms.ColumnHeader colNameAddress;
        private System.Windows.Forms.ColumnHeader colCommentAddress;
        private System.Windows.Forms.TabPage tpEmail;
        private System.Windows.Forms.Button btAddEmail;
        private System.Windows.Forms.Button btUpdateEmail;
        private System.Windows.Forms.Button btDeleteEmail;
        private System.Windows.Forms.ListView lvUserEmail;
        private System.Windows.Forms.ColumnHeader colTypeEmail;
        private System.Windows.Forms.ColumnHeader colNameEmail;
        private System.Windows.Forms.ColumnHeader colCommentEmail;
        private System.Windows.Forms.TabPage tpTelephone;
        private System.Windows.Forms.Button btAddPhone;
        private System.Windows.Forms.Button btUpdateTelephone;
        private System.Windows.Forms.Button btDeleteTelephone;
        private System.Windows.Forms.ListView lvUserTelephone;
        private System.Windows.Forms.ColumnHeader colTypeTelephone;
        private System.Windows.Forms.ColumnHeader colNameTelephone;
        private System.Windows.Forms.ColumnHeader colCommentTelephone;
        private System.Windows.Forms.Button btChangeDetails;
        private System.Windows.Forms.Button btDeactivateAccount;
        private System.Windows.Forms.Button btAccountInfo;
    }
}
