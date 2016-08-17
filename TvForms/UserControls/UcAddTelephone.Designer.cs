namespace TvForms.UserControls
{
    partial class UcAddTelephone
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
            this.gbNumber = new System.Windows.Forms.GroupBox();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.lbNumber = new System.Windows.Forms.Label();
            this.cbNumberType = new System.Windows.Forms.ComboBox();
            this.lbNumberType = new System.Windows.Forms.Label();
            this.lbNumberComment = new System.Windows.Forms.Label();
            this.gbNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNumber
            // 
            this.gbNumber.Controls.Add(this.tbNumber);
            this.gbNumber.Controls.Add(this.tbComment);
            this.gbNumber.Controls.Add(this.lbNumber);
            this.gbNumber.Controls.Add(this.cbNumberType);
            this.gbNumber.Controls.Add(this.lbNumberType);
            this.gbNumber.Controls.Add(this.lbNumberComment);
            this.gbNumber.Location = new System.Drawing.Point(3, 3);
            this.gbNumber.Name = "gbNumber";
            this.gbNumber.Size = new System.Drawing.Size(434, 129);
            this.gbNumber.TabIndex = 14;
            this.gbNumber.TabStop = false;
            this.gbNumber.Text = "Phone";
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
            // cbNumberType
            // 
            this.cbNumberType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumberType.FormattingEnabled = true;
            this.cbNumberType.Location = new System.Drawing.Point(81, 95);
            this.cbNumberType.Name = "cbNumberType";
            this.cbNumberType.Size = new System.Drawing.Size(121, 21);
            this.cbNumberType.TabIndex = 11;
            // 
            // lbNumberType
            // 
            this.lbNumberType.AutoSize = true;
            this.lbNumberType.Location = new System.Drawing.Point(17, 98);
            this.lbNumberType.Name = "lbNumberType";
            this.lbNumberType.Size = new System.Drawing.Size(34, 13);
            this.lbNumberType.TabIndex = 5;
            this.lbNumberType.Text = "Type:";
            // 
            // lbNumberComment
            // 
            this.lbNumberComment.AutoSize = true;
            this.lbNumberComment.Location = new System.Drawing.Point(17, 61);
            this.lbNumberComment.Name = "lbNumberComment";
            this.lbNumberComment.Size = new System.Drawing.Size(54, 13);
            this.lbNumberComment.TabIndex = 6;
            this.lbNumberComment.Text = "Comment:";
            // 
            // UcAddTelephone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbNumber);
            this.Name = "UcAddTelephone";
            this.Size = new System.Drawing.Size(440, 135);
            this.gbNumber.ResumeLayout(false);
            this.gbNumber.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNumber;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.ComboBox cbNumberType;
        private System.Windows.Forms.Label lbNumberType;
        private System.Windows.Forms.Label lbNumberComment;
    }
}
