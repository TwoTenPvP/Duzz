namespace CNC.Forms
{
    partial class EventControll
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
            this.eventType = new System.Windows.Forms.ComboBox();
            this.lblOn = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.eventToExecute = new System.Windows.Forms.ComboBox();
            this.txtEventParam = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // eventType
            // 
            this.eventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventType.FormattingEnabled = true;
            this.eventType.Items.AddRange(new object[] {
            "Connect",
            "Disconnect",
            "Timer",
            "FirstTimeConnect"});
            this.eventType.Location = new System.Drawing.Point(41, 3);
            this.eventType.Name = "eventType";
            this.eventType.Size = new System.Drawing.Size(121, 21);
            this.eventType.TabIndex = 0;
            // 
            // lblOn
            // 
            this.lblOn.AutoSize = true;
            this.lblOn.Location = new System.Drawing.Point(11, 6);
            this.lblOn.Name = "lblOn";
            this.lblOn.Size = new System.Drawing.Size(24, 13);
            this.lblOn.TabIndex = 1;
            this.lblOn.Text = "On:";
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Location = new System.Drawing.Point(168, 6);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(24, 13);
            this.lblEvent.TabIndex = 3;
            this.lblEvent.Text = "Do:";
            // 
            // eventToExecute
            // 
            this.eventToExecute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventToExecute.FormattingEnabled = true;
            this.eventToExecute.Items.AddRange(new object[] {
            "GetLogin",
            "GetCookies",
            "KillProcessByName",
            "KillProcessById",
            "ElevatePermission",
            "OpenWebsite"});
            this.eventToExecute.Location = new System.Drawing.Point(198, 3);
            this.eventToExecute.Name = "eventToExecute";
            this.eventToExecute.Size = new System.Drawing.Size(121, 21);
            this.eventToExecute.TabIndex = 2;
            // 
            // txtEventParam
            // 
            this.txtEventParam.Location = new System.Drawing.Point(325, 4);
            this.txtEventParam.Name = "txtEventParam";
            this.txtEventParam.Size = new System.Drawing.Size(269, 20);
            this.txtEventParam.TabIndex = 4;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(629, 4);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 5;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // EventControll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtEventParam);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.eventToExecute);
            this.Controls.Add(this.lblOn);
            this.Controls.Add(this.eventType);
            this.Name = "EventControll";
            this.Size = new System.Drawing.Size(688, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblOn;
        private System.Windows.Forms.Label lblEvent;
        public System.Windows.Forms.ComboBox eventType;
        public System.Windows.Forms.ComboBox eventToExecute;
        public System.Windows.Forms.TextBox txtEventParam;
        public System.Windows.Forms.CheckBox chkActive;
    }
}
