using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;
using Unify.Application.DTOs;
using Unify.Application.Interfaces;
using Unify.CrossCutting.Logging;
using Unify.Domain.Entities;
using Unify.UI.Controls.Classes;
using Unify.UI.Controls.Enums;
using Unify.UI.Controls.Extensions;
using Unify.UI.Theme;

namespace Unify.UI.WinForms.Forms.Cadastros.Orcamentos
{
    public partial class frmListaOrcamentos : UnifyForm
    {
        public OrcamentoDetalhadoDTO OrcamentoSelecionado { get; set; }

        private IOrcamentoService _orcamentoService;
        private ILogger _logger;
        public frmListaOrcamentos(ILogger logger, IOrcamentoService orcamentoService)
        {
            InitializeComponent();
            this.SetIcon();

            _logger = logger;
            _orcamentoService = orcamentoService;
        }

        private void frmListaOrcamentos_Shown(object sender, EventArgs e)
        {
            CarregaGrid();
            ConfigureGrid();
        }

        private void CarregaGrid()
        {
            try
            {
                gridOrcamentos.DataSource = _orcamentoService.ObterTodosDetalhado();
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

        private void ConfigureGrid()
        {
            gridOrcamentos.InicializarPadrao();

            var visibleIndex = 0;

            gridOrcamentos.EnableSingleCheckSelection();

            gridOrcamentos.ConfigurarColuna("Nome", "Cliente", ++visibleIndex);
            gridOrcamentos.ConfigurarColuna("Documento", "CPF/CNPJ", ++visibleIndex);
            gridOrcamentos.ConfigurarColuna("Email", "Email", ++visibleIndex);
            gridOrcamentos.ConfigurarColuna("Telefone", "Fone", ++visibleIndex);
            gridOrcamentos.ConfigurarColuna("Dt_Criacao", "Dt.Criação", ++visibleIndex, 90);
            gridOrcamentos.ConfigurarColuna("Dt_PrazoFinalizacao", "Dt.Finalização", ++visibleIndex);
            gridOrcamentos.ConfigurarColuna("ValorTotal", "Vlr.Total", ++visibleIndex, 80);
            gridOrcamentos.ConfigurarColuna("SituacaoDescricao", "Situação", ++visibleIndex, 80);

            gridOrcamentos.ConfigurarContextMenu(options: Grid.MenuOptions.Todos);

            gridOrcamentos.ConfigurarRowEdit(
                add: () => { },
                optionDelete: new Grid.OptionDelete()
                {
                    AfterRowDelete = Excluir
                },
                edit: campo => unifyFrame1_ConfirmarButtonClick(null, null),
                duplicate: () => Duplicar()
            );

        }
        private void Excluir()
        {
            try
            {
                var row = gridOrcamentos.GetFocusedRow<OrcamentoDTO>();

                if (row == null)
                    return;

                _orcamentoService.Excluir(row.Id);
                CarregaGrid();

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
                var row = gridOrcamentos.GetFocusedRow<OrcamentoDTO>();

                if (row == null)
                    return;

                _orcamentoService.Duplicar(row);

                CarregaGrid();

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

        private void txtFiltro_InputTextChanged(object sender, EventArgs e)
        {
            gridOrcamentos.FilterGrid(txtFiltro.Text);
        }

        private void unifyFrame1_ConfirmarButtonClick(object sender, EventArgs e)
        {
            var row = gridOrcamentos.GetCheckedRow<OrcamentoDetalhadoDTO>();

            if (row == null)
                return;

            OrcamentoSelecionado = row;

            this.DialogResult = DialogResult.OK;
        }
    }
}
