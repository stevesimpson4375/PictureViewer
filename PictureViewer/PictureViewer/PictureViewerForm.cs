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

    public partial class PictureViewer : Form
    {

        Size picBoxSize = new Size(550, 250);
        Image imageOriginal;
        protected string[] pFileNames;
        protected int pCurrentImage = -1;
        String[] filesInFolder;
        List<String> filesInFolderWithValidExtension = new List<String>();
        int fileIndex;
        string picName;
        bool dragging;
        Point start;
        Point basePoint = new Point(0, 0);
        string nextPic;

        public PictureViewer()
        {
            InitializeComponent();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // This button allows the user to search for a file, view it, and create 
            // a string[] of filepaths of the other files in the same directory

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (CheckIfValidFileType(openFileDialog1.FileName))
                {
                    LoadNewPictureAndFileNames();
                }
                else
                {
                    MessageBox.Show("You can only select image files","Error");
                }
            }
        }

        private void zoomSlider_Scroll(object sender, ScrollEventArgs e)
        {
            if (zoomSlider.Value > 1)
            {
                pictureBox1.Size = new Size(zoomSlider.Value * picBoxSize.Width, zoomSlider.Value * picBoxSize.Height);
				panOnSize(pictureBox1.Size);
            }
            else
            {
                pictureBox1.Size = new Size(zoomSlider.Value * picBoxSize.Width, zoomSlider.Value * picBoxSize.Height);
                pictureBox1.Location = basePoint;
            }
			
        }
		
		private void panOnSize(Size pictureSize)
		{
			pictureBox1.Location = new Point(-pictureSize.Width/4,-pictureSize.Height/4);
		}

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            // The next button increments the current index for the string[] and loads the next filepath
            nextPic = "";
            if (fileIndex < filesInFolderWithValidExtension.Count - 1)
            {
                nextPic = filesInFolderWithValidExtension[++fileIndex];
            }
            else
            {
                fileIndex = 0;
                nextPic = filesInFolderWithValidExtension[0];
            }
            LoadNewPicture();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            nextPic = "";
            if (fileIndex > 0)
            {
                nextPic = filesInFolderWithValidExtension[--fileIndex];
            }
            else
            {
                fileIndex = filesInFolderWithValidExtension.Count;
                nextPic = filesInFolderWithValidExtension[--fileIndex];
            }
            LoadNewPicture();
        }

        // This method matches the pictureBox size to the panel
        private void pictureBoxSizeMatch()
        {
            pictureBox1.Size = splitContainer1.Panel2.Size;
            picBoxSize = splitContainer1.Panel2.Size;
            pictureBox1.Location = basePoint;
        }

        // This method allows the arrow keys to operate buttons
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

        // The mouse down event finds the location of the mouse click and determines that the mouse is dragging,
        // the dragging boolean is set to false with mouseClickUp
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                start = e.Location;
            }
        }

        // Dragging the mouse after clicking pans the picture
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                pictureBox1.Location = new Point(pictureBox1.Left + e.Location.X - start.X,
                    pictureBox1.Top + e.Location.Y - start.Y);
            }
        }
        // http://stackoverflow.com/questions/8985586/a-simple-panning-picturebox-winforms

        // Releasing the mouse button stops the panning
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        // The pictureBox is resized when the user changes the size of the form
        private void PictureViewer_Resize(object sender, EventArgs e)
        {
            pictureBoxSizeMatch();
        }

        // Loading a new picture through the open file dialog must do some resizing and create a new string[] of file names
        private void LoadNewPictureAndFileNames()
        {
            imageOriginal = Image.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = imageOriginal;
            picName = openFileDialog1.FileName;

            filesInFolder = Directory.GetFiles(Path.GetDirectoryName(openFileDialog1.FileName));

            filesInFolderWithValidExtension.Clear(); // required to remove any previous selections

            for (int x = 0; x < filesInFolder.Length; ++x)
            {
                if (CheckIfValidFileType(filesInFolder[x]))
                {
                    filesInFolderWithValidExtension.Add(filesInFolder[x]);
                }
            }
            
            // This for statement determines where the picture the user selected is in the string array
            for (int x = 0; x < filesInFolderWithValidExtension.Count; ++x)
            {
                if (picName.Equals(filesInFolderWithValidExtension[x]))
                {
                    fileIndex = x;
                }
            }
            pictureBoxSizeMatch();
        }

        // Loading a new picture requires setting the next filepath, loading a pic, and resizing the picturebox
        private void LoadNewPicture()
        {
            pictureBox1.Image.Dispose();
            try
            {
                pictureBox1.Image = Image.FromFile(nextPic);
                pictureBoxSizeMatch();
            }
            catch (OutOfMemoryException) { }; // This error is most likely a file that cannot be open, so it is skipped
        }

        private bool CheckIfValidFileType(string fileToCheck)
        {
            bool isValid = false;

            if (fileToCheck.EndsWith(".jpg") || fileToCheck.EndsWith(".png") || fileToCheck.EndsWith(".gif"))
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
