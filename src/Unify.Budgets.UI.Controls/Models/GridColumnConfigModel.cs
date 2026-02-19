using System.Windows.Forms;
using Unify.Budgets.UI.Controls.Enums;

namespace Unify.Budgets.UI.Controls.Models
{
    public class GridColumnConfigModel
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public int Width { get; set; } = 100;
        public GridColumnType Type { get; set; }
        public string Format { get; set; }
        public DataGridViewContentAlignment Alignment { get; set; } = DataGridViewContentAlignment.MiddleLeft;
        public bool Visible { get; set; } = true;
        public bool ReadOnly { get; set; } = true;
    }

}
