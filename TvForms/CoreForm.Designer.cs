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
            this.bSaveCore = new System.Windows.Forms.Button();
            this.bCancelCore = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSavedScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionalServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountRechargeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.panelCore = new System.Windows.Forms.Panel();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
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
            this.bCancelCore.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelCore.Location = new System.Drawing.Point(579, 386);
            this.bCancelCore.Name = "bCancelCore";
            this.bCancelCore.Size = new System.Drawing.Size(75, 23);
            this.bCancelCore.TabIndex = 2;
            this.bCancelCore.Text = "Cancel";
            this.bCancelCore.UseVisualStyleBackColor = true;
            this.bCancelCore.Click += new System.EventHandler(this.bCancelCore_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openXmlToolStripMenuItem,
            this.openSavedScheduleToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openXmlToolStripMenuItem
            // 
            this.openXmlToolStripMenuItem.Name = "openXmlToolStripMenuItem";
            this.openXmlToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openXmlToolStripMenuItem.Text = "Open xml File";
            this.openXmlToolStripMenuItem.Click += new System.EventHandler(this.openXmlToolStripMenuItem_Click);
            // 
            // openSavedScheduleToolStripMenuItem
            // 
            this.openSavedScheduleToolStripMenuItem.Name = "openSavedScheduleToolStripMenuItem";
            this.openSavedScheduleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openSavedScheduleToolStripMenuItem.Text = "Open saved schedule";
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
            // panelCore
            // 
            this.panelCore.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCore.Location = new System.Drawing.Point(0, 24);
            this.panelCore.Name = "panelCore";
            this.panelCore.Size = new System.Drawing.Size(666, 352);
            this.panelCore.TabIndex = 3;
            // 
            // CoreForm
            // 
            this.AcceptButton = this.bSaveCore;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancelCore;
            this.ClientSize = new System.Drawing.Size(666, 421);
            this.Controls.Add(this.panelCore);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bSaveCore;
        private System.Windows.Forms.Button bCancelCore;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openXmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSavedScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem additionalServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountRechargeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.Panel panelCore;
    }
}

