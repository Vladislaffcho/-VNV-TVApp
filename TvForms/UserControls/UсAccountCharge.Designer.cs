namespace TvForms
{
    partial class UсAccountCharge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UсAccountCharge));
            this.mtbCvvCode = new System.Windows.Forms.MaskedTextBox();
            this.mtbDateCard = new System.Windows.Forms.MaskedTextBox();
            this.mtbCardNumber = new System.Windows.Forms.MaskedTextBox();
            this.lbEnterSumm = new System.Windows.Forms.Label();
            this.pbVisa = new System.Windows.Forms.PictureBox();
            this.pbMasterCard = new System.Windows.Forms.PictureBox();
            this.pbMaestro = new System.Windows.Forms.PictureBox();
            this.lbCVVCode = new System.Windows.Forms.Label();
            this.lbDateCard = new System.Windows.Forms.Label();
            this.ldCreditCard = new System.Windows.Forms.Label();
            this.lLbLicenceMaestro = new System.Windows.Forms.LinkLabel();
            this.tbSummRecharge = new System.Windows.Forms.TextBox();
            this.lLbLicenceMaster = new System.Windows.Forms.LinkLabel();
            this.lLbLicenceVisa = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMasterCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaestro)).BeginInit();
            this.SuspendLayout();
            // 
            // mtbCvvCode
            // 
            this.mtbCvvCode.Location = new System.Drawing.Point(117, 75);
            this.mtbCvvCode.Mask = "000";
            this.mtbCvvCode.Name = "mtbCvvCode";
            this.mtbCvvCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCvvCode.Size = new System.Drawing.Size(35, 20);
            this.mtbCvvCode.TabIndex = 3;
            // 
            // mtbDateCard
            // 
            this.mtbDateCard.Location = new System.Drawing.Point(117, 47);
            this.mtbDateCard.Mask = "00/00";
            this.mtbDateCard.Name = "mtbDateCard";
            this.mtbDateCard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbDateCard.Size = new System.Drawing.Size(35, 20);
            this.mtbDateCard.TabIndex = 2;
            // 
            // mtbCardNumber
            // 
            this.mtbCardNumber.Location = new System.Drawing.Point(117, 21);
            this.mtbCardNumber.Mask = "0000-0000-0000-0000";
            this.mtbCardNumber.Name = "mtbCardNumber";
            this.mtbCardNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCardNumber.Size = new System.Drawing.Size(113, 20);
            this.mtbCardNumber.TabIndex = 1;
            // 
            // lbEnterSumm
            // 
            this.lbEnterSumm.AutoSize = true;
            this.lbEnterSumm.Location = new System.Drawing.Point(17, 108);
            this.lbEnterSumm.Name = "lbEnterSumm";
            this.lbEnterSumm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbEnterSumm.Size = new System.Drawing.Size(65, 13);
            this.lbEnterSumm.TabIndex = 25;
            this.lbEnterSumm.Text = "Summ (грн.)";
            // 
            // pbVisa
            // 
            this.pbVisa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbVisa.BackgroundImage")));
            this.pbVisa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVisa.Location = new System.Drawing.Point(365, 70);
            this.pbVisa.Name = "pbVisa";
            this.pbVisa.Size = new System.Drawing.Size(64, 40);
            this.pbVisa.TabIndex = 24;
            this.pbVisa.TabStop = false;
            this.pbVisa.DoubleClick += new System.EventHandler(this.pbVisa_DoubleClick);
            // 
            // pbMasterCard
            // 
            this.pbMasterCard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbMasterCard.BackgroundImage")));
            this.pbMasterCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMasterCard.Location = new System.Drawing.Point(276, 10);
            this.pbMasterCard.Name = "pbMasterCard";
            this.pbMasterCard.Size = new System.Drawing.Size(64, 38);
            this.pbMasterCard.TabIndex = 23;
            this.pbMasterCard.TabStop = false;
            this.pbMasterCard.DoubleClick += new System.EventHandler(this.pbMasterCard_DoubleClick);
            // 
            // pbMaestro
            // 
            this.pbMaestro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbMaestro.BackgroundImage")));
            this.pbMaestro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMaestro.InitialImage = null;
            this.pbMaestro.Location = new System.Drawing.Point(365, 10);
            this.pbMaestro.Name = "pbMaestro";
            this.pbMaestro.Size = new System.Drawing.Size(64, 40);
            this.pbMaestro.TabIndex = 22;
            this.pbMaestro.TabStop = false;
            this.pbMaestro.DoubleClick += new System.EventHandler(this.pbMaestro_DoubleClick);
            // 
            // lbCVVCode
            // 
            this.lbCVVCode.AutoSize = true;
            this.lbCVVCode.Location = new System.Drawing.Point(17, 78);
            this.lbCVVCode.Name = "lbCVVCode";
            this.lbCVVCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbCVVCode.Size = new System.Drawing.Size(83, 13);
            this.lbCVVCode.TabIndex = 21;
            this.lbCVVCode.Text = "Enter CVV-code";
            // 
            // lbDateCard
            // 
            this.lbDateCard.AutoSize = true;
            this.lbDateCard.Location = new System.Drawing.Point(17, 50);
            this.lbDateCard.Name = "lbDateCard";
            this.lbDateCard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbDateCard.Size = new System.Drawing.Size(80, 13);
            this.lbDateCard.TabIndex = 20;
            this.lbDateCard.Text = "Enter date card";
            // 
            // ldCreditCard
            // 
            this.ldCreditCard.AutoSize = true;
            this.ldCreditCard.Location = new System.Drawing.Point(17, 24);
            this.ldCreditCard.Name = "ldCreditCard";
            this.ldCreditCard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ldCreditCard.Size = new System.Drawing.Size(94, 13);
            this.ldCreditCard.TabIndex = 19;
            this.ldCreditCard.Text = "Enter card number";
            // 
            // lLbLicenceMaestro
            // 
            this.lLbLicenceMaestro.AutoSize = true;
            this.lLbLicenceMaestro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lLbLicenceMaestro.Location = new System.Drawing.Point(272, 125);
            this.lLbLicenceMaestro.Name = "lLbLicenceMaestro";
            this.lLbLicenceMaestro.Size = new System.Drawing.Size(86, 13);
            this.lLbLicenceMaestro.TabIndex = 5;
            this.lLbLicenceMaestro.TabStop = true;
            this.lLbLicenceMaestro.Text = "Licence Maestro";
            this.lLbLicenceMaestro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lLbLicenceMaestro_LinkClicked);
            // 
            // tbSummRecharge
            // 
            this.tbSummRecharge.Location = new System.Drawing.Point(117, 105);
            this.tbSummRecharge.Name = "tbSummRecharge";
            this.tbSummRecharge.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbSummRecharge.Size = new System.Drawing.Size(113, 20);
            this.tbSummRecharge.TabIndex = 4;
            this.tbSummRecharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lLbLicenceMaster
            // 
            this.lLbLicenceMaster.AutoSize = true;
            this.lLbLicenceMaster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lLbLicenceMaster.Location = new System.Drawing.Point(353, 125);
            this.lLbLicenceMaster.Name = "lLbLicenceMaster";
            this.lLbLicenceMaster.Size = new System.Drawing.Size(44, 13);
            this.lLbLicenceMaster.TabIndex = 26;
            this.lLbLicenceMaster.TabStop = true;
            this.lLbLicenceMaster.Text = "/Master";
            this.lLbLicenceMaster.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lLbLicenceMaster_LinkClicked);
            // 
            // lLbLicenceVisa
            // 
            this.lLbLicenceVisa.AutoSize = true;
            this.lLbLicenceVisa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lLbLicenceVisa.Location = new System.Drawing.Point(393, 125);
            this.lLbLicenceVisa.Name = "lLbLicenceVisa";
            this.lLbLicenceVisa.Size = new System.Drawing.Size(36, 13);
            this.lLbLicenceVisa.TabIndex = 27;
            this.lLbLicenceVisa.TabStop = true;
            this.lLbLicenceVisa.Text = "/VISA";
            this.lLbLicenceVisa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lLbLicenceVisa_LinkClicked);
            // 
            // UсAccountCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lLbLicenceVisa);
            this.Controls.Add(this.lLbLicenceMaster);
            this.Controls.Add(this.tbSummRecharge);
            this.Controls.Add(this.lLbLicenceMaestro);
            this.Controls.Add(this.mtbCvvCode);
            this.Controls.Add(this.mtbDateCard);
            this.Controls.Add(this.mtbCardNumber);
            this.Controls.Add(this.lbEnterSumm);
            this.Controls.Add(this.pbVisa);
            this.Controls.Add(this.pbMasterCard);
            this.Controls.Add(this.pbMaestro);
            this.Controls.Add(this.lbCVVCode);
            this.Controls.Add(this.lbDateCard);
            this.Controls.Add(this.ldCreditCard);
            this.Name = "UсAccountCharge";
            this.Size = new System.Drawing.Size(438, 152);
            ((System.ComponentModel.ISupportInitialize)(this.pbVisa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMasterCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMaestro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox mtbCvvCode;
        private System.Windows.Forms.MaskedTextBox mtbDateCard;
        private System.Windows.Forms.MaskedTextBox mtbCardNumber;
        private System.Windows.Forms.Label lbEnterSumm;
        private System.Windows.Forms.PictureBox pbVisa;
        private System.Windows.Forms.PictureBox pbMasterCard;
        private System.Windows.Forms.PictureBox pbMaestro;
        private System.Windows.Forms.Label lbCVVCode;
        private System.Windows.Forms.Label lbDateCard;
        private System.Windows.Forms.Label ldCreditCard;
        private System.Windows.Forms.LinkLabel lLbLicenceMaestro;
        private System.Windows.Forms.TextBox tbSummRecharge;
        private System.Windows.Forms.LinkLabel lLbLicenceMaster;
        private System.Windows.Forms.LinkLabel lLbLicenceVisa;
    }
}
