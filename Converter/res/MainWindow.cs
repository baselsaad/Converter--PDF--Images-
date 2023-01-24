using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Converter.res;

namespace Converter
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_PDFToImage(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Supported Files (*.pdf)|";
            openFileDialog.Multiselect = false;
            openFileDialog.SupportMultiDottedExtensions = false;
            openFileDialog.CheckFileExists = true;
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var file = openFileDialog.FileName;
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

                string output = "";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    output = folderBrowserDialog.SelectedPath;
                    if (output.Trim().Length == 0)
                    {
                        ShowErrorMessage("Select output path!!");
                        return;
                    }
                }
                else
                {
                    ShowErrorMessage("Select output path!!");
                    return;
                }

                output += @"\";
                Action lambda = () => { ConverterUtil.PdfToImage(file, output); };
                using (Loading loading = new Loading(lambda))
                {
                    loading.ShowDialog(this);
                }

            }
        }

        private void btn_ImageToPDF(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Supported Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg;";
            openFileDialog.Multiselect = true;
            openFileDialog.SupportMultiDottedExtensions = true;
            openFileDialog.CheckFileExists = true;

            string[] paths = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK) // Test result.
            {
                paths = openFileDialog.FileNames;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.FileName = "test.pdf";

            string outputDir = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                outputDir = saveFileDialog.FileName;
                if (outputDir.Trim().Length == 0)
                {
                    ShowErrorMessage("Select output path!!");
                    return;
                }
            }
            else
            {
                ShowErrorMessage("Select output path!!");
                return;
            }

            Action lambda = () => { ConverterUtil.ImagesToPdf(paths, outputDir); };

            using (Loading loading = new Loading(lambda))
            {
                loading.ShowDialog(this);
            }

        }


        private static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
