namespace TextCap
{
    partial class ImageForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // ImageForm
            // 
            ClientSize = new Size(800, 600);
            Name = "ImageForm";
            Text = "ROI Selector";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }
    }
}
