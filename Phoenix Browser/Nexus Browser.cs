using EasyTabs;
using Phoenix_Browser;
using Phoenix_Browser.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace Nexus_Browser
{
    public partial class AppContainer : TitleBarTabs
    {
        private static int tabCount = 1; 

        public AppContainer()
        {
            var defaultSettings = Settings.Default;
            InitializeComponent();
            TabRenderer = new ChromeTabRenderer(this);
            if (defaultSettings.aero_switch_tabs == true)
            {
                AeroPeekEnabled = true;
            }
            else
            {
                AeroPeekEnabled = false;
            }

            string filePath = Application.StartupPath + "\\Browser Icon.ico";
            Icon icon = new Icon(filePath);
            this.Icon = icon;


        }

        // Handle the method CreateTab that allows the user to create a new Tab
        // on your app when clicking
        public override TitleBarTab CreateTab()
        {
            var newTab = new TabPage();
            return new TitleBarTab(this)
            {
                // The content will be an instance of another Form
                // In our example, we will create a new instance of the Form1
                Content = new browser_form
                {
                    Text = "New Tab "
                }
            };
        }

        // The rest of the events in your app here if you need to .....
    }
}
