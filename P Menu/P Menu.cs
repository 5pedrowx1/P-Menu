using System;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace P_Menu
{
    public partial class P_Menu : Form
    {

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(
            IntPtr hWnd,
            int id,
            int fsModifiers,
            int vk
            );

        private const int MOD_NOREPEAT = 0x4000;
        private const int WM_HOTKEY = 0x0312;
        private const int VK_INSERT = 0x2D;

        private int selectedIndex = -1;
        private int contadorCliques = 0;
        private int indiceCorPadrao = 0;
        private readonly List<Button> excludedButtons = new List<Button>();
        private readonly List<Button> buttons = new List<Button>();
        private readonly int hotkeyId = 0;
        private readonly Dictionary<Control, bool> controlesVisiveis = new Dictionary<Control, bool>();
        private readonly Timer corTimer = new Timer();
        private readonly ResourceManager _ResourceManager;
        private readonly Timer timer = new Timer();
        private readonly Color[] cores = { Color.Cornsilk, Color.Blue, Color.Green, Color.Yellow };
        private DateTime ultimoClique = DateTime.Now;
        private Color corPadrao = Color.Red;


        public P_Menu()
        {
            InitializeComponent();
            AssignButtonEvents();
            RegisterHotKey(this.Handle, hotkeyId, MOD_NOREPEAT, VK_INSERT);
            _ResourceManager = new ResourceManager(typeof(Properties.Resources));
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            corTimer.Interval = 1000;
            corTimer.Tick += CorTimer_Tick;
            this.KeyPreview = true;
            this.KeyDown += P_Menu_KeyDown;
            this.Activated += P_Menu_Activated;
        }

        //Nunca mais tento algo parecido que merda...
        private void Abrir_Programa_Click(object sender, EventArgs e)
        {
            string[] excludeFolders = { Environment.GetFolderPath(Environment.SpecialFolder.System), GetRecycleBinPath() };
            string programa = Prompt.ShowDialog("Digite o nome do programa, atalho ou URL: ", "Abrir Programa");

            if (!string.IsNullOrEmpty(programa))
            {
                try
                {
                    string[] drives = Environment.GetLogicalDrives();

                    foreach (string drive in drives)
                    {
                        if (!drive.StartsWith("C:\\Windows\\System32", StringComparison.OrdinalIgnoreCase))
                        {
                            try
                            {
                                string[] files = Directory.GetFiles(drive, $"*{programa}*", SearchOption.AllDirectories);
                                foreach (string file in files)
                                {
                                    try
                                    {
                                        if (!IsExcludedFolder(Path.GetDirectoryName(file), excludeFolders))
                                        {
                                            if (file.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                                            {
                                                Process.Start(file);
                                                return;
                                            }
                                            else if (file.EndsWith(".lnk", StringComparison.OrdinalIgnoreCase))
                                            {
                                                string targetPath = GetShortcutTarget(file);
                                                if (!string.IsNullOrEmpty(targetPath))
                                                {
                                                    Process.Start(targetPath);
                                                    return;
                                                }
                                            }
                                            else if (file.EndsWith(".url", StringComparison.OrdinalIgnoreCase))
                                            {
                                                string url = ReadUrlFromFile(file);
                                                if (!string.IsNullOrEmpty(url))
                                                {
                                                    Process.Start(url);
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show($"Erro ao abrir o programa: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                            catch (UnauthorizedAccessException)
                            {
                                continue;
                            }
                        }
                    }

                    MessageBox.Show($"O programa '{programa}' não foi encontrado no PC.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao procurar programas no PC: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetRecycleBinPath()
        {
            string drives = string.Join(";", Environment.GetLogicalDrives().Select(drive => $"{drive.TrimEnd('\\')}\\$Recycle.Bin"));
            string[] recycleBinPaths = Directory.GetDirectories(drives, "*", SearchOption.TopDirectoryOnly);
            foreach (string path in recycleBinPaths)
            {
                if (Path.GetFileName(path).ToLower().StartsWith("$recycle.bin"))
                {
                    return path;
                }
            }
            return null;
        }

        private bool IsExcludedFolder(string folderPath, string[] excludeFolders)
        {
            foreach (string excludedFolder in excludeFolders)
            {
                if (folderPath.StartsWith(excludedFolder, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private string GetShortcutTarget(string shortcutPath)
        {
            try
            {
                IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutPath);
                return shortcut.TargetPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter o destino do atalho: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private string ReadUrlFromFile(string urlFilePath)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(urlFilePath);
                foreach (string line in lines)
                {
                    if (line.Trim().StartsWith("URL=", StringComparison.OrdinalIgnoreCase))
                    {
                        return line.Trim().Substring(4).Trim();
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao ler URL do arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };

                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "OK", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };

                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        private void Fechar_Programa_Click(object sender, EventArgs e)
        {
            MatarProcesso matarProcessoForm = new MatarProcesso();
            matarProcessoForm.ShowDialog();
        }

        private void Procurar_URL_Click(object sender, EventArgs e)
        {
            string palavraOuUrl = Prompt.ShowDialog("Digite a URL ou palavra-chave: ", "Procurar na Web");

            if (!string.IsNullOrWhiteSpace(palavraOuUrl))
            {
                if (Uri.TryCreate(palavraOuUrl, UriKind.Absolute, out Uri urlResult) && (urlResult.Scheme == Uri.UriSchemeHttp || urlResult.Scheme == Uri.UriSchemeHttps))
                {
                    Process.Start(palavraOuUrl);
                }
                else
                {
                    try
                    {
                        string query = Uri.EscapeDataString(palavraOuUrl);
                        string searchUrl = $"https://www.bing.com/search?q={query}";

                        Process.Start("cmd", $"/c start {searchUrl}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao realizar a busca: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Navegar_Pelo_PC_Click(object sender, EventArgs e)
        {
            Navegar_Pelo_PC PC = new Navegar_Pelo_PC();
            PC.ShowDialog();
        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            Limpar limpar = new Limpar();
            limpar.ShowDialog();
        }

        private void Games_Click(object sender, EventArgs e)
        {
            Games G = new Games();
            G.ShowDialog();
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Text_Menu_Click(object sender, EventArgs e)
        {
            if ((DateTime.Now - ultimoClique).TotalMilliseconds < 500)
            {
                contadorCliques++;

                if (contadorCliques >= 4)
                {
                    Text_Menu.Text = "5pedrowx1";
                    corPadrao = cores[indiceCorPadrao];
                    indiceCorPadrao = (indiceCorPadrao + 1) % cores.Length;
                    corTimer.Start();
                    contadorCliques = 0;

                    Text_Menu.ForeColor = corPadrao;
                    Text_Menu.Location = new Point(25, 9);

                    timer.Start();
                    contadorCliques = 0;
                }
            }
            else
            {
                contadorCliques = 1;
            }

            ultimoClique = DateTime.Now;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Text_Menu.Text = "Menu";
            Text_Menu.ForeColor = Color.Red;
            Text_Menu.Location = new Point(67, 9);
            timer.Stop();
            corTimer.Stop();
        }

        private void CorTimer_Tick(object sender, EventArgs e)
        {
            Text_Menu.ForeColor = cores[indiceCorPadrao];
            indiceCorPadrao = (indiceCorPadrao + 1) % cores.Length;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void P_Menu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Home)
            {
                Application.Exit();
            }

            if (e.KeyCode == Keys.Enter && selectedIndex != -1)
            {
                if (!excludedButtons.Contains(buttons[selectedIndex]))
                {

                }
            }
        }

        private void P_Menu_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void SetButtonAppearance(Button button, bool isSelected)
        {
            if (button == null)
                return;

            if (isSelected)
            {
                button.FlatAppearance.BorderColor = Color.Red;
                button.FlatAppearance.BorderSize = 2;
            }
            else
            {
                button.FlatAppearance.BorderColor = SystemColors.Control;
                button.FlatAppearance.BorderSize = 1;
            }
        }

        private void P_Menu_Activated(object sender, EventArgs e)
        {
            this.Focus();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == hotkeyId)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                }
            }
        }

        private void Abrir_Programa_Enter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            SetButtonAppearance(button, true);
        }

        private void Abrir_Programa_Leave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            SetButtonAppearance(button, false);
        }

        private void AssignButtonEvents()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    buttons.Add(button);
                    button.GotFocus += Button_GotFocus;
                    button.LostFocus += Button_LostFocus;
                }
            }
        }

        private void Button_GotFocus(object sender, EventArgs e)
        {
            Button button = sender as Button;
            selectedIndex = buttons.IndexOf(button);
            HighlightSelectedButton();
        }

        private void Button_LostFocus(object sender, EventArgs e)
        {
            selectedIndex = -1;
            HighlightSelectedButton();
        }

        private void HighlightSelectedButton()
        {
            foreach (Button button in buttons)
            {
                if (buttons.IndexOf(button) == selectedIndex)
                {
                    SetButtonAppearance(button, true);
                }
                else
                {
                    SetButtonAppearance(button, false);
                }
            }
        }
    }
}

