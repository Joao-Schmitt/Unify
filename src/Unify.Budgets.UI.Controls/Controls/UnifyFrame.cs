using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unify.Budgets.UI.Controls.Classes;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Unify.Budgets.UI.Controls.Controls
{
    public partial class UnifyFrame : UserControl
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            int msg,
            int wParam,
            int lParam
        );


        public event EventHandler ConfirmarButtonClick;
        public event EventHandler SairButtonClick;
        public UnifyFrame()
        {
            InitializeComponent();
            RegistrarEventos();
            ConfiguraInfo();
        }

        private void RegistrarEventos()
        {
            btnConfirmar.Click += btnConfirmar_Click;
            btnSair.Click += btnSair_Click;
            info.Paint += Panel1_Paint;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.ConfirmarButtonClick?.Invoke(sender, e);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            SairButtonClick?.Invoke(sender, e);
            this.UseWaitCursor = false;
            this.FindForm()?.Close();
        }

        [Category("Custom")]
        public bool ConfirmarButtonVisible
        {
            get => btnConfirmar.Visible;
            set => btnConfirmar.Visible = value;
        }

        [Category("Custom")]
        public bool SairButtonVisible
        {
            get => btnSair.Visible;
            set => btnSair.Visible = value;
        }

        [Category("Custom")]
        public bool InfoVisible
        {
            get => info.Visible;
            set {
                info.Visible = value;
                lblInfo.Visible = value;
            }
        }

        [Category("Custom")]
        public string InfoText
        {
            get => lblInfo.Text;
            set => lblInfo.Text = value;
        }

        private void ConfiguraInfo()
        {
            info.BackColor = Theme.UnifyTheme.ThemePrimary;
            lblInfo.ForeColor = Color.White;
            lblInfo.Font = Theme.UnifyTheme.Font;
            lblInfo.BackColor = Color.Transparent;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            //var g = e.Graphics;
            //g.SmoothingMode = SmoothingMode.AntiAlias;

            //var panel = (Panel)sender;
            //var rect = panel.ClientRectangle;

            //using (var brush = new LinearGradientBrush(
            //    rect,
            //    Color.FromArgb(209, 8, 9),   // #D10809
            //    Color.FromArgb(160, 6, 7),
            //    LinearGradientMode.Vertical))
            //{
            //    g.FillRectangle(brush, rect);
            //}
        }

        private void info_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            Form parentForm = this.FindForm();
            if (parentForm == null)
                return;

            if (e.Clicks == 2)
            {
                parentForm.WindowState =
                    parentForm.WindowState == FormWindowState.Maximized
                        ? FormWindowState.Normal
                        : FormWindowState.Maximized;
            }

            ReleaseCapture();
            SendMessage(parentForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
    }
}
