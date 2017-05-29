namespace CNC
{
    partial class Main
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
            this.clientListView = new System.Windows.Forms.ListView();
            this.ipAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.operatingSystem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clientMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientListView
            // 
            this.clientListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ipAddress,
            this.operatingSystem});
            this.clientListView.Location = new System.Drawing.Point(12, 12);
            this.clientListView.Name = "clientListView";
            this.clientListView.Size = new System.Drawing.Size(836, 286);
            this.clientListView.TabIndex = 0;
            this.clientListView.UseCompatibleStateImageBehavior = false;
            this.clientListView.View = System.Windows.Forms.View.Details;
            this.clientListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clientListView_MouseClick);
            // 
            // ipAddress
            // 
            this.ipAddress.Text = "IP Address";
            this.ipAddress.Width = 126;
            // 
            // operatingSystem
            // 
            this.operatingSystem.Text = "OperatingSystem";
            this.operatingSystem.Width = 112;
            // 
            // clientMenuStrip
            // 
            this.clientMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem});
            this.clientMenuStrip.Name = "clientMenuStrip";
            this.clientMenuStrip.Size = new System.Drawing.Size(113, 26);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processManagerToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // processManagerToolStripMenuItem
            // 
            this.processManagerToolStripMenuItem.Name = "processManagerToolStripMenuItem";
            this.processManagerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.processManagerToolStripMenuItem.Text = "Process Manager";
            this.processManagerToolStripMenuItem.Click += new System.EventHandler(this.processManagerToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 310);
            this.Controls.Add(this.clientListView);
            this.Name = "Main";
            this.Text = "CNC";
            this.clientMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader ipAddress;
        private System.Windows.Forms.ColumnHeader operatingSystem;
        private System.Windows.Forms.ListView clientListView;
        private System.Windows.Forms.ContextMenuStrip clientMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processManagerToolStripMenuItem;
    }
}

