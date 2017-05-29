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
            this.accountType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clientMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sleepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hibernateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regeditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elevateApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surveillanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteControllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteWebcamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordExtractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyloggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMessageboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.denialOfServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientListView
            // 
            this.clientListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ipAddress,
            this.operatingSystem,
            this.accountType,
            this.username});
            this.clientListView.FullRowSelect = true;
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
            this.operatingSystem.Width = 280;
            // 
            // accountType
            // 
            this.accountType.Text = "Account Type";
            this.accountType.Width = 124;
            // 
            // username
            // 
            this.username.Text = "Username";
            this.username.Width = 158;
            // 
            // clientMenuStrip
            // 
            this.clientMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.surveillanceToolStripMenuItem,
            this.miscToolStripMenuItem,
            this.applicationToolStripMenuItem});
            this.clientMenuStrip.Name = "clientMenuStrip";
            this.clientMenuStrip.Size = new System.Drawing.Size(153, 114);
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.reconnectToolStripMenuItem,
            this.uninstallToolStripMenuItem,
            this.closeToolStripMenuItem1});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // reconnectToolStripMenuItem
            // 
            this.reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
            this.reconnectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reconnectToolStripMenuItem.Text = "Restart";
            // 
            // uninstallToolStripMenuItem
            // 
            this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            this.uninstallToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.uninstallToolStripMenuItem.Text = "Uninstall";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processManagerToolStripMenuItem,
            this.powerStateToolStripMenuItem,
            this.systemInfoToolStripMenuItem,
            this.startupManagerToolStripMenuItem,
            this.connectionManagerToolStripMenuItem,
            this.regeditToolStripMenuItem,
            this.fileManagerToolStripMenuItem,
            this.elevateApplicationToolStripMenuItem});
            this.systemToolStripMenuItem.Image = global::CNC.Properties.Resources.system_icon;
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // processManagerToolStripMenuItem
            // 
            this.processManagerToolStripMenuItem.Image = global::CNC.Properties.Resources.process_icon;
            this.processManagerToolStripMenuItem.Name = "processManagerToolStripMenuItem";
            this.processManagerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.processManagerToolStripMenuItem.Text = "Process Manager";
            this.processManagerToolStripMenuItem.Click += new System.EventHandler(this.processManagerToolStripMenuItem_Click);
            // 
            // powerStateToolStripMenuItem
            // 
            this.powerStateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shutdownToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.sleepToolStripMenuItem,
            this.hibernateToolStripMenuItem});
            this.powerStateToolStripMenuItem.Image = global::CNC.Properties.Resources.computer_icon;
            this.powerStateToolStripMenuItem.Name = "powerStateToolStripMenuItem";
            this.powerStateToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.powerStateToolStripMenuItem.Text = "Power State";
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Image = global::CNC.Properties.Resources.shutdown_icon;
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Image = global::CNC.Properties.Resources.restart_icon;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // sleepToolStripMenuItem
            // 
            this.sleepToolStripMenuItem.Image = global::CNC.Properties.Resources.sleep_icon;
            this.sleepToolStripMenuItem.Name = "sleepToolStripMenuItem";
            this.sleepToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sleepToolStripMenuItem.Text = "Sleep";
            this.sleepToolStripMenuItem.Click += new System.EventHandler(this.sleepToolStripMenuItem_Click);
            // 
            // hibernateToolStripMenuItem
            // 
            this.hibernateToolStripMenuItem.Image = global::CNC.Properties.Resources.hibernate_icon;
            this.hibernateToolStripMenuItem.Name = "hibernateToolStripMenuItem";
            this.hibernateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hibernateToolStripMenuItem.Text = "Hibernate";
            this.hibernateToolStripMenuItem.Click += new System.EventHandler(this.hibernateToolStripMenuItem_Click);
            // 
            // systemInfoToolStripMenuItem
            // 
            this.systemInfoToolStripMenuItem.Name = "systemInfoToolStripMenuItem";
            this.systemInfoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.systemInfoToolStripMenuItem.Text = "System Info";
            // 
            // startupManagerToolStripMenuItem
            // 
            this.startupManagerToolStripMenuItem.Name = "startupManagerToolStripMenuItem";
            this.startupManagerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.startupManagerToolStripMenuItem.Text = "Startup Manager";
            // 
            // connectionManagerToolStripMenuItem
            // 
            this.connectionManagerToolStripMenuItem.Name = "connectionManagerToolStripMenuItem";
            this.connectionManagerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.connectionManagerToolStripMenuItem.Text = "Connection Manager";
            // 
            // regeditToolStripMenuItem
            // 
            this.regeditToolStripMenuItem.Name = "regeditToolStripMenuItem";
            this.regeditToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.regeditToolStripMenuItem.Text = "Regedit";
            // 
            // fileManagerToolStripMenuItem
            // 
            this.fileManagerToolStripMenuItem.Name = "fileManagerToolStripMenuItem";
            this.fileManagerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.fileManagerToolStripMenuItem.Text = "File Manager";
            // 
            // elevateApplicationToolStripMenuItem
            // 
            this.elevateApplicationToolStripMenuItem.Image = global::CNC.Properties.Resources.uac_icon1;
            this.elevateApplicationToolStripMenuItem.Name = "elevateApplicationToolStripMenuItem";
            this.elevateApplicationToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.elevateApplicationToolStripMenuItem.Text = "Elevate Application";
            this.elevateApplicationToolStripMenuItem.Click += new System.EventHandler(this.elevateApplicationToolStripMenuItem_Click);
            // 
            // surveillanceToolStripMenuItem
            // 
            this.surveillanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteControllToolStripMenuItem,
            this.remoteWebcamToolStripMenuItem,
            this.passwordExtractToolStripMenuItem,
            this.keyloggerToolStripMenuItem});
            this.surveillanceToolStripMenuItem.Image = global::CNC.Properties.Resources.spy_icon;
            this.surveillanceToolStripMenuItem.Name = "surveillanceToolStripMenuItem";
            this.surveillanceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.surveillanceToolStripMenuItem.Text = "Surveillance";
            // 
            // remoteControllToolStripMenuItem
            // 
            this.remoteControllToolStripMenuItem.Image = global::CNC.Properties.Resources.mouse_icon;
            this.remoteControllToolStripMenuItem.Name = "remoteControllToolStripMenuItem";
            this.remoteControllToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.remoteControllToolStripMenuItem.Text = "Remote Dekstop";
            this.remoteControllToolStripMenuItem.Click += new System.EventHandler(this.remoteControllToolStripMenuItem_Click);
            // 
            // remoteWebcamToolStripMenuItem
            // 
            this.remoteWebcamToolStripMenuItem.Name = "remoteWebcamToolStripMenuItem";
            this.remoteWebcamToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.remoteWebcamToolStripMenuItem.Text = "Remote Webcam";
            // 
            // passwordExtractToolStripMenuItem
            // 
            this.passwordExtractToolStripMenuItem.Name = "passwordExtractToolStripMenuItem";
            this.passwordExtractToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.passwordExtractToolStripMenuItem.Text = "Password Extract";
            // 
            // keyloggerToolStripMenuItem
            // 
            this.keyloggerToolStripMenuItem.Name = "keyloggerToolStripMenuItem";
            this.keyloggerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.keyloggerToolStripMenuItem.Text = "Keylogger";
            // 
            // miscToolStripMenuItem
            // 
            this.miscToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMessageboxToolStripMenuItem,
            this.scriptingToolStripMenuItem,
            this.denialOfServiceToolStripMenuItem,
            this.openWebsiteToolStripMenuItem});
            this.miscToolStripMenuItem.Image = global::CNC.Properties.Resources.settings_icon;
            this.miscToolStripMenuItem.Name = "miscToolStripMenuItem";
            this.miscToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.miscToolStripMenuItem.Text = "Misc";
            // 
            // showMessageboxToolStripMenuItem
            // 
            this.showMessageboxToolStripMenuItem.Name = "showMessageboxToolStripMenuItem";
            this.showMessageboxToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.showMessageboxToolStripMenuItem.Text = "Show Messagebox";
            this.showMessageboxToolStripMenuItem.Click += new System.EventHandler(this.showMessageboxToolStripMenuItem_Click);
            // 
            // scriptingToolStripMenuItem
            // 
            this.scriptingToolStripMenuItem.Name = "scriptingToolStripMenuItem";
            this.scriptingToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.scriptingToolStripMenuItem.Text = "Scripting";
            // 
            // denialOfServiceToolStripMenuItem
            // 
            this.denialOfServiceToolStripMenuItem.Name = "denialOfServiceToolStripMenuItem";
            this.denialOfServiceToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.denialOfServiceToolStripMenuItem.Text = "Denial of Service";
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Image = global::CNC.Properties.Resources.close_icon1;
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem1_Click);
            // 
            // openWebsiteToolStripMenuItem
            // 
            this.openWebsiteToolStripMenuItem.Name = "openWebsiteToolStripMenuItem";
            this.openWebsiteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.openWebsiteToolStripMenuItem.Text = "Open Website";
            this.openWebsiteToolStripMenuItem.Click += new System.EventHandler(this.openWebsiteToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem powerStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sleepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hibernateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem surveillanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteControllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miscToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader accountType;
        private System.Windows.Forms.ColumnHeader username;
        private System.Windows.Forms.ToolStripMenuItem showMessageboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem denialOfServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteWebcamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordExtractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyloggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regeditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elevateApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uninstallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openWebsiteToolStripMenuItem;
    }
}

