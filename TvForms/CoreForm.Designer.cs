namespace TvForms
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
            this.saveYourListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionalServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountRechargeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bSaveCore = new System.Windows.Forms.Button();
            this.bCancelCore = new System.Windows.Forms.Button();
            this.tabCore = new System.Windows.Forms.TabControl();
            this.tabCoreAllCh = new System.Windows.Forms.TabPage();
            this.tabCoreMyCh = new System.Windows.Forms.TabPage();
            this.tabCoreTvShow = new System.Windows.Forms.TabPage();
            this.msMain.SuspendLayout();
            this.tabCore.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem,
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
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.additionalServiceToolStripMenuItem,
            this.ordersToolStripMenuItem,
            this.accountRechargeToolStripMenuItem,
            this.profileToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.actionsToolStripMenuItem.Text = "User actions";
            // 
            // additionalServiceToolStripMenuItem
            // 
            this.additionalServiceToolStripMenuItem.Name = "additionalServiceToolStripMenuItem";
            this.additionalServiceToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.additionalServiceToolStripMenuItem.Text = "Additional service";
            this.additionalServiceToolStripMenuItem.Click += new System.EventHandler(this.additionalServiceToolStripMenuItem_Click);
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ordersToolStripMenuItem.Text = "Orders history";
            // 
            // accountRechargeToolStripMenuItem
            // 
            this.accountRechargeToolStripMenuItem.Name = "accountRechargeToolStripMenuItem";
            this.accountRechargeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.accountRechargeToolStripMenuItem.Text = "Account Recharge";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.profileToolStripMenuItem.Text = "Profile";
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
            this.bSaveCore.Click += new System.EventHandler(this.bSaveCore_Click);
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
            // tabCore
            // 
            this.tabCore.Controls.Add(this.tabCoreAllCh);
            this.tabCore.Controls.Add(this.tabCoreMyCh);
            this.tabCore.Controls.Add(this.tabCoreTvShow);
            this.tabCore.Location = new System.Drawing.Point(12, 27);
            this.tabCore.Multiline = true;
            this.tabCore.Name = "tabCore";
            this.tabCore.SelectedIndex = 0;
            this.tabCore.Size = new System.Drawing.Size(642, 353);
            this.tabCore.TabIndex = 3;
            this.tabCore.Tag = "";
            // 
            // tabCoreAllCh
            // 
            this.tabCoreAllCh.BackColor = System.Drawing.Color.Khaki;
            this.tabCoreAllCh.Location = new System.Drawing.Point(4, 22);
            this.tabCoreAllCh.Name = "tabCoreAllCh";
            this.tabCoreAllCh.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoreAllCh.Size = new System.Drawing.Size(634, 327);
            this.tabCoreAllCh.TabIndex = 0;
            this.tabCoreAllCh.Text = "All Channels";
            // 
            // tabCoreMyCh
            // 
            this.tabCoreMyCh.BackColor = System.Drawing.Color.MistyRose;
            this.tabCoreMyCh.Location = new System.Drawing.Point(4, 22);
            this.tabCoreMyCh.Name = "tabCoreMyCh";
            this.tabCoreMyCh.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoreMyCh.Size = new System.Drawing.Size(634, 327);
            this.tabCoreMyCh.TabIndex = 1;
            this.tabCoreMyCh.Text = "My Channels";
            // 
            // tabCoreTvShow
            // 
            this.tabCoreTvShow.BackColor = System.Drawing.Color.PowderBlue;
            this.tabCoreTvShow.Location = new System.Drawing.Point(4, 22);
            this.tabCoreTvShow.Name = "tabCoreTvShow";
            this.tabCoreTvShow.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoreTvShow.Size = new System.Drawing.Size(634, 327);
            this.tabCoreTvShow.TabIndex = 2;
            this.tabCoreTvShow.Text = "My TV Show";
            
            // 
            // CoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 421);
            this.Controls.Add(this.tabCore);
            this.Controls.Add(this.bCancelCore);
            this.Controls.Add(this.bSaveCore);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "CoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VNV TV Shedule";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tabCore.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem additionalServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountRechargeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.TabControl tabCore;
        private System.Windows.Forms.TabPage tabCoreAllCh;
        private System.Windows.Forms.TabPage tabCoreMyCh;
        private System.Windows.Forms.TabPage tabCoreTvShow;
    }
}

