using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Gif
{
    public partial class GifForm : Form
    {
        public static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GifForm());
            }
        }

        private PictureBox pictureBox;

        public GifForm()
        {
            pictureBox = new PictureBox() { Parent = this, Dock = DockStyle.Fill };
            pictureBox.Image = Image.FromStream(new WebClient().OpenRead("https://cs11.pikabu.ru/post_img/2018/05/28/9/1527521546127893416.gif"));
            pictureBox.Start();
        }
    }

    public class PictureBox : UserControl
    {
        public Image Image { get; set; }

        public PictureBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        public void Start()
        {
            ImageAnimator.Animate(Image, OnFrameChanged);
        }

        private void OnFrameChanged(object o, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image != null)
            {
                e.Graphics.DrawImage(Image, ClientRectangle);
                ImageAnimator.UpdateFrames(Image);
            }
        }
    }
}
