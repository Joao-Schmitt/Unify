using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Unify.UI.Controls.Classes
{
    static class NativeMethods
    {
        [DllImport("user32.dll")]
        private static extern bool RedrawWindow(
            IntPtr hWnd, IntPtr lprc, IntPtr hrgn, uint flags);

        public static void Redraw(IntPtr handle)
        {
            RedrawWindow(handle, IntPtr.Zero, IntPtr.Zero,
                0x0001 | 0x0004 | 0x0100);
        }
    }
}
