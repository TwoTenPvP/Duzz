namespace CNC.Forms
{
    partial class CookieRecovery
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
            this.listView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hostKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.expiresUTC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastAccessUTC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.secure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.httpOnly = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.expired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.persistent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.browser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hostKey,
            this.name,
            this.value,
            this.path,
            this.expiresUTC,
            this.lastAccessUTC,
            this.secure,
            this.httpOnly,
            this.expired,
            this.persistent,
            this.browser});
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(12, 12);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1022, 403);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 113;
            // 
            // hostKey
            // 
            this.hostKey.Text = "Host Key";
            this.hostKey.Width = 109;
            // 
            // value
            // 
            this.value.Text = "Value";
            this.value.Width = 91;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(959, 422);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // path
            // 
            this.path.Text = "Path";
            // 
            // expiresUTC
            // 
            this.expiresUTC.Text = "Expires (UTC)";
            this.expiresUTC.Width = 113;
            // 
            // lastAccessUTC
            // 
            this.lastAccessUTC.Text = "Last Access (UTC)";
            this.lastAccessUTC.Width = 132;
            // 
            // secure
            // 
            this.secure.Text = "Secure";
            // 
            // httpOnly
            // 
            this.httpOnly.Text = "HTTP Only";
            this.httpOnly.Width = 80;
            // 
            // expired
            // 
            this.expired.Text = "Expired";
            // 
            // persistent
            // 
            this.persistent.Text = "Persistent";
            // 
            // browser
            // 
            this.browser.Text = "Browser";
            // 
            // CookieRecovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 457);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listView);
            this.Name = "CookieRecovery";
            this.Text = "Cookie Recovery";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader hostKey;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.ColumnHeader expiresUTC;
        private System.Windows.Forms.ColumnHeader lastAccessUTC;
        private System.Windows.Forms.ColumnHeader secure;
        private System.Windows.Forms.ColumnHeader httpOnly;
        private System.Windows.Forms.ColumnHeader expired;
        private System.Windows.Forms.ColumnHeader persistent;
        private System.Windows.Forms.ColumnHeader browser;
    }
}