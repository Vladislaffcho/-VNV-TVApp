namespace TvForms
{
    partial class UcUserAccount
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
            this.components = new System.ComponentModel.Container();
            this.gbAccountInfo = new System.Windows.Forms.GroupBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.lbLogin = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbIsActiveAcc = new System.Windows.Forms.TextBox();
            this.tbAccBalance = new System.Windows.Forms.TextBox();
            this.tbAccountId = new System.Windows.Forms.TextBox();
            this.lbIsActiveAccount = new System.Windows.Forms.Label();
            this.lbAccountBalance = new System.Windows.Forms.Label();
            this.lbAccountId = new System.Windows.Forms.Label();
            this.gbAccountInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAccountInfo
            // 
            this.gbAccountInfo.Controls.Add(this.tbIsActiveAcc);
            this.gbAccountInfo.Controls.Add(this.tbAccBalance);
            this.gbAccountInfo.Controls.Add(this.tbAccountId);
            this.gbAccountInfo.Controls.Add(this.lbIsActiveAccount);
            this.gbAccountInfo.Controls.Add(this.lbAccountBalance);
            this.gbAccountInfo.Controls.Add(this.lbAccountId);
            this.gbAccountInfo.Controls.Add(this.tbLogin);
            this.gbAccountInfo.Controls.Add(this.tbLastName);
            this.gbAccountInfo.Controls.Add(this.tbName);
            this.gbAccountInfo.Controls.Add(this.lbLogin);
            this.gbAccountInfo.Controls.Add(this.lbLastName);
            this.gbAccountInfo.Controls.Add(this.lbUserName);
            this.gbAccountInfo.Location = new System.Drawing.Point(0, 0);
            this.gbAccountInfo.Name = "gbAccountInfo";
            this.gbAccountInfo.Size = new System.Drawing.Size(437, 132);
            this.gbAccountInfo.TabIndex = 0;
            this.gbAccountInfo.TabStop = false;
            this.gbAccountInfo.Text = "Account INFO";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(6, 26);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(58, 13);
            this.lbUserName.TabIndex = 0;
            this.lbUserName.Text = "User name";
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Location = new System.Drawing.Point(6, 59);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(81, 13);
            this.lbLastName.TabIndex = 1;
            this.lbLastName.Text = "User Last name";
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(6, 93);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(54, 13);
            this.lbLogin.TabIndex = 2;
            this.lbLogin.Text = "User login";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbName.Cursor = System.Windows.Forms.Cursors.No;
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(99, 23);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tbLastName
            // 
            this.tbLastName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbLastName.Cursor = System.Windows.Forms.Cursors.No;
            this.tbLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLastName.Location = new System.Drawing.Point(99, 56);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.ReadOnly = true;
            this.tbLastName.Size = new System.Drawing.Size(100, 20);
            this.tbLastName.TabIndex = 2;
            this.tbLastName.TextChanged += new System.EventHandler(this.tbLastName_TextChanged);
            // 
            // tbLogin
            // 
            this.tbLogin.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbLogin.Cursor = System.Windows.Forms.Cursors.No;
            this.tbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLogin.Location = new System.Drawing.Point(99, 90);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.ReadOnly = true;
            this.tbLogin.Size = new System.Drawing.Size(100, 20);
            this.tbLogin.TabIndex = 3;
            this.tbLogin.TextChanged += new System.EventHandler(this.tbLogin_TextChanged);
            // 
            // tbIsActiveAcc
            // 
            this.tbIsActiveAcc.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbIsActiveAcc.Cursor = System.Windows.Forms.Cursors.No;
            this.tbIsActiveAcc.Location = new System.Drawing.Point(316, 90);
            this.tbIsActiveAcc.Name = "tbIsActiveAcc";
            this.tbIsActiveAcc.ReadOnly = true;
            this.tbIsActiveAcc.Size = new System.Drawing.Size(100, 20);
            this.tbIsActiveAcc.TabIndex = 6;
            this.tbIsActiveAcc.TextChanged += new System.EventHandler(this.tbIsActiveAcc_TextChanged);
            // 
            // tbAccBalance
            // 
            this.tbAccBalance.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbAccBalance.Cursor = System.Windows.Forms.Cursors.No;
            this.tbAccBalance.Location = new System.Drawing.Point(316, 56);
            this.tbAccBalance.Name = "tbAccBalance";
            this.tbAccBalance.ReadOnly = true;
            this.tbAccBalance.Size = new System.Drawing.Size(100, 20);
            this.tbAccBalance.TabIndex = 5;
            this.tbAccBalance.TextChanged += new System.EventHandler(this.tbAccBalance_TextChanged);
            // 
            // tbAccountId
            // 
            this.tbAccountId.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbAccountId.Cursor = System.Windows.Forms.Cursors.No;
            this.tbAccountId.Location = new System.Drawing.Point(316, 23);
            this.tbAccountId.Name = "tbAccountId";
            this.tbAccountId.ReadOnly = true;
            this.tbAccountId.Size = new System.Drawing.Size(100, 20);
            this.tbAccountId.TabIndex = 4;
            this.tbAccountId.TextChanged += new System.EventHandler(this.tbAccountId_TextChanged);
            // 
            // lbIsActiveAccount
            // 
            this.lbIsActiveAccount.AutoSize = true;
            this.lbIsActiveAccount.Location = new System.Drawing.Point(223, 93);
            this.lbIsActiveAccount.Name = "lbIsActiveAccount";
            this.lbIsActiveAccount.Size = new System.Drawing.Size(78, 13);
            this.lbIsActiveAccount.TabIndex = 8;
            this.lbIsActiveAccount.Text = "Account status";
            // 
            // lbAccountBalance
            // 
            this.lbAccountBalance.AutoSize = true;
            this.lbAccountBalance.Location = new System.Drawing.Point(223, 59);
            this.lbAccountBalance.Name = "lbAccountBalance";
            this.lbAccountBalance.Size = new System.Drawing.Size(88, 13);
            this.lbAccountBalance.TabIndex = 7;
            this.lbAccountBalance.Text = "Account balance";
            // 
            // lbAccountId
            // 
            this.lbAccountId.AutoSize = true;
            this.lbAccountId.Location = new System.Drawing.Point(223, 26);
            this.lbAccountId.Name = "lbAccountId";
            this.lbAccountId.Size = new System.Drawing.Size(59, 13);
            this.lbAccountId.TabIndex = 6;
            this.lbAccountId.Text = "Account Id";
            // 
            // UcUserAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAccountInfo);
            this.Name = "UcUserAccount";
            this.Size = new System.Drawing.Size(440, 135);
            this.gbAccountInfo.ResumeLayout(false);
            this.gbAccountInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAccountInfo;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tbIsActiveAcc;
        private System.Windows.Forms.TextBox tbAccBalance;
        private System.Windows.Forms.TextBox tbAccountId;
        private System.Windows.Forms.Label lbIsActiveAccount;
        private System.Windows.Forms.Label lbAccountBalance;
        private System.Windows.Forms.Label lbAccountId;
    }
}
