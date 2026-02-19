using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Unify.Budgets.UI.Theme;

namespace Unify.Budgets.UI.Controls.Extensions
{
    public static class Grid
    {
        private const string CHECK_COLUMN_NAME = "__chk_single_select";

        #region Configuração de Colunas

        public static DataGridViewColumn ConfigurarColuna(this DataGridView grd, string coluna, string caption, int visibleIndex) => ConfigurarColuna(grd, coluna, caption, visibleIndex, "", 0);
        public static DataGridViewColumn ConfigurarColuna(this DataGridView grd, string coluna, string caption, int visibleIndex, int tamanho = 0) => ConfigurarColuna(grd, coluna, caption, visibleIndex, "", tamanho);
        public static DataGridViewColumn ConfigurarColuna(this DataGridView grd, string coluna, string caption, int visibleIndex, string formatString, int tamanho)
        {
            DataGridViewColumn col;

            if (!grd.Columns.Contains(coluna))
            {
                col = new DataGridViewTextBoxColumn
                {
                    Name = coluna,
                    DataPropertyName = coluna
                };
                grd.Columns.Add(col);
            }
            else
            {
                col = grd.Columns[coluna];
            }

            col.HeaderText = caption;

            if (visibleIndex >= 0)
            {
                col.DisplayIndex = Math.Min(visibleIndex, grd.Columns.Count - 1);
                col.Visible = true;
            }
            else
                col.Visible = false;

            if (tamanho > 0)
            {
                col.Width = tamanho;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            else
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (!string.IsNullOrWhiteSpace(formatString))
                col.DefaultCellStyle.Format = formatString;

            col.ReadOnly();

            return col;
        }

        public static DataGridViewColumn SetWidth(this DataGridViewColumn column, int width)
        {
            column.Width = width;
            return column;
        }

        public static DataGridViewColumn SetVisible(this DataGridViewColumn column, bool visible)
        {
            column.Visible = visible;
            return column;
        }

        public static DataGridViewColumn ReadOnly(this DataGridViewColumn column)
        {
            column.ReadOnly = true;
            return column;
        }

        public static DataGridViewColumn SetTextHAlignment(
            this DataGridViewColumn column,
            DataGridViewContentAlignment alignment)
        {
            column.DefaultCellStyle.Alignment = alignment;
            return column;
        }

        public static DataGridViewColumn SetBold(this DataGridViewColumn column)
        {
            column.DefaultCellStyle.Font =
                new Font(SystemFonts.DefaultFont, FontStyle.Bold);
            return column;
        }

        #endregion

        #region Inicialização Padrão

        public static void InicializarPadrao(this DataGridView grd)
        {
            grd.AllowUserToAddRows = false;
            grd.AllowUserToDeleteRows = true;
            grd.AllowUserToOrderColumns = true;
            grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grd.MultiSelect = false;
            grd.AutoGenerateColumns = false;
            grd.RowHeadersVisible = false;
            grd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grd.AllowUserToResizeRows = false;
            grd.ReadOnly = false;
            grd.BackgroundColor = UnifyTheme.ThemeSecondary;
            grd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            grd.EnableHeadersVisualStyles = false;
            grd.ColumnHeadersDefaultCellStyle.BackColor = UnifyTheme.Surface;
            grd.ColumnHeadersDefaultCellStyle.ForeColor = UnifyTheme.TextPrimary;
            grd.ColumnHeadersDefaultCellStyle.Font = UnifyTheme.Font;
            grd.DefaultCellStyle.BackColor = UnifyTheme.Background;
            grd.DefaultCellStyle.ForeColor = UnifyTheme.TextPrimary;
            grd.DefaultCellStyle.SelectionForeColor = Color.White;
            grd.DefaultCellStyle.SelectionBackColor = UnifyTheme.Accent;
            grd.ColumnHeadersDefaultCellStyle.SelectionBackColor = UnifyTheme.Surface;
            grd.Cursor = Cursors.Hand;
            grd.DefaultCellStyle.Font = UnifyTheme.Font;
            grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grd.ColumnHeadersHeight = 40;     // altura do header
            grd.ShowCellToolTips = false;
            grd.AllowUserToAddRows = false;
            grd.AllowUserToDeleteRows = false;
            grd.AllowUserToOrderColumns = true;

            grd.EnableRightClickRowFocus();

            //ApplyRoundedBorder(grd, 1, UnifyTheme.TextSecondary);

            grd.KeyDown -= Grid_KeyDown;
            grd.KeyDown += Grid_KeyDown;

            foreach (DataGridViewColumn col in grd.Columns)
                col.Visible = false;
        }

        private static void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            var grd = sender as DataGridView;

            if (e.Control && e.KeyCode == Keys.C)
            {
                if (grd.CurrentCell != null)
                {
                    Clipboard.SetText(
                        grd.CurrentCell.Value?.ToString() ?? string.Empty);
                    e.Handled = true;
                }
            }
        }


