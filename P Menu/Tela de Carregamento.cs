using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Resources;

namespace P_Menu
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundReactRgn(
            int nLeftReact,
            int nTopReact,
            int nRightReact,
            int nBottomReact,
            int nWidhEllipse,
            int nHeightEllipse
            );


        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundReactRgn(0, 0, Width, Height, 25, 25));
            ProgressBar1.Value = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar1.Value += 1;
            ProgressBar1.Text = ProgressBar1.Value.ToString() + "%";

            if( ProgressBar1.Value == 100 )
            {
                timer1.Enabled = false;
                P_Menu P = new P_Menu();
                P.Show();
                this.Hide();
            }
        }
    }
}
