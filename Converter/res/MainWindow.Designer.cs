namespace Converter
{
    partial class MainWindow
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
            this.ImagetoPDF = new System.Windows.Forms.Button();
            this.PDFtoImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ImagetoPDF
            // 
            this.ImagetoPDF.Location = new System.Drawing.Point(424, 156);
            this.ImagetoPDF.Name = "ImagetoPDF";
            this.ImagetoPDF.Size = new System.Drawing.Size(152, 60);
            this.ImagetoPDF.TabIndex = 0;
            this.ImagetoPDF.Text = "Image to PDF";
            this.ImagetoPDF.UseVisualStyleBackColor = true;
            this.ImagetoPDF.Click += new System.EventHandler(this.btn_ImageToPDF);
            // 
            // PDFtoImage
            // 
            this.PDFtoImage.Location = new System.Drawing.Point(233, 156);
            this.PDFtoImage.Name = "PDFtoImage";
            this.PDFtoImage.Size = new System.Drawing.Size(159, 60);
            this.PDFtoImage.TabIndex = 1;
            this.PDFtoImage.Text = "PDF to Image";
            this.PDFtoImage.UseVisualStyleBackColor = true;
            this.PDFtoImage.Click += new System.EventHandler(this.btn_PDFToImage);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PDFtoImage);
            this.Controls.Add(this.ImagetoPDF);
            this.Name = "MainWindow";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ImagetoPDF;
        private System.Windows.Forms.Button PDFtoImage;
    }
}

