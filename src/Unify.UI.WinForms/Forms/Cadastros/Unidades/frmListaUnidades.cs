using System;
using System.Windows.Forms;
using Unify.Application.DTOs;
using Unify.Application.Interfaces;
using Unify.CrossCutting.Logging;
using Unify.Domain.Exceptions;
using Unify.UI.Controls.Classes;
using Unify.UI.Controls.Enums;
using Unify.UI.Controls.Extensions;
using Unify.UI.Theme;
using Unify.UI.WinForms.Classes;

namespace Unify.UI.WinForms.Forms.Cadastros.Unidades
{
    public partial class frmListaUnidades : UnifyForm
    {
        private IUnidadeService _UnidadeService;
        private ILogger _logger;
        public frmListaUnidades(ILogger logger, IUnidadeService UnidadeService)
        {
            InitializeComponent();
            this.SetIcon();

            _logger = logger;
            _UnidadeService = UnidadeService;
        }

        private void frmListaUnidades_Shown(object sender, EventArgs e)
        {
            CarregaGrid();
            ConfigureGrid();
        }

        private void CarregaGrid()
        {
            try
            {
                gridUnidades.DataSource = _UnidadeService.ObterTodos();
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
            gridUnidades.InicializarPadrao();

            var visibleIndex = 0;

            //gridUnidades.ConfigurarColuna("Id", "Id", ++visibleIndex, 60);
            gridUnidades.ConfigurarColuna("Sigla", "Sigla", ++visibleIndex, 100);
            gridUnidades.ConfigurarColuna("Descricao", "Descrição", ++visibleIndex);

            gridUnidades.ConfigurarContextMenu(options: Grid.MenuOptions.Editar | Grid.MenuOptions.Excluir);

            gridUnidades.ConfigurarRowEdit(
                add: () => Adicionar(),
                optionDelete: new Grid.OptionDelete()
                {
                    AfterRowDelete = Excluir
                },
                edit: campo => Editar(campo)
            );

        } 

        private void btnAdd_Click(object sender, EventArgs e) => Adicionar();
        private void Adicionar()
        {
            using (var frm = FormResolver.Resolve<frmUnidade>())
            {
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    Toast.Show("Unidade gravado com sucesso!", ToastType.Success);
                    CarregaGrid();
                }
            }
        }

        private void Editar(string column)
        {
            var row = gridUnidades.GetFocusedRow<UnidadeDTO>();

            if (row == null)
                return;

            using (var frm = FormResolver.Resolve<frmUnidade>())
            {
                frm.Row = row;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Toast.Show("Unidade gravado com sucesso!", ToastType.Success);
                    CarregaGrid();
                }
            }
        }

        private void Excluir()
        {
            try
            {
                var row = gridUnidades.GetFocusedRow<UnidadeDTO>();

                if (row == null)
                    return;

                _UnidadeService.Excluir(row.Id);
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

        private void txtFiltro_InputTextChanged(object sender, EventArgs e)
        {
            gridUnidades.FilterGrid(txtFiltro.Text);
        }
    }
}
