namespace TvForms
{
    partial class ProgressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbPersents = new System.Windows.Forms.Label();
            this.lbIntProgress = new System.Windows.Forms.Label();
            this.pbProgressLine = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 45);
            this.panel1.TabIndex = 0;
            // 
            // lbPersents
            // 
            this.lbPersents.AutoSize = true;
            this.lbPersents.Location = new System.Drawing.Point(207, 30);
            this.lbPersents.Name = "lbPersents";
            this.lbPersents.Size = new System.Drawing.Size(15, 13);
            this.lbPersents.TabIndex = 5;
            this.lbPersents.Text = "%";
            // 
            // lbIntProgress
            // 
            this.lbIntProgress.AutoSize = true;
            this.lbIntProgress.Location = new System.Drawing.Point(142, 30);
            this.lbIntProgress.Name = "lbIntProgress";
            this.lbIntProgress.Size = new System.Drawing.Size(47, 13);
            this.lbIntProgress.TabIndex = 4;
            this.lbIntProgress.Text = "progress";
            // 
            // pbProgressLine
            // 
            this.pbProgressLine.Location = new System.Drawing.Point(4, 4);
            this.pbProgressLine.Name = "pbProgressLine";
            this.pbProgressLine.Size = new System.Drawing.Size(218, 23);
            this.pbProgressLine.TabIndex = 3;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 46);
            this.ControlBox = false;
            this.Controls.Add(this.lbPersents);
            this.Controls.Add(this.lbIntProgress);
            this.Controls.Add(this.pbProgressLine);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(243, 85);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(243, 85);
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress file download";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbPersents;
        private System.Windows.Forms.Label lbIntProgress;
        private System.Windows.Forms.ProgressBar pbProgressLine;
    }
}