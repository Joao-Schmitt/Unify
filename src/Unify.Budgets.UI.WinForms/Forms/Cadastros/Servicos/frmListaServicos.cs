using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using Unify.Budgets.Application.DTOs;
using Unify.Budgets.Application.Interfaces;
using Unify.Budgets.CrossCutting.Logging;
using Unify.Budgets.UI.Controls.Classes;
using Unify.Budgets.UI.Controls.Enums;
using Unify.Budgets.UI.Controls.Extensions;
using Unify.Budgets.UI.Theme;
using Unify.Budgets.UI.WinForms.Classes;

namespace Unify.Budgets.UI.WinForms.Forms.Cadastros.Servicos
{
    public partial class frmListaServicos : UnifyForm
    {
        private IServicoService _ServicoService;
        private ILogger _logger;
        public frmListaServicos(ILogger logger, IServicoService ServicoService)
        {
            InitializeComponent();
            this.SetIcon();

            _logger = logger;
            _ServicoService = ServicoService;
        }

        private void frmListaServicos_Shown(object sender, EventArgs e)
        {
            CarregaGrid();
            ConfigureGrid();
        }

        private void CarregaGrid()
        {
            try
            {
                gridServicos.DataSource = _ServicoService.ObterTodos();
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
            gridServicos.InicializarPadrao();

            var visibleIndex = 0;

            gridServicos.ConfigurarColuna("Nome", "Serviço", ++visibleIndex);
            gridServicos.ConfigurarColuna("PrecoBase", "Preço", ++visibleIndex, "N2", 100);
            gridServicos.ConfigurarColuna("TempoMedioMinutos", "Tempo (Min)", ++visibleIndex, 120);
            gridServicos.ConfigurarColuna("Observacoes", "Observações", ++visibleIndex);
            gridServicos.ConfigurarColuna("Ativo", "Status", ++visibleIndex, 80);

            gridServicos.ConfigurarContextMenu(options: Grid.MenuOptions.Todos);

            gridServicos.ConfigurarRowEdit(
                add: () => Adicionar(),
                optionDelete: new Grid.OptionDelete()
                {
                    AfterRowDelete = Excluir
                },
                edit: campo => Editar(campo),
                duplicate: () => Duplicar()
            );

        } 

        private void btnAdd_Click(object sender, EventArgs e) => Adicionar();
        private void Adicionar()
        {
            using (var frm = FormResolver.Resolve<frmServico>())
            {
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    Toast.Show("Servico gravado com sucesso!", ToastType.Success);
                    CarregaGrid();
                }
            }
        }

        private void Editar(string column)
        {
            var row = gridServicos.GetFocusedRow<ServicoDTO>();

            if (row == null)
                return;

            using (var frm = FormResolver.Resolve<frmServico>())
            {
                frm.Row = row;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Toast.Show("Servico gravado com sucesso!", ToastType.Success);
                    CarregaGrid();
                }
            }
        }

        private void Excluir()
        {
            try
            {
                var row = gridServicos.GetFocusedRow<ServicoDTO>();

                if (row == null)
                    return;

                _ServicoService.Excluir(row.Id);
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
                var row = gridServicos.GetFocusedRow<ServicoDTO>();

                if (row == null)
                    return;


                _ServicoService.Criar(new ServicoDTO()
                {
                    Nome = row.Nome,
                    PrecoBase = row.PrecoBase,
                    TempoMedioMinutos = row.TempoMedioMinutos,
                    Observacoes = row.Observacoes,
                    Ativo = row.Ativo
                });

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
            gridServicos.FilterGrid(txtFiltro.Text);
        }
    }
}
