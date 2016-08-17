namespace TvForms.UserControls
{
    partial class UcUpdateEmail
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
            this.gbEmail = new System.Windows.Forms.GroupBox();
            this.tbUserEmail = new System.Windows.Forms.TextBox();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.lbEmailName = new System.Windows.Forms.Label();
            this.cbEmailType = new System.Windows.Forms.ComboBox();
            this.lbEmailType = new System.Windows.Forms.Label();
            this.lbComment = new System.Windows.Forms.Label();
            this.gbEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEmail
            // 
            this.gbEmail.Controls.Add(this.tbUserEmail);
            this.gbEmail.Controls.Add(this.tbComment);
            this.gbEmail.Controls.Add(this.lbEmailName);
            this.gbEmail.Controls.Add(this.cbEmailType);
            this.gbEmail.Controls.Add(this.lbEmailType);
            this.gbEmail.Controls.Add(this.lbComment);
            this.gbEmail.Location = new System.Drawing.Point(3, 3);
            this.gbEmail.Name = "gbEmail";
            this.gbEmail.Size = new System.Drawing.Size(434, 129);
            this.gbEmail.TabIndex = 14;
            this.gbEmail.TabStop = false;
            this.gbEmail.Text = "Email";
            // 
            // tbUserEmail
            // 
            this.tbUserEmail.Location = new System.Drawing.Point(81, 19);
            this.tbUserEmail.Name = "tbUserEmail";
            this.tbUserEmail.Size = new System.Drawing.Size(337, 20);
            this.tbUserEmail.TabIndex = 9;
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(81, 58);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(337, 20);
            this.tbComment.TabIndex = 10;
            // 
            // lbEmailName
            // 
            this.lbEmailName.AutoSize = true;
            this.lbEmailName.Location = new System.Drawing.Point(17, 22);
            this.lbEmailName.Name = "lbEmailName";
            this.lbEmailName.Size = new System.Drawing.Size(35, 13);
            this.lbEmailName.TabIndex = 4;
            this.lbEmailName.Text = "Email:";
            // 
            // cbEmailType
            // 
            this.cbEmailType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmailType.FormattingEnabled = true;
            this.cbEmailType.Location = new System.Drawing.Point(81, 95);
            this.cbEmailType.Name = "cbEmailType";
            this.cbEmailType.Size = new System.Drawing.Size(121, 21);
            this.cbEmailType.TabIndex = 11;
            // 
            // lbEmailType
            // 
            this.lbEmailType.AutoSize = true;
            this.lbEmailType.Location = new System.Drawing.Point(17, 98);
            this.lbEmailType.Name = "lbEmailType";
            this.lbEmailType.Size = new System.Drawing.Size(34, 13);
            this.lbEmailType.TabIndex = 5;
            this.lbEmailType.Text = "Type:";
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
            // UcUpdateEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbEmail);
            this.Name = "UcUpdateEmail";
            this.Size = new System.Drawing.Size(440, 135);
            this.gbEmail.ResumeLayout(false);
            this.gbEmail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEmail;
        private System.Windows.Forms.TextBox tbUserEmail;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label lbEmailName;
        private System.Windows.Forms.ComboBox cbEmailType;
        private System.Windows.Forms.Label lbEmailType;
        private System.Windows.Forms.Label lbComment;
    }
}
