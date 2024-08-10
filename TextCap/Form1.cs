using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace TextCap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            // Logic to start the capture process
            // Example: Open ImageForm for screenshot
            using (var screenshotForm = new ImageForm(GetScreenshot()))
            {
                screenshotForm.ShowDialog();
            }
        }

        private void btnOpenOutputFolder_Click(object sender, EventArgs e)
        {
            // Define output folder path
            string outputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");

            // Check if the folder exists
            if (Directory.Exists(outputFolder))
            {
                // Open the output folder
                Process.Start("explorer.exe", outputFolder);
            }
            else
            {
                MessageBox.Show("Output folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap GetScreenshot()
        {
            // Implement your screenshot capture logic here
            // This is a placeholder implementation
            var bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (var gfx = Graphics.FromImage(bmp))
            {
                gfx.CopyFromScreen(0, 0, 0, 0, bmp.Size);
            }
            return bmp;
        }

        // Other event handlers and methods for Form1
    }
}
