namespace UserControls
{
    partial class UcPayments
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
            this.btOrderView = new System.Windows.Forms.Button();
            this.lbOrder = new System.Windows.Forms.Label();
            this.tbSurnameUser = new System.Windows.Forms.TextBox();
            this.tbNameUser = new System.Windows.Forms.TextBox();
            this.lbSurnameUser = new System.Windows.Forms.Label();
            this.lbNameUser = new System.Windows.Forms.Label();
            this.scPayments = new System.Windows.Forms.SplitContainer();
            this.lvPayments = new System.Windows.Forms.ListView();
            this.paymentId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userLogin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.summ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.orderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbPayments = new System.Windows.Forms.GroupBox();
            this.btChargeAccount = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbBallance = new System.Windows.Forms.Label();
            this.lbUAH = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scPayments)).BeginInit();
            this.scPayments.Panel1.SuspendLayout();
            this.scPayments.Panel2.SuspendLayout();
            this.scPayments.SuspendLayout();
            this.gbPayments.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOrderView
            // 
            this.btOrderView.BackColor = System.Drawing.SystemColors.Control;
            this.btOrderView.Location = new System.Drawing.Point(9, 222);
            this.btOrderView.Name = "btOrderView";
            this.btOrderView.Size = new System.Drawing.Size(146, 23);
            this.btOrderView.TabIndex = 39;
            this.btOrderView.Text = "Order view";
            this.btOrderView.UseVisualStyleBackColor = false;
            // 
            // lbOrder
            // 
            this.lbOrder.AutoSize = true;
            this.lbOrder.Location = new System.Drawing.Point(9, 206);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(33, 13);
            this.lbOrder.TabIndex = 38;
            this.lbOrder.Text = "Order";
            // 
            // tbSurnameUser
            // 
            this.tbSurnameUser.Location = new System.Drawing.Point(9, 70);
            this.tbSurnameUser.Name = "tbSurnameUser";
            this.tbSurnameUser.Size = new System.Drawing.Size(146, 20);
            this.tbSurnameUser.TabIndex = 27;
            // 
            // tbNameUser
            // 
            this.tbNameUser.Location = new System.Drawing.Point(9, 27);
            this.tbNameUser.Name = "tbNameUser";
            this.tbNameUser.Size = new System.Drawing.Size(146, 20);
            this.tbNameUser.TabIndex = 26;
            // 
            // lbSurnameUser
            // 
            this.lbSurnameUser.AutoSize = true;
            this.lbSurnameUser.Location = new System.Drawing.Point(9, 54);
            this.lbSurnameUser.Name = "lbSurnameUser";
            this.lbSurnameUser.Size = new System.Drawing.Size(49, 13);
            this.lbSurnameUser.TabIndex = 25;
            this.lbSurnameUser.Text = "Surname";
            // 
            // lbNameUser
            // 
            this.lbNameUser.AutoSize = true;
            this.lbNameUser.Location = new System.Drawing.Point(9, 11);
            this.lbNameUser.Name = "lbNameUser";
            this.lbNameUser.Size = new System.Drawing.Size(35, 13);
            this.lbNameUser.TabIndex = 24;
            this.lbNameUser.Text = "Name";
            // 
            // scPayments
            // 
            this.scPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scPayments.Location = new System.Drawing.Point(3, 16);
            this.scPayments.Name = "scPayments";
            // 
            // scPayments.Panel1
            // 
            this.scPayments.Panel1.Controls.Add(this.lvPayments);
            // 
            // scPayments.Panel2
            // 
            this.scPayments.Panel2.Controls.Add(this.lbUAH);
            this.scPayments.Panel2.Controls.Add(this.textBox1);
            this.scPayments.Panel2.Controls.Add(this.lbBallance);
            this.scPayments.Panel2.Controls.Add(this.btChargeAccount);
            this.scPayments.Panel2.Controls.Add(this.btOrderView);
            this.scPayments.Panel2.Controls.Add(this.lbOrder);
            this.scPayments.Panel2.Controls.Add(this.tbSurnameUser);
            this.scPayments.Panel2.Controls.Add(this.tbNameUser);
            this.scPayments.Panel2.Controls.Add(this.lbSurnameUser);
            this.scPayments.Panel2.Controls.Add(this.lbNameUser);
            this.scPayments.Size = new System.Drawing.Size(617, 297);
            this.scPayments.SplitterDistance = 451;
            this.scPayments.TabIndex = 0;
            // 
            // lvPayments
            // 
            this.lvPayments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lvPayments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.paymentId,
            this.userLogin,
            this.date,
            this.summ,
            this.orderId});
            this.lvPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPayments.FullRowSelect = true;
            this.lvPayments.GridLines = true;
            this.lvPayments.Location = new System.Drawing.Point(0, 0);
            this.lvPayments.Name = "lvPayments";
            this.lvPayments.ShowItemToolTips = true;
            this.lvPayments.Size = new System.Drawing.Size(451, 297);
            this.lvPayments.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvPayments.TabIndex = 1;
            this.lvPayments.UseCompatibleStateImageBehavior = false;
            this.lvPayments.View = System.Windows.Forms.View.Details;
            // 
            // paymentId
            // 
            this.paymentId.Text = "ID";
            this.paymentId.Width = 33;
            // 
            // userLogin
            // 
            this.userLogin.Text = "Login";
            this.userLogin.Width = 81;
            // 
            // date
            // 
            this.date.Text = "Date";
            this.date.Width = 76;
            // 
            // summ
            // 
            this.summ.Text = "Summ";
            this.summ.Width = 49;
            // 
            // orderId
            // 
            this.orderId.Text = "Order number";
            this.orderId.Width = 62;
            // 
            // gbPayments
            // 
            this.gbPayments.AutoSize = true;
            this.gbPayments.Controls.Add(this.scPayments);
            this.gbPayments.Location = new System.Drawing.Point(4, 3);
            this.gbPayments.Name = "gbPayments";
            this.gbPayments.Size = new System.Drawing.Size(623, 316);
            this.gbPayments.TabIndex = 2;
            this.gbPayments.TabStop = false;
            this.gbPayments.Text = "Payments";
            // 
            // btChargeAccount
            // 
            this.btChargeAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btChargeAccount.Location = new System.Drawing.Point(9, 260);
            this.btChargeAccount.Name = "btChargeAccount";
            this.btChargeAccount.Size = new System.Drawing.Size(146, 23);
            this.btChargeAccount.TabIndex = 40;
            this.btChargeAccount.Text = "Charge account";
            this.btChargeAccount.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 120);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 20);
            this.textBox1.TabIndex = 42;
            // 
            // lbBallance
            // 
            this.lbBallance.AutoSize = true;
            this.lbBallance.Location = new System.Drawing.Point(9, 104);
            this.lbBallance.Name = "lbBallance";
            this.lbBallance.Size = new System.Drawing.Size(48, 13);
            this.lbBallance.TabIndex = 41;
            this.lbBallance.Text = "Ballance";
            // 
            // lbUAH
            // 
            this.lbUAH.AutoSize = true;
            this.lbUAH.Location = new System.Drawing.Point(88, 123);
            this.lbUAH.Name = "lbUAH";
            this.lbUAH.Size = new System.Drawing.Size(27, 13);
            this.lbUAH.TabIndex = 43;
            this.lbUAH.Text = "грн.";
            // 
            // UcPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPayments);
            this.Name = "UcPayments";
            this.Size = new System.Drawing.Size(630, 323);
            this.scPayments.Panel1.ResumeLayout(false);
            this.scPayments.Panel2.ResumeLayout(false);
            this.scPayments.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scPayments)).EndInit();
            this.scPayments.ResumeLayout(false);
            this.gbPayments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOrderView;
        private System.Windows.Forms.Label lbOrder;
        private System.Windows.Forms.TextBox tbSurnameUser;
        private System.Windows.Forms.TextBox tbNameUser;
        private System.Windows.Forms.Label lbSurnameUser;
        private System.Windows.Forms.Label lbNameUser;
        private System.Windows.Forms.SplitContainer scPayments;
        private System.Windows.Forms.ListView lvPayments;
        private System.Windows.Forms.ColumnHeader paymentId;
        private System.Windows.Forms.ColumnHeader userLogin;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader summ;
        private System.Windows.Forms.ColumnHeader orderId;
        private System.Windows.Forms.Label lbUAH;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbBallance;
        private System.Windows.Forms.Button btChargeAccount;
        private System.Windows.Forms.GroupBox gbPayments;
    }
}
