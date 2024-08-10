using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;

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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }

            using (var screenshotForm = new ImageForm(ConvertToBmp(filePath)))
            {
                screenshotForm.ShowDialog();
            }
        }

        private Bitmap ConvertToBmp(string filePath)
        {
            try
            {
                using (Image image = Image.FromFile(filePath))
                {
                    // If the image is already in BMP format, return it as-is
                    if (image.RawFormat.Equals(ImageFormat.Bmp))
                        return new Bitmap(image);

                    // Otherwise, convert and save the image as BMP
                    string bmpPath = Path.ChangeExtension(filePath, ".bmp");
                    using (Bitmap bmp = new Bitmap(image))
                    {
                        bmp.Save(bmpPath, ImageFormat.Bmp);
                    }
                    return new Bitmap(bmpPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading or converting image: {ex.Message}");
                return null;
            }
        }

        // Other event handlers and methods for Form1
    }
}
