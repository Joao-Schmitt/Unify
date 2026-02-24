using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using Unify.Application.DTOs;
using Unify.Application.Interfaces;
using Unify.CrossCutting.Logging;
using Unify.UI.Controls.Classes;
using Unify.UI.Controls.Enums;
using Unify.UI.Controls.Extensions;
using Unify.UI.Theme;
using Unify.UI.WinForms.Classes;

namespace Unify.UI.WinForms.Forms.Cadastros.Produtos
{
    public partial class frmListaProdutos : UnifyForm
    {
        public bool Selecao { get; set; }
        public ProdutoDTO ProdutoSelecionado { get; set; }

        private IProdutoService _produtoService;
        private ILogger _logger;
        public frmListaProdutos(ILogger logger, IProdutoService produtoService)
        {
            InitializeComponent();
            this.SetIcon();

            _logger = logger;
            _produtoService = produtoService;
        }

        private void frmListaProdutos_Shown(object sender, EventArgs e)
        {
            CarregaGrid();
            ConfigureGrid();

            if (Selecao)
                unifyFrame1.ConfirmarButtonVisible = true;
        }

        private void CarregaGrid()
        {
            try
            {
                gridProdutos.DataSource = _produtoService.ObterTodos();
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
            gridProdutos.InicializarPadrao();

            var visibleIndex = 0;

            if (Selecao)
                gridProdutos.EnableSingleCheckSelection();

            gridProdutos.ConfigurarColuna("Nome", "Produto", ++visibleIndex);
            gridProdutos.ConfigurarColuna("Unidade", "Unidade", ++visibleIndex, 90);
            gridProdutos.ConfigurarColuna("PrecoUnidade", "Preço", ++visibleIndex);
            gridProdutos.ConfigurarColuna("Ativo", "Status", ++visibleIndex, 80);

            gridProdutos.ConfigurarContextMenu(options: Grid.MenuOptions.Todos);

            gridProdutos.ConfigurarRowEdit(
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
            using (var frm = FormResolver.Resolve<frmProduto>())
            {
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    Toast.Show("Produto gravado com sucesso!", ToastType.Success);
                    CarregaGrid();
                }
            }
        }

        private void Editar(string column)
        {
            var row = gridProdutos.GetFocusedRow<ProdutoDTO>();

            if (row == null)
                return;

            using (var frm = FormResolver.Resolve<frmProduto>())
            {
                frm.Row = row;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Toast.Show("Produto gravado com sucesso!", ToastType.Success);
                    CarregaGrid();
                }
            }
        }

        private void Excluir()
        {
            try
            {
                var row = gridProdutos.GetFocusedRow<ProdutoDTO>();

                if (row == null)
                    return;

                _produtoService.Excluir(row.Id);
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
                var row = gridProdutos.GetFocusedRow<ProdutoDTO>();

                if (row == null)
                    return;


                _produtoService.Criar(new ProdutoDTO()
                {
                    Nome = row.Nome,
                    Unidade = row.Unidade,
                    PrecoUnidade = row.PrecoUnidade,
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
            gridProdutos.FilterGrid(txtFiltro.Text);
        }

        private void unifyFrame1_ConfirmarButtonClick(object sender, EventArgs e)
        {
            if (!Selecao)
                return;

            var row = gridProdutos.GetCheckedRow<ProdutoDTO>();

            if (row == null)
                return;

            if (!row.Ativo)
            {
                Toast.Show("Produto inativo!", ToastType.Warning);
                return;
            }

            ProdutoSelecionado = row;

            this.DialogResult = DialogResult.OK;
        }
    }
}
