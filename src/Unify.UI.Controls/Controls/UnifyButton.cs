using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Unify.UI.Controls.Enums;
using Unify.UI.Theme;

namespace Unify.UI.Controls.Controls
{

    [DefaultEvent("Click")]
    public partial class UnifyButton : UserControl
    {
        private bool _hover;
        private bool _pressed;
        private ButtonTheme _theme = ButtonTheme.Primary;
        private string _text = "Button";

        public UnifyButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            Font = UnifyTheme.Font;
            Size = new Size(103, 29);
            Cursor = Cursors.Hand;
        }

        #region Properties

        [Category("Appearance")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                Invalidate();
            }
        }


        [Category("Appearance")]
        public ButtonTheme Theme
        {
            get => _theme;
            set
            {
                _theme = value;
                Invalidate();
            }
        }

        #endregion

        #region Theme Definitions

        private Color GetBackColor()
        {
            if (!Enabled)
                return Color.FromArgb(200, 200, 200);

            switch (_theme)
            {
                case ButtonTheme.White:
                    return Color.White;

                case ButtonTheme.Primary:
                    return UnifyTheme.Primary;

                case ButtonTheme.Success:
                    return UnifyTheme.Success;

                case ButtonTheme.Warning:
                    return UnifyTheme.Warning;

                case ButtonTheme.Danger:
                    return UnifyTheme.Danger;

                case ButtonTheme.ThemePrimary:
                    return UnifyTheme.ThemePrimary;

                case ButtonTheme.ThemeSecondary:
                    return UnifyTheme.ThemeSecondary;

                default:
                    return UnifyTheme.ThemePrimary;
            }
        }

        private Color ResolveForeColor()
        {
            // Se o desenvolvedor definiu manualmente
            // ou desativou o modo automático, respeitamos 100%
            if (!UseAutomaticForeColor || ForeColor != SystemColors.ControlText)
                return ForeColor;

            // Comportamento padrão apenas se não houver definição explícita
            if (_theme == ButtonTheme.White)
                return Color.FromArgb(60, 60, 60);

            return Color.White;
        }

        private bool _useAutomaticForeColor = true;

        [Category("Appearance")]
        [Description("Define se o controle deve calcular automaticamente a cor da fonte conforme o tema")]
        public bool UseAutomaticForeColor
        {
            get => _useAutomaticForeColor;
            set
            {
                _useAutomaticForeColor = value;
                Invalidate();
            }
        }

        private Color GetHoverColor(Color baseColor)
        {
            return ControlPaint.Light(baseColor, 0.10f);
        }

        private Color GetPressedColor(Color baseColor)
        {
            return ControlPaint.Dark(baseColor, 0.10f);
        }

        #endregion

        #region Painting

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = ClientRectangle;
            rect.Inflate(-1, -1);

            var back = GetBackColor();

            if (_pressed)
                back = GetPressedColor(back);
            else if (_hover)
                back = GetHoverColor(back);

            var backEnd = ControlPaint.Dark(back, 0.15f);

            using (GraphicsPath path = CreateRoundRect(rect, 6))
            using (SolidBrush brush = new SolidBrush(back))
            {
                g.FillPath(brush, path);

                if (_theme == ButtonTheme.White)
                {
                    using (Pen pen = new Pen(Color.FromArgb(217, 217, 217)))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }

            TextRenderer.DrawText(
                g,
                Text,
                Font,
                rect,
                ResolveForeColor(),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }


        private GraphicsPath CreateRoundRect(Rectangle r, int radius)
        {
            var path = new GraphicsPath();

            path.AddArc(r.X, r.Y, radius, radius, 180, 90);
            path.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90);
            path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90);

            path.CloseFigure();
            return path;
        }

        #endregion

        #region Mouse Events

        protected override void OnMouseEnter(EventArgs e)
        {
            _hover = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _hover = false;
            _pressed = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _pressed = true;
                Invalidate();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _pressed = false;
            Invalidate();
            base.OnMouseUp(e);
        }

        #endregion

        #region Accessibility

        protected override void OnEnabledChanged(EventArgs e)
        {
            Cursor = Enabled ? Cursors.Hand : Cursors.Default;
            Invalidate();
            base.OnEnabledChanged(e);
        }

        #endregion
    }

}
