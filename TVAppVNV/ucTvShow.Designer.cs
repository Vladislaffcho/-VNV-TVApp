namespace TVAppVNV
{
    partial class ucTvShow
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
            this.gbTvShow = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // gbTvShow
            // 
            this.gbTvShow.Location = new System.Drawing.Point(3, 3);
            this.gbTvShow.Name = "gbTvShow";
            this.gbTvShow.Size = new System.Drawing.Size(550, 300);
            this.gbTvShow.TabIndex = 0;
            this.gbTvShow.TabStop = false;
            this.gbTvShow.Text = "TV Show choose";
            // 
            // ucTvShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTvShow);
            this.Name = "ucTvShow";
            this.Size = new System.Drawing.Size(560, 310);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTvShow;
    }
}
