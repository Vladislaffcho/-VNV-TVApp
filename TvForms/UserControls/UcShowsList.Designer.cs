namespace TvForms
{
    partial class UcShowsList
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
            this.DateShows = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameShows = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChannelName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvShowPrograms
            // 
            this.lvShowPrograms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.TimeShows,
            this.DateShows,
            this.NameShows,
            this.ChannelName});
            this.lvShowPrograms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvShowPrograms.FullRowSelect = true;
            this.lvShowPrograms.GridLines = true;
            this.lvShowPrograms.Location = new System.Drawing.Point(0, 0);
            this.lvShowPrograms.Name = "lvShowPrograms";
            this.lvShowPrograms.ShowItemToolTips = true;
            this.lvShowPrograms.Size = new System.Drawing.Size(477, 308);
            this.lvShowPrograms.TabIndex = 0;
            this.lvShowPrograms.UseCompatibleStateImageBehavior = false;
            this.lvShowPrograms.View = System.Windows.Forms.View.Details;
            //this.lvShowPrograms.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvShowPrograms_ItemCheck);
            // 
            // Number
            // 
            this.Number.Text = "№";
            this.Number.Width = 57;
            // 
            // TimeShows
            // 
            this.TimeShows.Text = "Time";
            this.TimeShows.Width = 53;
            // 
            // DateShows
            // 
            this.DateShows.Text = "Date";
            this.DateShows.Width = 48;
            // 
            // NameShows
            // 
            this.NameShows.Text = "Name";
            this.NameShows.Width = 197;
            // 
            // ChannelName
            // 
            this.ChannelName.Text = "Channel";
            this.ChannelName.Width = 96;
            // 
            // UcShowsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvShowPrograms);
            this.Name = "UcShowsList";
            this.Size = new System.Drawing.Size(477, 308);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvShowPrograms;
        private System.Windows.Forms.ColumnHeader TimeShows;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader NameShows;
        private System.Windows.Forms.ColumnHeader DateShows;
        private System.Windows.Forms.ColumnHeader ChannelName;
    }
}
