using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Phoenix_Browser
{
    public partial class drop_menu : Form
    {
        public drop_menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Bitmap bp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            Rectangle cr = Screen.PrimaryScreen.Bounds;
            Graphics cg = Graphics.FromImage(bp);
            cg.CopyFromScreen(cr.Left, cr.Top, 0, 0, cr.Size);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Images|*.png;*.bmp;*.jpeg";
            saveFileDialog1.DefaultExt = "jpeg";
            saveFileDialog1.AddExtension = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImageFormat format = ImageFormat.Jpeg;
                string ext = System.IO.Path.GetExtension(saveFileDialog1.FileName);
                switch (ext)
                {
                    case ".jpeg":
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                }
                bp.Save(saveFileDialog1.FileName, format);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            menu1 mm = new menu1();
            mm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fscreen fscreen = new fscreen();
            fscreen.ShowDialog();
            this.Hide();
        }
        Form3 frm3 = new Form3();
        bool isopen = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (isopen == false)
            {
                isopen = true;

                frm3.Show();
            }
            else
            {
                isopen = false;
                frm3.Hide();
            }

        }
    }
}
