using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace P_Menu
{
    public partial class Selecionar_Drive : Form
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

        private readonly DriveInfo[] drives;

        public Selecionar_Drive(DriveInfo[] drives)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundReactRgn(0, 0, Width, Height, 25, 25));

            this.drives = drives;

            foreach (DriveInfo drive in drives)
            {
                Button button = new Button
                {
                    Text = drive.Name,
                    Tag = drive.RootDirectory.FullName
                };
                button.Click += Button_Click;
                flowLayoutPanel.Controls.Add(button);
            }

            Button Fechar = new Button
            {
                Text = "Fechar",
                ForeColor = System.Drawing.Color.Red,
                BackColor = System.Drawing.Color.Black,
                Size = new System.Drawing.Size(215, 32),
                Anchor = AnchorStyles.Bottom,
            };
            Fechar.Click += Fechar_Click;
            flowLayoutPanel.Controls.Add(Fechar);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string drivePath = ((Button)sender).Tag.ToString();
            Process.Start("explorer.exe", drivePath);

            Close();
        }

        private void Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


