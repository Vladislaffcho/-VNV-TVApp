namespace TvForms
{
    
    partial class ucAllChannels
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
            this.gbUcAllChannel = new System.Windows.Forms.GroupBox();
            this.gbAllCh_Description = new System.Windows.Forms.GroupBox();
            this.rtbAllCh_Description = new System.Windows.Forms.RichTextBox();
            this.tbAllCh_Adult = new System.Windows.Forms.TextBox();
            this.lbAllCh_Adult = new System.Windows.Forms.Label();
            this.lbAllCh_UAH = new System.Windows.Forms.Label();
            this.maskTbAllCh_Price = new System.Windows.Forms.MaskedTextBox();
            this.lbAllCh_Price = new System.Windows.Forms.Label();
            this.tabAllCh_Shows = new System.Windows.Forms.TabControl();
            this.tabAllCh_Monday = new System.Windows.Forms.TabPage();
            this.tabAllCh_Tuesday = new System.Windows.Forms.TabPage();
            this.tabAllCh_Wednesday = new System.Windows.Forms.TabPage();
            this.tabAllCh_Thursday = new System.Windows.Forms.TabPage();
            this.tabAllCh_Friday = new System.Windows.Forms.TabPage();
            this.tabAllCh_Saturday = new System.Windows.Forms.TabPage();
            this.tabAllCh_Sunday = new System.Windows.Forms.TabPage();
            this.chBxAllChannel = new System.Windows.Forms.CheckedListBox();
            this.gbUcAllChannel.SuspendLayout();
            this.gbAllCh_Description.SuspendLayout();
            this.tabAllCh_Shows.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUcAllChannel
            // 
            this.gbUcAllChannel.Controls.Add(this.gbAllCh_Description);
            this.gbUcAllChannel.Controls.Add(this.tbAllCh_Adult);
            this.gbUcAllChannel.Controls.Add(this.lbAllCh_Adult);
            this.gbUcAllChannel.Controls.Add(this.lbAllCh_UAH);
            this.gbUcAllChannel.Controls.Add(this.maskTbAllCh_Price);
            this.gbUcAllChannel.Controls.Add(this.lbAllCh_Price);
            this.gbUcAllChannel.Controls.Add(this.tabAllCh_Shows);
            this.gbUcAllChannel.Controls.Add(this.chBxAllChannel);
            this.gbUcAllChannel.Location = new System.Drawing.Point(0, 0);
            this.gbUcAllChannel.Name = "gbUcAllChannel";
            this.gbUcAllChannel.Size = new System.Drawing.Size(631, 324);
            this.gbUcAllChannel.TabIndex = 0;
            this.gbUcAllChannel.TabStop = false;
            this.gbUcAllChannel.Text = "Channel choose";
            // 
            // gbAllCh_Description
            // 
            this.gbAllCh_Description.Controls.Add(this.rtbAllCh_Description);
            this.gbAllCh_Description.Location = new System.Drawing.Point(217, 253);
            this.gbAllCh_Description.Name = "gbAllCh_Description";
            this.gbAllCh_Description.Size = new System.Drawing.Size(414, 65);
            this.gbAllCh_Description.TabIndex = 8;
            this.gbAllCh_Description.TabStop = false;
            this.gbAllCh_Description.Text = "Channel description";
            // 
            // rtbAllCh_Description
            // 
            this.rtbAllCh_Description.Enabled = false;
            this.rtbAllCh_Description.Location = new System.Drawing.Point(0, 19);
            this.rtbAllCh_Description.Name = "rtbAllCh_Description";
            this.rtbAllCh_Description.Size = new System.Drawing.Size(414, 46);
            this.rtbAllCh_Description.TabIndex = 0;
            this.rtbAllCh_Description.Text = "";
            // 
            // tbAllCh_Adult
            // 
            this.tbAllCh_Adult.Enabled = false;
            this.tbAllCh_Adult.Location = new System.Drawing.Point(518, 227);
            this.tbAllCh_Adult.Name = "tbAllCh_Adult";
            this.tbAllCh_Adult.Size = new System.Drawing.Size(61, 20);
            this.tbAllCh_Adult.TabIndex = 7;
            // 
            // lbAllCh_Adult
            // 
            this.lbAllCh_Adult.AutoSize = true;
            this.lbAllCh_Adult.Location = new System.Drawing.Point(432, 231);
            this.lbAllCh_Adult.Name = "lbAllCh_Adult";
            this.lbAllCh_Adult.Size = new System.Drawing.Size(70, 13);
            this.lbAllCh_Adult.TabIndex = 6;
            this.lbAllCh_Adult.Text = "Adult content";
            // 
            // lbAllCh_UAH
            // 
            this.lbAllCh_UAH.AutoSize = true;
            this.lbAllCh_UAH.Location = new System.Drawing.Point(384, 231);
            this.lbAllCh_UAH.Name = "lbAllCh_UAH";
            this.lbAllCh_UAH.Size = new System.Drawing.Size(30, 13);
            this.lbAllCh_UAH.TabIndex = 5;
            this.lbAllCh_UAH.Text = "UAH";
            // 
            // maskTbAllCh_Price
            // 
            this.maskTbAllCh_Price.Enabled = false;
            this.maskTbAllCh_Price.Location = new System.Drawing.Point(303, 227);
            this.maskTbAllCh_Price.Name = "maskTbAllCh_Price";
            this.maskTbAllCh_Price.Size = new System.Drawing.Size(75, 20);
            this.maskTbAllCh_Price.TabIndex = 4;
            // 
            // lbAllCh_Price
            // 
            this.lbAllCh_Price.AutoSize = true;
            this.lbAllCh_Price.Location = new System.Drawing.Point(224, 231);
            this.lbAllCh_Price.Name = "lbAllCh_Price";
            this.lbAllCh_Price.Size = new System.Drawing.Size(72, 13);
            this.lbAllCh_Price.TabIndex = 3;
            this.lbAllCh_Price.Text = "Channel price";
            // 
            // tabAllCh_Shows
            // 
            this.tabAllCh_Shows.Controls.Add(this.tabAllCh_Monday);
            this.tabAllCh_Shows.Controls.Add(this.tabAllCh_Tuesday);
            this.tabAllCh_Shows.Controls.Add(this.tabAllCh_Wednesday);
            this.tabAllCh_Shows.Controls.Add(this.tabAllCh_Thursday);
            this.tabAllCh_Shows.Controls.Add(this.tabAllCh_Friday);
            this.tabAllCh_Shows.Controls.Add(this.tabAllCh_Saturday);
            this.tabAllCh_Shows.Controls.Add(this.tabAllCh_Sunday);
            this.tabAllCh_Shows.Location = new System.Drawing.Point(217, 14);
            this.tabAllCh_Shows.Name = "tabAllCh_Shows";
            this.tabAllCh_Shows.SelectedIndex = 0;
            this.tabAllCh_Shows.Size = new System.Drawing.Size(414, 214);
            this.tabAllCh_Shows.TabIndex = 2;
            // 
            // tabAllCh_Monday
            // 
            this.tabAllCh_Monday.Location = new System.Drawing.Point(4, 22);
            this.tabAllCh_Monday.Name = "tabAllCh_Monday";
            this.tabAllCh_Monday.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllCh_Monday.Size = new System.Drawing.Size(406, 188);
            this.tabAllCh_Monday.TabIndex = 0;
            this.tabAllCh_Monday.Text = "Monday";
            this.tabAllCh_Monday.UseVisualStyleBackColor = true;
            // 
            // tabAllCh_Tuesday
            // 
            this.tabAllCh_Tuesday.Location = new System.Drawing.Point(4, 22);
            this.tabAllCh_Tuesday.Name = "tabAllCh_Tuesday";
            this.tabAllCh_Tuesday.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllCh_Tuesday.Size = new System.Drawing.Size(406, 188);
            this.tabAllCh_Tuesday.TabIndex = 1;
            this.tabAllCh_Tuesday.Text = "Tuesday";
            this.tabAllCh_Tuesday.UseVisualStyleBackColor = true;
            this.tabAllCh_Tuesday.Click += new System.EventHandler(this.tabAllChTuesday_Click);
            // 
            // tabAllCh_Wednesday
            // 
            this.tabAllCh_Wednesday.Location = new System.Drawing.Point(4, 22);
            this.tabAllCh_Wednesday.Name = "tabAllCh_Wednesday";
            this.tabAllCh_Wednesday.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllCh_Wednesday.Size = new System.Drawing.Size(406, 188);
            this.tabAllCh_Wednesday.TabIndex = 2;
            this.tabAllCh_Wednesday.Text = "Wednesday";
            this.tabAllCh_Wednesday.UseVisualStyleBackColor = true;
            
            // 
            // tabAllCh_Thursday
            // 
            this.tabAllCh_Thursday.Location = new System.Drawing.Point(4, 22);
            this.tabAllCh_Thursday.Name = "tabAllCh_Thursday";
            this.tabAllCh_Thursday.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllCh_Thursday.Size = new System.Drawing.Size(406, 188);
            this.tabAllCh_Thursday.TabIndex = 3;
            this.tabAllCh_Thursday.Text = "Thursday";
            this.tabAllCh_Thursday.UseVisualStyleBackColor = true;
            
            // 
            // tabAllCh_Friday
            // 
            this.tabAllCh_Friday.Location = new System.Drawing.Point(4, 22);
            this.tabAllCh_Friday.Name = "tabAllCh_Friday";
            this.tabAllCh_Friday.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllCh_Friday.Size = new System.Drawing.Size(406, 188);
            this.tabAllCh_Friday.TabIndex = 4;
            this.tabAllCh_Friday.Text = "Friday";
            this.tabAllCh_Friday.UseVisualStyleBackColor = true;
            
            // 
            // tabAllCh_Saturday
            // 
            this.tabAllCh_Saturday.Location = new System.Drawing.Point(4, 22);
            this.tabAllCh_Saturday.Name = "tabAllCh_Saturday";
            this.tabAllCh_Saturday.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllCh_Saturday.Size = new System.Drawing.Size(406, 188);
            this.tabAllCh_Saturday.TabIndex = 5;
            this.tabAllCh_Saturday.Text = "Saturday";
            this.tabAllCh_Saturday.UseVisualStyleBackColor = true;
            
            // 
            // tabAllCh_Sunday
            // 
            this.tabAllCh_Sunday.Location = new System.Drawing.Point(4, 22);
            this.tabAllCh_Sunday.Name = "tabAllCh_Sunday";
            this.tabAllCh_Sunday.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllCh_Sunday.Size = new System.Drawing.Size(406, 188);
            this.tabAllCh_Sunday.TabIndex = 6;
            this.tabAllCh_Sunday.Text = "Sunday";
            this.tabAllCh_Sunday.UseVisualStyleBackColor = true;
            
            // 
            // chBxAllChannel
            // 
            this.chBxAllChannel.FormattingEnabled = true;
            this.chBxAllChannel.Items.AddRange(new object[] {
            "1+1",
            "TET",
            "2+2",
            "Inter",
            "ICTV",
            "Noviy",
            "5 Channel",
            "More..."});
            this.chBxAllChannel.Location = new System.Drawing.Point(6, 14);
            this.chBxAllChannel.Name = "chBxAllChannel";
            this.chBxAllChannel.Size = new System.Drawing.Size(205, 304);
            this.chBxAllChannel.TabIndex = 1;
            // 
            // ucAllChannels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbUcAllChannel);
            this.Name = "ucAllChannels";
            this.Size = new System.Drawing.Size(634, 327);
            this.gbUcAllChannel.ResumeLayout(false);
            this.gbUcAllChannel.PerformLayout();
            this.gbAllCh_Description.ResumeLayout(false);
            this.tabAllCh_Shows.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUcAllChannel;
        private System.Windows.Forms.CheckedListBox chBxAllChannel;
        private System.Windows.Forms.TabControl tabAllCh_Shows;
        private System.Windows.Forms.TabPage tabAllCh_Monday;
        private System.Windows.Forms.TabPage tabAllCh_Tuesday;
        private System.Windows.Forms.TabPage tabAllCh_Wednesday;
        private System.Windows.Forms.TabPage tabAllCh_Thursday;
        private System.Windows.Forms.TabPage tabAllCh_Friday;
        private System.Windows.Forms.TabPage tabAllCh_Saturday;
        private System.Windows.Forms.TabPage tabAllCh_Sunday;
        private System.Windows.Forms.Label lbAllCh_UAH;
        private System.Windows.Forms.MaskedTextBox maskTbAllCh_Price;
        private System.Windows.Forms.Label lbAllCh_Price;
        private System.Windows.Forms.GroupBox gbAllCh_Description;
        private System.Windows.Forms.TextBox tbAllCh_Adult;
        private System.Windows.Forms.Label lbAllCh_Adult;
        private System.Windows.Forms.RichTextBox rtbAllCh_Description;
    }
}
