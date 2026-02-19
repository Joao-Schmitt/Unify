using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Unify.Budgets.UI.Controls.Controls;

namespace Unify.Budgets.UI.Theme
{
    public static class FormEx
    {
        public static void SetIcon(this Form form)
        {
            var ms = new MemoryStream(UnifyTheme.MainIcon);
            form.Icon = new Icon(ms);
        }
    }
}
