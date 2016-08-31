namespace TvForms.UserControls
{
    partial class UcResetPassword
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
            this.lbUserEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lbConfirmCode = new System.Windows.Forms.Label();
            this.tbEnterCode = new System.Windows.Forms.TextBox();
            this.lbCodeFromEmail = new System.Windows.Forms.Label();
            this.tbCodeFromEmail = new System.Windows.Forms.TextBox();
            this.btSendCode = new System.Windows.Forms.Button();
            this.lbNewPassword = new System.Windows.Forms.Label();
            this.tbNewPass = new System.Windows.Forms.TextBox();
            this.btCheckCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbUserEmail
            // 
            this.lbUserEmail.AutoSize = true;
            this.lbUserEmail.Location = new System.Drawing.Point(29, 21);
            this.lbUserEmail.Name = "lbUserEmail";
            this.lbUserEmail.Size = new System.Drawing.Size(99, 13);
            this.lbUserEmail.TabIndex = 0;
            this.lbUserEmail.Text = "Your email address:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(146, 18);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(173, 20);
            this.tbEmail.TabIndex = 1;
            // 
            // lbConfirmCode
            // 
            this.lbConfirmCode.AutoSize = true;
            this.lbConfirmCode.Location = new System.Drawing.Point(29, 47);
            this.lbConfirmCode.Name = "lbConfirmCode";
            this.lbConfirmCode.Size = new System.Drawing.Size(112, 13);
            this.lbConfirmCode.TabIndex = 0;
            this.lbConfirmCode.Text = "Enter code from email:";
            // 
            // tbEnterCode
            // 
            this.tbEnterCode.Location = new System.Drawing.Point(147, 44);
            this.tbEnterCode.Name = "tbEnterCode";
            this.tbEnterCode.Size = new System.Drawing.Size(172, 20);
            this.tbEnterCode.TabIndex = 4;
            // 
            // lbCodeFromEmail
            // 
            this.lbCodeFromEmail.AutoSize = true;
            this.lbCodeFromEmail.Location = new System.Drawing.Point(29, 73);
            this.lbCodeFromEmail.Name = "lbCodeFromEmail";
            this.lbCodeFromEmail.Size = new System.Drawing.Size(85, 13);
            this.lbCodeFromEmail.TabIndex = 0;
            this.lbCodeFromEmail.Text = "Code from email:";
            // 
            // tbCodeFromEmail
            // 
            this.tbCodeFromEmail.Location = new System.Drawing.Point(147, 70);
            this.tbCodeFromEmail.Name = "tbCodeFromEmail";
            this.tbCodeFromEmail.ReadOnly = true;
            this.tbCodeFromEmail.Size = new System.Drawing.Size(172, 20);
            this.tbCodeFromEmail.TabIndex = 3;
            // 
            // btSendCode
            // 
            this.btSendCode.Location = new System.Drawing.Point(345, 16);
            this.btSendCode.Name = "btSendCode";
            this.btSendCode.Size = new System.Drawing.Size(75, 23);
            this.btSendCode.TabIndex = 2;
            this.btSendCode.Text = "Send Code";
            this.btSendCode.UseVisualStyleBackColor = true;
            this.btSendCode.Click += new System.EventHandler(this.btSendCode_Click);
            // 
            // lbNewPassword
            // 
            this.lbNewPassword.AutoSize = true;
            this.lbNewPassword.Location = new System.Drawing.Point(29, 99);
            this.lbNewPassword.Name = "lbNewPassword";
            this.lbNewPassword.Size = new System.Drawing.Size(80, 13);
            this.lbNewPassword.TabIndex = 0;
            this.lbNewPassword.Text = "New password:";
            // 
            // tbNewPass
            // 
            this.tbNewPass.Location = new System.Drawing.Point(147, 96);
            this.tbNewPass.Name = "tbNewPass";
            this.tbNewPass.ReadOnly = true;
            this.tbNewPass.Size = new System.Drawing.Size(172, 20);
            this.tbNewPass.TabIndex = 6;
            // 
            // btCheckCode
            // 
            this.btCheckCode.Location = new System.Drawing.Point(345, 42);
            this.btCheckCode.Name = "btCheckCode";
            this.btCheckCode.Size = new System.Drawing.Size(75, 23);
            this.btCheckCode.TabIndex = 5;
            this.btCheckCode.Text = "Check Code";
            this.btCheckCode.UseVisualStyleBackColor = true;
            this.btCheckCode.Click += new System.EventHandler(this.btCheckCode_Click);
            // 
            // UcResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btCheckCode);
            this.Controls.Add(this.btSendCode);
            this.Controls.Add(this.tbNewPass);
            this.Controls.Add(this.lbNewPassword);
            this.Controls.Add(this.tbCodeFromEmail);
            this.Controls.Add(this.lbCodeFromEmail);
            this.Controls.Add(this.tbEnterCode);
            this.Controls.Add(this.lbConfirmCode);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lbUserEmail);
            this.Name = "UcResetPassword";
            this.Size = new System.Drawing.Size(440, 135);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUserEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lbConfirmCode;
        private System.Windows.Forms.TextBox tbEnterCode;
        private System.Windows.Forms.Label lbCodeFromEmail;
        private System.Windows.Forms.TextBox tbCodeFromEmail;
        private System.Windows.Forms.Button btSendCode;
        private System.Windows.Forms.Label lbNewPassword;
        private System.Windows.Forms.TextBox tbNewPass;
        private System.Windows.Forms.Button btCheckCode;
    }
}
