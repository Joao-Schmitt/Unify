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

namespace Unify.UI.WinForms.Forms.Cadastros.Clientes
{
    public partial class frmListaClientes : UnifyForm
    {
        public bool Selecao { get; set; }
        public ClienteDTO ClienteSelecionado { get; set; }

        private IClienteService _clienteService;
        private ILogger _logger;
        public frmListaClientes(ILogger logger, IClienteService clienteService)
        {
            InitializeComponent();
            this.SetIcon();

            _logger = logger;
            _clienteService = clienteService;
        }

        private void frmListaClientes_Shown(object sender, EventArgs e)
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
                gridClientes.DataSource = _clienteService.ObterTodos();
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
            gridClientes.InicializarPadrao();

            var visibleIndex = 0;

            if(Selecao)
                gridClientes.EnableSingleCheckSelection();

            gridClientes.ConfigurarColuna("Nome", "Cliente", ++visibleIndex);
            gridClientes.ConfigurarColuna("Documento", "CPF/CNPJ", ++visibleIndex);
            gridClientes.ConfigurarColuna("Email", "E-mail", ++visibleIndex);
            gridClientes.ConfigurarColuna("Telefone", "Fone", ++visibleIndex);
            gridClientes.ConfigurarColuna("Rua", "Rua", ++visibleIndex);
            gridClientes.ConfigurarColuna("Bairro", "Bairro", ++visibleIndex);
            gridClientes.ConfigurarColuna("Numero", "Número", ++visibleIndex, 100);
            gridClientes.ConfigurarColuna("Cidade", "Cidade", ++visibleIndex);
            gridClientes.ConfigurarColuna("Estado", "Estado", ++visibleIndex, 60);
            gridClientes.ConfigurarColuna("CEP", "Cep", ++visibleIndex, 120);
            gridClientes.ConfigurarColuna("Complemento", "Complemento", ++visibleIndex);
            gridClientes.ConfigurarColuna("Ativo", "Ativo", ++visibleIndex, 60);


            gridClientes.ConfigurarContextMenu(options: Grid.MenuOptions.Todos);

            gridClientes.ConfigurarRowEdit(
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
            using (var frm = FormResolver.Resolve<frmCliente>())
            {
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    Toast.Show("Cliente gravado com sucesso!", ToastType.Success);
                    CarregaGrid();
                }
            }
        }

        private void Editar(string column)
        {
            var row = gridClientes.GetFocusedRow<ClienteDTO>();

            if (row == null)
                return;

            using (var frm = FormResolver.Resolve<frmCliente>())
            {
                frm.Row = row;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Toast.Show("Cliente gravado com sucesso!", ToastType.Success);
                    CarregaGrid();
                }
            }
        }

        private void Excluir()
        {
            try
            {
                var row = gridClientes.GetFocusedRow<ClienteDTO>();

                if (row == null)
                    return;

                _clienteService.Excluir(row.Id);
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
                var row = gridClientes.GetFocusedRow<ClienteDTO>();

                if (row == null)
                    return;

                _clienteService.Criar(new ClienteDTO()
                {
                    Nome = row.Nome,
                    Documento = row.Documento,
                    Email = row.Email,
                    Telefone = row.Telefone,
                    Rua = row.Rua,
                    Cidade = row.Cidade,
                    Estado = row.Estado,
                    Bairro = row.Bairro,
                    Numero = row.Numero,
                    CEP = row.CEP,
                    Complemento = row.Complemento,
                    Ativo = row.Ativo,
                    Dt_Criacao = DateTime.Now
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
            gridClientes.FilterGrid(txtFiltro.Text);
        }

        private void unifyFrame1_ConfirmarButtonClick(object sender, EventArgs e)
        {
            if (!Selecao)
                return;

            var row = gridClientes.GetCheckedRow<ClienteDTO>();

            if (row == null)
                return;

            if(!row.Ativo)
            {
                Toast.Show("Cliente inativo!", ToastType.Warning);
                return;
            }

            ClienteSelecionado = row;

            this.DialogResult = DialogResult.OK;
        }
    }
}
