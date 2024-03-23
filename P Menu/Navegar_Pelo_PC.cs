using IWshRuntimeLibrary;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace P_Menu
{
    public partial class Navegar_Pelo_PC : Form
    {
        public Navegar_Pelo_PC()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundReactRgn(0, 0, Width, Height, 25, 25));
        }

        private void Ambiente_de_trabalho_Click(object sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (Directory.Exists(desktopPath))
            {
                Process.Start("explorer.exe", desktopPath);
            }
            else
            {
                MessageBox.Show("O caminho da Área de Trabalho não foi encontrado no seu sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Transferências_Click(object sender, EventArgs e)
        {
            string transferenciasPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";

            if (Directory.Exists(transferenciasPath))
            {
                Process.Start("explorer.exe", transferenciasPath);
            }
            else
            {
                MessageBox.Show("O caminho de Transferências não foi encontrado no seu sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Documentos_Click(object sender, EventArgs e)
        {
            string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (Directory.Exists(documentosPath))
            {
                Process.Start("explorer.exe", documentosPath);
            }
            else
            {
                MessageBox.Show("O caminho dos Documentos não foi encontrado no seu sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Imagens_Click(object sender, EventArgs e)
        {
            string imagePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (Directory.Exists(imagePath))
            {
                Process.Start("explorer.exe", imagePath);
            }
            else
            {
                MessageBox.Show("O caminho da pasta de Imagens não foi encontrado no seu sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Música_Click(object sender, EventArgs e)
        {
            string musicPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            if (Directory.Exists(musicPath))
            {
                Process.Start("explorer.exe", musicPath);
            }
            else
            {
                MessageBox.Show("O caminho da pasta de Músicas não foi encontrado no seu sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Vídeos_Click(object sender, EventArgs e)
        {
            string videosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

            if (Directory.Exists(videosPath))
            {
                Process.Start("explorer.exe", videosPath);
            }
            else
            {
                MessageBox.Show("O caminho da pasta Vídeos não foi encontrado no seu sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reciclagem_Click(object sender, EventArgs e)
        {
            string recycleBinPath = "::{645FF040-5081-101B-9F08-00AA002F954E}";

            Process.Start("explorer.exe", recycleBinPath);
        }

        private void DiscoLocal_Click(object sender, EventArgs e)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            if (drives.Length > 1)
            {
                Selecionar_Drive SDrives = new Selecionar_Drive(drives);
                SDrives.ShowDialog();
            }
            else if (drives.Length == 1)
            {
                string selectedDrivePath = drives[0].RootDirectory.FullName;
                Process.Start("explorer.exe", selectedDrivePath);
            }
            else
            {
                MessageBox.Show("Nenhum disco local foi encontrado no seu sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundReactRgn(
            int nLeftReact,
            int nTopReact,
            int nRightReact,
            int nBottomReact,
            int nWidhEllipse,
            int nHeightEllipse
            );
    }
}

