using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Tesseract;

namespace TextCap
{
    public partial class ImageForm : Form
    {
        private Bitmap _screenshot;
        private Rectangle _roi;
        private Bitmap _buffer;

        public ImageForm(Bitmap screenshot)
        {
            InitializeComponent();
            _screenshot = screenshot;
            this.BackgroundImage = _screenshot;
            this.DoubleBuffered = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _roi = new Rectangle(e.Location, Size.Empty);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                _roi.Size = new Size(e.X - _roi.X, e.Y - _roi.Y);
                Invalidate(); // Trigger OnPaint
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                using (Bitmap croppedBitmap = new Bitmap(_roi.Width, _roi.Height))
                {
                    using (Graphics g = Graphics.FromImage(croppedBitmap))
                    {
                        g.DrawImage(_screenshot, 0, 0, _roi, GraphicsUnit.Pixel);
                    }

                    // Convert Bitmap to Pix
                    Pix pix;
                    using (var ms = new MemoryStream())
                    {
                        croppedBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        ms.Seek(0, SeekOrigin.Begin);
                        pix = Pix.LoadFromMemory(ms.ToArray());
                    }

                    // Extract text
                    string extractedText;
                    using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                    {
                        using (var page = engine.Process(pix))
                        {
                            extractedText = page.GetText();
                        }
                    }

                    // Define output folder path
                    string outputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
                    Directory.CreateDirectory(outputFolder);

                    // Save to file in output folder
                    string fileName = $"TextCap_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                    string filePath = Path.Combine(outputFolder, fileName);
                    File.WriteAllText(filePath, extractedText);

                    // Show notification
                    var result = MessageBox.Show($"File saved as {fileName}\n Do you want to open the folder?", "File Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{filePath}\"");
                    }
                }

                this.Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_screenshot != null)
            {
                // Draw the screenshot to the off-screen buffer
                if (_buffer == null || _buffer.Width != this.ClientSize.Width || _buffer.Height != this.ClientSize.Height)
                {
                    _buffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
                }
                using (Graphics g = Graphics.FromImage(_buffer))
                {
                    g.DrawImage(_screenshot, Point.Empty);
                    if (_roi != Rectangle.Empty)
                    {
                        using (Pen pen = new Pen(Color.Red, 2))
                        {
                            g.DrawRectangle(pen, _roi);
                        }
                    }
                }
                e.Graphics.DrawImage(_buffer, Point.Empty);
            }
        }
    }
}
