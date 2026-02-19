using System;
using System.Windows.Forms;
using Unify.Budgets.Application.DTOs;
using Unify.Budgets.Application.Interfaces;
using Unify.Budgets.Application.Services;
using Unify.Budgets.CrossCutting.Logging;
using Unify.Budgets.Domain.Entities;
using Unify.Budgets.Domain.Exceptions;
using Unify.Budgets.Shared.Conversion.Infra.Conversao;
using Unify.Budgets.UI.Controls.Classes;
using Unify.Budgets.UI.Controls.Enums;
using Unify.Budgets.UI.Theme;

namespace Unify.Budgets.UI.WinForms.Forms.Cadastros.Unidades
{
    public partial class frmUnidade : UnifyForm
    {
        public UnidadeDTO Row { get; set; }

        private IUnidadeService _UnidadeService;
        private ILogger _logger;

        public frmUnidade(ILogger logger, IUnidadeService UnidadeService)
        {
            InitializeComponent();
            this.SetIcon();

            _UnidadeService = UnidadeService;
            _logger = logger;
        }

        private void frmUnidade_Shown(object sender, EventArgs e)
        {
            if (Row != null)
            {
                txtSigla.Text = Row.Sigla;
                txtDescricao.Text = Row.Descricao;
            }
            else
            {
                Row = new UnidadeDTO();
            }

            txtSigla.Focus();
        }

        private void unifyFrame1_ConfirmarButtonClick(object sender, EventArgs e)
        {
            try
            {
                Row.Sigla = txtSigla.Text;
                Row.Descricao = txtDescricao.Text;

                if (Row.Id != 0)
                {
                    _UnidadeService.Atualizar(Row);
                }
                else
                {
                    _UnidadeService.Criar(Row);
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

        private void txtDescricao_ActionClick(object sender, EventArgs e)
        {

        }
    }
}