        #endregion

        #region Row Edit

        public class OptionDelete
        {
            public bool UseDeleteKey { get; set; } = true;
            public Action BeforeRowDelete { get; set; }
            public Action AfterRowDelete { get; set; }
        }

        public static void ConfigurarRowEdit(
            this DataGridView grd,
            Action add,
            Action<string> edit,
            OptionDelete optionDelete = null,
            Action duplicate = null,
            bool somenteLeitura = false)
        {
            grd.DoubleClick += (s, e) =>
            {
                if (somenteLeitura || edit == null) return;

                if (grd.CurrentCell != null)
                    edit(grd.Columns[grd.CurrentCell.ColumnIndex].Name);
            };

            grd.KeyDown += (s, e) =>
            {
                if (somenteLeitura) return;

                switch (e.KeyCode)
                {
                    case Keys.Insert:
                    case Keys.Add:
                        add?.Invoke();
                        break;

                    case Keys.Enter:
                        edit?.Invoke(string.Empty);
                        break;

                    case Keys.Delete:
                        if (optionDelete?.UseDeleteKey == true)
                        {
                            optionDelete.BeforeRowDelete?.Invoke();

                            if (MessageBox.Show(
                                "Confirma Exclusão do Registro?",
                                "Atenção",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                optionDelete.AfterRowDelete?.Invoke();
                            }
                        }
                        break;

                    case Keys.D:
                        if (e.Control)
                            duplicate?.Invoke();
                        break;
                }
            };
        }

        #endregion

        #region Drag and Drop

        public static void ConfiguraDragDrop(this DataGridView grd)
        {
            grd.AllowDrop = true;

            grd.MouseDown += (s, e) =>
            {
                if (grd.CurrentRow != null)
                    grd.DoDragDrop(grd.CurrentRow, DragDropEffects.Move);
            };

            grd.DragOver += (s, e) =>
            {
                e.Effect = DragDropEffects.Move;
            };

            grd.DragDrop += (s, e) =>
            {
                var clientPoint = grd.PointToClient(new Point(e.X, e.Y));
                var hit = grd.HitTest(clientPoint.X, clientPoint.Y);

                if (hit.RowIndex >= 0 && e.Data.GetDataPresent(typeof(DataGridViewRow)))
                {
                    var row = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                    grd.Rows.Remove(row);
                    grd.Rows.Insert(hit.RowIndex, row);
                }
            };
        }

        #endregion

        #region DataSource Helpers

        public static T GetFocusedRow<T>(this DataGridView grd) where T : class
        {
            return grd.CurrentRow?.DataBoundItem as T;
        }

        public static IEnumerable<T> GetSelectedRows<T>(this DataGridView grd)
            where T : class
        {
            foreach (DataGridViewRow r in grd.SelectedRows)
                if (r.DataBoundItem is T item)
                    yield return item;
        }

        #endregion

        #region Context Menu

        [Flags]
        public enum MenuOptions
        {
            Nenhum = 0,
            Duplicar = 1,
            Editar = 2,
            Excluir = 4,
            Todos = Duplicar | Editar | Excluir
        }

        public static void ConfigurarContextMenu(
            this DataGridView grd,
            ContextMenuStrip menu = null,
            MenuOptions options = MenuOptions.Todos)
        {
            if (menu == null)
                menu = new ContextMenuStrip();

            if (options.HasFlag(MenuOptions.Editar))
            {
                menu.Items.Add("Editar", null,
                    (s, e) => SendKeys.Send("{ENTER}"));
            }

            if (options.HasFlag(MenuOptions.Duplicar))
            {
                menu.Items.Add("Duplicar", null,
                    (s, e) => SendKeys.Send("^D"));
            }

            if (options.HasFlag(MenuOptions.Excluir))
            {
                menu.Items.Add("Excluir", null,
                    (s, e) => SendKeys.Send("{DELETE}"));
            }

            grd.ContextMenuStrip = menu;
        }

        #endregion

        #region Layout XML

        public static string GetLayoutAsXml(this DataGridView grd)
        {
            var xdoc = new XDocument(
                new XElement("Grid",
                    grd.Columns.Cast<DataGridViewColumn>()
                        .Select(c =>
                            new XElement("Column",
                                new XAttribute("Name", c.Name),
                                new XAttribute("Visible", c.Visible),
                                new XAttribute("Width", c.Width),
                                new XAttribute("DisplayIndex", c.DisplayIndex)
                            ))
                ));

            return xdoc.ToString();
        }

        public static void RestoreLayout(this DataGridView grd, string xml)
        {
            if (string.IsNullOrWhiteSpace(xml)) return;

            var xdoc = XDocument.Parse(xml);

            foreach (var el in xdoc.Descendants("Column"))
            {
                var name = el.Attribute("Name")?.Value;

                if (!grd.Columns.Contains(name))
                    continue;

                var col = grd.Columns[name];

                col.Visible = bool.Parse(el.Attribute("Visible").Value);
                col.Width = int.Parse(el.Attribute("Width").Value);
                col.DisplayIndex = int.Parse(el.Attribute("DisplayIndex").Value);
            }
        }

        #endregion

        #region MultiSelect CheckBox

        public static void EnableMultiSelect(this DataGridView grd, string checkField)
        {
            if (!grd.Columns.Contains(checkField))
            {
                var chk = new DataGridViewCheckBoxColumn
                {
                    Name = checkField,
                    DataPropertyName = checkField,
                    Width = 32
                };

                grd.Columns.Insert(0, chk);
            }

            grd.MultiSelect = true;
            grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        #endregion

        #region Utilidades Visuais

        public static Size ReCalcGridSize(this DataGridView grd)
        {
            int width = grd.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .Sum(c => c.Width) + 4;

            int height =
                grd.Rows.Cast<DataGridViewRow>().Sum(r => r.Height) +
                grd.ColumnHeadersHeight + 4;

            grd.Size = new Size(width, height);

            return grd.Size;
        }

        public static void ResetFilter(this DataGridView grd)
        {
            var bs = grd.DataSource as BindingSource;
            if (bs != null)
                bs.RemoveFilter();
        }

        private static void ApplyRoundedBorder(this DataGridView grid, int radius = 8, Color? borderColor = null)
        {
            var color = borderColor ?? Color.FromArgb(217, 217, 217);

            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = Color.White;

            grid.Paint += (s, e) =>
            {
                var rect = grid.ClientRectangle;

                var regionRect = new Rectangle(
                    rect.X,
                    rect.Y,
                    rect.Width - 1,
                    rect.Height - 1);

                var drawRect = new Rectangle(
                    rect.X,
                    rect.Y,
                    rect.Width - 2,
                    rect.Height - 2);

                using (var pathRegion = CreateRoundRect(regionRect, radius))
                using (var pathDraw = CreateRoundRect(drawRect, radius))
                using (var pen = new Pen(color))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    grid.Region = new Region(pathRegion);

                    e.Graphics.DrawPath(pen, pathDraw);
                }
            };
        }

        private static GraphicsPath CreateRoundRect(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);

            path.CloseFigure();
            return path;
        }
        #endregion

