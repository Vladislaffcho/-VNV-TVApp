namespace TvForms.Forms
{
    partial class AdditionalServicesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdditionalServicesForm));
            this.btClose = new System.Windows.Forms.Button();
            this.lvMyAdditionalService = new System.Windows.Forms.ListView();
            this.colMyServiceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMyServicePrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvAvailableAdditionalServices = new System.Windows.Forms.ListView();
            this.colAvailServiceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAvailServicePrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbAvailableServices = new System.Windows.Forms.GroupBox();
            this.gbUserServices = new System.Windows.Forms.GroupBox();
            this.btAddService = new System.Windows.Forms.Button();
            this.colAvailServiceAgeLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMyServiceAgeLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbAvailableServices.SuspendLayout();
            this.gbUserServices.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(358, 155);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 4;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // lvMyAdditionalService
            // 
            this.lvMyAdditionalService.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMyServiceName,
            this.colMyServicePrice,
            this.colMyServiceAgeLimit});
            this.lvMyAdditionalService.FullRowSelect = true;
            this.lvMyAdditionalService.GridLines = true;
            this.lvMyAdditionalService.Location = new System.Drawing.Point(6, 19);
            this.lvMyAdditionalService.Name = "lvMyAdditionalService";
            this.lvMyAdditionalService.Size = new System.Drawing.Size(200, 109);
            this.lvMyAdditionalService.TabIndex = 6;
            this.lvMyAdditionalService.UseCompatibleStateImageBehavior = false;
            this.lvMyAdditionalService.View = System.Windows.Forms.View.Details;
            // 
            // colMyServiceName
            // 
            this.colMyServiceName.Text = "Service";
            this.colMyServiceName.Width = 94;
            // 
            // colMyServicePrice
            // 
            this.colMyServicePrice.Text = "Price";
            this.colMyServicePrice.Width = 51;
            // 
            // lvAvailableAdditionalServices
            // 
            this.lvAvailableAdditionalServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAvailServiceName,
            this.colAvailServicePrice,
            this.colAvailServiceAgeLimit});
            this.lvAvailableAdditionalServices.FullRowSelect = true;
            this.lvAvailableAdditionalServices.GridLines = true;
            this.lvAvailableAdditionalServices.Location = new System.Drawing.Point(6, 19);
            this.lvAvailableAdditionalServices.Name = "lvAvailableAdditionalServices";
            this.lvAvailableAdditionalServices.Size = new System.Drawing.Size(200, 109);
            this.lvAvailableAdditionalServices.TabIndex = 6;
            this.lvAvailableAdditionalServices.UseCompatibleStateImageBehavior = false;
            this.lvAvailableAdditionalServices.View = System.Windows.Forms.View.Details;
            // 
            // colAvailServiceName
            // 
            this.colAvailServiceName.Text = "Service";
            this.colAvailServiceName.Width = 94;
            // 
            // colAvailServicePrice
            // 
            this.colAvailServicePrice.Text = "Price";
            this.colAvailServicePrice.Width = 51;
            // 
            // gbAvailableServices
            // 
            this.gbAvailableServices.Controls.Add(this.btAddService);
            this.gbAvailableServices.Controls.Add(this.lvAvailableAdditionalServices);
            this.gbAvailableServices.Location = new System.Drawing.Point(3, 3);
            this.gbAvailableServices.Name = "gbAvailableServices";
            this.gbAvailableServices.Size = new System.Drawing.Size(207, 164);
            this.gbAvailableServices.TabIndex = 7;
            this.gbAvailableServices.TabStop = false;
            this.gbAvailableServices.Text = "Available Services";
            // 
            // gbUserServices
            // 
            this.gbUserServices.Controls.Add(this.lvMyAdditionalService);
            this.gbUserServices.Location = new System.Drawing.Point(235, 3);
            this.gbUserServices.Name = "gbUserServices";
            this.gbUserServices.Size = new System.Drawing.Size(207, 133);
            this.gbUserServices.TabIndex = 8;
            this.gbUserServices.TabStop = false;
            this.gbUserServices.Text = "My Services";
            // 
            // btAddService
            // 
            this.btAddService.Location = new System.Drawing.Point(115, 135);
            this.btAddService.Name = "btAddService";
            this.btAddService.Size = new System.Drawing.Size(75, 23);
            this.btAddService.TabIndex = 7;
            this.btAddService.Text = "Add Service";
            this.btAddService.UseVisualStyleBackColor = true;
            this.btAddService.Click += new System.EventHandler(this.btAddService_Click);
            // 
            // colAvailServiceAgeLimit
            // 
            this.colAvailServiceAgeLimit.Text = "18+";
            this.colAvailServiceAgeLimit.Width = 51;
            // 
            // colMyServiceAgeLimit
            // 
            this.colMyServiceAgeLimit.Text = "18+";
            this.colMyServiceAgeLimit.Width = 51;
            // 
            // AdditionalServicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 190);
            this.Controls.Add(this.gbUserServices);
            this.Controls.Add(this.gbAvailableServices);
            this.Controls.Add(this.btClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(461, 229);
            this.MinimumSize = new System.Drawing.Size(461, 229);
            this.Name = "AdditionalServicesForm";
            this.Text = "Additional Services";
            this.gbAvailableServices.ResumeLayout(false);
            this.gbUserServices.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ListView lvMyAdditionalService;
        private System.Windows.Forms.ColumnHeader colMyServiceName;
        private System.Windows.Forms.ColumnHeader colMyServicePrice;
        private System.Windows.Forms.ColumnHeader colMyServiceAgeLimit;
        private System.Windows.Forms.ListView lvAvailableAdditionalServices;
        private System.Windows.Forms.ColumnHeader colAvailServiceName;
        private System.Windows.Forms.ColumnHeader colAvailServicePrice;
        private System.Windows.Forms.ColumnHeader colAvailServiceAgeLimit;
        private System.Windows.Forms.GroupBox gbAvailableServices;
        private System.Windows.Forms.Button btAddService;
        private System.Windows.Forms.GroupBox gbUserServices;
    }
}