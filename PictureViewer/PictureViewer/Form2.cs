﻿using System;
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

    public partial class Form2 : Form
    {

        Size original = new Size(550, 250);
        Image imageOriginal;
        protected string[] pFileNames;
        protected int pCurrentImage = -1;
        string[] filesInFolder;
        int fileIndex;
        string picName;

        public Form2()
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

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (hScrollBar1.Value > 0)
            {
                Size change = new Size(hScrollBar1.Value * original.Width, hScrollBar1.Value * original.Height);
                pictureBox1.Size = change;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
