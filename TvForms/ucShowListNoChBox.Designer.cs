namespace TvForms
{
    partial class ucShowListNoChBox
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
            this.lv_ShowNoChBox = new System.Windows.Forms.ListView();
            this.TimeShow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameShow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lv_ShowNoChBox
            // 
            this.lv_ShowNoChBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TimeShow,
            this.NameShow});
            this.lv_ShowNoChBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_ShowNoChBox.GridLines = true;
            this.lv_ShowNoChBox.Location = new System.Drawing.Point(0, 0);
            this.lv_ShowNoChBox.Name = "lv_ShowNoChBox";
            this.lv_ShowNoChBox.Size = new System.Drawing.Size(406, 188);
            this.lv_ShowNoChBox.TabIndex = 1;
            this.lv_ShowNoChBox.UseCompatibleStateImageBehavior = false;
            this.lv_ShowNoChBox.View = System.Windows.Forms.View.Details;
            // 
            // TimeShow
            // 
            this.TimeShow.Text = "Time";
            // 
            // NameShow
            // 
            this.NameShow.Text = "Name";
            this.NameShow.Width = 335;
            // 
            // ucShowListNoChBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lv_ShowNoChBox);
            this.Name = "ucShowListNoChBox";
            this.Size = new System.Drawing.Size(406, 188);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_ShowNoChBox;
        private System.Windows.Forms.ColumnHeader TimeShow;
        private System.Windows.Forms.ColumnHeader NameShow;
    }
}
