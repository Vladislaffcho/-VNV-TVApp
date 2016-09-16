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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSavedScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFavouriteToXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionalServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountRechargeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.panelCore = new System.Windows.Forms.Panel();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromXmlToolStripMenuItem,
            this.openSavedScheduleToolStripMenuItem,
            this.saveFavouriteToXmlToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadFromXmlToolStripMenuItem
            // 
            this.loadFromXmlToolStripMenuItem.Name = "loadFromXmlToolStripMenuItem";
            this.loadFromXmlToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.loadFromXmlToolStripMenuItem.Text = "Load channels from xml";
            this.loadFromXmlToolStripMenuItem.Click += new System.EventHandler(this.openXmlToolStripMenuItem_Click);
            // 
            // openSavedScheduleToolStripMenuItem
            // 
            this.openSavedScheduleToolStripMenuItem.Name = "openSavedScheduleToolStripMenuItem";
            this.openSavedScheduleToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openSavedScheduleToolStripMenuItem.Text = "Open saved schedule";
            this.openSavedScheduleToolStripMenuItem.Click += new System.EventHandler(this.openSavedScheduleToolStripMenuItem_Click);
            // 
            // saveFavouriteToXmlToolStripMenuItem
            // 
            this.saveFavouriteToXmlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xmlToolStripMenuItem,
            this.zipToolStripMenuItem});
            this.saveFavouriteToXmlToolStripMenuItem.Name = "saveFavouriteToXmlToolStripMenuItem";
            this.saveFavouriteToXmlToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveFavouriteToXmlToolStripMenuItem.Text = "Save favourite to...";
            // 
            // xmlToolStripMenuItem
            // 
            this.xmlToolStripMenuItem.Name = "xmlToolStripMenuItem";
            this.xmlToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.xmlToolStripMenuItem.Text = "*.xml";
            this.xmlToolStripMenuItem.Click += new System.EventHandler(this.xmlToolStripMenuItem_Click);
            // 
            // zipToolStripMenuItem
            // 
            this.zipToolStripMenuItem.Name = "zipToolStripMenuItem";
            this.zipToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.zipToolStripMenuItem.Text = "*.zip";
            this.zipToolStripMenuItem.Click += new System.EventHandler(this.zipToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.additionalServiceToolStripMenuItem,
            this.ordersToolStripMenuItem,
            this.accountRechargeToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.paymentsToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.actionsToolStripMenuItem.Text = "User actions";
            // 
            // additionalServiceToolStripMenuItem
            // 
            this.additionalServiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addServiceToolStripMenuItem,
            this.removeServicesToolStripMenuItem});
            this.additionalServiceToolStripMenuItem.Name = "additionalServiceToolStripMenuItem";
            this.additionalServiceToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.additionalServiceToolStripMenuItem.Text = "Additional service";
            this.additionalServiceToolStripMenuItem.Click += new System.EventHandler(this.additionalServiceToolStripMenuItem_Click);
            // 
            // addServiceToolStripMenuItem
            // 
            this.addServiceToolStripMenuItem.Name = "addServiceToolStripMenuItem";
            this.addServiceToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.addServiceToolStripMenuItem.Text = "Add Service";
            this.addServiceToolStripMenuItem.Click += new System.EventHandler(this.addServiceToolStripMenuItem_Click);
            // 
            // removeServicesToolStripMenuItem
            // 
            this.removeServicesToolStripMenuItem.Name = "removeServicesToolStripMenuItem";
            this.removeServicesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.removeServicesToolStripMenuItem.Text = "Remove Service";
            this.removeServicesToolStripMenuItem.Click += new System.EventHandler(this.removeServicesToolStripMenuItem_Click);
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ordersToolStripMenuItem.Text = "Orders history";
            this.ordersToolStripMenuItem.Click += new System.EventHandler(this.ordersToolStripMenuItem_Click);
            // 
            // accountRechargeToolStripMenuItem
            // 
            this.accountRechargeToolStripMenuItem.Name = "accountRechargeToolStripMenuItem";
            this.accountRechargeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.accountRechargeToolStripMenuItem.Text = "Account Recharge";
            this.accountRechargeToolStripMenuItem.Click += new System.EventHandler(this.accountRechargeToolStripMenuItem_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.profileToolStripMenuItem.Text = "Profile";
            this.profileToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click);
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.paymentsToolStripMenuItem.Text = "Payments";
            this.paymentsToolStripMenuItem.Click += new System.EventHandler(this.paymentsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(784, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "MainMenu";
            // 
            // panelCore
            // 
            this.panelCore.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelCore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCore.Location = new System.Drawing.Point(0, 24);
            this.panelCore.Name = "panelCore";
            this.panelCore.Size = new System.Drawing.Size(784, 437);
            this.panelCore.TabIndex = 3;
            // 
            // CoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panelCore);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VNV TV application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CoreForm_FormClosing);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromXmlToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFavouriteToXmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeServicesToolStripMenuItem;
    }
}

