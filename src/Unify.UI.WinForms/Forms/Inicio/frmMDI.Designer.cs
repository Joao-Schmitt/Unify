namespace Unify.UI.WinForms.Forms.Inicio
{
    partial class frmMDI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarRelatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesDeUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permissõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aparênciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parâmetrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportarUmErroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDashboard = new Unify.UI.Controls.Controls.UnifyButton();
            this.btnOrcamentos = new Unify.UI.Controls.Controls.UnifyButton();
            this.pnFooter = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnFinanceiro = new Unify.UI.Controls.Controls.UnifyButton();
            this.pnPrincipal = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.pnFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.cadastrosToolStripMenuItem,
            this.configuraçõesToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(904, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarRelatóriosToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            this.inicioToolStripMenuItem.BackColorChanged += new System.EventHandler(this.inicioToolStripMenuItem_BackColorChanged);
            // 
            // gerarRelatóriosToolStripMenuItem
            // 
            this.gerarRelatóriosToolStripMenuItem.Name = "gerarRelatóriosToolStripMenuItem";
            this.gerarRelatóriosToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.gerarRelatóriosToolStripMenuItem.Text = "Controle Financeiro";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produtosToolStripMenuItem,
            this.serviçosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.unidadesToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.ShowShortcutKeys = false;
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.produtosToolStripMenuItem.Text = "Produtos";
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click);
            // 
            // serviçosToolStripMenuItem
            // 
            this.serviçosToolStripMenuItem.Name = "serviçosToolStripMenuItem";
            this.serviçosToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.serviçosToolStripMenuItem.Text = "Serviços";
            this.serviçosToolStripMenuItem.Click += new System.EventHandler(this.serviçosToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // unidadesToolStripMenuItem
            // 
            this.unidadesToolStripMenuItem.Name = "unidadesToolStripMenuItem";
            this.unidadesToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.unidadesToolStripMenuItem.Text = "Unidades";
            this.unidadesToolStripMenuItem.Click += new System.EventHandler(this.unidadesToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesDeUsuárioToolStripMenuItem,
            this.permissõesToolStripMenuItem,
            this.aparênciaToolStripMenuItem,
            this.parâmetrosToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // configuraçõesDeUsuárioToolStripMenuItem
            // 
            this.configuraçõesDeUsuárioToolStripMenuItem.Name = "configuraçõesDeUsuárioToolStripMenuItem";
            this.configuraçõesDeUsuárioToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.configuraçõesDeUsuárioToolStripMenuItem.Text = "Configuração de Usuário";
            // 
            // permissõesToolStripMenuItem
            // 
            this.permissõesToolStripMenuItem.Name = "permissõesToolStripMenuItem";
            this.permissõesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.permissõesToolStripMenuItem.Text = "Permissões";
            // 
            // aparênciaToolStripMenuItem
            // 
            this.aparênciaToolStripMenuItem.Name = "aparênciaToolStripMenuItem";
            this.aparênciaToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.aparênciaToolStripMenuItem.Text = "Aparência";
            // 
            // parâmetrosToolStripMenuItem
            // 
            this.parâmetrosToolStripMenuItem.Name = "parâmetrosToolStripMenuItem";
            this.parâmetrosToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.parâmetrosToolStripMenuItem.Text = "Parâmetros";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportarUmErroToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // reportarUmErroToolStripMenuItem
            // 
            this.reportarUmErroToolStripMenuItem.Name = "reportarUmErroToolStripMenuItem";
            this.reportarUmErroToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.reportarUmErroToolStripMenuItem.Text = "Reportar Falha";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(883, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.Location = new System.Drawing.Point(591, 28);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(101, 32);
            this.btnDashboard.TabIndex = 4;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.Theme = Unify.UI.Controls.Enums.ButtonTheme.ThemePrimary;
            this.btnDashboard.UseAutomaticForeColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnOrcamentos
            // 
            this.btnOrcamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrcamentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrcamentos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOrcamentos.ForeColor = System.Drawing.Color.Gray;
            this.btnOrcamentos.Location = new System.Drawing.Point(694, 28);
            this.btnOrcamentos.Name = "btnOrcamentos";
            this.btnOrcamentos.Size = new System.Drawing.Size(101, 32);
            this.btnOrcamentos.TabIndex = 5;
            this.btnOrcamentos.Text = "Orçamentos";
            this.btnOrcamentos.Theme = Unify.UI.Controls.Enums.ButtonTheme.White;
            this.btnOrcamentos.UseAutomaticForeColor = true;
            this.btnOrcamentos.Click += new System.EventHandler(this.btnOrcamentos_Click);
            // 
            // pnFooter
            // 
            this.pnFooter.Controls.Add(this.lblUsuario);
            this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnFooter.Location = new System.Drawing.Point(0, 473);
            this.pnFooter.Name = "pnFooter";
            this.pnFooter.Size = new System.Drawing.Size(904, 23);
            this.pnFooter.TabIndex = 4;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(5, 1);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 15);
            this.lblUsuario.TabIndex = 7;
            this.lblUsuario.Text = "Usuário";
            // 
            // btnFinanceiro
            // 
            this.btnFinanceiro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinanceiro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinanceiro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFinanceiro.ForeColor = System.Drawing.Color.Gray;
            this.btnFinanceiro.Location = new System.Drawing.Point(797, 28);
            this.btnFinanceiro.Name = "btnFinanceiro";
            this.btnFinanceiro.Size = new System.Drawing.Size(101, 32);
            this.btnFinanceiro.TabIndex = 6;
            this.btnFinanceiro.Text = "Financeiro";
            this.btnFinanceiro.Theme = Unify.UI.Controls.Enums.ButtonTheme.White;
            this.btnFinanceiro.UseAutomaticForeColor = true;
            this.btnFinanceiro.Click += new System.EventHandler(this.btnFinanceiro_Click);
            // 
            // pnPrincipal
            // 
            this.pnPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnPrincipal.Location = new System.Drawing.Point(8, 66);
            this.pnPrincipal.Name = "pnPrincipal";
            this.pnPrincipal.Size = new System.Drawing.Size(890, 401);
            this.pnPrincipal.TabIndex = 7;
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 496);
            this.CloseOnEsc = false;
            this.Controls.Add(this.pnPrincipal);
            this.Controls.Add(this.btnFinanceiro);
            this.Controls.Add(this.btnOrcamentos);
            this.Controls.Add(this.pnFooter);
            this.Controls.Add(this.btnDashboard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMDI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMDI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnFooter.ResumeLayout(false);
            this.pnFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesDeUsuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permissõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aparênciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parâmetrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportarUmErroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarRelatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private Unify.UI.Controls.Controls.UnifyButton btnDashboard;
        private Unify.UI.Controls.Controls.UnifyButton btnOrcamentos;
        private System.Windows.Forms.Panel pnFooter;
        private Unify.UI.Controls.Controls.UnifyButton btnFinanceiro;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel pnPrincipal;
    }
}