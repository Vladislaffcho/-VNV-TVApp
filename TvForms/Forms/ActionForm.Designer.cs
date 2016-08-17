namespace TvForms
{
    partial class ActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionForm));
            this.panActionForm = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panActionForm
            // 
            this.panActionForm.Location = new System.Drawing.Point(0, 0);
            this.panActionForm.Name = "panActionForm";
            this.panActionForm.Size = new System.Drawing.Size(630, 323);
            this.panActionForm.TabIndex = 0;
            // 
            // ActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 323);
            this.Controls.Add(this.panActionForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User actions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panActionForm;
    }
}