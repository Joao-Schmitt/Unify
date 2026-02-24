using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;
using Unify.Application.DTOs;
using Unify.Application.Interfaces;
using Unify.Application.Services;
using Unify.CrossCutting.Logging;
using Unify.Domain.Entities;
using Unify.Domain.Enums;
using Unify.Domain.Exceptions;
using Unify.Shared.Conversion.Infra.Conversao;
using Unify.UI.Controls.Classes;
using Unify.UI.Controls.Enums;
using Unify.UI.Controls.Extensions;
using Unify.UI.Controls.Forms;
using Unify.UI.Theme;
using Unify.UI.WinForms.Classes;
using Unify.UI.WinForms.Forms.Cadastros.Clientes;
using Unify.UI.WinForms.Forms.Cadastros.Orcamentos;
using Unify.UI.WinForms.Forms.Cadastros.Produtos;

namespace Unify.UI.WinForms.Controls
{
    public partial class btnAddPagamento : UserControl
    {
        private IOrcamentoService _orcamentoService;
        private ILogger _logger;

        private OrcamentoSituacao status;
        private OrcamentoDetalhadoDTO orcamentoSelecionado;

        private long clienteSeleciodo;

        public btnAddPagamento(ILogger logger, IOrcamentoService orcamentoService)
        {
            InitializeComponent();

            _logger = logger;
            _orcamentoService = orcamentoService;
            
            // Theme
            lblTitulo.Font = UnifyTheme.TitleFont;
            lblTitulo.ForeColor = UnifyTheme.TextSecondary;
        }

        private void Orcamentos_Load(object sender, EventArgs e)
        {
            LimparCampos();
            txtNome.Focus();
        }

        private void LimparCampos()
        {
            status = OrcamentoSituacao.EmOrcamento;
            pnStatus.BackColor = UnifyTheme.Primary;
            lblStatus.Text = "Em Orçamento";

            orcamentoSelecionado = new OrcamentoDetalhadoDTO();
            txtNome.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtDocum.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFone.Text = string.Empty;
            txtRua.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtNr.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtCep.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            txtObservacoes.Text = string.Empty;

            txtValidade.Text = DateTime.Now.AddMonths(1).ToString("dd/MM/yyyy");
            txtPrazoFinalizacao.Text = DateTime.Now.AddMonths(6).ToString("dd/MM/yyyy");
            txtPrazoGarantia.Text = DateTime.Now.AddMonths(12).ToString("dd/MM/yyyy");
            txtVlrTotal.Text = "0";

            grdMateriais.DataSource = null;
            grdServicos.DataSource = null;
            grdDesconto.DataSource = null;
            grdPagamentos.DataSource = null;

            tabInsumos.Enabled = false;

            lblId.Text = "#Novo Registro";
        }

        #region Grid Materiais

        private void CarregaGridMateriais()
        {
            try
            {
                if (orcamentoSelecionado.Id == 0)
                    return;

                grdMateriais.DataSource = _orcamentoService.ObterMateriais(orcamentoSelecionado.Id);
            }
            catch (ApplicationException ex)
            {
                Toast.Show(ex.Message, ToastType.Warning);
            }
            catch (Exception ex)
            {
                Toast.Show("Ocorreu um erro ao tentar carregar os registros! \r\nConsulte o administrador do sistema.", ToastType.Error);
                _logger.Write("Ocorreu um erro ao tentar carregar os registros!", LogLevel.Error, ex);
            }
        }

        private void MontaGridMateriais()
        {
            grdMateriais.InicializarPadrao();

            var visibleIndex = 0;

            grdMateriais.ConfigurarColuna("NomeProduto", "Produto", ++visibleIndex);
            grdMateriais.ConfigurarColuna("Comprimento", "Comprimento", ++visibleIndex);
            grdMateriais.ConfigurarColuna("Largura", "Largura", ++visibleIndex);
            grdMateriais.ConfigurarColuna("AreaTotal", "Área Total", ++visibleIndex);
            grdMateriais.ConfigurarColuna("Quantidade", "Quantidade", ++visibleIndex);
            grdMateriais.ConfigurarColuna("PrecoTotal", "Preço", ++visibleIndex);
            grdMateriais.ConfigurarColuna("Observacoes", "Observações", ++visibleIndex);

            grdMateriais.ConfigurarContextMenu(options: Grid.MenuOptions.Todos);

            grdMateriais.ConfigurarRowEdit(
                add: () => Adicionar(),
                optionDelete: new Grid.OptionDelete()
                {
                    AfterRowDelete = Excluir
                },
                edit: campo => Editar(campo),
                duplicate: () => Duplicar()
            );

        }

