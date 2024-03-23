using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using Microsoft.VisualBasic.Devices;

namespace P_Menu
{
    public partial class Limpar : Form
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

        public Limpar()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundReactRgn(0, 0, Width, Height, 25, 25));
        }

        private void Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Apagra_Cookies_Click(object sender, EventArgs e)
        {
            ClearCookies();
        }

        private void ApFicheTempBrowser_Click(object sender, EventArgs e)
        {
            ClearBrowserTempFiles();
        }

        private void ClearCookies()
        {
            IWebDriver driver = GetWebDriver();
            if (driver != null)
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Quit();
                MessageBox.Show("Cookies apagados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nenhum navegador suportado foi encontrado ou nenhum navegador padrão está definido.\nPor favor, abra um navegador manualmente e limpe os cookies se necessário.", "Navegador não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearBrowserTempFiles()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "rundll32.exe",
                    Arguments = "InetCpl.cpl,ClearMyTracksByProcess 8",
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process.Start(psi);
                MessageBox.Show("Arquivos temporários do navegador apagados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar limpar os arquivos temporários do navegador: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IWebDriver GetWebDriver()
        {
            string defaultBrowser = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.htm\UserChoice", "ProgId", null)?.ToString();

            if (defaultBrowser != null)
            {
                if (defaultBrowser.Contains("ChromeHTML"))
                {
                    return new ChromeDriver();
                }
                else if (defaultBrowser.Contains("FirefoxHTML"))
                {
                    return new FirefoxDriver();
                }
                else if (defaultBrowser.Contains("AppXq0fevzme2pys62n3e0fbqa7peapykr8v"))
                {
                    return new EdgeDriver();
                }
            }

            if (IsChromeInstalled())
            {
                return new ChromeDriver();
            }
            else if (IsFirefoxInstalled())
            {
                return new FirefoxDriver();
            }
            else if (IsEdgeInstalled())
            {
                return new EdgeDriver();
            }

            return null;
        }

        private bool IsChromeInstalled()
        {
            return true;
        }

        private bool IsFirefoxInstalled()
        {
            return true;
        }

        private bool IsEdgeInstalled()
        {
            return true;
        }

        private void Limpar_Disco_Click(object sender, EventArgs e)
        {
            try
            {
                Process processo = new Process();
                processo.StartInfo.FileName = "cleanmgr.exe";
                processo.StartInfo.Arguments = "/sagerun:1";
                processo.Start();
                processo.WaitForExit();
                MessageBox.Show("Disco limpo com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao limpar o disco: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Desfragmentar_Disco_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("cmd.exe", "/c defrag C:");
                MessageBox.Show("Disco desfragmentado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao desfragmentar o disco: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
