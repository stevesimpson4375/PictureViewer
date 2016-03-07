using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Form1 : Form
    {
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

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                picName = openFileDialog1.FileName;
            }
            filesInFolder = Directory.GetFiles(@"F:\documents\pics\1\al");
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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
            pictureBox1.Load(nextPic);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
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
            pictureBox1.Load(nextPic);
        }

        // http://stackoverflow.com/questions/13393606/image-viewer-c-sharp-next-button
        // https://msdn.microsoft.com/en-us/library/bb882649.aspx
    }
}
