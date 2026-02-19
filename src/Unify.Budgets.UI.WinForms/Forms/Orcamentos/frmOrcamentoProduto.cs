using System;
using System.Windows.Forms;
using Unify.Budgets.Application.DTOs;
using Unify.Budgets.Application.Interfaces;
using Unify.Budgets.CrossCutting.Logging;
using Unify.Budgets.Domain.Exceptions;
using Unify.Budgets.Shared.Conversion.Infra.Conversao;
using Unify.Budgets.UI.Controls.Classes;
using Unify.Budgets.UI.Controls.Enums;
using Unify.Budgets.UI.Theme;
using Unify.Budgets.UI.WinForms.Classes;

namespace Unify.Budgets.UI.WinForms.Forms.Cadastros.Produtos
{
    public partial class frmOrcamentoProduto : UnifyForm
    {
        public long OrcametnoId { get; set; }
        public OrcamentoMaterialDTO Row { get; set; }
        private IOrcamentoService _orcamentoService;
        private IProdutoService _produtoService;
        private ILogger _logger;

        private ProdutoDTO _produtoSelecionado;

        public frmOrcamentoProduto(ILogger logger, IOrcamentoService orcamentoService, IProdutoService produtoService)
        {
            InitializeComponent();
            this.SetIcon();

            _orcamentoService = orcamentoService;
            _produtoService = produtoService;
            _logger = logger;
        }

        private void frmProduto_Shown(object sender, EventArgs e)
        {
            if (Row != null)
            {
                var produto = _produtoService.Obter(Row.ProdutoId);

                if (produto != null)
                {
                    txtNome.Text = produto.Nome;
                    txtUnidade.Text = produto.Unidade;
                    txtUnidadeDescricao.Text = produto.DescricaoUnidade;
                }
               
                txtVlrUnidade.Text = Row.PrecoUnidade.ToString("N2");
                txtQuantidade.Text = Row.Quantidade.ToString("N2");
                txtVlrTotal.Text = Row.PrecoTotal.ToString("N2");
            }
            else
            {
                Row = new OrcamentoMaterialDTO();
            }

            txtNome.Focus();
        }

        private void unifyFrame1_ConfirmarButtonClick(object sender, EventArgs e)
        {
            try
            {
                Row.OrcamentoId = OrcametnoId;
                Row.ProdutoId = _produtoSelecionado.Id;
                Row.PrecoUnidade = txtVlrUnidade.ValorSemMascara;
                Row.PrecoTotal = txtVlrTotal.ValorSemMascara;
                Row.Quantidade = txtQuantidade.ValorSemMascara;

                if (Row.Id != 0)
                {
                    _orcamentoService.AtualizarMaterial(Row);
                }
                else
                {
                    _orcamentoService.AdicionarMaterial(Row);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (ValidationException ex)
            {
                Toast.Show(ex.Message, ToastType.Warning);
            }
            catch (Exception ex)
            {
                Toast.Show("Ocorreu um erro ao tentar gravar os registros! \r\nConsulte o administrador do sistema.", ToastType.Warning);
                _logger.Write("Ocorreu um erro ao tentar gravar os registros!", LogLevel.Error, ex);
            }
        }

        private void btnSelecaoProduto_Click(object sender, EventArgs e)
        {
            using (var frm = FormResolver.Resolve<frmListaProdutos>())
            {
                frm.Selecao = true;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _produtoSelecionado = frm.ProdutoSelecionado;
                    AtualizaCampos();
                }
            }
        }

        private void AtualizaCampos()
        {
            txtNome.Text = _produtoSelecionado?.Nome ?? string.Empty;
            txtUnidade.Text = _produtoSelecionado?.Unidade ?? string.Empty;
            txtUnidadeDescricao.Text = _produtoSelecionado?.DescricaoUnidade ?? string.Empty;
            txtVlrUnidade.Text = SafeConverter.ToString(_produtoSelecionado?.PrecoUnidade ?? 0);
            txtVlrTotal.Text = SafeConverter.ToString(CalculaTotal());
        }

        private decimal CalculaTotal()
        {
            var qtd = txtUnidadeDescricao.ValorSemMascara;
            var vlr = txtVlrUnidade.ValorSemMascara;

            return qtd * vlr;
        }

        private void txtVlrUnidade_Leave(object sender, EventArgs e) => txtVlrTotal.Text = SafeConverter.ToString(CalculaTotal());
        private void txtQuantidade_Leave(object sender, EventArgs e) => txtVlrTotal.Text = SafeConverter.ToString(CalculaTotal());
    }
}
