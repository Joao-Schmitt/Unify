using System;
using System.Windows.Forms;
using Unify.Application.DTOs;
using Unify.Application.Interfaces;
using Unify.CrossCutting.Logging;
using Unify.Domain.Exceptions;
using Unify.Shared.Conversion.Infra.Conversao;
using Unify.UI.Controls.Classes;
using Unify.UI.Controls.Enums;
using Unify.UI.Theme;

namespace Unify.UI.WinForms.Forms.Cadastros.Servicos
{
    public partial class frmServico : Form
    {
        public ServicoDTO Row { get; set; }

        private IServicoService _ServicoService;
        private ILogger _logger;

        public frmServico(ILogger logger, IServicoService ServicoService)
        {
            InitializeComponent();
            this.SetIcon();

            _ServicoService = ServicoService;
            _logger = logger;
        }

        private void frmServico_Shown(object sender, EventArgs e)
        {
            if (Row != null)
            {
                txtNome.Text = Row.Nome;
                txtPreco.Text = Row.PrecoBase.ToString("N2");
                //txtTempo.Text = SafeConverter.ToString(Row.TempoMedioMinutos);
                //txtObs.Text = Row.Observacoes;
                chkAtivo.Checked = Row.Ativo;
            }
            else
            {
                Row = new ServicoDTO();
            }

            txtNome.Focus();
        }

        private void unifyFrame1_ConfirmarButtonClick(object sender, EventArgs e)
        {
            try
            {
                Row.Nome = txtNome.Text;
                Row.PrecoBase = txtPreco.ValorSemMascara;
                //Row.TempoMedioMinutos = SafeConverter.ToInt(txtTempo.Text);
                //Row.Observacoes = txtObs.Text;
                Row.Ativo = chkAtivo.Checked;

                if (Row.Id != 0)
                {
                    _ServicoService.Atualizar(Row);
                }
                else
                {
                    _ServicoService.Criar(Row);
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

    }
}
