namespace EditText
{
    partial class Warning
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Warning));
            this.okButton = new System.Windows.Forms.Button();
            this.errorNameLabel = new System.Windows.Forms.Label();
            this.errorBox = new System.Windows.Forms.RichTextBox();
            this.noButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okButton.BackgroundImage")));
            this.okButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.okButton.Location = new System.Drawing.Point(119, 209);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(58, 51);
            this.okButton.TabIndex = 0;
            this.toolTip1.SetToolTip(this.okButton, "ОК");
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // errorNameLabel
            // 
            this.errorNameLabel.AutoSize = true;
            this.errorNameLabel.Location = new System.Drawing.Point(12, 8);
            this.errorNameLabel.Name = "errorNameLabel";
            this.errorNameLabel.Size = new System.Drawing.Size(35, 13);
            this.errorNameLabel.TabIndex = 1;
            this.errorNameLabel.Text = "label1";
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(15, 56);
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(346, 147);
            this.errorBox.TabIndex = 2;
            this.errorBox.Text = "";
            // 
            // noButton
            // 
            this.noButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("noButton.BackgroundImage")));
            this.noButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.noButton.Location = new System.Drawing.Point(183, 209);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(60, 51);
            this.noButton.TabIndex = 3;
            this.toolTip1.SetToolTip(this.noButton, "Нет");
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // Warning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 262);
            this.ControlBox = false;
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.errorNameLabel);
            this.Controls.Add(this.okButton);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximumSize = new System.Drawing.Size(389, 300);
            this.MinimumSize = new System.Drawing.Size(389, 300);
            this.Name = "Warning";
            this.Text = "Список ошибок";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label errorNameLabel;
        private System.Windows.Forms.RichTextBox errorBox;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}