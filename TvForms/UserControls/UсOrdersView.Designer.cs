namespace UserControls
{
    partial class UсOrdersView
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
            this.orderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userLogin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isPaid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbOrderView = new System.Windows.Forms.GroupBox();
            this.scOrderView = new System.Windows.Forms.SplitContainer();
            this.lvOrdersView = new System.Windows.Forms.ListView();
            this.btPayment = new System.Windows.Forms.Button();
            this.lbPayment = new System.Windows.Forms.Label();
            this.tbIsDeletedOrder = new System.Windows.Forms.TextBox();
            this.lbIsDeletedOrder = new System.Windows.Forms.Label();
            this.tbIsPaidOrder = new System.Windows.Forms.TextBox();
            this.lbIsPaid = new System.Windows.Forms.Label();
            this.lbUAH = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lbPrice = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tbSurnameUser = new System.Windows.Forms.TextBox();
            this.tbNameUser = new System.Windows.Forms.TextBox();
            this.lbSurnameUser = new System.Windows.Forms.Label();
            this.lbNameUser = new System.Windows.Forms.Label();
            this.lbDueDateOrder = new System.Windows.Forms.Label();
            this.lbDateOrderFrom = new System.Windows.Forms.Label();
            this.lbDateOrder = new System.Windows.Forms.Label();
            this.cbChoseMedia = new System.Windows.Forms.ComboBox();
            this.gbOrderView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scOrderView)).BeginInit();
            this.scOrderView.Panel1.SuspendLayout();
            this.scOrderView.Panel2.SuspendLayout();
            this.scOrderView.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderId
            // 
            this.orderId.Text = "ID";
            this.orderId.Width = 34;
            // 
            // userLogin
            // 
            this.userLogin.Text = "Login";
            this.userLogin.Width = 81;
            // 
            // dueDate
            // 
            this.dueDate.Text = "Due date";
            this.dueDate.Width = 76;
            // 
            // isPaid
            // 
            this.isPaid.Text = "Is Paid";
            this.isPaid.Width = 49;
            // 
            // price
            // 
            this.price.Text = "Price";
            this.price.Width = 53;
            // 
            // gbOrderView
            // 
            this.gbOrderView.AutoSize = true;
            this.gbOrderView.Controls.Add(this.scOrderView);
            this.gbOrderView.Location = new System.Drawing.Point(4, 3);
            this.gbOrderView.Name = "gbOrderView";
            this.gbOrderView.Size = new System.Drawing.Size(623, 316);
            this.gbOrderView.TabIndex = 1;
            this.gbOrderView.TabStop = false;
            this.gbOrderView.Text = "Order view";
            // 
            // scOrderView
            // 
            this.scOrderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scOrderView.Location = new System.Drawing.Point(3, 16);
            this.scOrderView.Name = "scOrderView";
            // 
            // scOrderView.Panel1
            // 
            this.scOrderView.Panel1.Controls.Add(this.lvOrdersView);
            // 
            // scOrderView.Panel2
            // 
            this.scOrderView.Panel2.Controls.Add(this.btPayment);
            this.scOrderView.Panel2.Controls.Add(this.lbPayment);
            this.scOrderView.Panel2.Controls.Add(this.tbIsDeletedOrder);
            this.scOrderView.Panel2.Controls.Add(this.lbIsDeletedOrder);
            this.scOrderView.Panel2.Controls.Add(this.tbIsPaidOrder);
            this.scOrderView.Panel2.Controls.Add(this.lbIsPaid);
            this.scOrderView.Panel2.Controls.Add(this.lbUAH);
            this.scOrderView.Panel2.Controls.Add(this.tbPrice);
            this.scOrderView.Panel2.Controls.Add(this.lbPrice);
            this.scOrderView.Panel2.Controls.Add(this.dateTimePicker3);
            this.scOrderView.Panel2.Controls.Add(this.dateTimePicker2);
            this.scOrderView.Panel2.Controls.Add(this.dateTimePicker1);
            this.scOrderView.Panel2.Controls.Add(this.tbSurnameUser);
            this.scOrderView.Panel2.Controls.Add(this.tbNameUser);
            this.scOrderView.Panel2.Controls.Add(this.lbSurnameUser);
            this.scOrderView.Panel2.Controls.Add(this.lbNameUser);
            this.scOrderView.Panel2.Controls.Add(this.lbDueDateOrder);
            this.scOrderView.Panel2.Controls.Add(this.lbDateOrderFrom);
            this.scOrderView.Panel2.Controls.Add(this.lbDateOrder);
            this.scOrderView.Panel2.Controls.Add(this.cbChoseMedia);
            this.scOrderView.Size = new System.Drawing.Size(617, 297);
            this.scOrderView.SplitterDistance = 307;
            this.scOrderView.TabIndex = 0;
            // 
            // lvOrdersView
            // 
            this.lvOrdersView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lvOrdersView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.orderId,
            this.userLogin,
            this.dueDate,
            this.isPaid,
            this.price});
            this.lvOrdersView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOrdersView.FullRowSelect = true;
            this.lvOrdersView.GridLines = true;
            this.lvOrdersView.Location = new System.Drawing.Point(0, 0);
            this.lvOrdersView.Name = "lvOrdersView";
            this.lvOrdersView.ShowItemToolTips = true;
            this.lvOrdersView.Size = new System.Drawing.Size(307, 297);
            this.lvOrdersView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvOrdersView.TabIndex = 1;
            this.lvOrdersView.UseCompatibleStateImageBehavior = false;
            this.lvOrdersView.View = System.Windows.Forms.View.Details;
            // 
            // btPayment
            // 
            this.btPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btPayment.Location = new System.Drawing.Point(102, 268);
            this.btPayment.Name = "btPayment";
            this.btPayment.Size = new System.Drawing.Size(146, 23);
            this.btPayment.TabIndex = 39;
            this.btPayment.Text = "Payment view";
            this.btPayment.UseVisualStyleBackColor = false;
            // 
            // lbPayment
            // 
            this.lbPayment.AutoSize = true;
            this.lbPayment.Location = new System.Drawing.Point(4, 273);
            this.lbPayment.Name = "lbPayment";
            this.lbPayment.Size = new System.Drawing.Size(48, 13);
            this.lbPayment.TabIndex = 38;
            this.lbPayment.Text = "Payment";
            // 
            // tbIsDeletedOrder
            // 
            this.tbIsDeletedOrder.Location = new System.Drawing.Point(102, 243);
            this.tbIsDeletedOrder.Name = "tbIsDeletedOrder";
            this.tbIsDeletedOrder.Size = new System.Drawing.Size(146, 20);
            this.tbIsDeletedOrder.TabIndex = 37;
            this.tbIsDeletedOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbIsDeletedOrder
            // 
            this.lbIsDeletedOrder.AutoSize = true;
            this.lbIsDeletedOrder.Location = new System.Drawing.Point(4, 246);
            this.lbIsDeletedOrder.Name = "lbIsDeletedOrder";
            this.lbIsDeletedOrder.Size = new System.Drawing.Size(80, 13);
            this.lbIsDeletedOrder.TabIndex = 36;
            this.lbIsDeletedOrder.Text = "Is deleted order";
            // 
            // tbIsPaidOrder
            // 
            this.tbIsPaidOrder.Location = new System.Drawing.Point(102, 217);
            this.tbIsPaidOrder.Name = "tbIsPaidOrder";
            this.tbIsPaidOrder.Size = new System.Drawing.Size(146, 20);
            this.tbIsPaidOrder.TabIndex = 35;
            this.tbIsPaidOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbIsPaid
            // 
            this.lbIsPaid.AutoSize = true;
            this.lbIsPaid.Location = new System.Drawing.Point(4, 220);
            this.lbIsPaid.Name = "lbIsPaid";
            this.lbIsPaid.Size = new System.Drawing.Size(65, 13);
            this.lbIsPaid.TabIndex = 34;
            this.lbIsPaid.Text = "Is paid order";
            // 
            // lbUAH
            // 
            this.lbUAH.AutoSize = true;
            this.lbUAH.Location = new System.Drawing.Point(254, 194);
            this.lbUAH.Name = "lbUAH";
            this.lbUAH.Size = new System.Drawing.Size(27, 13);
            this.lbUAH.TabIndex = 33;
            this.lbUAH.Text = "грн.";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(102, 191);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(146, 20);
            this.tbPrice.TabIndex = 32;
            this.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(4, 194);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(57, 13);
            this.lbPrice.TabIndex = 31;
            this.lbPrice.Text = "Total price";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(102, 160);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker3.TabIndex = 30;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(102, 123);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 29;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(102, 89);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 28;
            // 
            // tbSurnameUser
            // 
            this.tbSurnameUser.Location = new System.Drawing.Point(159, 51);
            this.tbSurnameUser.Name = "tbSurnameUser";
            this.tbSurnameUser.Size = new System.Drawing.Size(143, 20);
            this.tbSurnameUser.TabIndex = 27;
            // 
            // tbNameUser
            // 
            this.tbNameUser.Location = new System.Drawing.Point(7, 51);
            this.tbNameUser.Name = "tbNameUser";
            this.tbNameUser.Size = new System.Drawing.Size(146, 20);
            this.tbNameUser.TabIndex = 26;
            // 
            // lbSurnameUser
            // 
            this.lbSurnameUser.AutoSize = true;
            this.lbSurnameUser.Location = new System.Drawing.Point(156, 34);
            this.lbSurnameUser.Name = "lbSurnameUser";
            this.lbSurnameUser.Size = new System.Drawing.Size(49, 13);
            this.lbSurnameUser.TabIndex = 25;
            this.lbSurnameUser.Text = "Surname";
            // 
            // lbNameUser
            // 
            this.lbNameUser.AutoSize = true;
            this.lbNameUser.Location = new System.Drawing.Point(4, 34);
            this.lbNameUser.Name = "lbNameUser";
            this.lbNameUser.Size = new System.Drawing.Size(35, 13);
            this.lbNameUser.TabIndex = 24;
            this.lbNameUser.Text = "Name";
            // 
            // lbDueDateOrder
            // 
            this.lbDueDateOrder.AutoSize = true;
            this.lbDueDateOrder.Location = new System.Drawing.Point(4, 166);
            this.lbDueDateOrder.Name = "lbDueDateOrder";
            this.lbDueDateOrder.Size = new System.Drawing.Size(78, 13);
            this.lbDueDateOrder.TabIndex = 23;
            this.lbDueDateOrder.Text = "Due date order";
            // 
            // lbDateOrderFrom
            // 
            this.lbDateOrderFrom.AutoSize = true;
            this.lbDateOrderFrom.Location = new System.Drawing.Point(4, 129);
            this.lbDateOrderFrom.Name = "lbDateOrderFrom";
            this.lbDateOrderFrom.Size = new System.Drawing.Size(81, 13);
            this.lbDateOrderFrom.TabIndex = 22;
            this.lbDateOrderFrom.Text = "Order valid from";
            // 
            // lbDateOrder
            // 
            this.lbDateOrder.AutoSize = true;
            this.lbDateOrder.Location = new System.Drawing.Point(4, 95);
            this.lbDateOrder.Name = "lbDateOrder";
            this.lbDateOrder.Size = new System.Drawing.Size(57, 13);
            this.lbDateOrder.TabIndex = 21;
            this.lbDateOrder.Text = "Date order";
            // 
            // cbChoseMedia
            // 
            this.cbChoseMedia.DisplayMember = "0";
            this.cbChoseMedia.FormattingEnabled = true;
            this.cbChoseMedia.Items.AddRange(new object[] {
            "Channels",
            "TV shows"});
            this.cbChoseMedia.Location = new System.Drawing.Point(7, 5);
            this.cbChoseMedia.Name = "cbChoseMedia";
            this.cbChoseMedia.Size = new System.Drawing.Size(121, 21);
            this.cbChoseMedia.TabIndex = 20;
            this.cbChoseMedia.Text = "Choose media";
            // 
            // UсOrdersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbOrderView);
            this.Name = "UсOrdersView";
            this.Size = new System.Drawing.Size(630, 323);
            this.gbOrderView.ResumeLayout(false);
            this.scOrderView.Panel1.ResumeLayout(false);
            this.scOrderView.Panel2.ResumeLayout(false);
            this.scOrderView.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scOrderView)).EndInit();
            this.scOrderView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader orderId;
        private System.Windows.Forms.ColumnHeader userLogin;
        private System.Windows.Forms.ColumnHeader dueDate;
        private System.Windows.Forms.ColumnHeader isPaid;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.GroupBox gbOrderView;
        private System.Windows.Forms.SplitContainer scOrderView;
        private System.Windows.Forms.ListView lvOrdersView;
        private System.Windows.Forms.Button btPayment;
        private System.Windows.Forms.Label lbPayment;
        private System.Windows.Forms.TextBox tbIsDeletedOrder;
        private System.Windows.Forms.Label lbIsDeletedOrder;
        private System.Windows.Forms.TextBox tbIsPaidOrder;
        private System.Windows.Forms.Label lbIsPaid;
        private System.Windows.Forms.Label lbUAH;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox tbSurnameUser;
        private System.Windows.Forms.TextBox tbNameUser;
        private System.Windows.Forms.Label lbSurnameUser;
        private System.Windows.Forms.Label lbNameUser;
        private System.Windows.Forms.Label lbDueDateOrder;
        private System.Windows.Forms.Label lbDateOrderFrom;
        private System.Windows.Forms.Label lbDateOrder;
        private System.Windows.Forms.ComboBox cbChoseMedia;
        //private System.Windows.Forms.ColumnHeader columnHeader1;
        //private System.Windows.Forms.ColumnHeader columnHeader2;
        //private System.Windows.Forms.ColumnHeader columnHeader3;
        //private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
