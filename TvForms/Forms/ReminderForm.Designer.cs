namespace TvForms
{
    partial class ReminderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReminderForm));
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbProgTime = new System.Windows.Forms.Label();
            this.tbProgrTime = new System.Windows.Forms.TextBox();
            this.tbProgName = new System.Windows.Forms.TextBox();
            this.lbProgName = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.tbSMSNumber = new System.Windows.Forms.TextBox();
            this.lbSMS = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbUserName
            // 
            this.tbUserName.Enabled = false;
            this.tbUserName.Location = new System.Drawing.Point(301, 12);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(189, 20);
            this.tbUserName.TabIndex = 0;
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(205, 15);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(29, 13);
            this.lbUser.TabIndex = 1;
            this.lbUser.Text = "User";
            // 
            // lbProgTime
            // 
            this.lbProgTime.AutoSize = true;
            this.lbProgTime.Location = new System.Drawing.Point(205, 52);
            this.lbProgTime.Name = "lbProgTime";
            this.lbProgTime.Size = new System.Drawing.Size(82, 13);
            this.lbProgTime.TabIndex = 2;
            this.lbProgTime.Text = "Programme time";
            // 
            // tbProgrTime
            // 
            this.tbProgrTime.Enabled = false;
            this.tbProgrTime.Location = new System.Drawing.Point(301, 49);
            this.tbProgrTime.Name = "tbProgrTime";
            this.tbProgrTime.Size = new System.Drawing.Size(189, 20);
            this.tbProgrTime.TabIndex = 3;
            // 
            // tbProgName
            // 
            this.tbProgName.Enabled = false;
            this.tbProgName.Location = new System.Drawing.Point(301, 75);
            this.tbProgName.Name = "tbProgName";
            this.tbProgName.Size = new System.Drawing.Size(264, 20);
            this.tbProgName.TabIndex = 5;
            // 
            // lbProgName
            // 
            this.lbProgName.AutoSize = true;
            this.lbProgName.Location = new System.Drawing.Point(205, 78);
            this.lbProgName.Name = "lbProgName";
            this.lbProgName.Size = new System.Drawing.Size(91, 13);
            this.lbProgName.TabIndex = 4;
            this.lbProgName.Text = "Programme Name";
            // 
            // tbEmail
            // 
            this.tbEmail.Enabled = false;
            this.tbEmail.Location = new System.Drawing.Point(301, 139);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(189, 20);
            this.tbEmail.TabIndex = 7;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(205, 142);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(63, 13);
            this.lbEmail.TabIndex = 6;
            this.lbEmail.Text = "Send E-mail";
            // 
            // tbSMSNumber
            // 
            this.tbSMSNumber.Enabled = false;
            this.tbSMSNumber.Location = new System.Drawing.Point(301, 113);
            this.tbSMSNumber.Name = "tbSMSNumber";
            this.tbSMSNumber.Size = new System.Drawing.Size(189, 20);
            this.tbSMSNumber.TabIndex = 9;
            // 
            // lbSMS
            // 
            this.lbSMS.AutoSize = true;
            this.lbSMS.Location = new System.Drawing.Point(205, 116);
            this.lbSMS.Name = "lbSMS";
            this.lbSMS.Size = new System.Drawing.Size(58, 13);
            this.lbSMS.TabIndex = 8;
            this.lbSMS.Text = "Send SMS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TvForms.Properties.Resources.clock_icon_2;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(23, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // ReminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 172);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbSMSNumber);
            this.Controls.Add(this.lbSMS);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.tbProgName);
            this.Controls.Add(this.lbProgName);
            this.Controls.Add(this.tbProgrTime);
            this.Controls.Add(this.lbProgTime);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.tbUserName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(595, 211);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(595, 211);
            this.Name = "ReminderForm";
            this.Text = "ReminderForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbProgTime;
        private System.Windows.Forms.TextBox tbProgrTime;
        private System.Windows.Forms.TextBox tbProgName;
        private System.Windows.Forms.Label lbProgName;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox tbSMSNumber;
        private System.Windows.Forms.Label lbSMS;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}