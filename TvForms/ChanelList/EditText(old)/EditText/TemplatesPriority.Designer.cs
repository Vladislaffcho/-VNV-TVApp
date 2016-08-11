namespace EditText
{
    partial class TemplatesPriority
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplatesPriority));
            this.normListBox = new System.Windows.Forms.ListBox();
            this.rtfListBox = new System.Windows.Forms.ListBox();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // normListBox
            // 
            this.normListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.normListBox.FormattingEnabled = true;
            this.normListBox.ItemHeight = 18;
            this.normListBox.Location = new System.Drawing.Point(12, 12);
            this.normListBox.Name = "normListBox";
            this.normListBox.Size = new System.Drawing.Size(513, 274);
            this.normListBox.TabIndex = 2;
            this.normListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.normListBox_MouseClick);
            // 
            // rtfListBox
            // 
            this.rtfListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtfListBox.FormattingEnabled = true;
            this.rtfListBox.ItemHeight = 18;
            this.rtfListBox.Location = new System.Drawing.Point(13, 296);
            this.rtfListBox.Name = "rtfListBox";
            this.rtfListBox.Size = new System.Drawing.Size(512, 166);
            this.rtfListBox.TabIndex = 3;
            this.rtfListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rtfListBox_MouseClick);
            // 
            // upButton
            // 
            this.upButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("upButton.BackgroundImage")));
            this.upButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.upButton.Location = new System.Drawing.Point(531, 79);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(58, 56);
            this.upButton.TabIndex = 4;
            this.toolTip1.SetToolTip(this.upButton, "Переместить услугу вверх");
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("downButton.BackgroundImage")));
            this.downButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.downButton.Location = new System.Drawing.Point(531, 141);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(58, 51);
            this.downButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.downButton, "Переместить услугу вниз");
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelButton.BackgroundImage")));
            this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelButton.Location = new System.Drawing.Point(531, 401);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(58, 52);
            this.cancelButton.TabIndex = 7;
            this.toolTip1.SetToolTip(this.cancelButton, "Отмена");
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okButton.BackgroundImage")));
            this.okButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.okButton.Location = new System.Drawing.Point(531, 339);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(58, 56);
            this.okButton.TabIndex = 6;
            this.toolTip1.SetToolTip(this.okButton, "ОК");
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // TemplatesPriority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 465);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.rtfListBox);
            this.Controls.Add(this.normListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TemplatesPriority";
            this.Text = "TemplatesPriority";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox normListBox;
        private System.Windows.Forms.ListBox rtfListBox;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}