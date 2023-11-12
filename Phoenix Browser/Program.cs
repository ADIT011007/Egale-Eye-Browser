using CefSharp;
using CefSharp.WinForms;
using EasyTabs;
using Nexus_Browser;
using System;
using System.IO;
using System.Windows.Forms;

namespace Phoenix_Browser
{
    static class Program
    {
        private static readonly Lazy<CefSettings> cefSettings = new Lazy<CefSettings>(() =>
        {
            var settings = new CefSettings
            {
                BackgroundColor = 255,
                CommandLineArgsDisabled = false,
                IgnoreCertificateErrors = false,
                RemoteDebuggingPort = 1024
            };
            if(Properties.Settings.Default.first_start == true)
            {
                browser_form frmb = new browser_form();
                frmb.Close();
                Form1 frm1 = new Form1();
                frm1.ShowDialog();
            }
            if (Properties.Settings.Default.best_osr_switch == true)
            {
                settings.SetOffScreenRenderingBestPerformanceArgs();
            }
            else
            {
                //Blank
            }
            if (Properties.Settings.Default.User_Prefs_Switch == true)
            {
                settings.PersistUserPreferences = true; // Enable persistent storage for user preferences
                string appDataLocalPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string cacheDirectory = Path.Combine(appDataLocalPath, "Egale Eye Browser", "Browser Data");

                settings.CachePath = cacheDirectory;
                settings.CefCommandLineArgs.Add("--disk-cache-dir", settings.CachePath);
            }
            else
            {
                settings.PersistUserPreferences = false; // Disable persistent storage for user preferences
            }
            if (Properties.Settings.Default.Cookies_session_Switch == true)
            {
                settings.CefCommandLineArgs.Add("--enable-file-cookies");
                settings.PersistSessionCookies = true; // Enable persistent storage for session cookies
            }
            else
            {
                settings.CefCommandLineArgs.Remove("--enable-file-cookies");
                settings.PersistSessionCookies = false; // Disable persistent storage for session cookies
            }

            if (Properties.Settings.Default.hardware_frame_Sceduling == true)//NEW HARDWARE FRAME SCHEDULING
            {
                settings.CefCommandLineArgs.Add("enable-begin-frame-scheduling", "1");
            }
            else
            {
                settings.CefCommandLineArgs.Remove("enable-begin-frame-scheduling");
            }


            if (Properties.Settings.Default.hardware_v_sync == true)//NEW HARDWARE V SYNC
            {
                settings.CefCommandLineArgs.Add("disable-gpu-vsync", "1"); //Disable Vsync
            }
            else
            {
                settings.CefCommandLineArgs.Remove("disable-gpu-vsync"); //Disable Vsync
            }

            if (Properties.Settings.Default.hardware_gpu_composting == true)//NEW HARDWARE GPU COMPOSITING
            {
                settings.CefCommandLineArgs.Remove("disable-gpu-compositing");
            }
            else
            {
                settings.CefCommandLineArgs.Add("disable-gpu-compositing", "1");
            }


            if (Properties.Settings.Default.Geo_Location_Switch == true)
            {
                settings.CefCommandLineArgs.Add("enable-features", "EnableGeolocation");
                settings.CefCommandLineArgs.Add("--enable-geolocation", "1");
            }
            else
            {
                settings.CefCommandLineArgs.Add("disable-features", "Geolocation");
            }

            if (Properties.Settings.Default.settings_dark == true)
            {
                settings.CefCommandLineArgs.Add("force-dark-mode", "1");
            }
            else
            {
                settings.CefCommandLineArgs.Remove("force-dark-mode");
            }
            if (Properties.Settings.Default.hardware_acc_switch == true)//NEW HARDWARE DISABLE/ENABLE GPU
            {
                settings.CefCommandLineArgs.Add("--enable-vulkan");
            }
            else
            {
                settings.CefCommandLineArgs.Add("disable-gpu", "1");
            }
            if (Properties.Settings.Default.javascrpts_switch == true)
            {
                settings.CefCommandLineArgs.Add("enable-javascript", "1"); // Enable JavaScript
            }
            else
            {
                settings.CefCommandLineArgs.Add("disable-javascript", "1"); // Disable JavaScript
            }

            settings.CefCommandLineArgs.Add("enable-media-stream");
            settings.CefCommandLineArgs.Add("--enable-widevine");
            settings.CefCommandLineArgs.Add("--enable-print-preview");
            settings.CefCommandLineArgs.Add("--password-store");
            settings.MultiThreadedMessageLoop = true;
            settings.CefCommandLineArgs.Add("--component-updater=fast-update");
            settings.CefCommandLineArgs.Add("--enable-javascript");
            settings.EnablePrintPreview();
            return settings;
        });
        private static TitleBarTabsApplicationContext applicationContext;
        private static AppContainer container;
        private static Timer tabNameTimer;



        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            // Initialize CEF the first time it is accessed
            Cef.Initialize(cefSettings.Value, true);

            container = new AppContainer();

            // Create tabs and start application
            container.TabDeselected += Container_TabRemoved;

            // Add the initial Tab
            container.Tabs.Add(
                new TitleBarTab(container)
                {
                    Content = new browser_form()
                }
            );

            // Set initial tab the first one
            container.SelectedTabIndex = 0;

            // Start the timer to update tab name
            tabNameTimer = new Timer();
            tabNameTimer.Interval = 1000; // 1 second
            tabNameTimer.Tick += TabNameTimer_Tick;
            tabNameTimer.Start();

            // Start the application
            Application.Run(container);
        }

        private static void Container_TabRemoved(object sender, TitleBarTabEventArgs e)
        {
            UpdateTabName();
        }

        private static void TabNameTimer_Tick(object sender, EventArgs e)
        {
            UpdateTabName();
        }

        private static void UpdateTabName()
        {
            // Update the text of each tab
            foreach (TitleBarTab tab in container.Tabs)
            {
                var bf = (browser_form)tab.Content;
                string websiteName = bf.WebsiteName;
                tab.Content.Text = websiteName;
            }
        }
    }
}