        private void btnAddMaterial_Click(object sender, EventArgs e) => Adicionar();
        private void Adicionar()
        {
            using (var frm = FormResolver.Resolve<frmOrcamentoProduto>())
            {
                frm.OrcametnoId = orcamentoSelecionado.Id;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Toast.Show("Produto gravado com sucesso!", ToastType.Success);
                    CarregaGridMateriais();
                }
            }
        }
        private void Editar(string column)
        {
            var row = grdMateriais.GetFocusedRow<OrcamentoMaterialDetalhadoDTO>();

            if (row == null)
                return;

            using (var frm = FormResolver.Resolve<frmOrcamentoProduto>())
            {
                frm.Row = row;
                frm.OrcametnoId = orcamentoSelecionado.Id;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Toast.Show("Produto gravado com sucesso!", ToastType.Success);
                    CarregaGridMateriais();
                }
            }
        }
        private void Excluir()
        {
            try
            {
                var row = grdMateriais.GetFocusedRow<OrcamentoMaterialDTO>();

                if (row == null)
                    return;

                _orcamentoService.ExcluirMaterial(row.Id);
                CarregaGridMateriais();

                Toast.Show("Registro deletado com sucesso!", ToastType.Success);
            }
            catch (ValidationException ex)
            {
                Toast.Show(ex.Message, ToastType.Warning);
            }
            catch (Exception ex)
            {
                Toast.Show("Ocorreu um erro ao tentar excluir os registros! \r\nConsulte o administrador do sistema.", ToastType.Warning);
                _logger.Write("Ocorreu um erro ao tentar excluir os registros!", LogLevel.Error, ex);
            }
        }
        private void Duplicar()
        {
            try
            {
                var row = grdMateriais.GetFocusedRow<OrcamentoMaterialDTO>();

                if (row == null)
                    return;


                _orcamentoService.AdicionarMaterial(new OrcamentoMaterialDTO()
                {
                    OrcamentoId = row.OrcamentoId,
                    ProdutoId = row.ProdutoId,
                    PrecoUnidade = row.PrecoUnidade,
                    Quantidade = row.Quantidade,
                    PrecoTotal = row.PrecoTotal
                });

                CarregaGridMateriais();

                Toast.Show("Registro duplicado com sucesso!", ToastType.Success);
            }
            catch (ValidationException ex)
            {
                Toast.Show(ex.Message, ToastType.Warning);
            }
            catch (Exception ex)
            {
                Toast.Show("Ocorreu um erro ao tentar duplicar os registros! \r\nConsulte o administrador do sistema.", ToastType.Warning);
                _logger.Write("Ocorreu um erro ao tentar duplicar os registros!", LogLevel.Error, ex);
            }
        }

        #endregion

        #region Grid Servicos
        private void CarregaGridServicos()
        {

        }

        private void MontaGridServicos()
        {

        }
        #endregion

        #region Status
        private void pnStatus_Click(object sender, EventArgs e) => AlterarStatus();
        private void AlterarStatus()
        {
            switch (status)
            {
                case OrcamentoSituacao.EmOrcamento:
                    pnStatus.BackColor = UnifyTheme.Warning;
                    lblStatus.Text = "Aprovado";
                    status = OrcamentoSituacao.EmProducao;
                    break;
                case OrcamentoSituacao.EmProducao:
                    pnStatus.BackColor = UnifyTheme.Success;
                    lblStatus.Text = "Concluído";
                    status = OrcamentoSituacao.Finalizado;
                    break;
                case OrcamentoSituacao.Finalizado:
                    pnStatus.BackColor = UnifyTheme.Danger;
                    lblStatus.Text = "Cancelado";
                    status = OrcamentoSituacao.Cancelado;
                    break;
                case OrcamentoSituacao.Cancelado:
                    pnStatus.BackColor = UnifyTheme.Primary;
                    lblStatus.Text = "Em Orçamento";
                    status = OrcamentoSituacao.EmOrcamento;
                    break;
            }
        }
        #endregion

        #region Selecoes

        // Cliente
        private void btnSelecaoCliente_Click(object sender, EventArgs e)
        {
            using (var frm = FormResolver.Resolve<frmListaClientes>())
            {
                frm.Selecao = true;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtNome.Text = frm.ClienteSelecionado.Nome;
                    txtDocum.Text = frm.ClienteSelecionado.Documento;
                    txtEmail.Text = frm.ClienteSelecionado.Email;
                    txtFone.Text = frm.ClienteSelecionado.Telefone;
                    txtRua.Text = frm.ClienteSelecionado.Rua;
                    txtCidade.Text = frm.ClienteSelecionado.Cidade;
                    txtBairro.Text = frm.ClienteSelecionado.Bairro;
                    txtNr.Text = frm.ClienteSelecionado.Numero;
                    txtEstado.Text = frm.ClienteSelecionado.Estado;
                    txtCep.Text = frm.ClienteSelecionado.CEP;
                    txtComplemento.Text = frm.ClienteSelecionado.Complemento;
                    clienteSeleciodo = frm.ClienteSelecionado.Id;
                }
            }
        }

        // Mapa
        private void btnMapas_Click(object sender, EventArgs e)
        {
            try
            {
                var model = new EnderecoModel()
                {
                    Rua = txtRua.Text,
                    Numero = txtNr.Text,
                    Bairro = txtBairro.Text,
                    Cidade = txtCidade.Text,
                    Estado = txtEstado.Text,
                    CEP = txtCep.Text
                };

                using (var frmMap = new frmMap(model))
                {
                    if (frmMap.ShowDialog() == DialogResult.OK)
                    {
                        txtRua.Text = frmMap.EnderecoSelecionado.Rua;
                        txtNr.Text = frmMap.EnderecoSelecionado.Numero;
                        txtBairro.Text = frmMap.EnderecoSelecionado.Bairro;
                        txtCidade.Text = frmMap.EnderecoSelecionado.Cidade;
                        txtEstado.Text = frmMap.EnderecoSelecionado.Estado;
                        txtCep.Text = frmMap.EnderecoSelecionado.CEP;
                    }
                }
            }
            catch (Exception ex)
            {
                Toast.Show("Ocorreu um erro ao tentar carregar o mapa! \r\nConsulte o administrador do sistema.", ToastType.Error);
                _logger.Write("Ocorreu um erro ao tentar carregar o mapa!", LogLevel.Error, ex);
            }
        }

        // Orçamento
        private void btnSelecaoOrcamento_Click(object sender, EventArgs e)
        {
            using (var frm = FormResolver.Resolve<frmListaOrcamentos>())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (orcamentoSelecionado == null)
                        return;

                    orcamentoSelecionado = frm.OrcamentoSelecionado;
                    PopulaCampos(orcamentoSelecionado);

                    tabInsumos.Enabled = true;

                    CarregaGridMateriais();
                    MontaGridMateriais();

                    CarregaGridServicos();
                    MontaGridServicos();
                }
            }
        }
        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var dto = new OrcamentoDTO()
                {
                    ClienteId = clienteSeleciodo,
                    Bairro = txtBairro.Text,
                    Rua = txtRua.Text,
                    Cidade = txtCidade.Text,
                    Numero = txtNr.Text,
                    Estado = txtEstado.Text,
                    CEP = txtCep.Text,
                    Complemento = txtComplemento.Text,
                    UsuarioId = 666, // ajustar para o usuario atual
                    Dt_PrazoFinalizacao = SafeConverter.ToDateTime(txtPrazoFinalizacao.Text),
                    Dt_Criacao = DateTime.Now,
                    Dt_PrazoGarantia = SafeConverter.ToDateTime(txtPrazoGarantia.Text),
                    Dt_Validade = SafeConverter.ToDateTime(txtValidade.Text),
                    SituacaoId = (long)status

                    // Add restante
                };

                if (orcamentoSelecionado.Id == 0)
                {
                    _orcamentoService.Criar(dto);
                }
                else
                {
                    dto.Id = orcamentoSelecionado.Id;
                    _orcamentoService.Atualizar(dto);
                }

                tabInsumos.Enabled = true;

                CarregaGridMateriais();
                MontaGridMateriais();

                CarregaGridServicos();
                MontaGridServicos();

                Toast.Show("Registro gravado com sucesso!", ToastType.Success);
            }
            catch (ValidationException ex)
            {
                Toast.Show(ex.Message, ToastType.Warning);
            }
            catch (Exception ex)
            {
                Toast.Show("Ocorreu um erro ao tentar gravar os registros! \r\nConsulte o administrador do sistema.", ToastType.Error);
                _logger.Write("Ocorreu um erro ao tentar gravar os registros!", LogLevel.Error, ex);
            }
        }

        private void PopulaCampos(OrcamentoDetalhadoDTO orcamento)
        {
            txtNome.Text = orcamento.Nome;
            txtDocum.Text = orcamento.Documento;
            txtEmail.Text = orcamento.Email;
            txtFone.Text = orcamento.Telefone;
            txtRua.Text = orcamento.Rua;
            txtCidade.Text = orcamento.Cidade;
            txtBairro.Text = orcamento.Bairro;
            txtNr.Text = orcamento.Numero;
            txtEstado.Text = orcamento.Estado;
            txtCep.Text = orcamento.CEP;
            txtComplemento.Text = orcamento.Complemento;
            txtPrazoFinalizacao.Text = orcamento.Dt_PrazoFinalizacao.ToString("dd/MM/yyyy");
            txtPrazoGarantia.Text = orcamento.Dt_PrazoGarantia.ToString("dd/MM/yyyy");
            txtVlrTotal.ValorSemMascara = orcamento.ValorTotal;
            clienteSeleciodo = orcamento.ClienteId;
            orcamentoSelecionado = orcamento;
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e) => LimparCampos();
    }
}
