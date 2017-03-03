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
    public partial class SlideShow : Form
    {

        // variables
        DrawPanel pan_image = new DrawPanel();
        DrawPanel pan_layer = new DrawPanel();
        Timer timer1 = new Timer();
        List<string> imageFiles = null;
        int counter = 0;
        int secondsToWait = 10;
        int speed1 = 20;           // tick speed ms
        int speed2 = 5;            // alpha (0-255) change speed
        int dir = 8;               // direction >0 : fade-in..
        string imagefolder = "";
        int index = 1;

        public SlideShow()
        {
            InitializeComponent();
            pan_image.Parent = this;
            pan_layer.Parent = this;
            imagefolder = GetImgFolderPath();
        }

        private string GetImgFolderPath()
        {
            string _Path = Path.GetDirectoryName(Application.ExecutablePath) + @"\..\..\images\";
            return _Path;
        }

        private void SlideShow_Load(object sender, EventArgs e)
        {


            imageFiles = Directory.GetFiles(imagefolder, "*.jpg", SearchOption.AllDirectories).ToList();
            //imageFiles = imageFiles.OrderBy(a => Guid.NewGuid()).ToList();

            pan_image.BackgroundImage = Image.FromFile(imageFiles[0]);
            pan_image.Dock = DockStyle.Fill;
            pan_layer.Parent = pan_image;
            pan_layer.BackColor = pan_image.BackColor;
            pan_layer.Dock = DockStyle.Fill;

            pan_image.BackgroundImageLayout = ImageLayout.Zoom;
            pan_layer.BackgroundImageLayout = ImageLayout.Zoom;

            timer1.Tick += timer1_Tick;
            timer1.Interval = speed1;
            timer1.Start();

        }

        bool changeImage()
        {
            if (pan_image.BackgroundImage != null)
            {
                var img = pan_image.BackgroundImage;
                pan_image.BackgroundImage = null;
                img.Dispose();
            }
            pan_image.BackgroundImage = Image.FromFile(imageFiles[index++]);
            return index < imageFiles.Count;
        }

        void timer1_Tick(object sender, EventArgs e)
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
                if (!changeImage()) timer1.Stop();
                dir = speed2;
            }
            // create the new, semi-transparent color:
            Color col = Color.FromArgb(255 - alpha, pan_image.BackColor);
            // display the layer:
            pan_layer.BackColor = col;
            pan_layer.Refresh();
        }
    }

    class DrawPanel : Panel
    {
        public DrawPanel() { DoubleBuffered = true; }
    }
}
