namespace TVAppVNV
{
    partial class CoreForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoreForm));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveYourListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bSaveCore = new System.Windows.Forms.Button();
            this.bCancelCore = new System.Windows.Forms.Button();
            this.scCore = new System.Windows.Forms.SplitContainer();
            this.lvListChanel = new System.Windows.Forms.ListView();
            this.chNumColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbDaysWeek = new System.Windows.Forms.ComboBox();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tVShowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountRechargeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionalServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scCore)).BeginInit();
            this.scCore.Panel1.SuspendLayout();
            this.scCore.Panel2.SuspendLayout();
            this.scCore.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.userListToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(666, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "MainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInToolStripMenuItem,
            this.changeScheduleToolStripMenuItem,
            this.saveYourListToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // changeScheduleToolStripMenuItem
            // 
            this.changeScheduleToolStripMenuItem.Name = "changeScheduleToolStripMenuItem";
            this.changeScheduleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.changeScheduleToolStripMenuItem.Text = "Open xml File";
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.logInToolStripMenuItem.Text = "Log In";
            // 
            // saveYourListToolStripMenuItem
            // 
            this.saveYourListToolStripMenuItem.Name = "saveYourListToolStripMenuItem";
            this.saveYourListToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveYourListToolStripMenuItem.Text = "Open saved schedule";
            this.saveYourListToolStripMenuItem.Click += new System.EventHandler(this.saveYourListToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // userListToolStripMenuItem
            // 
            this.userListToolStripMenuItem.Name = "userListToolStripMenuItem";
            this.userListToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.userListToolStripMenuItem.Text = "User List";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // bSaveCore
            // 
            this.bSaveCore.Location = new System.Drawing.Point(498, 386);
            this.bSaveCore.Name = "bSaveCore";
            this.bSaveCore.Size = new System.Drawing.Size(75, 23);
            this.bSaveCore.TabIndex = 1;
            this.bSaveCore.Text = "Save";
            this.bSaveCore.UseVisualStyleBackColor = true;
            // 
            // bCancelCore
            // 
            this.bCancelCore.Location = new System.Drawing.Point(579, 386);
            this.bCancelCore.Name = "bCancelCore";
            this.bCancelCore.Size = new System.Drawing.Size(75, 23);
            this.bCancelCore.TabIndex = 2;
            this.bCancelCore.Text = "Cancel";
            this.bCancelCore.UseVisualStyleBackColor = true;
            this.bCancelCore.Click += new System.EventHandler(this.bCancelCore_Click);
            // 
            // scCore
            // 
            this.scCore.Dock = System.Windows.Forms.DockStyle.Top;
            this.scCore.Location = new System.Drawing.Point(0, 24);
            this.scCore.Name = "scCore";
            // 
            // scCore.Panel1
            // 
            this.scCore.Panel1.Controls.Add(this.lvListChanel);
            // 
            // scCore.Panel2
            // 
            this.scCore.Panel2.Controls.Add(this.cbDaysWeek);
            this.scCore.Size = new System.Drawing.Size(666, 340);
            this.scCore.SplitterDistance = 184;
            this.scCore.TabIndex = 5;
            // 
            // lvListChanel
            // 
            this.lvListChanel.BackColor = System.Drawing.SystemColors.Window;
            this.lvListChanel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNumColumn,
            this.chNameColumn});
            this.lvListChanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvListChanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvListChanel.FullRowSelect = true;
            this.lvListChanel.GridLines = true;
            this.lvListChanel.Location = new System.Drawing.Point(0, 0);
            this.lvListChanel.Name = "lvListChanel";
            this.lvListChanel.Size = new System.Drawing.Size(184, 340);
            this.lvListChanel.TabIndex = 0;
            this.lvListChanel.UseCompatibleStateImageBehavior = false;
            this.lvListChanel.View = System.Windows.Forms.View.Details;
            // 
            // chNumColumn
            // 
            this.chNumColumn.Text = "Number";
            this.chNumColumn.Width = 52;
            // 
            // chNameColumn
            // 
            this.chNameColumn.Text = "Chanel Name";
            this.chNameColumn.Width = 125;
            // 
            // cbDaysWeek
            // 
            this.cbDaysWeek.FormattingEnabled = true;
            this.cbDaysWeek.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.cbDaysWeek.Location = new System.Drawing.Point(2, 0);
            this.cbDaysWeek.Name = "cbDaysWeek";
            this.cbDaysWeek.Size = new System.Drawing.Size(121, 21);
            this.cbDaysWeek.TabIndex = 0;
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleToolStripMenuItem,
            this.tVShowsToolStripMenuItem,
            this.channelsToolStripMenuItem,
            this.additionalServiceToolStripMenuItem,
            this.ordersToolStripMenuItem,
            this.accountRechargeToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.scheduleToolStripMenuItem.Text = "Schedules";
            // 
            // tVShowsToolStripMenuItem
            // 
            this.tVShowsToolStripMenuItem.Name = "tVShowsToolStripMenuItem";
            this.tVShowsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.tVShowsToolStripMenuItem.Text = "TV Shows";
            // 
            // channelsToolStripMenuItem
            // 
            this.channelsToolStripMenuItem.Name = "channelsToolStripMenuItem";
            this.channelsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.channelsToolStripMenuItem.Text = "Channels";
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ordersToolStripMenuItem.Text = "Orders";
            // 
            // accountRechargeToolStripMenuItem
            // 
            this.accountRechargeToolStripMenuItem.Name = "accountRechargeToolStripMenuItem";
            this.accountRechargeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.accountRechargeToolStripMenuItem.Text = "Account Recharge";
            // 
            // additionalServiceToolStripMenuItem
            // 
            this.additionalServiceToolStripMenuItem.Name = "additionalServiceToolStripMenuItem";
            this.additionalServiceToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.additionalServiceToolStripMenuItem.Text = "Additional service";
            // 
            // CoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 421);
            this.Controls.Add(this.bCancelCore);
            this.Controls.Add(this.bSaveCore);
            this.Controls.Add(this.scCore);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "CoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VNV TV Shedule";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.scCore.Panel1.ResumeLayout(false);
            this.scCore.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scCore)).EndInit();
            this.scCore.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveYourListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button bSaveCore;
        private System.Windows.Forms.Button bCancelCore;
        private System.Windows.Forms.SplitContainer scCore;
        private System.Windows.Forms.ListView lvListChanel;
        private System.Windows.Forms.ColumnHeader chNumColumn;
        private System.Windows.Forms.ColumnHeader chNameColumn;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userListToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbDaysWeek;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tVShowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem additionalServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountRechargeToolStripMenuItem;
    }
}

