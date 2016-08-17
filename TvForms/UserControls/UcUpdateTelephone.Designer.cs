namespace TvForms.UserControls
{
    partial class UcUpdateTelephone
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
            this.gbPhone = new System.Windows.Forms.GroupBox();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.lbNumber = new System.Windows.Forms.Label();
            this.cbPhoneType = new System.Windows.Forms.ComboBox();
            this.lbPhoneType = new System.Windows.Forms.Label();
            this.lbComment = new System.Windows.Forms.Label();
            this.gbPhone.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPhone
            // 
            this.gbPhone.Controls.Add(this.tbNumber);
            this.gbPhone.Controls.Add(this.tbComment);
            this.gbPhone.Controls.Add(this.lbNumber);
            this.gbPhone.Controls.Add(this.cbPhoneType);
            this.gbPhone.Controls.Add(this.lbPhoneType);
            this.gbPhone.Controls.Add(this.lbComment);
            this.gbPhone.Location = new System.Drawing.Point(3, 3);
            this.gbPhone.Name = "gbPhone";
            this.gbPhone.Size = new System.Drawing.Size(434, 129);
            this.gbPhone.TabIndex = 15;
            this.gbPhone.TabStop = false;
            this.gbPhone.Text = "Telephone";
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(81, 19);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(337, 20);
            this.tbNumber.TabIndex = 9;
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(81, 58);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(337, 20);
            this.tbComment.TabIndex = 10;
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(17, 22);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(47, 13);
            this.lbNumber.TabIndex = 4;
            this.lbNumber.Text = "Number:";
            // 
            // cbPhoneType
            // 
            this.cbPhoneType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhoneType.FormattingEnabled = true;
            this.cbPhoneType.Location = new System.Drawing.Point(81, 95);
            this.cbPhoneType.Name = "cbPhoneType";
            this.cbPhoneType.Size = new System.Drawing.Size(121, 21);
            this.cbPhoneType.TabIndex = 11;
            // 
            // lbPhoneType
            // 
            this.lbPhoneType.AutoSize = true;
            this.lbPhoneType.Location = new System.Drawing.Point(17, 98);
            this.lbPhoneType.Name = "lbPhoneType";
            this.lbPhoneType.Size = new System.Drawing.Size(34, 13);
            this.lbPhoneType.TabIndex = 5;
            this.lbPhoneType.Text = "Type:";
            // 
            // lbComment
            // 
            this.lbComment.AutoSize = true;
            this.lbComment.Location = new System.Drawing.Point(17, 61);
            this.lbComment.Name = "lbComment";
            this.lbComment.Size = new System.Drawing.Size(54, 13);
            this.lbComment.TabIndex = 6;
            this.lbComment.Text = "Comment:";
            // 
            // UcUpdateTelephone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPhone);
            this.Name = "UcUpdateTelephone";
            this.Size = new System.Drawing.Size(440, 135);
            this.gbPhone.ResumeLayout(false);
            this.gbPhone.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPhone;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.ComboBox cbPhoneType;
        private System.Windows.Forms.Label lbPhoneType;
        private System.Windows.Forms.Label lbComment;
    }
}
