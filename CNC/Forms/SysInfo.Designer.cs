namespace CNC.Forms
{
    partial class SysInfo
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
            this.infoListView = new System.Windows.Forms.ListView();
            this.key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // infoListView
            // 
            this.infoListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.key,
            this.value});
            this.infoListView.FullRowSelect = true;
            this.infoListView.GridLines = true;
            this.infoListView.Location = new System.Drawing.Point(12, 12);
            this.infoListView.Name = "infoListView";
            this.infoListView.Size = new System.Drawing.Size(590, 477);
            this.infoListView.TabIndex = 0;
            this.infoListView.UseCompatibleStateImageBehavior = false;
            this.infoListView.View = System.Windows.Forms.View.Details;
            // 
            // key
            // 
            this.key.Text = "Key";
            this.key.Width = 129;
            // 
            // value
            // 
            this.value.Text = "Value";
            this.value.Width = 408;
            // 
            // SystemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 501);
            this.Controls.Add(this.infoListView);
            this.Name = "SystemInfo";
            this.Text = "SystemInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView infoListView;
        private System.Windows.Forms.ColumnHeader key;
        private System.Windows.Forms.ColumnHeader value;
    }
}