using System;
using System.Windows.Forms;
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

namespace Unify.UI.WinForms.Forms.Cadastros.Unidades
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
