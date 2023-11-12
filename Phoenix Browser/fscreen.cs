using System;
using System.Windows.Forms;

namespace Phoenix_Browser
{
    public partial class fscreen : Form
    {
        public fscreen()
        {
            InitializeComponent();
        }

        private void chromiumHostControl1_Click(object sender, EventArgs e)
        {

        }

        private void fscreen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            chromiumWebBrowser1.LoadUrl(Properties.Settings.Default.fs_link);
            toolStripButton1.Image = Properties.Resources.Home;
        }

        private void fscreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            chromiumWebBrowser1.Dispose();
            if (chromiumWebBrowser1.IsDisposed)
            {
                this.Dispose();
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            kryptonToolStrip1.BringToFront();
            pictureBox1.SendToBack();
            kryptonToolStrip1.Visible = true;
            tickCount = 0;
            timer1.Stop();
            timer1.Dispose();
        }
        int tickCount = 0; // Initialize a tick count variable at the class level
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tickCount++; // Increment the tick count each time the timer ticks

            if (tickCount == 3)
            {
                kryptonToolStrip1.Hide();
                pictureBox1.BringToFront();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            pictureBox1.BringToFront();
            kryptonToolStrip1.SendToBack();
        }
    }
}