        public static void FilterGrid(this DataGridView grid, string texto)
        {
            if (grid.Rows.Count == 0)
                return;

            texto = (texto ?? string.Empty).Trim().ToLowerInvariant();

            CurrencyManager cm =
                grid.BindingContext[grid.DataSource] as CurrencyManager;

            grid.SuspendLayout();

            try
            {
                if (cm != null)
                    cm.SuspendBinding();

                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    bool encontrou = false;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value == null)
                            continue;

                        var valor = cell.Value.ToString().ToLowerInvariant();

                        if (valor.Contains(texto))
                        {
                            encontrou = true;
                            break;
                        }
                    }

                    if (string.IsNullOrEmpty(texto))
                    {
                        row.Visible = true;
                    }
                    else if (encontrou)
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            finally
            {
                if (cm != null)
                    cm.ResumeBinding();

                grid.ResumeLayout();
            }
        }

        public static void EnableRightClickRowFocus(this DataGridView grid)
        {
            if (grid == null)
                throw new ArgumentNullException(nameof(grid));

            // Evita múltiplas inscrições no evento
            grid.CellMouseDown -= Grid_CellMouseDown;
            grid.CellMouseDown += Grid_CellMouseDown;

            // Configurações recomendadas
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
        }

        private static void Grid_CellMouseDown(
            object sender,
            DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            if (!(sender is DataGridView grid))
                return;

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            grid.ClearSelection();
            grid.CurrentCell = grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            grid.Rows[e.RowIndex].Selected = true;
        }

