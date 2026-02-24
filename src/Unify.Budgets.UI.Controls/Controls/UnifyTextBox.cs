using ExCSS;
using Svg;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Unify.Budgets.UI.Controls.Classes;
using Unify.Budgets.UI.Controls.Enums;
using Unify.Budgets.UI.Theme;

namespace Unify.Budgets.UI.Controls.Controls
{
    [DefaultEvent("ActionClick")]
    public partial class UnifyTextBox : UserControl
    {
        public event EventHandler InputTextChanged;

        //public bool PlaceholderAtivo { get; private set; }
        //private string _placeholder = string.Empty;

        private TipoMascara _tipoMascara = TipoMascara.Texto;
        private string _mascaraCustomizada = string.Empty;
        private bool _readOnly;
        private bool _usarFonteCustomizada = false; 

        public UnifyTextBox()
        {
            InitializeComponent();
            RegistrarEventos();
            AplicarEstiloPadrao();
        }

        private void RegistrarEventos()
        {
            txtInput.KeyPress += ValidarMascaraKeyPress;
            txtInput.TextChanged += AplicarMascaraOnChange;
        }

        #region Propriedades Públicas
        [Category("Custom")]
        public string Caption
        {
            get => lblCaption.Text;
            set => lblCaption.Text = value;
        }

        [Category("Custom")]
        public bool UsarFonteCustomizada
        {
            get => _usarFonteCustomizada;
            set => _usarFonteCustomizada = value;
        }

        [Category("Custom")]
        public override Font Font
        {
            get => txtInput.Font;
            set => txtInput.Font = _usarFonteCustomizada ? value : new Font("Segoe UI", 10);
        }

        [Category("Custom")]
        public Color ForeColorInput
        {
            get => txtInput.ForeColor;
            set => txtInput.ForeColor = value;
        }


        [Category("Custom")]
        public Color BackColorInput
        {
            get => txtInput.BackColor;
            set {
                txtInput.BackColor = value;
                pnlContainer.BackColor = value;
            }
        }

        private decimal _valorSemMascara = 0;
        public decimal ValorSemMascara
        {
            get => _valorSemMascara;
            set => _valorSemMascara = value;
        }

        [Category("Custom")]
        public HorizontalAlignment TextAlign
        {
            get => txtInput.TextAlign;
            set => txtInput.TextAlign = value;
        }

        [Category("Custom")]
        public TipoMascara Mascara
        {
            get => _tipoMascara;
            set => _tipoMascara = value;
        }

        [Category("Custom")]
        public string MascaraCustomizada
        {
            get => _mascaraCustomizada;
            set => _mascaraCustomizada = value;
        }

        [Browsable(true)]
        public override string Text
        {
            get => txtInput.Text;
            set
            {
                txtInput.Text = value;
            }
        }


        #endregion

        #region Eventos

        [Category("Custom")]
        public event EventHandler ActionClick;

        #endregion

        #region Máscaras

        private void ValidarMascaraKeyPress(object sender, KeyPressEventArgs e)
        {
            //if (PlaceholderAtivo) return;

            switch (_tipoMascara)
            {
                case TipoMascara.Inteiro:
                    e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 8;
                    break;

                case TipoMascara.Decimal:
                case TipoMascara.Moeda:
                    e.Handled = !char.IsDigit(e.KeyChar) &&
                                e.KeyChar != 8 &&
                                e.KeyChar != ',';
                    break;
            }
        }

        private void AplicarMascaraOnChange(object sender, EventArgs e)
        {
            // Proteção de tamanho
            if (txtInput.MaxLength > 0 &&
                txtInput.Text.Length > txtInput.MaxLength)
            {
                txtInput.Text = txtInput.Text.Substring(0, txtInput.MaxLength);
                txtInput.SelectionStart = txtInput.Text.Length;
                return;
            }

            switch (_tipoMascara)
            {
                case TipoMascara.Moeda:
                    FormatarMoeda();
                    break;

                case TipoMascara.Data:
                    AplicarRegex(@"\d{2}/\d{2}/\d{4}");
                    break;

                case TipoMascara.DataHora:
                    AplicarRegex(@"\d{2}/\d{2}/\d{4} \d{2}:\d{2}");
                    break;

                case TipoMascara.Personalizada:
                    AplicarRegex(_mascaraCustomizada);
                    break;
            }
        }

        private void FormatarMoeda()
        {
            var somenteNumeros = Regex.Replace(txtInput.Text, @"[^\d]", "");

            if (MaxLength > 0 && somenteNumeros.Length > MaxLength)
                somenteNumeros = somenteNumeros.Substring(0, MaxLength);

            if (decimal.TryParse(somenteNumeros, out var valor))
            {
                valor /= 100;

                ValorSemMascara = valor;

                txtInput.Text = valor.ToString("C", new CultureInfo("pt-BR"));
                txtInput.SelectionStart = txtInput.Text.Length;
            }
        }


        private void AplicarRegex(string pattern)
        {
            if (!Regex.IsMatch(txtInput.Text, pattern))
                txtInput.ForeColor = Color.Red;
            else
                txtInput.ForeColor = UnifyTheme.TextPrimary;
        }

        #endregion

        #region Estilo

        private void AplicarEstiloPadrao()
        {
            this.DoubleBuffered = true;

            if(!this.UsarFonteCustomizada)
               txtInput.Font = UnifyTheme.Font;
        }

        #endregion

        #region Exposição Nativa

        public void SelectAll() => txtInput.SelectAll();
        public void Clear() => txtInput.Clear();
        public void FocusInput() => txtInput.Focus();

        [Browsable(false)]
        public TextBox InnerTextBox => txtInput;

        #endregion

        #region Somente Leitura

        [Category("Custom")]
        public bool ReadOnly
        {
            get => _readOnly;
            set
            {
                _readOnly = value;

                txtInput.ReadOnly = value;
                txtInput.BackColor = value
                    ? Color.FromArgb(245, 245, 245)
                    : Color.White;

                // Permite seleção e cópia
                txtInput.ShortcutsEnabled = true;
                txtInput.Cursor = Cursors.IBeam;
            }
        }

        #endregion

        #region Exposição TextBox Nativo

        public new bool Enabled
        {
            get => txtInput.Enabled;
            set
            {
                txtInput.Enabled = value;
            }
        }
        #endregion

        #region MaxLength

        [Category("Custom")]
        [Description("Define o tamanho máximo de caracteres do campo")]
        public int MaxLength
        {
            get => txtInput.MaxLength;
            set => txtInput.MaxLength = value;
        }
        #endregion

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            this.InputTextChanged?.Invoke(sender, e);
        }
    }
}
