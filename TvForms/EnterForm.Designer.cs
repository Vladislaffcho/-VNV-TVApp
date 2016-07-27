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
            this.bEnForm_Cancel = new System.Windows.Forms.Button();
            this.bEnForm_Enter = new System.Windows.Forms.Button();
            this.tbEnForm_Login = new System.Windows.Forms.TextBox();
            this.lbEnForm_Login = new System.Windows.Forms.Label();
            this.lbEnForm_Password = new System.Windows.Forms.Label();
            this.tbEnForm_Pass = new System.Windows.Forms.TextBox();
            this.linkLbEnForm_FogotPass = new System.Windows.Forms.LinkLabel();
            this.lbEnForm_Welcome = new System.Windows.Forms.Label();
            this.picEnForm_Login = new System.Windows.Forms.PictureBox();
            this.chBEnForm_ShowPass = new System.Windows.Forms.CheckBox();
            this.linkLbEnForm_Register = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picEnForm_Login)).BeginInit();
            this.SuspendLayout();
            // 
            // bEnForm_Cancel
            // 
            this.bEnForm_Cancel.Location = new System.Drawing.Point(327, 129);
            this.bEnForm_Cancel.Name = "bEnForm_Cancel";
            this.bEnForm_Cancel.Size = new System.Drawing.Size(75, 23);
            this.bEnForm_Cancel.TabIndex = 0;
            this.bEnForm_Cancel.Text = "Cancel";
            this.bEnForm_Cancel.UseVisualStyleBackColor = true;
            // 
            // bEnForm_Enter
            // 
            this.bEnForm_Enter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bEnForm_Enter.Location = new System.Drawing.Point(246, 129);
            this.bEnForm_Enter.Name = "bEnForm_Enter";
            this.bEnForm_Enter.Size = new System.Drawing.Size(75, 23);
            this.bEnForm_Enter.TabIndex = 1;
            this.bEnForm_Enter.Text = "Enter";
            this.bEnForm_Enter.UseVisualStyleBackColor = true;
            this.bEnForm_Enter.Click += new System.EventHandler(this.bEnterF_Enter_Click);
            // 
            // tbEnForm_Login
            // 
            this.tbEnForm_Login.Location = new System.Drawing.Point(121, 55);
            this.tbEnForm_Login.Name = "tbEnForm_Login";
            this.tbEnForm_Login.Size = new System.Drawing.Size(281, 20);
            this.tbEnForm_Login.TabIndex = 2;
            // 
            // lbEnForm_Login
            // 
            this.lbEnForm_Login.AutoSize = true;
            this.lbEnForm_Login.Location = new System.Drawing.Point(62, 58);
            this.lbEnForm_Login.Name = "lbEnForm_Login";
            this.lbEnForm_Login.Size = new System.Drawing.Size(33, 13);
            this.lbEnForm_Login.TabIndex = 3;
            this.lbEnForm_Login.Text = "Login";
            // 
            // lbEnForm_Password
            // 
            this.lbEnForm_Password.AutoSize = true;
            this.lbEnForm_Password.Location = new System.Drawing.Point(62, 84);
            this.lbEnForm_Password.Name = "lbEnForm_Password";
            this.lbEnForm_Password.Size = new System.Drawing.Size(53, 13);
            this.lbEnForm_Password.TabIndex = 4;
            this.lbEnForm_Password.Text = "Password";
            // 
            // tbEnForm_Pass
            // 
            this.tbEnForm_Pass.Location = new System.Drawing.Point(121, 81);
            this.tbEnForm_Pass.Name = "tbEnForm_Pass";
            this.tbEnForm_Pass.Size = new System.Drawing.Size(281, 20);
            this.tbEnForm_Pass.TabIndex = 5;
            // 
            // linkLbEnForm_FogotPass
            // 
            this.linkLbEnForm_FogotPass.AutoSize = true;
            this.linkLbEnForm_FogotPass.Location = new System.Drawing.Point(118, 142);
            this.linkLbEnForm_FogotPass.Name = "linkLbEnForm_FogotPass";
            this.linkLbEnForm_FogotPass.Size = new System.Drawing.Size(91, 13);
            this.linkLbEnForm_FogotPass.TabIndex = 6;
            this.linkLbEnForm_FogotPass.TabStop = true;
            this.linkLbEnForm_FogotPass.Text = "Forgot password?";
            // 
            // lbEnForm_Welcome
            // 
            this.lbEnForm_Welcome.AutoSize = true;
            this.lbEnForm_Welcome.Location = new System.Drawing.Point(66, 18);
            this.lbEnForm_Welcome.Name = "lbEnForm_Welcome";
            this.lbEnForm_Welcome.Size = new System.Drawing.Size(323, 13);
            this.lbEnForm_Welcome.TabIndex = 7;
            this.lbEnForm_Welcome.Text = "Welcome to TV Programm application, please enter you credentials";
            // 
            // picEnForm_Login
            // 
            this.picEnForm_Login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picEnForm_Login.BackgroundImage")));
            this.picEnForm_Login.InitialImage = null;
            this.picEnForm_Login.Location = new System.Drawing.Point(2, 2);
            this.picEnForm_Login.Name = "picEnForm_Login";
            this.picEnForm_Login.Size = new System.Drawing.Size(50, 50);
            this.picEnForm_Login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picEnForm_Login.TabIndex = 8;
            this.picEnForm_Login.TabStop = false;
            // 
            // chBEnForm_ShowPass
            // 
            this.chBEnForm_ShowPass.AutoSize = true;
            this.chBEnForm_ShowPass.Location = new System.Drawing.Point(121, 108);
            this.chBEnForm_ShowPass.Name = "chBEnForm_ShowPass";
            this.chBEnForm_ShowPass.Size = new System.Drawing.Size(76, 17);
            this.chBEnForm_ShowPass.TabIndex = 9;
            this.chBEnForm_ShowPass.Text = "show pass";
            this.chBEnForm_ShowPass.UseVisualStyleBackColor = true;
            // 
            // linkLbEnForm_Register
            // 
            this.linkLbEnForm_Register.AutoSize = true;
            this.linkLbEnForm_Register.Location = new System.Drawing.Point(30, 142);
            this.linkLbEnForm_Register.Name = "linkLbEnForm_Register";
            this.linkLbEnForm_Register.Size = new System.Drawing.Size(46, 13);
            this.linkLbEnForm_Register.TabIndex = 10;
            this.linkLbEnForm_Register.TabStop = true;
            this.linkLbEnForm_Register.Text = "Register";
            // 
            // EnterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 164);
            this.Controls.Add(this.linkLbEnForm_Register);
            this.Controls.Add(this.chBEnForm_ShowPass);
            this.Controls.Add(this.picEnForm_Login);
            this.Controls.Add(this.lbEnForm_Welcome);
            this.Controls.Add(this.linkLbEnForm_FogotPass);
            this.Controls.Add(this.tbEnForm_Pass);
            this.Controls.Add(this.lbEnForm_Password);
            this.Controls.Add(this.lbEnForm_Login);
            this.Controls.Add(this.tbEnForm_Login);
            this.Controls.Add(this.bEnForm_Enter);
            this.Controls.Add(this.bEnForm_Cancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorization";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnterForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.picEnForm_Login)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bEnForm_Cancel;
        private System.Windows.Forms.Button bEnForm_Enter;
        private System.Windows.Forms.TextBox tbEnForm_Login;
        private System.Windows.Forms.Label lbEnForm_Login;
        private System.Windows.Forms.Label lbEnForm_Password;
        private System.Windows.Forms.TextBox tbEnForm_Pass;
        private System.Windows.Forms.LinkLabel linkLbEnForm_FogotPass;
        private System.Windows.Forms.Label lbEnForm_Welcome;
        private System.Windows.Forms.PictureBox picEnForm_Login;
        private System.Windows.Forms.CheckBox chBEnForm_ShowPass;
        private System.Windows.Forms.LinkLabel linkLbEnForm_Register;
    }
}