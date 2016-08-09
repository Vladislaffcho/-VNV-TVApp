namespace TvForms
{
    partial class ucAddAddress
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
            this.tbUserAddress = new System.Windows.Forms.TextBox();
            this.lbAddressComment = new System.Windows.Forms.Label();
            this.lbAddressType = new System.Windows.Forms.Label();
            this.lbAddressName = new System.Windows.Forms.Label();
            this.cbAddressType = new System.Windows.Forms.ComboBox();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbUserAddress
            // 
            this.tbUserAddress.Location = new System.Drawing.Point(80, 19);
            this.tbUserAddress.Name = "tbUserAddress";
            this.tbUserAddress.Size = new System.Drawing.Size(337, 20);
            this.tbUserAddress.TabIndex = 9;
            // 
            // lbAddressComment
            // 
            this.lbAddressComment.AutoSize = true;
            this.lbAddressComment.Location = new System.Drawing.Point(16, 61);
            this.lbAddressComment.Name = "lbAddressComment";
            this.lbAddressComment.Size = new System.Drawing.Size(54, 13);
            this.lbAddressComment.TabIndex = 6;
            this.lbAddressComment.Text = "Comment:";
            // 
            // lbAddressType
            // 
            this.lbAddressType.AutoSize = true;
            this.lbAddressType.Location = new System.Drawing.Point(16, 98);
            this.lbAddressType.Name = "lbAddressType";
            this.lbAddressType.Size = new System.Drawing.Size(34, 13);
            this.lbAddressType.TabIndex = 5;
            this.lbAddressType.Text = "Type:";
            // 
            // lbAddressName
            // 
            this.lbAddressName.AutoSize = true;
            this.lbAddressName.Location = new System.Drawing.Point(16, 22);
            this.lbAddressName.Name = "lbAddressName";
            this.lbAddressName.Size = new System.Drawing.Size(48, 13);
            this.lbAddressName.TabIndex = 4;
            this.lbAddressName.Text = "Address:";
            // 
            // cbAddressType
            // 
            this.cbAddressType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAddressType.FormattingEnabled = true;
            this.cbAddressType.Location = new System.Drawing.Point(80, 95);
            this.cbAddressType.Name = "cbAddressType";
            this.cbAddressType.Size = new System.Drawing.Size(121, 21);
            this.cbAddressType.TabIndex = 10;
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(80, 58);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(337, 20);
            this.tbComment.TabIndex = 11;
            // 
            // ucAddAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.cbAddressType);
            this.Controls.Add(this.tbUserAddress);
            this.Controls.Add(this.lbAddressComment);
            this.Controls.Add(this.lbAddressType);
            this.Controls.Add(this.lbAddressName);
            this.Name = "ucAddAddress";
            this.Size = new System.Drawing.Size(440, 135);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbUserAddress;
        private System.Windows.Forms.Label lbAddressComment;
        private System.Windows.Forms.Label lbAddressType;
        private System.Windows.Forms.Label lbAddressName;
        private System.Windows.Forms.ComboBox cbAddressType;
        private System.Windows.Forms.TextBox tbComment;
    }
}
