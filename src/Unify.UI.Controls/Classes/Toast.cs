using System.Threading;
using System.Windows.Forms;
using Unify.UI.Controls.Enums;
using Unify.UI.Controls.Forms;

namespace Unify.UI.Controls.Classes
{
    public static class Toast
    {
        public static void Show(string text, ToastType type = ToastType.Info, int time = 3000)
        {
            var t = new Thread(() =>
            {
                var toast = new frmToast(text, type, time);
                toast.StartPosition = FormStartPosition.Manual;

                var area = Screen.PrimaryScreen.WorkingArea;
                toast.Left = area.Right - toast.Width - 20;
                toast.Top = area.Bottom - toast.Height - 20;

                Application.Run(toast);
            });

            t.IsBackground = true;
            t.Start();
        }
    }

}
