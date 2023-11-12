using CefSharp;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Phoenix_Browser
{
    public partial class menu1 : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public menu1()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Blue500, MaterialSkin.Primary.Indigo700, MaterialSkin.Accent.Blue100, MaterialSkin.TextShade.WHITE);
        }

        private void menu1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.javascrpts_switch == true)
            {
                materialSwitch12.Checked = true;
            }
            else
            {
                materialSwitch12.Checked = false;
            }
            if (Properties.Settings.Default.off_screen_rendering == true)
            {
                materialSwitch11.Checked = true;
            }
            else
            {
                materialSwitch11.Checked = false;
            }

            if (Properties.Settings.Default.aero_switch_tabs == true)
            {
                materialSwitch10.Checked = true;
            }
            else
            {
                materialSwitch10.Checked = false;
            }
            if (Properties.Settings.Default.ad_blocker_switch == true)
            {
                materialSwitch9.Checked = true;
            }
            else
            {
                materialSwitch9.Checked = false;
            }
            // Set the timer interval to 5 seconds (5000 milliseconds)
            timer1.Interval = 5000;
            // Attach the event handler for the timer
            timer1.Tick += timer1_Tick;
            // Start the timer
            timer1.Start();
            if (Properties.Settings.Default.settings_dark == true)
            {
                materialSwitch8.Checked = true;
                materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
                materialSwitch8.Checked = false;

            }
            if (Properties.Settings.Default.Cookies_session_Switch == true)
            {
                materialSwitch7.Checked = true;
            }
            else
            {
                materialSwitch7.Checked = false;
            }
            if (Properties.Settings.Default.User_Prefs_Switch == true)
            {
                materialSwitch6.Checked = true;
            }
            else
            {
                materialSwitch6.Checked = false;
            }
            if (Properties.Settings.Default.Geo_Location_Switch == true)
            {
                materialSwitch5.Checked = true;
            }
            else
            {
                materialSwitch5.Checked = false;
            }
            if (Properties.Settings.Default.hardware_gpu_composting == true)
            {
                materialSwitch4.Checked = true;
            }
            else
            {
                materialSwitch4.Checked = false;
            }

            if (Properties.Settings.Default.hardware_v_sync == true)
            {
                materialSwitch3.Checked = true;
            }
            else
            {
                materialSwitch3.Checked = false;
            }
            if (Properties.Settings.Default.hardware_frame_Sceduling == true)
            {
                materialSwitch2.Checked = true;
            }
            else
            {
                materialSwitch2.Checked = false;
            }
            if (Properties.Settings.Default.hardware_acc_switch == true)
            {
                materialSwitch1.Checked = true;
            }
            else
            {
                materialSwitch1.Checked = false;
            }
            materialLabel1.Text = "CEF Commnit Hash :" + " " + Cef.CefCommitHash;
            materialLabel2.Text = "CEF Sharp Version :" + " " + Cef.CefSharpVersion;
            materialLabel3.Text = "CEF Version :" + " " + Cef.CefVersion;
            materialLabel4.Text = "Chromium Version :" + " " + Cef.ChromiumVersion;
        }

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch1.Checked)
            {
                Properties.Settings.Default.hardware_acc_switch = true;
                Properties.Settings.Default.Save();
                materialSwitch4.Checked = true;
                Properties.Settings.Default.hardware_gpu_composting = true;
                Properties.Settings.Default.Save();
                materialSwitch2.Checked = true;
                materialSwitch3.Checked = true;
                Properties.Settings.Default.hardware_v_sync = true;
                Properties.Settings.Default.hardware_frame_Sceduling = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.hardware_acc_switch = false;
                Properties.Settings.Default.Save();
            }
        }

        private void materialSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch2.Checked)
            {
                Properties.Settings.Default.hardware_frame_Sceduling = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.hardware_frame_Sceduling = false;
                Properties.Settings.Default.Save();
            }

        }

        private void materialSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch3.Checked)
            {
                Properties.Settings.Default.hardware_v_sync = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.hardware_v_sync = false;
                Properties.Settings.Default.Save();
            }
        }

        private void materialSwitch4_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch4.Checked)
            {
                Properties.Settings.Default.hardware_gpu_composting = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.hardware_gpu_composting = false;
                Properties.Settings.Default.Save();
            }
        }

        private void materialSwitch5_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch5.Checked)
            {
                Properties.Settings.Default.Geo_Location_Switch = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Geo_Location_Switch = false;
                Properties.Settings.Default.Save();
            }
        }

        private void materialSwitch6_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch6.Checked)
            {
                Properties.Settings.Default.User_Prefs_Switch = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.User_Prefs_Switch = false;
                Properties.Settings.Default.Save();
            }
        }

        private void materialSwitch7_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch7.Checked)
            {
                Properties.Settings.Default.Cookies_session_Switch = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Cookies_session_Switch = false;
                Properties.Settings.Default.Save();
            }
        }
        private long GetFolderSize(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                return Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories)
                    .Select(file => new FileInfo(file).Length)
                    .Sum();
            }
            else
            {
                return 0;
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string folderName = "Egale Eye Browser"; // Replace with the actual folder name you want to work with
            string localAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderPath = Path.Combine(localAppDataFolder, folderName);

            if (Directory.Exists(folderPath))
            {
                long folderSizeInBytes = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories).Sum(file => new FileInfo(file).Length);
                long folderSizeInKilobytes = folderSizeInBytes / 1024;
                long folderSizeInMegabytes = folderSizeInKilobytes / 1024;

                // Display folder size in bytes, kilobytes, and megabytes
                MessageBox.Show($"Folder Size:\nBytes: {folderSizeInBytes} B\nKilobytes: {folderSizeInKilobytes} KB\nMegabytes: {folderSizeInMegabytes} MB");
            }
            else
            {
                MessageBox.Show("Folder not found in the AppData\\Local folder.");
            }
        }

        private string GetUserLocalAppDataFolder(string subfolder)
        {
            string localAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(localAppDataFolder, subfolder);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Periodically update the sizes on the labels
            DisplayFolderSize("Egale Eye Browser\\Browser Data\\Session Storage", label1);
            DisplayFolderSize("Egale Eye Browser\\Browser Data\\Network", label2);
            DisplayFolderSize("Egale Eye Browser\\Browser Data\\IndexedDB", label3);
            DisplayFolderSize("Egale Eye Browser\\Browser Data\\Cache\\Cache_Data", label4);
            DisplayFolderSize("Egale Eye Browser\\Browser Data\\GPUCache", label5);
            DisplayFolderSize("Egale Eye Browser\\Browser Data", label6);
        }
        private void DisplayFolderSize(string subfolder, Label label)
        {
            string folderPath = GetUserLocalAppDataFolder(subfolder);

            // Check if the folder exists
            if (Directory.Exists(folderPath))
            {
                // Get the folder size in bytes
                long folderSize = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories)
                    .Select(file => new FileInfo(file).Length)
                    .Sum();

                // Convert bytes to a human-readable format (e.g., KB, MB, GB)
                string formattedSize = FormatSize(folderSize);
                label.Text = $"Size: {formattedSize}";
            }
            else
            {
                label.Text = "Folder not found.";
            }
        }

        private string FormatSize(long sizeInBytes)
        {
            string[] sizeSuffixes = { "B", "KB", "MB", "GB", "TB" };
            int i = 0;
            double size = sizeInBytes;

            while (size >= 1024 && i < sizeSuffixes.Length - 1)
            {
                size /= 1024;
                i++;
            }

            return $"{size:0.##} {sizeSuffixes[i]}";
        }

        private void DeleteFolder(string subfolder)
        {
            string folderPath = GetUserLocalAppDataFolder(subfolder);

            // Check if the folder exists
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
                MessageBox.Show("Folder deleted successfully.");
            }
            else
            {
                MessageBox.Show("Folder not found.");
            }
        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            // Delete the first folder and update the label
            DeleteFolder("Egale Eye Browser\\Browser Data\\Session Storage");
            label1.Text = "Size: 0 B";
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            // Delete the second folder and update the label
            DeleteFolder("Egale Eye Browser\\Browser Data\\Network");
            label2.Text = "Size: 0 B";
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            // Delete the third folder and update the label
            DeleteFolder("Egale Eye Browser\\Browser Data\\IndexedDB");
            label3.Text = "Size: 0 B";
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            // Delete the "Cache_Data" folder and update the label
            DeleteFolder("Egale Eye Browser\\Browser Data\\Cache\\Cache_Data");
            label4.Text = "Size: 0 B";
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            // Delete the "Cache_Data" folder and update the label
            DeleteFolder("Egale Eye Browser\\Browser Data\\GPUCache");
            label4.Text = "Size: 0 B";
        }

        private void menu1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void materialSwitch8_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch8.Checked)
            {
                Properties.Settings.Default.settings_dark = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.settings_dark = false;
                Properties.Settings.Default.Save();
            }
        }

        private void materialSwitch9_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch9.Checked)
            {
                Properties.Settings.Default.ad_blocker_switch = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.ad_blocker_switch = false;
                Properties.Settings.Default.Save();
            }
        }

        private void materialSwitch10_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch10.Checked)
            {
                Properties.Settings.Default.aero_switch_tabs = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.aero_switch_tabs = false;
                Properties.Settings.Default.Save();
            }
        }

        private void materialSwitch11_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch11.Checked)
            {
                Properties.Settings.Default.off_screen_rendering = true;
                Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.off_screen_rendering = false;
                Properties.Settings.Default.Save();
            }
        }

        private void materialSwitch12_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch12.Checked)
            {
                Properties.Settings.Default.javascrpts_switch = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.javascrpts_switch = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
