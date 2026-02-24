using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Unify.UI.Controls.Enums;

namespace Unify.UI.Controls.Forms
{
    public partial class frmToast : Form
    {
        private Timer lifeTimer = new Timer();
        private Timer animTimer = new Timer();
        private int targetTop;
        private int opacityStep = 0;

        public frmToast(string text, ToastType type, int time)
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            Opacity = 0;

            lblText.Text = text;

            switch (type)
            {
                case ToastType.Success:
                    BackColor = Color.FromArgb(30, 170, 120);
                    break;

                case ToastType.Warning:
                    BackColor = Color.FromArgb(245, 180, 60);
                    break;

                case ToastType.Error:
                    BackColor = Color.FromArgb(220, 70, 70);
                    break;

                default:
                    BackColor = Color.FromArgb(80, 140, 230);
                    break;
            }


            lifeTimer.Interval = time;
            lifeTimer.Tick += (s, e) => Close();

            animTimer.Interval = 15;
            animTimer.Tick += AnimateIn;

            Load += ToastForm_Load;
        }

        private void ToastForm_Load(object sender, EventArgs e)
        {
            var area = Screen.PrimaryScreen.WorkingArea;
            Left = area.Right - Width - 20;
            Top = area.Bottom - Height - 20;
            targetTop = area.Bottom - Height - 30;

            animTimer.Start();
            lifeTimer.Start();
        }

        private void AnimateIn(object sender, EventArgs e)
        {
            try
            {
                if (Opacity < 1) Opacity += 0.08;
                if (Top > targetTop) Top -= 8;
                if (Opacity >= 1 && Top <= targetTop)
                    animTimer.Stop();
            }
            catch
            {
            }
        }
    }

}
