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

        Size picBoxSize = new Size(550, 250);
        Image imageOriginal;
        protected string[] pFileNames;
        protected int pCurrentImage = -1;
        string[] filesInFolder;
        int fileIndex;
        string picName;
        bool dragging;
        Point start;

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

            pictureBoxSizeMatch();
        }

        private void zoomSlider_Scroll(object sender, ScrollEventArgs e)
        {
            if (zoomSlider.Value > 0)
            {
                Size change = new Size(zoomSlider.Value * picBoxSize.Width, zoomSlider.Value * picBoxSize.Height);
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
            pictureBoxSizeMatch();
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
            pictureBoxSizeMatch();
        }

        private void pictureBoxSizeMatch()
        {
            if (pictureBox1.Size.Width < splitContainer1.Panel2.Size.Width)
            {
                pictureBox1.Size = splitContainer1.Panel2.Size;
                picBoxSize = splitContainer1.Panel2.Size;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                previousButton.PerformClick();
                return true; //for the active control to see the keypress, return false
            }
            else if (keyData == Keys.Right)
            {
                nextButton.PerformClick();
                return true; //for the active control to see the keypress, return false
            }

            else
                return base.ProcessCmdKey(ref msg, keyData);

            // http://stackoverflow.com/questions/1298640/c-sharp-trying-to-capture-the-keydown-event-on-a-form
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                start = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                pictureBox1.Location = new Point(pictureBox1.Left + e.Location.X - start.X,
                    pictureBox1.Top + e.Location.Y - start.Y);
            }
        }
        // http://stackoverflow.com/questions/8985586/a-simple-panning-picturebox-winforms

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
