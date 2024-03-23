using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace P_Menu
{
    public partial class MatarProcesso : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        // Define as constantes para habilitar a movimentação do formulário
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundReactRgn(
            int nLeftReact,
            int nTopReact,
            int nRightReact,
            int nBottomReact,
            int nWidhEllipse,
            int nHeightEllipse
        );

        public MatarProcesso()
        {
            InitializeComponent();
            ListarProcessos();
            this.TopMost = false;
            this.MouseDown += MatarProcesso_MouseDown;
            Region = System.Drawing.Region.FromHrgn(CreateRoundReactRgn(0, 0, Width, Height, 25, 25));
        }

        private void ListarProcessos()
        {
            ListBoxProcessos.Items.Clear();

            Process[] processos = Process.GetProcesses();
            foreach (Process processo in processos)
            {
                try
                {
                    // Filtra processos críticos
                    if (processo.PriorityClass == ProcessPriorityClass.High || processo.PriorityClass == ProcessPriorityClass.RealTime)
                    {
                        continue; // Pula processos com prioridade alta ou tempo real
                    }

                    ListBoxProcessos.Items.Add(processo.ProcessName);
                }
                catch (Exception ex)
                {
                    // Lida com a exceção de "Acesso Negado"
                    // Você pode adicionar código aqui para logar o erro ou realizar outras ações necessárias
                    Console.WriteLine($"Erro ao acessar o processo: {ex.Message}");
                }
            }
        }

        private void BtnMatar_Click(object sender, EventArgs e)
        {
            if (ListBoxProcessos.SelectedItem != null)
            {
                string nomeProcesso = ListBoxProcessos.SelectedItem.ToString();

                DialogResult resultado = MessageBox.Show($"Tem certeza que deseja encerrar o processo '{nomeProcesso}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    Process[] processos = Process.GetProcessesByName(nomeProcesso);
                    foreach (Process processo in processos)
                    {
                        try
                        {
                            processo.Kill();
                            processo.WaitForExit();
                            MessageBox.Show($"O processo '{nomeProcesso}' foi encerrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao encerrar o processo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    ListarProcessos();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um processo da lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            ListarProcessos();
        }

        // Manipula o evento MouseDown do formulário para permitir a movimentação
        private void MatarProcesso_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MatarProcesso_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.BringToFront();
            }
        }
    }
}