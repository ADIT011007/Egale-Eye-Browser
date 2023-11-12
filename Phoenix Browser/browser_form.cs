using CefSharp;
using CefsharpSandbox;
using System;
using System.Web.Hosting;
using System.Windows.Forms;

namespace Phoenix_Browser
{
    public partial class browser_form : Form
    {
        public string WebsiteName { get; set; }
        private string filePath;
        public browser_form()
        {
            InitializeComponent();
        }
        bool is_open = false;
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (is_open == true)
            {
                drop_menu drp_menu = new drop_menu();
                drp_menu.Close();
                is_open = false;
            }
            else
            {
                drop_menu drp_menu = new drop_menu();
                drp_menu.Show();
                is_open = true;
            }
        }

        private void chromiumWebBrowser1_LoadingStateChanged(object sender, CefSharp.LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading)
            {
                // Assuming 'this' refers to your form containing toolStripButton3
                this.Invoke((MethodInvoker)delegate
                {
                    toolStripButton3.Image = Properties.Resources.X_PNG;
                });
            }
            else
            {
                toolStripButton3.Image = Properties.Resources.Reload;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Back();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Forward();
        }

        private void chromiumWebBrowser1_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            Properties.Settings.Default.fs_link = e.Url;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (chromiumWebBrowser1.IsLoading == true)
            {
                chromiumWebBrowser1.Stop();
            }
            else
            {
                chromiumWebBrowser1.Reload();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void chromiumWebBrowser1_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            kryptonTextBox1.Invoke((MethodInvoker)delegate
            {
                kryptonTextBox1.Text = e.Address.ToString();
            });

            Uri uri = new Uri(e.Address);
            string domain = uri.Host;
            string[] parts = domain.Split('.');

            string websiteName = parts.Length >= 2 ? parts[parts.Length - 2] : "";

            string subdomain = parts.Length > 2 ? parts[0] : "";
            WebsiteName = websiteName;
        }

        private void browser_form_Load(object sender, EventArgs e)
        {
            chromiumWebBrowser1.LoadUrl("www.google.com");
            chromiumWebBrowser1.DownloadHandler = new MyCustomDownloadHandler(new Form3());
            if (Properties.Settings.Default.ad_blocker_switch == true)
            {
                var adBlocker = new AdBlocker();
                var requestHandler = new CustomRequestHandler(adBlocker);
                chromiumWebBrowser1.RequestHandler = requestHandler;
            }
        }

        private void kryptonTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Check if the text in the KryptonTextBox ends with one of the specified domain extensions
                string text = kryptonTextBox1.Text;

                if (text.EndsWith(".com") || text.EndsWith(".in") || text.EndsWith(".org"))

                {
                    chromiumWebBrowser1.LoadUrl(kryptonTextBox1.Text);
                }
                else
                {
                    chromiumWebBrowser1.LoadUrl("https://www.google.com/search?q=" + kryptonTextBox1.Text);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.first_start = true;
            Properties.Settings.Default.Save();
            Application.Restart ();
        }
    }
}
