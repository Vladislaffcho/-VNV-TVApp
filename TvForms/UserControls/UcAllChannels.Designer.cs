using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    
    partial class UcAllChannels
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.tabControl_Shows = new System.Windows.Forms.TabControl();
            this.tabShows_Sunday = new System.Windows.Forms.TabPage();
            this.tabShows_Monday = new System.Windows.Forms.TabPage();
            this.tabShows_Tuesday = new System.Windows.Forms.TabPage();
            this.tabShows_Wednesday = new System.Windows.Forms.TabPage();
            this.tabShows_Thursday = new System.Windows.Forms.TabPage();
            this.tabShows_Friday = new System.Windows.Forms.TabPage();
            this.tabShows_Saturday = new System.Windows.Forms.TabPage();
            this.gbAllCh_Description = new System.Windows.Forms.GroupBox();
            this.rtbAllCh_Description = new System.Windows.Forms.RichTextBox();
            this.gbUcAllChannel = new System.Windows.Forms.GroupBox();
            this.cbCheckAll = new System.Windows.Forms.CheckBox();
            this.cbMyChosenShows = new System.Windows.Forms.CheckBox();
            this.lvChannelsList = new System.Windows.Forms.ListView();
            this.lvChNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvChName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPriceChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvIsAdultChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl_Shows.SuspendLayout();
            this.gbAllCh_Description.SuspendLayout();
            this.gbUcAllChannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_Shows
            // 
            this.tabControl_Shows.Controls.Add(this.tabShows_Sunday);
            this.tabControl_Shows.Controls.Add(this.tabShows_Monday);
            this.tabControl_Shows.Controls.Add(this.tabShows_Tuesday);
            this.tabControl_Shows.Controls.Add(this.tabShows_Wednesday);
            this.tabControl_Shows.Controls.Add(this.tabShows_Thursday);
            this.tabControl_Shows.Controls.Add(this.tabShows_Friday);
            this.tabControl_Shows.Controls.Add(this.tabShows_Saturday);
            this.tabControl_Shows.Location = new System.Drawing.Point(350, 14);
            this.tabControl_Shows.Name = "tabControl_Shows";
            this.tabControl_Shows.SelectedIndex = 0;
            this.tabControl_Shows.Size = new System.Drawing.Size(485, 334);
            this.tabControl_Shows.TabIndex = 2;
            //this.tabControl_Shows.SelectedIndexChanged += new System.EventHandler(this.tabControl_Shows_SelectedIndexChanged);
            // 
            // tabShows_Sunday
            // 
            this.tabShows_Sunday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Sunday.Name = "tabShows_Sunday";
            this.tabShows_Sunday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Sunday.Size = new System.Drawing.Size(477, 308);
            this.tabShows_Sunday.TabIndex = 8;
            this.tabShows_Sunday.Text = "Sunday";
            this.tabShows_Sunday.UseVisualStyleBackColor = true;
            // 
            // tabShows_Monday
            // 
            this.tabShows_Monday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Monday.Name = "tabShows_Monday";
            this.tabShows_Monday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Monday.Size = new System.Drawing.Size(477, 308);
            this.tabShows_Monday.TabIndex = 1;
            this.tabShows_Monday.Text = "Monday";
            this.tabShows_Monday.UseVisualStyleBackColor = true;
            // 
            // tabShows_Tuesday
            // 
            this.tabShows_Tuesday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Tuesday.Name = "tabShows_Tuesday";
            this.tabShows_Tuesday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Tuesday.Size = new System.Drawing.Size(477, 308);
            this.tabShows_Tuesday.TabIndex = 7;
            this.tabShows_Tuesday.Text = "Tuesday";
            this.tabShows_Tuesday.UseVisualStyleBackColor = true;
            // 
            // tabShows_Wednesday
            // 
            this.tabShows_Wednesday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Wednesday.Name = "tabShows_Wednesday";
            this.tabShows_Wednesday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Wednesday.Size = new System.Drawing.Size(477, 308);
            this.tabShows_Wednesday.TabIndex = 3;
            this.tabShows_Wednesday.Text = "Wednesday";
            this.tabShows_Wednesday.UseVisualStyleBackColor = true;
            // 
            // tabShows_Thursday
            // 
            this.tabShows_Thursday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Thursday.Name = "tabShows_Thursday";
            this.tabShows_Thursday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Thursday.Size = new System.Drawing.Size(477, 308);
            this.tabShows_Thursday.TabIndex = 4;
            this.tabShows_Thursday.Text = "Thursday";
            this.tabShows_Thursday.UseVisualStyleBackColor = true;
            // 
            // tabShows_Friday
            // 
            this.tabShows_Friday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Friday.Name = "tabShows_Friday";
            this.tabShows_Friday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Friday.Size = new System.Drawing.Size(477, 308);
            this.tabShows_Friday.TabIndex = 5;
            this.tabShows_Friday.Text = "Friday";
            this.tabShows_Friday.UseVisualStyleBackColor = true;
            // 
            // tabShows_Saturday
            // 
            this.tabShows_Saturday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Saturday.Name = "tabShows_Saturday";
            this.tabShows_Saturday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Saturday.Size = new System.Drawing.Size(477, 308);
            this.tabShows_Saturday.TabIndex = 6;
            this.tabShows_Saturday.Text = "Saturday";
            this.tabShows_Saturday.UseVisualStyleBackColor = true;
            // 
            // gbAllCh_Description
            // 
            this.gbAllCh_Description.Controls.Add(this.rtbAllCh_Description);
            this.gbAllCh_Description.Location = new System.Drawing.Point(350, 373);
            this.gbAllCh_Description.Name = "gbAllCh_Description";
            this.gbAllCh_Description.Size = new System.Drawing.Size(485, 50);
            this.gbAllCh_Description.TabIndex = 8;
            this.gbAllCh_Description.TabStop = false;
            this.gbAllCh_Description.Text = "Show description";
            // 
            // rtbAllCh_Description
            // 
            this.rtbAllCh_Description.Enabled = false;
            this.rtbAllCh_Description.Location = new System.Drawing.Point(2, 18);
            this.rtbAllCh_Description.Name = "rtbAllCh_Description";
            this.rtbAllCh_Description.Size = new System.Drawing.Size(487, 33);
            this.rtbAllCh_Description.TabIndex = 0;
            this.rtbAllCh_Description.Text = "";
            // 
            // gbUcAllChannel
            // 
            this.gbUcAllChannel.Controls.Add(this.cbCheckAll);
            this.gbUcAllChannel.Controls.Add(this.cbMyChosenShows);
            this.gbUcAllChannel.Controls.Add(this.lvChannelsList);
            this.gbUcAllChannel.Controls.Add(this.gbAllCh_Description);
            this.gbUcAllChannel.Controls.Add(this.tabControl_Shows);
            this.gbUcAllChannel.Location = new System.Drawing.Point(3, 0);
            this.gbUcAllChannel.Name = "gbUcAllChannel";
            this.gbUcAllChannel.Size = new System.Drawing.Size(838, 426);
            this.gbUcAllChannel.TabIndex = 0;
            this.gbUcAllChannel.TabStop = false;
            this.gbUcAllChannel.Text = "Channel choose";
            // 
            // cbCheckAll
            // 
            this.cbCheckAll.AutoSize = true;
            this.cbCheckAll.Location = new System.Drawing.Point(674, 354);
            this.cbCheckAll.Name = "cbCheckAll";
            this.cbCheckAll.Size = new System.Drawing.Size(70, 17);
            this.cbCheckAll.TabIndex = 10;
            this.cbCheckAll.Text = "Check all";
            this.cbCheckAll.UseVisualStyleBackColor = true;
            this.cbCheckAll.CheckedChanged += new System.EventHandler(this.cbCheckAll_CheckedChanged);
            // 
            // cbMyChosenShows
            // 
            this.cbMyChosenShows.AutoSize = true;
            this.cbMyChosenShows.Location = new System.Drawing.Point(750, 354);
            this.cbMyChosenShows.Name = "cbMyChosenShows";
            this.cbMyChosenShows.Size = new System.Drawing.Size(85, 17);
            this.cbMyChosenShows.TabIndex = 0;
            this.cbMyChosenShows.Text = "Only chosen";
            this.cbMyChosenShows.UseVisualStyleBackColor = true;
            this.cbMyChosenShows.CheckedChanged += new System.EventHandler(this.cbMyChosenShows_CheckedChanged);
            // 
            // lvChannelsList
            // 
            this.lvChannelsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lvChannelsList.CheckBoxes = true;
            this.lvChannelsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvChNumber,
            this.lvChName,
            this.lvPriceChannel,
            this.lvIsAdultChannel});
            this.lvChannelsList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvChannelsList.FullRowSelect = true;
            this.lvChannelsList.GridLines = true;
            this.lvChannelsList.LabelWrap = false;
            this.lvChannelsList.Location = new System.Drawing.Point(3, 16);
            this.lvChannelsList.Name = "lvChannelsList";
            this.lvChannelsList.ShowItemToolTips = true;
            this.lvChannelsList.Size = new System.Drawing.Size(341, 407);
            this.lvChannelsList.TabIndex = 9;
            this.lvChannelsList.UseCompatibleStateImageBehavior = false;
            this.lvChannelsList.View = System.Windows.Forms.View.Details;
            this.lvChannelsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvChannelsList_ItemCheck);
            // 
            // lvChNumber
            // 
            this.lvChNumber.Text = "№";
            this.lvChNumber.Width = 47;
            // 
            // lvChName
            // 
            this.lvChName.Text = "Channel";
            this.lvChName.Width = 166;
            // 
            // lvPriceChannel
            // 
            this.lvPriceChannel.Text = "Price";
            this.lvPriceChannel.Width = 64;
            // 
            // lvIsAdultChannel
            // 
            this.lvIsAdultChannel.Text = "Adult";
            this.lvIsAdultChannel.Width = 37;
            // 
            // UcAllChannels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.gbUcAllChannel);
            this.Name = "UcAllChannels";
            this.Size = new System.Drawing.Size(844, 429);
            this.tabControl_Shows.ResumeLayout(false);
            this.gbAllCh_Description.ResumeLayout(false);
            this.gbUcAllChannel.ResumeLayout(false);
            this.gbUcAllChannel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabControl_Shows;
        private TabPage tabShows_Monday;
        private TabPage tabShows_Wednesday;
        private TabPage tabShows_Thursday;
        private TabPage tabShows_Friday;
        private TabPage tabShows_Saturday;
        private GroupBox gbAllCh_Description;
        private RichTextBox rtbAllCh_Description;
        private GroupBox gbUcAllChannel;
        private ListView lvChannelsList;
        private ColumnHeader lvChNumber;
        private ColumnHeader lvChName;
        private TabPage tabShows_Tuesday;
        private TabPage tabShows_Sunday;
        private ColumnHeader lvPriceChannel;
        private ColumnHeader lvIsAdultChannel;
        private CheckBox cbMyChosenShows;
        private CheckBox cbCheckAll;
    }
}
