using System.Drawing;
using Unify.Budgets.UI.Controls.Properties;

namespace Unify.Budgets.UI.Theme
{
    public class UnifyTheme
    {
        public static readonly Color Primary = ColorTranslator.FromHtml("#0D6EFD");
        public static readonly Color Success = ColorTranslator.FromHtml("#198754");
        public static readonly Color Warning = ColorTranslator.FromHtml("#FFC107");
        public static readonly Color Danger = ColorTranslator.FromHtml("#DC3545");

        public static readonly Color ThemePrimary = ColorTranslator.FromHtml("#1f1f1f"); //ColorTranslator.FromHtml("#d10300");
        public static readonly Color ThemeSecondary = ColorTranslator.FromHtml("#F1F2F6");
        public static readonly Color ThemeFocused = ColorTranslator.FromHtml("#2d2d30"); //ColorTranslator.FromHtml("#d10300");

        public static readonly Color Background = ColorTranslator.FromHtml("#F5F6FA");
        public static readonly Color Surface = ColorTranslator.FromHtml("#FFFFFF");
        public static readonly Color Border = ColorTranslator.FromHtml("#E0E0E0");
        public static readonly Color Accent = ColorTranslator.FromHtml("#5676d6");  //ColorTranslator.FromHtml("#FF6B6B");

        public static readonly Color TextPrimary = ColorTranslator.FromHtml("#1F1F1F");
        public static readonly Color TextSecondary = ColorTranslator.FromHtml("#6B6B6B");
        public static readonly Color Disabled = ColorTranslator.FromHtml("#BDBDBD");

        public static readonly Font Font = new Font("Segoe UI", 9.4f);
        public static readonly Font TitleFont = new Font("Segoe UI", 12f, FontStyle.Bold);
        public static readonly string LinkTag = "link";

        public static byte[] MainIcon = Resources.Unify;
    }
}
