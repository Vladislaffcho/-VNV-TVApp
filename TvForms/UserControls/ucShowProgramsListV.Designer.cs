namespace TvForms
{
    partial class ucShowProgramsListV
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
            this.lvShowPrograms = new System.Windows.Forms.ListView();
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeShows = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameShows = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvShowPrograms
            // 
            this.lvShowPrograms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.TimeShows,
            this.NameShows});
            this.lvShowPrograms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShowPrograms.FullRowSelect = true;
            this.lvShowPrograms.GridLines = true;
            this.lvShowPrograms.Location = new System.Drawing.Point(0, 0);
            this.lvShowPrograms.Name = "lvShowPrograms";
            this.lvShowPrograms.Size = new System.Drawing.Size(406, 188);
            this.lvShowPrograms.TabIndex = 0;
            this.lvShowPrograms.UseCompatibleStateImageBehavior = false;
            this.lvShowPrograms.View = System.Windows.Forms.View.Details;
            
            // 
            // Number
            // 
            this.Number.Text = "№";
            this.Number.Width = 46;
            // 
            // TimeShows
            // 
            this.TimeShows.Text = "Time";
            // 
            // NameShows
            // 
            this.NameShows.Text = "Name";
            this.NameShows.Width = 290;
            // 
            // ucShowProgramsListV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvShowPrograms);
            this.Name = "ucShowProgramsListV";
            this.Size = new System.Drawing.Size(406, 188);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvShowPrograms;
        private System.Windows.Forms.ColumnHeader TimeShows;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader NameShows;
    }
}
