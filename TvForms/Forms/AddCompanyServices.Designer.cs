namespace TvForms.Forms
{
    partial class AddCompanyServices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCompanyServices));
            this.tbServiceName = new System.Windows.Forms.TextBox();
            this.lbServiceName = new System.Windows.Forms.Label();
            this.lbServicePrice = new System.Windows.Forms.Label();
            this.cbAdultContent = new System.Windows.Forms.CheckBox();
            this.numServicePrice = new System.Windows.Forms.NumericUpDown();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numServicePrice)).BeginInit();
            this.SuspendLayout();
            // 
            // tbServiceName
            // 
            this.tbServiceName.Location = new System.Drawing.Point(115, 12);
            this.tbServiceName.Name = "tbServiceName";
            this.tbServiceName.Size = new System.Drawing.Size(191, 20);
            this.tbServiceName.TabIndex = 0;
            // 
            // lbServiceName
            // 
            this.lbServiceName.AutoSize = true;
            this.lbServiceName.Location = new System.Drawing.Point(36, 15);
            this.lbServiceName.Name = "lbServiceName";
            this.lbServiceName.Size = new System.Drawing.Size(43, 13);
            this.lbServiceName.TabIndex = 2;
            this.lbServiceName.Text = "Service";
            // 
            // lbServicePrice
            // 
            this.lbServicePrice.AutoSize = true;
            this.lbServicePrice.Location = new System.Drawing.Point(36, 54);
            this.lbServicePrice.Name = "lbServicePrice";
            this.lbServicePrice.Size = new System.Drawing.Size(31, 13);
            this.lbServicePrice.TabIndex = 3;
            this.lbServicePrice.Text = "Price";
            // 
            // cbAdultContent
            // 
            this.cbAdultContent.AutoSize = true;
            this.cbAdultContent.Location = new System.Drawing.Point(39, 93);
            this.cbAdultContent.Name = "cbAdultContent";
            this.cbAdultContent.Size = new System.Drawing.Size(97, 17);
            this.cbAdultContent.TabIndex = 4;
            this.cbAdultContent.Text = "For Adults Only";
            this.cbAdultContent.UseVisualStyleBackColor = true;
            // 
            // numServicePrice
            // 
            this.numServicePrice.Location = new System.Drawing.Point(115, 52);
            this.numServicePrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numServicePrice.Name = "numServicePrice";
            this.numServicePrice.Size = new System.Drawing.Size(191, 20);
            this.numServicePrice.TabIndex = 5;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(166, 126);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 6;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(267, 126);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // AddCompanyServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 161);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.numServicePrice);
            this.Controls.Add(this.cbAdultContent);
            this.Controls.Add(this.lbServicePrice);
            this.Controls.Add(this.lbServiceName);
            this.Controls.Add(this.tbServiceName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(370, 200);
            this.MinimumSize = new System.Drawing.Size(370, 200);
            this.Name = "AddCompanyServices";
            this.Text = "Add New Service";
            ((System.ComponentModel.ISupportInitialize)(this.numServicePrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbServiceName;
        private System.Windows.Forms.Label lbServiceName;
        private System.Windows.Forms.Label lbServicePrice;
        private System.Windows.Forms.CheckBox cbAdultContent;
        private System.Windows.Forms.NumericUpDown numServicePrice;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
    }
}