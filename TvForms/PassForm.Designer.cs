namespace TvForms
{
    partial class PassForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassForm));
            this.bPassForm_Cancel = new System.Windows.Forms.Button();
            this.bPassForm_Enter = new System.Windows.Forms.Button();
            this.tbPassForm_Login = new System.Windows.Forms.TextBox();
            this.lbPassForm_Login = new System.Windows.Forms.Label();
            this.lbPassForm_Password = new System.Windows.Forms.Label();
            this.tbPassForm_Pass = new System.Windows.Forms.TextBox();
            this.linkLbPassForm_FogotPass = new System.Windows.Forms.LinkLabel();
            this.lbPassForm_Welcome = new System.Windows.Forms.Label();
            this.picPassForm_Login = new System.Windows.Forms.PictureBox();
            this.chBPassForm_ShowPass = new System.Windows.Forms.CheckBox();
            this.linkLbPassForm_Register = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picPassForm_Login)).BeginInit();
            this.SuspendLayout();
            // 
            // bPassForm_Cancel
            // 
            this.bPassForm_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bPassForm_Cancel.Location = new System.Drawing.Point(327, 129);
            this.bPassForm_Cancel.Name = "bPassForm_Cancel";
            this.bPassForm_Cancel.Size = new System.Drawing.Size(75, 23);
            this.bPassForm_Cancel.TabIndex = 0;
            this.bPassForm_Cancel.Text = "Cancel";
            this.bPassForm_Cancel.UseVisualStyleBackColor = true;
            // 
            // bPassForm_Enter
            // 
            this.bPassForm_Enter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bPassForm_Enter.Location = new System.Drawing.Point(246, 129);
            this.bPassForm_Enter.Name = "bPassForm_Enter";
            this.bPassForm_Enter.Size = new System.Drawing.Size(75, 23);
            this.bPassForm_Enter.TabIndex = 1;
            this.bPassForm_Enter.Text = "Enter";
            this.bPassForm_Enter.UseVisualStyleBackColor = true;
            // 
            // tbPassForm_Login
            // 
            this.tbPassForm_Login.Location = new System.Drawing.Point(121, 55);
            this.tbPassForm_Login.Name = "tbPassForm_Login";
            this.tbPassForm_Login.Size = new System.Drawing.Size(281, 20);
            this.tbPassForm_Login.TabIndex = 2;
            // 
            // lbPassForm_Login
            // 
            this.lbPassForm_Login.AutoSize = true;
            this.lbPassForm_Login.Location = new System.Drawing.Point(62, 58);
            this.lbPassForm_Login.Name = "lbPassForm_Login";
            this.lbPassForm_Login.Size = new System.Drawing.Size(33, 13);
            this.lbPassForm_Login.TabIndex = 3;
            this.lbPassForm_Login.Text = "Login";
            // 
            // lbPassForm_Password
            // 
            this.lbPassForm_Password.AutoSize = true;
            this.lbPassForm_Password.Location = new System.Drawing.Point(62, 84);
            this.lbPassForm_Password.Name = "lbPassForm_Password";
            this.lbPassForm_Password.Size = new System.Drawing.Size(53, 13);
            this.lbPassForm_Password.TabIndex = 4;
            this.lbPassForm_Password.Text = "Password";
            // 
            // tbPassForm_Pass
            // 
            this.tbPassForm_Pass.Location = new System.Drawing.Point(121, 81);
            this.tbPassForm_Pass.Name = "tbPassForm_Pass";
            this.tbPassForm_Pass.Size = new System.Drawing.Size(281, 20);
            this.tbPassForm_Pass.TabIndex = 5;
            // 
            // linkLbPassForm_FogotPass
            // 
            this.linkLbPassForm_FogotPass.AutoSize = true;
            this.linkLbPassForm_FogotPass.Location = new System.Drawing.Point(118, 142);
            this.linkLbPassForm_FogotPass.Name = "linkLbPassForm_FogotPass";
            this.linkLbPassForm_FogotPass.Size = new System.Drawing.Size(91, 13);
            this.linkLbPassForm_FogotPass.TabIndex = 6;
            this.linkLbPassForm_FogotPass.TabStop = true;
            this.linkLbPassForm_FogotPass.Text = "Forgot password?";
            // 
            // lbPassForm_Welcome
            // 
            this.lbPassForm_Welcome.AutoSize = true;
            this.lbPassForm_Welcome.Location = new System.Drawing.Point(66, 18);
            this.lbPassForm_Welcome.Name = "lbPassForm_Welcome";
            this.lbPassForm_Welcome.Size = new System.Drawing.Size(323, 13);
            this.lbPassForm_Welcome.TabIndex = 7;
            this.lbPassForm_Welcome.Text = "Welcome to TV Programm application, please enter you credentials";
            // 
            // picPassForm_Login
            // 
            this.picPassForm_Login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picPassForm_Login.BackgroundImage")));
            this.picPassForm_Login.InitialImage = null;
            this.picPassForm_Login.Location = new System.Drawing.Point(2, 2);
            this.picPassForm_Login.Name = "picPassForm_Login";
            this.picPassForm_Login.Size = new System.Drawing.Size(50, 50);
            this.picPassForm_Login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPassForm_Login.TabIndex = 8;
            this.picPassForm_Login.TabStop = false;
            // 
            // chBPassForm_ShowPass
            // 
            this.chBPassForm_ShowPass.AutoSize = true;
            this.chBPassForm_ShowPass.Location = new System.Drawing.Point(121, 108);
            this.chBPassForm_ShowPass.Name = "chBPassForm_ShowPass";
            this.chBPassForm_ShowPass.Size = new System.Drawing.Size(76, 17);
            this.chBPassForm_ShowPass.TabIndex = 9;
            this.chBPassForm_ShowPass.Text = "show pass";
            this.chBPassForm_ShowPass.UseVisualStyleBackColor = true;
            this.chBPassForm_ShowPass.CheckStateChanged += new System.EventHandler(this.chBPassForm_ShowPass_CheckStateChanged);
            // 
            // linkLbPassForm_Register
            // 
            this.linkLbPassForm_Register.AutoSize = true;
            this.linkLbPassForm_Register.Location = new System.Drawing.Point(30, 142);
            this.linkLbPassForm_Register.Name = "linkLbPassForm_Register";
            this.linkLbPassForm_Register.Size = new System.Drawing.Size(46, 13);
            this.linkLbPassForm_Register.TabIndex = 10;
            this.linkLbPassForm_Register.TabStop = true;
            this.linkLbPassForm_Register.Text = "Register";
            // 
            // PassForm
            // 
            this.AcceptButton = this.bPassForm_Enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bPassForm_Cancel;
            this.ClientSize = new System.Drawing.Size(414, 164);
            this.ControlBox = false;
            this.Controls.Add(this.linkLbPassForm_Register);
            this.Controls.Add(this.chBPassForm_ShowPass);
            this.Controls.Add(this.picPassForm_Login);
            this.Controls.Add(this.lbPassForm_Welcome);
            this.Controls.Add(this.linkLbPassForm_FogotPass);
            this.Controls.Add(this.tbPassForm_Pass);
            this.Controls.Add(this.lbPassForm_Password);
            this.Controls.Add(this.lbPassForm_Login);
            this.Controls.Add(this.tbPassForm_Login);
            this.Controls.Add(this.bPassForm_Enter);
            this.Controls.Add(this.bPassForm_Cancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(430, 203);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(430, 203);
            this.Name = "PassForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorization";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PassForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picPassForm_Login)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bPassForm_Cancel;
        private System.Windows.Forms.Button bPassForm_Enter;
        private System.Windows.Forms.TextBox tbPassForm_Login;
        private System.Windows.Forms.Label lbPassForm_Login;
        private System.Windows.Forms.Label lbPassForm_Password;
        private System.Windows.Forms.TextBox tbPassForm_Pass;
        private System.Windows.Forms.LinkLabel linkLbPassForm_FogotPass;
        private System.Windows.Forms.Label lbPassForm_Welcome;
        private System.Windows.Forms.PictureBox picPassForm_Login;
        private System.Windows.Forms.CheckBox chBPassForm_ShowPass;
        private System.Windows.Forms.LinkLabel linkLbPassForm_Register;
    }
}