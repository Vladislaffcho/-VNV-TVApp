namespace TvForms.Forms
{
    partial class DeleteServiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteServiceForm));
            this.lvAdditionalServices = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colForAdults = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbServices = new System.Windows.Forms.GroupBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.gbServices.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvAdditionalServices
            // 
            this.lvAdditionalServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colPrice,
            this.colForAdults});
            this.lvAdditionalServices.FullRowSelect = true;
            this.lvAdditionalServices.GridLines = true;
            this.lvAdditionalServices.Location = new System.Drawing.Point(6, 19);
            this.lvAdditionalServices.Name = "lvAdditionalServices";
            this.lvAdditionalServices.Size = new System.Drawing.Size(257, 111);
            this.lvAdditionalServices.TabIndex = 0;
            this.lvAdditionalServices.UseCompatibleStateImageBehavior = false;
            this.lvAdditionalServices.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Service";
            this.colName.Width = 131;
            // 
            // colPrice
            // 
            this.colPrice.Text = "Price";
            this.colPrice.Width = 78;
            // 
            // colForAdults
            // 
            this.colForAdults.Text = "18+";
            this.colForAdults.Width = 43;
            // 
            // gbServices
            // 
            this.gbServices.Controls.Add(this.lvAdditionalServices);
            this.gbServices.Location = new System.Drawing.Point(4, 3);
            this.gbServices.Name = "gbServices";
            this.gbServices.Size = new System.Drawing.Size(268, 140);
            this.gbServices.TabIndex = 1;
            this.gbServices.TabStop = false;
            this.gbServices.Text = "Services";
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(192, 152);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(111, 152);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 3;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // DeleteServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 182);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.gbServices);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(293, 221);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(293, 221);
            this.Name = "DeleteServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeleteServiceForm";
            this.gbServices.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvAdditionalServices;
        private System.Windows.Forms.GroupBox gbServices;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.ColumnHeader colForAdults;
    }
}