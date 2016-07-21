namespace EditText
{
    partial class PrefSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrefSelect));
            this.addButton = new System.Windows.Forms.Button();
            this.prefBox = new System.Windows.Forms.TextBox();
            this.delButton = new System.Windows.Forms.Button();
            this.allPrefListBox = new System.Windows.Forms.ListBox();
            this.loadFromFileButton = new System.Windows.Forms.Button();
            this.winEncodingButton = new System.Windows.Forms.Button();
            this.dosEncodingButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.utf8Button = new System.Windows.Forms.Button();
            this.saveToFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.Name = "addButton";
            this.toolTip1.SetToolTip(this.addButton, resources.GetString("addButton.ToolTip"));
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // prefBox
            // 
            resources.ApplyResources(this.prefBox, "prefBox");
            this.prefBox.Name = "prefBox";
            // 
            // delButton
            // 
            resources.ApplyResources(this.delButton, "delButton");
            this.delButton.Name = "delButton";
            this.toolTip1.SetToolTip(this.delButton, resources.GetString("delButton.ToolTip"));
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // allPrefListBox
            // 
            resources.ApplyResources(this.allPrefListBox, "allPrefListBox");
            this.allPrefListBox.FormattingEnabled = true;
            this.allPrefListBox.Name = "allPrefListBox";
            // 
            // loadFromFileButton
            // 
            resources.ApplyResources(this.loadFromFileButton, "loadFromFileButton");
            this.loadFromFileButton.Name = "loadFromFileButton";
            this.loadFromFileButton.UseVisualStyleBackColor = true;
            this.loadFromFileButton.Click += new System.EventHandler(this.loadFromFilebutton1_Click);
            // 
            // winEncodingButton
            // 
            this.winEncodingButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.winEncodingButton, "winEncodingButton");
            this.winEncodingButton.Name = "winEncodingButton";
            this.winEncodingButton.UseVisualStyleBackColor = true;
            this.winEncodingButton.Click += new System.EventHandler(this.winEncodingButton_Click);
            // 
            // dosEncodingButton
            // 
            this.dosEncodingButton.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.dosEncodingButton, "dosEncodingButton");
            this.dosEncodingButton.Name = "dosEncodingButton";
            this.dosEncodingButton.UseVisualStyleBackColor = true;
            this.dosEncodingButton.Click += new System.EventHandler(this.dosEncodingButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.toolTip1.SetToolTip(this.cancelButton, resources.GetString("cancelButton.ToolTip"));
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.toolTip1.SetToolTip(this.okButton, resources.GetString("okButton.ToolTip"));
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // utf8Button
            // 
            this.utf8Button.ForeColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.utf8Button, "utf8Button");
            this.utf8Button.Name = "utf8Button";
            this.utf8Button.UseVisualStyleBackColor = true;
            this.utf8Button.Click += new System.EventHandler(this.utf8Button_Click);
            // 
            // saveToFileButton
            // 
            resources.ApplyResources(this.saveToFileButton, "saveToFileButton");
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.UseVisualStyleBackColor = true;
            this.saveToFileButton.Click += new System.EventHandler(this.saveToFileButton_Click);
            // 
            // PrefSelect
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.saveToFileButton);
            this.Controls.Add(this.utf8Button);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.dosEncodingButton);
            this.Controls.Add(this.winEncodingButton);
            this.Controls.Add(this.loadFromFileButton);
            this.Controls.Add(this.allPrefListBox);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.prefBox);
            this.Controls.Add(this.addButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PrefSelect";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox prefBox;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.ListBox allPrefListBox;
        private System.Windows.Forms.Button loadFromFileButton;
        private System.Windows.Forms.Button winEncodingButton;
        private System.Windows.Forms.Button dosEncodingButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button utf8Button;
        private System.Windows.Forms.Button saveToFileButton;
    }
}