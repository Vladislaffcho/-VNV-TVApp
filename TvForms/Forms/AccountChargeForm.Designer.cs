namespace TvForms
{
    partial class AccountChargeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountChargeForm));
            this.panChargeAccount = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOkey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panChargeAccount
            // 
            this.panChargeAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panChargeAccount.Location = new System.Drawing.Point(2, 2);
            this.panChargeAccount.Name = "panChargeAccount";
            this.panChargeAccount.Size = new System.Drawing.Size(440, 154);
            this.panChargeAccount.TabIndex = 0;
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(367, 162);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOkey
            // 
            this.btOkey.Location = new System.Drawing.Point(286, 162);
            this.btOkey.Name = "btOkey";
            this.btOkey.Size = new System.Drawing.Size(75, 23);
            this.btOkey.TabIndex = 2;
            this.btOkey.Text = "Ok";
            this.btOkey.UseVisualStyleBackColor = true;
            this.btOkey.Click += new System.EventHandler(this.btOkey_Click);
            // 
            // AccountChargeForm
            // 
            this.AcceptButton = this.btOkey;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(445, 190);
            this.ControlBox = false;
            this.Controls.Add(this.btOkey);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.panChargeAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(461, 229);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(461, 229);
            this.Name = "AccountChargeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Charge account";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccountChargeForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panChargeAccount;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOkey;
    }
}