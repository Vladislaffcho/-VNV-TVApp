﻿namespace TvForms
{
    partial class UcFavoirute
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
            this.scContainerFav = new System.Windows.Forms.SplitContainer();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbUAH = new System.Windows.Forms.Label();
            this.lbUAH_balance = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbAccountBalance = new System.Windows.Forms.Label();
            this.btOrder = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChannelName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Programm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Adult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.scContainerFav)).BeginInit();
            this.scContainerFav.Panel1.SuspendLayout();
            this.scContainerFav.Panel2.SuspendLayout();
            this.scContainerFav.SuspendLayout();
            this.SuspendLayout();
            // 
            // scContainerFav
            // 
            this.scContainerFav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scContainerFav.Location = new System.Drawing.Point(0, 0);
            this.scContainerFav.Name = "scContainerFav";
            // 
            // scContainerFav.Panel1
            // 
            this.scContainerFav.Panel1.Controls.Add(this.listView1);
            // 
            // scContainerFav.Panel2
            // 
            this.scContainerFav.Panel2.Controls.Add(this.btOrder);
            this.scContainerFav.Panel2.Controls.Add(this.lbUAH_balance);
            this.scContainerFav.Panel2.Controls.Add(this.textBox2);
            this.scContainerFav.Panel2.Controls.Add(this.lbAccountBalance);
            this.scContainerFav.Panel2.Controls.Add(this.lbUAH);
            this.scContainerFav.Panel2.Controls.Add(this.textBox1);
            this.scContainerFav.Panel2.Controls.Add(this.lbTotalPrice);
            this.scContainerFav.Size = new System.Drawing.Size(844, 429);
            this.scContainerFav.SplitterDistance = 643;
            this.scContainerFav.TabIndex = 0;
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.Location = new System.Drawing.Point(15, 23);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(57, 13);
            this.lbTotalPrice.TabIndex = 0;
            this.lbTotalPrice.Text = "Total price";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.Location = new System.Drawing.Point(18, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(85, 20);
            this.textBox1.TabIndex = 1;
            // 
            // lbUAH
            // 
            this.lbUAH.AutoSize = true;
            this.lbUAH.Location = new System.Drawing.Point(111, 42);
            this.lbUAH.Name = "lbUAH";
            this.lbUAH.Size = new System.Drawing.Size(27, 13);
            this.lbUAH.TabIndex = 2;
            this.lbUAH.Text = "грн.";
            // 
            // lbUAH_balance
            // 
            this.lbUAH_balance.AutoSize = true;
            this.lbUAH_balance.Location = new System.Drawing.Point(111, 96);
            this.lbUAH_balance.Name = "lbUAH_balance";
            this.lbUAH_balance.Size = new System.Drawing.Size(27, 13);
            this.lbUAH_balance.TabIndex = 5;
            this.lbUAH_balance.Text = "грн.";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox2.Location = new System.Drawing.Point(18, 93);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(85, 20);
            this.textBox2.TabIndex = 4;
            // 
            // lbAccountBalance
            // 
            this.lbAccountBalance.AutoSize = true;
            this.lbAccountBalance.Location = new System.Drawing.Point(15, 77);
            this.lbAccountBalance.Name = "lbAccountBalance";
            this.lbAccountBalance.Size = new System.Drawing.Size(88, 13);
            this.lbAccountBalance.TabIndex = 3;
            this.lbAccountBalance.Text = "Account balance";
            // 
            // btOrder
            // 
            this.btOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btOrder.Location = new System.Drawing.Point(3, 403);
            this.btOrder.Name = "btOrder";
            this.btOrder.Size = new System.Drawing.Size(191, 23);
            this.btOrder.TabIndex = 6;
            this.btOrder.Text = "Make order";
            this.btOrder.UseVisualStyleBackColor = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.ChannelName,
            this.Adult,
            this.Price,
            this.Date,
            this.Time,
            this.Programm});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(643, 429);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Number
            // 
            this.Number.Text = "№";
            this.Number.Width = 45;
            // 
            // ChannelName
            // 
            this.ChannelName.Text = "Channel";
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 53;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 53;
            // 
            // Programm
            // 
            this.Programm.Text = "Programm";
            this.Programm.Width = 313;
            // 
            // Adult
            // 
            this.Adult.Text = "Adult";
            this.Adult.Width = 38;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 51;
            // 
            // UcFavoirute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scContainerFav);
            this.Name = "UcFavoirute";
            this.Size = new System.Drawing.Size(844, 429);
            this.scContainerFav.Panel1.ResumeLayout(false);
            this.scContainerFav.Panel2.ResumeLayout(false);
            this.scContainerFav.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scContainerFav)).EndInit();
            this.scContainerFav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scContainerFav;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader ChannelName;
        private System.Windows.Forms.ColumnHeader Adult;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader Programm;
        private System.Windows.Forms.Button btOrder;
        private System.Windows.Forms.Label lbUAH_balance;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbAccountBalance;
        private System.Windows.Forms.Label lbUAH;
        private System.Windows.Forms.TextBox textBox1;
    }
}