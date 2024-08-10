namespace TextCap
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnOpenOutputFolder;

        private void InitializeComponent()
        {
            btnCapture = new Button();
            btnOpenOutputFolder = new Button();
            btnLoad = new Button();
            SuspendLayout();
            // 
            // btnCapture
            // 
            btnCapture.Location = new Point(81, 12);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(175, 22);
            btnCapture.TabIndex = 0;
            btnCapture.Text = "Capture";
            btnCapture.UseVisualStyleBackColor = true;
            btnCapture.Click += btnCapture_Click;
            // 
            // btnOpenOutputFolder
            // 
            btnOpenOutputFolder.Location = new Point(81, 68);
            btnOpenOutputFolder.Name = "btnOpenOutputFolder";
            btnOpenOutputFolder.Size = new Size(175, 22);
            btnOpenOutputFolder.TabIndex = 1;
            btnOpenOutputFolder.Text = "Open Output Folder";
            btnOpenOutputFolder.UseVisualStyleBackColor = true;
            btnOpenOutputFolder.Click += btnOpenOutputFolder_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(81, 40);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(175, 22);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 105);
            Controls.Add(btnLoad);
            Controls.Add(btnCapture);
            Controls.Add(btnOpenOutputFolder);
            Name = "Form1";
            Text = "TextCap";
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Button btnLoad;
    }
}
