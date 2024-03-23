namespace P_Menu
{
    partial class P_Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P_Menu));
            this.Fechar_Programa = new System.Windows.Forms.Button();
            this.Text_Menu = new System.Windows.Forms.Label();
            this.Procurar_URL = new System.Windows.Forms.Button();
            this.Navegar_Pelo_PC = new System.Windows.Forms.Button();
            this.Limpar = new System.Windows.Forms.Button();
            this.Games = new System.Windows.Forms.Button();
            this.Abrir_Programa = new System.Windows.Forms.Button();
            this.BtnFechar = new System.Windows.Forms.Button();
            this.BtnMinimizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Fechar_Programa
            // 
            this.Fechar_Programa.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Fechar_Programa, "Fechar_Programa");
            this.Fechar_Programa.ForeColor = System.Drawing.Color.Red;
            this.Fechar_Programa.Name = "Fechar_Programa";
            this.Fechar_Programa.UseVisualStyleBackColor = true;
            this.Fechar_Programa.Click += new System.EventHandler(this.Fechar_Programa_Click);
            // 
            // Text_Menu
            // 
            resources.ApplyResources(this.Text_Menu, "Text_Menu");
            this.Text_Menu.ForeColor = System.Drawing.Color.Red;
            this.Text_Menu.Name = "Text_Menu";
            this.Text_Menu.Click += new System.EventHandler(this.Text_Menu_Click);
            // 
            // Procurar_URL
            // 
            this.Procurar_URL.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Procurar_URL, "Procurar_URL");
            this.Procurar_URL.ForeColor = System.Drawing.Color.Red;
            this.Procurar_URL.Name = "Procurar_URL";
            this.Procurar_URL.UseVisualStyleBackColor = true;
            this.Procurar_URL.Click += new System.EventHandler(this.Procurar_URL_Click);
            // 
            // Navegar_Pelo_PC
            // 
            this.Navegar_Pelo_PC.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Navegar_Pelo_PC, "Navegar_Pelo_PC");
            this.Navegar_Pelo_PC.ForeColor = System.Drawing.Color.Red;
            this.Navegar_Pelo_PC.Name = "Navegar_Pelo_PC";
            this.Navegar_Pelo_PC.UseVisualStyleBackColor = true;
            this.Navegar_Pelo_PC.Click += new System.EventHandler(this.Navegar_Pelo_PC_Click);
            // 
            // Limpar
            // 
            this.Limpar.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Limpar, "Limpar");
            this.Limpar.ForeColor = System.Drawing.Color.Red;
            this.Limpar.Name = "Limpar";
            this.Limpar.UseVisualStyleBackColor = true;
            this.Limpar.Click += new System.EventHandler(this.Limpar_Click);
            // 
            // Games
            // 
            this.Games.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Games, "Games");
            this.Games.ForeColor = System.Drawing.Color.Red;
            this.Games.Name = "Games";
            this.Games.UseVisualStyleBackColor = true;
            this.Games.Click += new System.EventHandler(this.Games_Click);
            // 
            // Abrir_Programa
            // 
            this.Abrir_Programa.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Abrir_Programa, "Abrir_Programa");
            this.Abrir_Programa.ForeColor = System.Drawing.Color.Red;
            this.Abrir_Programa.Name = "Abrir_Programa";
            this.Abrir_Programa.Tag = "";
            this.Abrir_Programa.UseVisualStyleBackColor = true;
            this.Abrir_Programa.Click += new System.EventHandler(this.Abrir_Programa_Click);
            // 
            // BtnFechar
            // 
            this.BtnFechar.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.BtnFechar, "BtnFechar");
            this.BtnFechar.ForeColor = System.Drawing.Color.Red;
            this.BtnFechar.Name = "BtnFechar";
            this.BtnFechar.TabStop = false;
            this.BtnFechar.Tag = "BtnFechar";
            this.BtnFechar.UseVisualStyleBackColor = true;
            this.BtnFechar.Click += new System.EventHandler(this.BtnFechar_Click);
            // 
            // BtnMinimizar
            // 
            this.BtnMinimizar.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.BtnMinimizar, "BtnMinimizar");
            this.BtnMinimizar.ForeColor = System.Drawing.Color.Red;
            this.BtnMinimizar.Name = "BtnMinimizar";
            this.BtnMinimizar.TabStop = false;
            this.BtnMinimizar.Tag = "BtnMinimizar";
            this.BtnMinimizar.UseVisualStyleBackColor = true;
            this.BtnMinimizar.Click += new System.EventHandler(this.BtnMinimizar_Click);
            this.BtnMinimizar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.P_Menu_KeyDown);
            this.BtnMinimizar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.P_Menu_KeyUp);
            // 
            // P_Menu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.BtnMinimizar);
            this.Controls.Add(this.BtnFechar);
            this.Controls.Add(this.Text_Menu);
            this.Controls.Add(this.Games);
            this.Controls.Add(this.Limpar);
            this.Controls.Add(this.Navegar_Pelo_PC);
            this.Controls.Add(this.Procurar_URL);
            this.Controls.Add(this.Abrir_Programa);
            this.Controls.Add(this.Fechar_Programa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "P_Menu";
            this.Opacity = 0.8D;
            this.Enter += new System.EventHandler(this.Abrir_Programa_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.P_Menu_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.P_Menu_KeyUp);
            this.Leave += new System.EventHandler(this.Abrir_Programa_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Fechar_Programa;
        private System.Windows.Forms.Label Text_Menu;
        private System.Windows.Forms.Button Procurar_URL;
        private System.Windows.Forms.Button Navegar_Pelo_PC;
        private System.Windows.Forms.Button Limpar;
        private System.Windows.Forms.Button Games;
        private System.Windows.Forms.Button Abrir_Programa;
        private System.Windows.Forms.Button BtnFechar;
        private System.Windows.Forms.Button BtnMinimizar;
    }
}