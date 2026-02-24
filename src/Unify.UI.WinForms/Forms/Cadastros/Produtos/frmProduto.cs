using System;
using System.Data.Entity.Core.Mapping;
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

namespace Unify.UI.WinForms.Forms.Cadastros.Produtos
{
    public partial class frmProduto : UnifyForm
    {
        public ProdutoDTO Row { get; set; }

        private IProdutoService _produtoService;
        private IUnidadeService _unidadeService;
        private ILogger _logger;

        public frmProduto(ILogger logger, IProdutoService produtoService, IUnidadeService unidadeService)
        {
            InitializeComponent();
            this.SetIcon();

            _produtoService = produtoService;
            _logger = logger;
            _unidadeService = unidadeService;
        }

        private void frmProduto_Shown(object sender, EventArgs e)
        {
            if (Row != null)
            {
                txtNome.Text = Row.Nome;
                txtUnidade.Text = Row.Unidade;
                txtUnidadeDescricao.Text = Row.DescricaoUnidade;
                txtVlrUnidade.Text = Row.PrecoUnidade.ToString("N2");
            }
            else
            {
                Row = new ProdutoDTO();
            }

            txtNome.Focus();
        }

        private void unifyFrame1_ConfirmarButtonClick(object sender, EventArgs e)
        {
            try
            {
                Row.Nome = txtNome.Text;
                Row.Unidade = txtUnidade.Text;
                Row.PrecoUnidade = txtVlrUnidade.ValorSemMascara;
                Row.Ativo = chkAtivo.Checked;

                if (Row.Id != 0)
                {
                    _produtoService.Atualizar(Row);
                }
                else
                {
                    _produtoService.Criar(Row);
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

        private void txtUnidade_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnidade.Text))
                return;

            txtUnidadeDescricao.Text = _unidadeService.ObterPorSigla(txtUnidade.Text)?.Descricao?? string.Empty;
        }
    }
}
