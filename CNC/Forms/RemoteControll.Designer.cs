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
            this.numericFrameRate = new System.Windows.Forms.NumericUpDown();
            this.numericMonitor = new System.Windows.Forms.NumericUpDown();
            this.txtFps = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.screenImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFrameRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMonitor)).BeginInit();
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
            this.screenImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.screenImage.TabIndex = 0;
            this.screenImage.TabStop = false;
            // 
            // statusButton
            // 
            this.statusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusButton.Location = new System.Drawing.Point(12, 501);
            this.statusButton.Name = "statusButton";
            this.statusButton.Size = new System.Drawing.Size(75, 23);
            this.statusButton.TabIndex = 1;
            this.statusButton.Text = "Start";
            this.statusButton.UseVisualStyleBackColor = true;
            this.statusButton.Click += new System.EventHandler(this.statusButton_Click);
            // 
            // numericFrameRate
            // 
            this.numericFrameRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericFrameRate.Location = new System.Drawing.Point(93, 504);
            this.numericFrameRate.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericFrameRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericFrameRate.Name = "numericFrameRate";
            this.numericFrameRate.Size = new System.Drawing.Size(120, 20);
            this.numericFrameRate.TabIndex = 2;
            this.numericFrameRate.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericFrameRate.ValueChanged += new System.EventHandler(this.numericFrameRate_ValueChanged);
            // 
            // numericMonitor
            // 
            this.numericMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericMonitor.Location = new System.Drawing.Point(532, 504);
            this.numericMonitor.Name = "numericMonitor";
            this.numericMonitor.Size = new System.Drawing.Size(120, 20);
            this.numericMonitor.TabIndex = 3;
            this.numericMonitor.ValueChanged += new System.EventHandler(this.numericMonitor_ValueChanged);
            // 
            // txtFps
            // 
            this.txtFps.AutoSize = true;
            this.txtFps.Location = new System.Drawing.Point(294, 511);
            this.txtFps.Name = "txtFps";
            this.txtFps.Size = new System.Drawing.Size(27, 13);
            this.txtFps.TabIndex = 4;
            this.txtFps.Text = "FPS";
            // 
            // RemoteControll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 536);
            this.Controls.Add(this.txtFps);
            this.Controls.Add(this.numericMonitor);
            this.Controls.Add(this.numericFrameRate);
            this.Controls.Add(this.statusButton);
            this.Controls.Add(this.screenImage);
            this.Name = "RemoteControll";
            this.Text = "RemoteControll";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RemoteControll_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.screenImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFrameRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMonitor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox screenImage;
        private System.Windows.Forms.Button statusButton;
        private System.Windows.Forms.NumericUpDown numericFrameRate;
        private System.Windows.Forms.NumericUpDown numericMonitor;
        private System.Windows.Forms.Label txtFps;
    }
}