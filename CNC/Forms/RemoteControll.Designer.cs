namespace CNC.Forms
{
    partial class RemoteControll
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
            this.screenImage = new System.Windows.Forms.PictureBox();
            this.statusButton = new System.Windows.Forms.Button();
            this.numericMonitor = new System.Windows.Forms.NumericUpDown();
            this.txtFps = new System.Windows.Forms.Label();
            this.trkFps = new System.Windows.Forms.TrackBar();
            this.txtCurrMon = new System.Windows.Forms.Label();
            this.chkControlMouse = new System.Windows.Forms.CheckBox();
            this.chkControlKeyboard = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.screenImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkFps)).BeginInit();
            this.SuspendLayout();
            // 
            // screenImage
            // 
            this.screenImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.screenImage.Location = new System.Drawing.Point(12, 12);
            this.screenImage.Name = "screenImage";
            this.screenImage.Size = new System.Drawing.Size(640, 480);
            this.screenImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.screenImage.TabIndex = 0;
            this.screenImage.TabStop = false;
            this.screenImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.screenImage_MouseClick);
            this.screenImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.screenImage_MouseMove);
            // 
            // statusButton
            // 
            this.statusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusButton.Location = new System.Drawing.Point(12, 525);
            this.statusButton.Name = "statusButton";
            this.statusButton.Size = new System.Drawing.Size(75, 23);
            this.statusButton.TabIndex = 1;
            this.statusButton.Text = "Start";
            this.statusButton.UseVisualStyleBackColor = true;
            this.statusButton.Click += new System.EventHandler(this.statusButton_Click);
            // 
            // numericMonitor
            // 
            this.numericMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericMonitor.Location = new System.Drawing.Point(532, 528);
            this.numericMonitor.Name = "numericMonitor";
            this.numericMonitor.Size = new System.Drawing.Size(120, 20);
            this.numericMonitor.TabIndex = 3;
            this.numericMonitor.ValueChanged += new System.EventHandler(this.numericMonitor_ValueChanged);
            // 
            // txtFps
            // 
            this.txtFps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFps.AutoSize = true;
            this.txtFps.Location = new System.Drawing.Point(203, 530);
            this.txtFps.Name = "txtFps";
            this.txtFps.Size = new System.Drawing.Size(51, 13);
            this.txtFps.TabIndex = 4;
            this.txtFps.Text = "10.0 FPS";
            // 
            // trkFps
            // 
            this.trkFps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trkFps.Location = new System.Drawing.Point(93, 525);
            this.trkFps.Maximum = 30;
            this.trkFps.Name = "trkFps";
            this.trkFps.Size = new System.Drawing.Size(104, 45);
            this.trkFps.TabIndex = 5;
            this.trkFps.Value = 10;
            this.trkFps.Scroll += new System.EventHandler(this.trkFps_Scroll);
            // 
            // txtCurrMon
            // 
            this.txtCurrMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrMon.AutoSize = true;
            this.txtCurrMon.Location = new System.Drawing.Point(447, 530);
            this.txtCurrMon.Name = "txtCurrMon";
            this.txtCurrMon.Size = new System.Drawing.Size(79, 13);
            this.txtCurrMon.TabIndex = 6;
            this.txtCurrMon.Text = "Current Monitor";
            // 
            // chkControlMouse
            // 
            this.chkControlMouse.AutoSize = true;
            this.chkControlMouse.Location = new System.Drawing.Point(12, 502);
            this.chkControlMouse.Name = "chkControlMouse";
            this.chkControlMouse.Size = new System.Drawing.Size(94, 17);
            this.chkControlMouse.TabIndex = 7;
            this.chkControlMouse.Text = "Control Mouse";
            this.chkControlMouse.UseVisualStyleBackColor = true;
            // 
            // chkControlKeyboard
            // 
            this.chkControlKeyboard.AutoSize = true;
            this.chkControlKeyboard.Location = new System.Drawing.Point(112, 502);
            this.chkControlKeyboard.Name = "chkControlKeyboard";
            this.chkControlKeyboard.Size = new System.Drawing.Size(107, 17);
            this.chkControlKeyboard.TabIndex = 8;
            this.chkControlKeyboard.Text = "Control Keyboard";
            this.chkControlKeyboard.UseVisualStyleBackColor = true;
            // 
            // RemoteControll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 560);
            this.Controls.Add(this.chkControlKeyboard);
            this.Controls.Add(this.chkControlMouse);
            this.Controls.Add(this.txtCurrMon);
            this.Controls.Add(this.trkFps);
            this.Controls.Add(this.txtFps);
            this.Controls.Add(this.numericMonitor);
            this.Controls.Add(this.statusButton);
            this.Controls.Add(this.screenImage);
            this.Name = "RemoteControll";
            this.Text = "RemoteControll";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemoteControll_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.screenImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkFps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox screenImage;
        private System.Windows.Forms.Button statusButton;
        private System.Windows.Forms.NumericUpDown numericMonitor;
        private System.Windows.Forms.Label txtFps;
        private System.Windows.Forms.TrackBar trkFps;
        private System.Windows.Forms.Label txtCurrMon;
        private System.Windows.Forms.CheckBox chkControlMouse;
        private System.Windows.Forms.CheckBox chkControlKeyboard;
    }
}