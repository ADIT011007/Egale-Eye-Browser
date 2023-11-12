using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoenix_Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void folder_Creaion()
        {
            // Create a folder in the local AppData
            string localAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderName = "MyAppFolder";
            string folderPath = Path.Combine(localAppDataFolder, folderName);

            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine($"Folder '{folderName}' created at '{folderPath}'");
                    progressBar1.Value = 35;
                }
                else
                {
                    Console.WriteLine($"Folder '{folderName}' already exists at '{folderPath}'");
                    progressBar1.Value = 35;
                    richTextBox1.Text = "Folder Creation Completed";
                    richTextBox1.Multiline = true;
                    MessageBox.Show($"Folder '{folderName}' already exists at '{folderPath}'");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the folder: {ex.Message}");
                MessageBox.Show($"An error occurred while creating the folder: {ex.Message}");
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            folder_Creaion();
        }
    }
}
