namespace BlendSlideShow
{
    partial class Form2
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
            this.pan_image = new System.Windows.Forms.Panel();
            this.pan_layer = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pan_image.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_image
            // 
            this.pan_image.Controls.Add(this.pan_layer);
            this.pan_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_image.Location = new System.Drawing.Point(0, 0);
            this.pan_image.Name = "pan_image";
            this.pan_image.Size = new System.Drawing.Size(284, 262);
            this.pan_image.TabIndex = 0;
            // 
            // pan_layer
            // 
            this.pan_layer.Location = new System.Drawing.Point(42, 103);
            this.pan_layer.Name = "pan_layer";
            this.pan_layer.Size = new System.Drawing.Size(200, 100);
            this.pan_layer.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pan_image);
            this.Name = "Form2";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pan_image.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_image;
        private System.Windows.Forms.Panel pan_layer;
        private System.Windows.Forms.Timer timer1;
    }
}