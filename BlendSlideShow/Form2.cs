using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlendSlideShow
{
    public partial class Form2 : Form
    {
        int counter = 0;
        int dir = 1;               // direction 1 = fade-in..
        int secondsToWait = 5;
        int speed1 = 25;           // tick speed ms
        int speed2 = 4; 

        public Form2()
        {
            InitializeComponent();

            pan_image.BackgroundImage = new Bitmap(GetImgFolderPath() + "img1.jpg");
            pan_layer.Parent = pan_image;
            pan_layer.BackColor = pan_image.BackColor;
            pan_layer.Size = pan_image.Size;
            pan_layer.Location = Point.Empty;
        }

        private string GetImgFolderPath()
        {
            string _Path = Path.GetDirectoryName(Application.ExecutablePath) + @"\..\..\images\";
            return _Path;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // we have just waited and now we fade-out:
            if (dir == 0)
            {
                timer1.Stop();
                dir = -speed2;
                counter = 254;
                timer1.Interval = speed2;
                timer1.Start();
            }

            // the next alpha value:
            int alpha = Math.Min(Math.Max(0, counter += dir), 255);

            //button1.Text = dir > 0 ? "Fade In" : "Fade Out";

            // fully faded-in: set up the long wait:
            if (counter >= 255)
            {
                timer1.Stop();
                //button1.Text = "Wait";
                timer1.Interval = secondsToWait * 1000;
                dir = 0;
                timer1.Start();


            }
            // fully faded-out: try to load a new image and set direction to fade-in or stop
            else if (counter <= 0)
            {
                //if (!changeImage())
                //{
                //    timer1.Stop();
                //    //button1.Text = "Done";
                //}
                dir = speed2;
            }

            // create the new, semi-transparent color:
            Color col = Color.FromArgb(255 - alpha, pan_image.BackColor);
            // display the layer:
            pan_layer.BackColor = col;
            pan_layer.Refresh();
        }

        //bool changeImage() { 
        //    pan_image.BackgroundImage = Image.FromFile(imageFiles[++index]); 
        //    return index < imageFiles.Count; 
        //}
    }
}
