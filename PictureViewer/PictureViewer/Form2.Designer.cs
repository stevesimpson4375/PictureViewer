namespace PictureViewer
{
    partial class PictureViewer
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openPicture = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.zoomSlider = new System.Windows.Forms.HScrollBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(659, 322);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // openPicture
            // 
            this.openPicture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.openPicture.Location = new System.Drawing.Point(129, 9);
            this.openPicture.Name = "openPicture";
            this.openPicture.Size = new System.Drawing.Size(88, 23);
            this.openPicture.TabIndex = 1;
            this.openPicture.Text = "Open a Picture";
            this.openPicture.UseVisualStyleBackColor = true;
            this.openPicture.Click += new System.EventHandler(this.showButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "All Files|*.*|Image Files|*.jpg;*png;*gif";
            this.openFileDialog1.FilterIndex = 2;
            // 
            // zoomSlider
            // 
            this.zoomSlider.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.zoomSlider.LargeChange = 1;
            this.zoomSlider.Location = new System.Drawing.Point(474, 9);
            this.zoomSlider.Maximum = 20;
            this.zoomSlider.Minimum = 1;
            this.zoomSlider.Name = "zoomSlider";
            this.zoomSlider.Size = new System.Drawing.Size(182, 17);
            this.zoomSlider.TabIndex = 3;
            this.zoomSlider.Value = 1;
            this.zoomSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.zoomSlider_Scroll);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.zoomLabel);
            this.splitContainer1.Panel1.Controls.Add(this.nextButton);
            this.splitContainer1.Panel1.Controls.Add(this.previousButton);
            this.splitContainer1.Panel1.Controls.Add(this.closeButton);
            this.splitContainer1.Panel1.Controls.Add(this.openPicture);
            this.splitContainer1.Panel1.Controls.Add(this.zoomSlider);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(665, 392);
            this.splitContainer1.SplitterDistance = 42;
            this.splitContainer1.TabIndex = 4;
            this.splitContainer1.TabStop = false;
            // 
            // zoomLabel
            // 
            this.zoomLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.zoomLabel.AutoSize = true;
            this.zoomLabel.Location = new System.Drawing.Point(436, 9);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(34, 13);
            this.zoomLabel.TabIndex = 7;
            this.zoomLabel.Text = "Zoom";
            // 
            // nextButton
            // 
            this.nextButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nextButton.Location = new System.Drawing.Point(304, 9);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 3;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.previousButton.Location = new System.Drawing.Point(223, 9);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(75, 23);
            this.previousButton.TabIndex = 2;
            this.previousButton.Text = "Previous";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.closeButton.Location = new System.Drawing.Point(12, 9);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // PictureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(665, 392);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PictureViewer";
            this.Text = "PictureViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.PictureViewer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button openPicture;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.HScrollBar zoomSlider;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Label zoomLabel;
    }
}