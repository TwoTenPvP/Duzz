namespace CNC.Forms
{
    partial class RemoteScript
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
            this.txtCode = new System.Windows.Forms.RichTextBox();
            this.radVB = new System.Windows.Forms.RadioButton();
            this.radJS = new System.Windows.Forms.RadioButton();
            this.radBAT = new System.Windows.Forms.RadioButton();
            this.chkRunSilent = new System.Windows.Forms.CheckBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(12, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(732, 389);
            this.txtCode.TabIndex = 0;
            this.txtCode.Text = "";
            // 
            // radVB
            // 
            this.radVB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radVB.AutoSize = true;
            this.radVB.Checked = true;
            this.radVB.Location = new System.Drawing.Point(12, 407);
            this.radVB.Name = "radVB";
            this.radVB.Size = new System.Drawing.Size(66, 17);
            this.radVB.TabIndex = 1;
            this.radVB.TabStop = true;
            this.radVB.Text = "VBScript";
            this.radVB.UseVisualStyleBackColor = true;
            // 
            // radJS
            // 
            this.radJS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radJS.AutoSize = true;
            this.radJS.Location = new System.Drawing.Point(84, 407);
            this.radJS.Name = "radJS";
            this.radJS.Size = new System.Drawing.Size(55, 17);
            this.radJS.TabIndex = 2;
            this.radJS.Text = "HTML";
            this.radJS.UseVisualStyleBackColor = true;
            // 
            // radBAT
            // 
            this.radBAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radBAT.AutoSize = true;
            this.radBAT.Location = new System.Drawing.Point(165, 407);
            this.radBAT.Name = "radBAT";
            this.radBAT.Size = new System.Drawing.Size(83, 17);
            this.radBAT.TabIndex = 3;
            this.radBAT.Text = "Batch Script";
            this.radBAT.UseVisualStyleBackColor = true;
            // 
            // chkRunSilent
            // 
            this.chkRunSilent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRunSilent.AutoSize = true;
            this.chkRunSilent.Location = new System.Drawing.Point(254, 408);
            this.chkRunSilent.Name = "chkRunSilent";
            this.chkRunSilent.Size = new System.Drawing.Size(77, 17);
            this.chkRunSilent.TabIndex = 4;
            this.chkRunSilent.Text = "Run silenly";
            this.chkRunSilent.UseVisualStyleBackColor = true;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(669, 408);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 5;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(588, 408);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // chkAdmin
            // 
            this.chkAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Location = new System.Drawing.Point(337, 407);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(122, 17);
            this.chkAdmin.TabIndex = 7;
            this.chkAdmin.Text = "Run as administrator";
            this.chkAdmin.UseVisualStyleBackColor = true;
            // 
            // RemoteScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 436);
            this.Controls.Add(this.chkAdmin);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.chkRunSilent);
            this.Controls.Add(this.radBAT);
            this.Controls.Add(this.radJS);
            this.Controls.Add(this.radVB);
            this.Controls.Add(this.txtCode);
            this.Name = "RemoteScript";
            this.Text = "RemoteScript";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtCode;
        private System.Windows.Forms.RadioButton radVB;
        private System.Windows.Forms.RadioButton radJS;
        private System.Windows.Forms.RadioButton radBAT;
        private System.Windows.Forms.CheckBox chkRunSilent;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.CheckBox chkAdmin;
    }
}