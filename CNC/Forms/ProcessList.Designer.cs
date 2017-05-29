﻿namespace CNC.Forms
{
    partial class ProcessList
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
            this.processListView = new System.Windows.Forms.ListView();
            this.processId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.windowTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // processListView
            // 
            this.processListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processId,
            this.processName,
            this.windowTitle});
            this.processListView.FullRowSelect = true;
            this.processListView.Location = new System.Drawing.Point(12, 12);
            this.processListView.Name = "processListView";
            this.processListView.Size = new System.Drawing.Size(743, 385);
            this.processListView.TabIndex = 0;
            this.processListView.UseCompatibleStateImageBehavior = false;
            this.processListView.View = System.Windows.Forms.View.Details;
            // 
            // processId
            // 
            this.processId.Text = "ID";
            this.processId.Width = 77;
            // 
            // processName
            // 
            this.processName.Text = "Name";
            this.processName.Width = 123;
            // 
            // windowTitle
            // 
            this.windowTitle.Text = "Window Title";
            // 
            // ProcessList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 409);
            this.Controls.Add(this.processListView);
            this.Name = "ProcessList";
            this.Text = "ProcessList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView processListView;
        private System.Windows.Forms.ColumnHeader processId;
        private System.Windows.Forms.ColumnHeader processName;
        private System.Windows.Forms.ColumnHeader windowTitle;
    }
}