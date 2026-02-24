using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Unify.UI.Controls.Controls;

namespace Unify.UI.Theme
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
