using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unify.Budgets.UI.Controls.Controls;

namespace Unify.Budgets.UI.Controls.Classes
{
    public class UnifyForm : Form
    {
        public bool CloseOnEsc { get; set; } = true;
        public UnifyForm()
        {
            //FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //MaximizarSemCobrirTaskbar();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UnifyForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "UnifyForm";
            this.ResumeLayout(false);

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (CloseOnEsc && keyData == Keys.Escape)
            {
                Close();
                return true; // tecla consumida
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //protected void MaximizarSemCobrirTaskbar()
        //{
        //    Screen screen = Screen.FromControl(this);
        //    Rectangle wa = screen.WorkingArea;

        //    WindowState = FormWindowState.Normal;
        //    Bounds = wa;
        //    Location = new Point(wa.Left, wa.Top);
        //}
    }
}
