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
        public OrcamentoMaterialDetalhadoDTO Row { get; set; }

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
                txtLargura.Text = Row.Largura.ToString("N2");
                txtComprimento.Text = Row.Quantidade.ToString("N2");
                txtVlrTotal.Text = Row.PrecoTotal.ToString("N2");
                txtArea.Text = Row.AreaTotal.ToString("N2");
                txtQuantidade.Text = Row.Quantidade.ToString("N2");
                txtObs.Text = Row.Observacoes;
            }
            else
            {
                Row = new OrcamentoMaterialDetalhadoDTO();
            }

            txtNome.Focus();
        }

        private void unifyFrame1_ConfirmarButtonClick(object sender, EventArgs e)
        {
            try
            {
                Row.OrcamentoId = OrcametnoId;
                Row.ProdutoId = _produtoSelecionado.Id;
                Row.NomeProduto = _produtoSelecionado.Nome;
                Row.PrecoUnidade = txtVlrUnidade.ValorSemMascara;
                Row.Largura = txtLargura.ValorSemMascara;
                Row.Comprimento = txtComprimento.ValorSemMascara;
                Row.AreaTotal = txtArea.ValorSemMascara;
                Row.PrecoTotal = txtVlrTotal.ValorSemMascara;
                Row.Quantidade = txtComprimento.ValorSemMascara;
                Row.Observacoes = txtObs.Text;

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
            AtualizaTotais();
        }       

        private void txtVlrUnidade_Leave(object sender, EventArgs e) => AtualizaTotais();
        private void txtQuantidade_Leave(object sender, EventArgs e) => AtualizaTotais();
        private void txtLargura_Leave(object sender, EventArgs e) => AtualizaTotais();
        private void txtComprimento_Leave(object sender, EventArgs e) => AtualizaTotais();
        private void txtUnidade_Leave(object sender, EventArgs e) => AtualizaTotais();

        private void AtualizaTotais()
        {
            var areaTotal = txtComprimento.ValorSemMascara * txtLargura.ValorSemMascara;
            txtArea.Text = areaTotal.ToString("N2");

            var vlrUnidade = txtVlrUnidade.ValorSemMascara;
            var quantidade = txtUnidadeDescricao.ValorSemMascara;

            // TODO: Adicionar campo no cadastro da unidade para saber se calcula área total ou não
            var total = vlrUnidade * (txtUnidade.Text.Equals("M²") ? areaTotal : 1) * quantidade;
            txtVlrTotal.Text = total.ToString("N2");
        } 
    }
}