        #region Selecao
        public static void EnableSingleCheckSelection(this DataGridView grid)
        {
            if (grid == null)
                throw new ArgumentNullException(nameof(grid));

            // Evita duplicação
            if (!grid.Columns.Contains(CHECK_COLUMN_NAME))
            {
                var chk = new DataGridViewCheckBoxColumn
                {
                    Name = CHECK_COLUMN_NAME,
                    HeaderText = "",
                    Width = 30,
                    FalseValue = false,
                    TrueValue = true
                };

                grid.Columns.Insert(0, chk);
            }

            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AllowUserToAddRows = false;

            // Remove handlers antigos (proteção contra múltiplas chamadas)
            grid.CurrentCellDirtyStateChanged -= Grid_CurrentCellDirtyStateChanged;
            grid.CellValueChanged -= Grid_CellValueChanged;

            // Registra eventos
            grid.CurrentCellDirtyStateChanged += Grid_CurrentCellDirtyStateChanged;
            grid.CellValueChanged += Grid_CellValueChanged;
        }


        public static T GetCheckedRow<T>(this DataGridView grd) where T : class
        {
            if (!grd.Columns.Contains(CHECK_COLUMN_NAME))
                return null;

            var row = grd.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells[CHECK_COLUMN_NAME].Value != null && Convert.ToBoolean(r.Cells[CHECK_COLUMN_NAME].Value));

            if (row == null)
                return null;

            return row?.DataBoundItem as T;
        }

        public static void ClearCheckedSelection(this DataGridView grid)
        {
            if (!grid.Columns.Contains(CHECK_COLUMN_NAME))
                return;

            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Cells[CHECK_COLUMN_NAME].Value = false;
            }
        }

        private static void Grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var grid = sender as DataGridView;

            if (grid?.IsCurrentCellDirty == true)
            {
                grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private static void Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;

            if (grid == null || e.RowIndex < 0)
                return;

            if (grid.Columns[e.ColumnIndex].Name != CHECK_COLUMN_NAME)
                return;

            bool marcado = Convert.ToBoolean(
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
            );

            if (!marcado)
                return;

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Index != e.RowIndex)
                {
                    row.Cells[CHECK_COLUMN_NAME].Value = false;
                }
            }

            // Sincroniza seleção visual
            grid.ClearSelection();
            grid.Rows[e.RowIndex].Selected = true;
        }
    }

    #endregion
}
