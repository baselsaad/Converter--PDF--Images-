using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using ImageMagick;
using static System.Net.Mime.MediaTypeNames;

namespace Converter
{
    class ConverterUtil
    {
        public static void ImagesToPdf(string[] imagePath, string pdfPath)
        {
            using (MagickImageCollection imageCollection = new MagickImageCollection())
            {
                // Add multiple images to the collection
                foreach (var image in imagePath)
                {
                    imageCollection.Add(image);
                }

                // Write the collection to a single pdf
                imageCollection.Write(pdfPath);
            }
        }

        public static void PdfToImage(string pdfFilePath, string imagePath)
        {
            string newFolderPath = Path.Combine(imagePath, "ConvertedImages");

            // if Directory Exists, change the name, to avoid overwriting the existing one!
            int i = 1;
            string copyName = newFolderPath;
            while(Directory.Exists(newFolderPath))
            {
                newFolderPath = copyName;
                newFolderPath += "("+i+")";
                i++;
            }

            Directory.CreateDirectory(newFolderPath);

            using (MagickImageCollection images = new MagickImageCollection())
            {
                var settings = new MagickReadSettings();
                settings.Density = new Density(300);

                // Add all the pages of the pdf file to the collection
                images.Read(pdfFilePath, settings);

                // Iterate through each page and save it as an image
                int pageNumber = 1;
                foreach (MagickImage image in images)
                {
                    // Set the image format and quality
                    image.Format = MagickFormat.Jpeg;
                    image.Quality = 100;

                    // Save the image in the new folder
                    string imageFileName = string.Format("{0}.jpg", pageNumber);
                    string imageFilePath = Path.Combine(newFolderPath, imageFileName);
                    image.Write(imageFilePath);

                    pageNumber++;
                }

            }
        }
    }

}
