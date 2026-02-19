using System.Drawing;
using System.Windows.Forms;
using Unify.Budgets.UI.Theme;

namespace Unify.Budgets.UI.Controls.Classes
{
    public class CustomMenuRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var item = e.Item;
            var g = e.Graphics;

            Color backColor;

            if (item.Selected)
                backColor = UnifyTheme.ThemeFocused; // fundo quando hover/expandido
            else
                backColor = UnifyTheme.ThemePrimary; // fundo normal

            using (var brush = new SolidBrush(backColor))
            {
                g.FillRectangle(brush, new Rectangle(Point.Empty, item.Size));
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            Color textColor = e.Item.Selected
                ? Color.White
                : Color.Gainsboro;

            e.TextColor = textColor;
            base.OnRenderItemText(e);
        }
    }
}
