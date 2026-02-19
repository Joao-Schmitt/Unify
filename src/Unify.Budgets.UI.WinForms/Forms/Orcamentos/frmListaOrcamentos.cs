using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;
using Unify.Budgets.Application.DTOs;
using Unify.Budgets.Application.Interfaces;
using Unify.Budgets.CrossCutting.Logging;
using Unify.Budgets.Domain.Entities;
using Unify.Budgets.UI.Controls.Classes;
using Unify.Budgets.UI.Controls.Enums;
using Unify.Budgets.UI.Controls.Extensions;
using Unify.Budgets.UI.Theme;
using Unify.Budgets.UI.WinForms.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Unify.Budgets.UI.WinForms.Forms.Cadastros.Orcamentos
{
    public partial class frmListaOrcamentos : UnifyForm
    {
        public OrcamentoDTO OrcamentoSelecionado { get; set; }

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
                gridOrcamentos.DataSource = _orcamentoService.ObterTodos();
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

            gridOrcamentos.ConfigurarColuna("Nome", "Orcamento", ++visibleIndex);
            gridOrcamentos.ConfigurarColuna("Unidade", "Unidade", ++visibleIndex, 90);
            gridOrcamentos.ConfigurarColuna("PrecoUnidade", "Preço", ++visibleIndex);
            gridOrcamentos.ConfigurarColuna("Ativo", "Status", ++visibleIndex, 80);

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
            var row = gridOrcamentos.GetCheckedRow<OrcamentoDTO>();

            if (row == null)
                return;

            OrcamentoSelecionado = row;

            this.DialogResult = DialogResult.OK;
        }
    }
}
