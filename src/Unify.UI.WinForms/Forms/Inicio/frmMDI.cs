using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unify.Application.Interfaces;
using Unify.CrossCutting.Logging;
using Unify.UI.Controls.Classes;
using Unify.UI.Controls.Controls;
using Unify.UI.Controls.Enums;
using Unify.UI.Controls.Extensions;
using Unify.UI.Theme;
using Unify.UI.WinForms.Classes;
using Unify.UI.WinForms.Controls;
using Unify.UI.WinForms.Forms.Cadastros.Clientes;
using Unify.UI.WinForms.Forms.Cadastros.Produtos;
using Unify.UI.WinForms.Forms.Cadastros.Servicos;
using Unify.UI.WinForms.Forms.Cadastros.Unidades;

namespace Unify.UI.WinForms.Forms.Inicio
{
    public partial class frmMDI : UnifyForm
    {
        private List<UnifyButton> lstBtnPages;

        private Dashboard _ucA;
        private Controls.btnAddPagamento _ucB;
        private Financeiro _ucC;


        private IOrcamentoService _orcamentoService;
        private ILogger _logger;


        public frmMDI(ILogger logger, IOrcamentoService orcamentoService)
        {
            InitializeComponent();

            _logger = logger;
            _orcamentoService = orcamentoService;

            this.SetIcon();
        }


        private void frmMDI_Load(object sender, EventArgs e)
        {
            menuStrip1.Renderer = new CustomMenuRenderer();
            menuStrip1.BackColor = UnifyTheme.ThemePrimary;
            menuStrip1.ForeColor = UnifyTheme.ThemeSecondary;

            this.pnFooter.BackColor = UnifyTheme.ThemePrimary;
            this.lblUsuario.Font = UnifyTheme.Font;
            this.lblUsuario.ForeColor = UnifyTheme.ThemeSecondary;

            lstBtnPages = new List<UnifyButton>()
            {
                btnDashboard,
                btnFinanceiro,
                btnOrcamentos
            };


            _ucA = new Dashboard();
            _ucB = new Controls.btnAddPagamento(_logger, _orcamentoService);
            _ucC = new Financeiro();

            InicializarUserControl(_ucA);
            InicializarUserControl(_ucB);
            InicializarUserControl(_ucC);

            ExibirControle(_ucA);
        }

        private void InicializarUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            uc.Visible = false;
            pnPrincipal.Controls.Add(uc);
        }

        private void ExibirControle(UserControl uc)
        {
            foreach (Control ctrl in pnPrincipal.Controls)
            {
                ctrl.Visible = false;
            }

            uc.Visible = true;
            uc.BringToFront();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = FormResolver.Resolve<frmListaProdutos>();
            frm.ShowDialog();
        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = FormResolver.Resolve<frmListaServicos>();
            frm.Show();
        }

        private void unidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = FormResolver.Resolve<frmListaUnidades>();
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = FormResolver.Resolve<frmListaClientes>();
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        
        private void btnDashboard_Click(object sender, EventArgs e) => ChangePage(btnDashboard, _ucA);
        private void btnOrcamentos_Click(object sender, EventArgs e) => ChangePage(btnOrcamentos, _ucB);
        private void btnFinanceiro_Click(object sender, EventArgs e) => ChangePage(btnFinanceiro, _ucC);


        private void ChangePage(UnifyButton button, UserControl control)
        {
            foreach (UnifyButton btn in lstBtnPages)
            {
                btn.Theme = ButtonTheme.White;
                btn.ForeColor = Color.Gray;
            }

            button.Theme = ButtonTheme.ThemePrimary;
            button.ForeColor = UnifyTheme.ThemeSecondary;

            ExibirControle(control);
        }

        private void inicioToolStripMenuItem_BackColorChanged(object sender, EventArgs e)
        {
            
        }


    }
}
