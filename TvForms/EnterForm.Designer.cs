namespace TvForms
{
    partial class EnterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterForm));
            this.bEnterF_Cancel = new System.Windows.Forms.Button();
            this.bEnterF_Enter = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lbEnterF_Welcome = new System.Windows.Forms.Label();
            this.picLogin = new System.Windows.Forms.PictureBox();
            this.chBEnterF_ShowPass = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // bEnterF_Cancel
            // 
            this.bEnterF_Cancel.Location = new System.Drawing.Point(327, 129);
            this.bEnterF_Cancel.Name = "bEnterF_Cancel";
            this.bEnterF_Cancel.Size = new System.Drawing.Size(75, 23);
            this.bEnterF_Cancel.TabIndex = 0;
            this.bEnterF_Cancel.Text = "Cancel";
            this.bEnterF_Cancel.UseVisualStyleBackColor = true;
     
            // 
            // bEnterF_Enter
            // 
            this.bEnterF_Enter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bEnterF_Enter.Location = new System.Drawing.Point(246, 129);
            this.bEnterF_Enter.Name = "bEnterF_Enter";
            this.bEnterF_Enter.Size = new System.Drawing.Size(75, 23);
            this.bEnterF_Enter.TabIndex = 1;
            this.bEnterF_Enter.Text = "Enter";
            this.bEnterF_Enter.UseVisualStyleBackColor = true;
            this.bEnterF_Enter.Click += new System.EventHandler(this.bEnterF_Enter_Click);
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(121, 55);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(281, 20);
            this.tbLogin.TabIndex = 2;
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(62, 58);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(33, 13);
            this.lbLogin.TabIndex = 3;
            this.lbLogin.Text = "Login";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(62, 84);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 4;
            this.lbPassword.Text = "Password";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(121, 81);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(281, 20);
            this.tbPassword.TabIndex = 5;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(45, 134);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(91, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgot password?";
            // 
            // lbEnterF_Welcome
            // 
            this.lbEnterF_Welcome.AutoSize = true;
            this.lbEnterF_Welcome.Location = new System.Drawing.Point(66, 18);
            this.lbEnterF_Welcome.Name = "lbEnterF_Welcome";
            this.lbEnterF_Welcome.Size = new System.Drawing.Size(323, 13);
            this.lbEnterF_Welcome.TabIndex = 7;
            this.lbEnterF_Welcome.Text = "Welcome to TV Programm application, please enter you credentials";
            // 
            // picLogin
            // 
            this.picLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLogin.BackgroundImage")));
            this.picLogin.InitialImage = null;
            this.picLogin.Location = new System.Drawing.Point(2, 2);
            this.picLogin.Name = "picLogin";
            this.picLogin.Size = new System.Drawing.Size(50, 50);
            this.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLogin.TabIndex = 8;
            this.picLogin.TabStop = false;
            // 
            // chBEnterF_ShowPass
            // 
            this.chBEnterF_ShowPass.AutoSize = true;
            this.chBEnterF_ShowPass.Location = new System.Drawing.Point(121, 108);
            this.chBEnterF_ShowPass.Name = "chBEnterF_ShowPass";
            this.chBEnterF_ShowPass.Size = new System.Drawing.Size(76, 17);
            this.chBEnterF_ShowPass.TabIndex = 9;
            this.chBEnterF_ShowPass.Text = "show pass";
            this.chBEnterF_ShowPass.UseVisualStyleBackColor = true;
            // 
            // EnterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 164);
            this.Controls.Add(this.chBEnterF_ShowPass);
            this.Controls.Add(this.picLogin);
            this.Controls.Add(this.lbEnterF_Welcome);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.bEnterF_Enter);
            this.Controls.Add(this.bEnterF_Cancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorization";
            ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bEnterF_Cancel;
        private System.Windows.Forms.Button bEnterF_Enter;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lbEnterF_Welcome;
        private System.Windows.Forms.PictureBox picLogin;
        private System.Windows.Forms.CheckBox chBEnterF_ShowPass;
    }
}