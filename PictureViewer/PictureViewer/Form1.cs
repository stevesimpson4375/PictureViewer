using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Form1 : Form
    {
        Image imageOriginal;
        protected string[] pFileNames;
        protected int pCurrentImage = -1;
        string[] filesInFolder;
        int fileIndex;
        string picName;

        public Form1()
        {
            InitializeComponent();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // This button allows the user to search for a file, view it, and create 
            // a string[] of filepaths of the other files in the same directory
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imageOriginal = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = imageOriginal;
                picName = openFileDialog1.FileName;
            }
            filesInFolder = Directory.GetFiles(Path.GetDirectoryName(openFileDialog1.FileName));

            // This for statement determines where the picture the user selected is in the string array
            for (int x = 0; x < filesInFolder.Length; ++x)
            {
                if (picName.Equals(filesInFolder[x]))
                {
                    fileIndex = x;
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // This checkbox currently switches between being able to zoom and fullscreen
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            string nextPic = "";
            if (fileIndex > 0)
            {
                nextPic = filesInFolder[--fileIndex];
            }
            else
            {
                fileIndex = filesInFolder.Length;
                nextPic = filesInFolder[--fileIndex];
            }
            imageOriginal = Image.FromFile(nextPic);
            pictureBox1.Image = imageOriginal;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            // The next button increments the current index for the string[] and loads the next filepath
            string nextPic = "";
            if (fileIndex < filesInFolder.Length - 1)
            {
                nextPic = filesInFolder[++fileIndex];
            }
            else
            {
                fileIndex = 0;
                nextPic = filesInFolder[0];
            }
            imageOriginal = Image.FromFile(nextPic);
            pictureBox1.Image = imageOriginal;
        }

        public Image PictureBoxZoom(Image img, Size size)
        {
            Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * size.Width), Convert.ToInt32(img.Height * size.Height));
            Graphics grap = Graphics.FromImage(bm);
            grap.InterpolationMode = InterpolationMode.HighQualityBicubic;
            return bm;
        }

        private void zoomSlider_Scroll(object sender, ScrollEventArgs e)
        {
            if (zoomSlider.Value > 0)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = PictureBoxZoom(imageOriginal, new Size(zoomSlider.Value, zoomSlider.Value));
            }
        }

        // http://stackoverflow.com/questions/13393606/image-viewer-c-sharp-next-button
        // https://msdn.microsoft.com/en-us/library/bb882649.aspx
        // http://www.dotnetcurry.com/ShowArticle.aspx?ID=196
    }
}
