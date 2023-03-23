using System.Runtime.InteropServices;

namespace AutoClickV1
{
    public partial class AutoClick : Form
    {
        public AutoClick()
        {
            InitializeComponent();
        }


        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwdata, int dwextrainfo);


        public enum mouseeventflags
        {
            LeftDown = 2,
            LeftUp = 4,
        }


        public void leftclick(Point p)
        {
            mouse_event((int)(mouseeventflags.LeftDown), p.X, p.Y, 0, 0);
            mouse_event((int)(mouseeventflags.LeftUp), p.X, p.Y, 0, 0);
        }


        bool stop = true;

        private void button1_Click(object sender, EventArgs e)
        {
            stop = (stop) ? false : true;
            timer1.Interval = (int)numericUpDown1.Value;
            timer1.Enabled = true;
            if (!stop) timer1.Start();
            if (stop) timer1.Stop();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            leftclick(new Point(MousePosition.X, MousePosition.Y));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }

}