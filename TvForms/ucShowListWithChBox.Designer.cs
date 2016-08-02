namespace TvForms
{
    partial class ucShowListWithChBox
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
            this.checkLb_Shows = new System.Windows.Forms.CheckedListBox();
            this.lbTimeUcShowWithCheck = new System.Windows.Forms.Label();
            this.lbProgUcShowWithCheck = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkLb_Shows
            // 
            this.checkLb_Shows.FormattingEnabled = true;
            this.checkLb_Shows.Location = new System.Drawing.Point(0, 19);
            this.checkLb_Shows.Name = "checkLb_Shows";
            this.checkLb_Shows.Size = new System.Drawing.Size(406, 169);
            this.checkLb_Shows.TabIndex = 0;
            // 
            // lbTimeUcShowWithCheck
            // 
            this.lbTimeUcShowWithCheck.AutoSize = true;
            this.lbTimeUcShowWithCheck.Location = new System.Drawing.Point(18, 4);
            this.lbTimeUcShowWithCheck.Name = "lbTimeUcShowWithCheck";
            this.lbTimeUcShowWithCheck.Size = new System.Drawing.Size(30, 13);
            this.lbTimeUcShowWithCheck.TabIndex = 1;
            this.lbTimeUcShowWithCheck.Text = "Time";
            // 
            // lbProgUcShowWithCheck
            // 
            this.lbProgUcShowWithCheck.AutoSize = true;
            this.lbProgUcShowWithCheck.Location = new System.Drawing.Point(56, 4);
            this.lbProgUcShowWithCheck.Name = "lbProgUcShowWithCheck";
            this.lbProgUcShowWithCheck.Size = new System.Drawing.Size(46, 13);
            this.lbProgUcShowWithCheck.TabIndex = 2;
            this.lbProgUcShowWithCheck.Text = "Program";
            // 
            // ucShowListWithChBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbProgUcShowWithCheck);
            this.Controls.Add(this.lbTimeUcShowWithCheck);
            this.Controls.Add(this.checkLb_Shows);
            this.Name = "ucShowListWithChBox";
            this.Size = new System.Drawing.Size(406, 188);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkLb_Shows;
        private System.Windows.Forms.Label lbTimeUcShowWithCheck;
        private System.Windows.Forms.Label lbProgUcShowWithCheck;
    }
}
