using System;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using System.Xml.Linq;
using Unify.Application.DTOs;
using Unify.Application.Interfaces;
using Unify.Application.Services;
using Unify.CrossCutting.Logging;
using Unify.Domain.Entities;
using Unify.Domain.Exceptions;
using Unify.Shared.Conversion.Infra.Conversao;
using Unify.UI.Controls.Classes;
using Unify.UI.Controls.Enums;
using Unify.UI.Theme;

namespace Unify.UI.WinForms.Forms.Cadastros.Clientes
{
    public partial class frmCliente : UnifyForm
    {
        public ClienteDTO Row { get; set; }

        private IClienteService _clienteService;
        private ILogger _logger;

        public frmCliente(ILogger logger, IClienteService clienteService)
        {
            InitializeComponent();
            this.SetIcon();

            _clienteService = clienteService;
            _logger = logger;
        }

        private void frmCliente_Shown(object sender, EventArgs e)
        {
            if (Row != null)
            {
                txtNome.Text = Row.Nome;
                txtDocum.Text = Row.Documento;
                txtEmail.Text = Row.Email;
                txtFone.Text = Row.Telefone;
                txtRua.Text = Row.Rua;
                txtCidade.Text = Row.Cidade;
                txtBairro.Text = Row.Bairro;
                txtNr.Text = Row.Numero;
                txtEstado.Text = Row.Estado;
                txtComplemento.Text = Row.Complemento;
                txtCep.Text = Row.CEP;
                chkAtivo.Checked = Row.Ativo;
            }
            else
            {
                Row = new ClienteDTO();
            }

            txtNome.Focus();
        }

        private void unifyFrame1_ConfirmarButtonClick(object sender, EventArgs e)
        {
            try
            {
                Row.Nome = txtNome.Text;
                Row.Documento = txtDocum.Text;
                Row.Email = txtEmail.Text;
                Row.Telefone = txtFone.Text;
                Row.Rua = txtRua.Text;
                Row.Cidade = txtCidade.Text;
                Row.Bairro = txtBairro.Text;
                Row.Numero = txtNr.Text;
                Row.Estado = txtEstado.Text;
                Row.CEP = txtCep.Text;
                Row.Complemento = txtComplemento.Text;
                Row.Ativo = chkAtivo.Checked;

                if (Row.Id != 0)
                {
                    _clienteService.Atualizar(Row);
                }
                else
                {
                    _clienteService.Criar(Row);
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

        private void txtUnidade_ActionClick(object sender, EventArgs e)
        {

        }
    }
}
