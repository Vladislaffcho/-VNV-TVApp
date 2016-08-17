namespace TvForms.UserControls
{
    partial class UcUpdateNames
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
            this.gbPersonalDetails = new System.Windows.Forms.GroupBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.gbPersonalDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPersonalDetails
            // 
            this.gbPersonalDetails.Controls.Add(this.tbFirstName);
            this.gbPersonalDetails.Controls.Add(this.tbLastName);
            this.gbPersonalDetails.Controls.Add(this.lbFirstName);
            this.gbPersonalDetails.Controls.Add(this.lbLastName);
            this.gbPersonalDetails.Location = new System.Drawing.Point(3, 3);
            this.gbPersonalDetails.Name = "gbPersonalDetails";
            this.gbPersonalDetails.Size = new System.Drawing.Size(434, 129);
            this.gbPersonalDetails.TabIndex = 16;
            this.gbPersonalDetails.TabStop = false;
            this.gbPersonalDetails.Text = "Personal Details";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(83, 37);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(335, 20);
            this.tbFirstName.TabIndex = 9;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(83, 76);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(335, 20);
            this.tbLastName.TabIndex = 10;
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Location = new System.Drawing.Point(17, 40);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(60, 13);
            this.lbFirstName.TabIndex = 4;
            this.lbFirstName.Text = "First Name:";
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Location = new System.Drawing.Point(17, 79);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(61, 13);
            this.lbLastName.TabIndex = 6;
            this.lbLastName.Text = "Last Name:";
            // 
            // UcUpdateNames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPersonalDetails);
            this.Name = "UcUpdateNames";
            this.Size = new System.Drawing.Size(440, 135);
            this.gbPersonalDetails.ResumeLayout(false);
            this.gbPersonalDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPersonalDetails;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.Label lbLastName;
    }
}
