namespace P_Menu
{
    partial class MatarProcesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatarProcesso));
            this.ListBoxProcessos = new System.Windows.Forms.ListBox();
            this.BtnMatar = new System.Windows.Forms.Button();
            this.BtnAtualizar = new System.Windows.Forms.Button();
            this.BtnFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListBoxProcessos
            // 
            this.ListBoxProcessos.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.ListBoxProcessos, "ListBoxProcessos");
            this.ListBoxProcessos.ForeColor = System.Drawing.Color.Red;
            this.ListBoxProcessos.FormattingEnabled = true;
            this.ListBoxProcessos.Name = "ListBoxProcessos";
            // 
            // BtnMatar
            // 
            this.BtnMatar.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.BtnMatar, "BtnMatar");
            this.BtnMatar.ForeColor = System.Drawing.Color.Red;
            this.BtnMatar.Name = "BtnMatar";
            this.BtnMatar.UseVisualStyleBackColor = true;
            this.BtnMatar.Click += new System.EventHandler(this.BtnMatar_Click);
            // 
            // BtnAtualizar
            // 
            this.BtnAtualizar.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.BtnAtualizar, "BtnAtualizar");
            this.BtnAtualizar.ForeColor = System.Drawing.Color.Red;
            this.BtnAtualizar.Name = "BtnAtualizar";
            this.BtnAtualizar.UseVisualStyleBackColor = true;
            this.BtnAtualizar.Click += new System.EventHandler(this.BtnAtualizar_Click);
            // 
            // BtnFechar
            // 
            this.BtnFechar.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.BtnFechar, "BtnFechar");
            this.BtnFechar.ForeColor = System.Drawing.Color.Red;
            this.BtnFechar.Name = "BtnFechar";
            this.BtnFechar.UseVisualStyleBackColor = true;
            this.BtnFechar.Click += new System.EventHandler(this.BtnFechar_Click);
            // 
            // MatarProcesso
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.BtnFechar);
            this.Controls.Add(this.BtnAtualizar);
            this.Controls.Add(this.BtnMatar);
            this.Controls.Add(this.ListBoxProcessos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MatarProcesso";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MatarProcesso_MouseDown_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxProcessos;
        private System.Windows.Forms.Button BtnMatar;
        private System.Windows.Forms.Button BtnAtualizar;
        private System.Windows.Forms.Button BtnFechar;
    }
}