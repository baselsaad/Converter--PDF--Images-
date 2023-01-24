using ImageMagick;
using System;
using System.IO;
using System.Windows.Forms;

namespace Converter
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

#if DEBUG
            string root = Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory));
            string ghostscriptPath = Path.Combine(root, @"..\..\vendor\Ghostscript\bin");
#else
            string ghostscriptPath = @"vendor\Ghostscript\bin\"; //the vendor should be copied to the release Folder
#endif

            MagickNET.SetGhostscriptDirectory(ghostscriptPath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
