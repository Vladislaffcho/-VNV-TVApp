namespace TVAppVNV
{
    partial class ActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionForm));
            this.btActionCancel = new System.Windows.Forms.Button();
            this.btActionOk = new System.Windows.Forms.Button();
            this.panelUserAction = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btActionCancel
            // 
            this.btActionCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btActionCancel.Location = new System.Drawing.Point(498, 329);
            this.btActionCancel.Name = "btActionCancel";
            this.btActionCancel.Size = new System.Drawing.Size(75, 23);
            this.btActionCancel.TabIndex = 0;
            this.btActionCancel.Text = "Cancel";
            this.btActionCancel.UseVisualStyleBackColor = true;
            this.btActionCancel.Click += new System.EventHandler(this.btActionCancel_Click);
            // 
            // btActionOk
            // 
            this.btActionOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btActionOk.Location = new System.Drawing.Point(417, 329);
            this.btActionOk.Name = "btActionOk";
            this.btActionOk.Size = new System.Drawing.Size(75, 23);
            this.btActionOk.TabIndex = 1;
            this.btActionOk.Text = "Ok";
            this.btActionOk.UseVisualStyleBackColor = true;
            this.btActionOk.Click += new System.EventHandler(this.btActionOk_Click);
            // 
            // panelUserAction
            // 
            this.panelUserAction.Location = new System.Drawing.Point(13, 13);
            this.panelUserAction.Name = "panelUserAction";
            this.panelUserAction.Size = new System.Drawing.Size(560, 310);
            this.panelUserAction.TabIndex = 2;
            // 
            // ActionForm
            // 
            this.AcceptButton = this.btActionOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btActionCancel;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.panelUserAction);
            this.Controls.Add(this.btActionOk);
            this.Controls.Add(this.btActionCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User actions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btActionCancel;
        private System.Windows.Forms.Button btActionOk;
        private System.Windows.Forms.Panel panelUserAction;
    }
}