﻿namespace BlendSlideShow
{
    partial class Form1
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
            this.blendPanel1 = new BlendPanel.BlendPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // blendPanel1
            // 
            this.blendPanel1.Blend = 0F;
            this.blendPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blendPanel1.Image1 = null;
            this.blendPanel1.Image2 = null;
            this.blendPanel1.Location = new System.Drawing.Point(0, 0);
            this.blendPanel1.Name = "blendPanel1";
            this.blendPanel1.Size = new System.Drawing.Size(284, 262);
            this.blendPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.blendPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private BlendPanel.BlendPanel blendPanel1;
        private System.Windows.Forms.Timer timer1;
    }
}

