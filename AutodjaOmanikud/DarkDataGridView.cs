using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutodjaOmanikud.UI
{
    public class DarkDataGridView : DataGridView
    {
        public DarkDataGridView()
        {
            BackgroundColor = Color.FromArgb(20, 20, 20);
            BorderStyle = BorderStyle.None;
            GridColor = Color.FromArgb(60, 60, 60);

            EnableHeadersVisualStyles = false;
            ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 140, 0);
            ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            DefaultCellStyle.BackColor = Color.FromArgb(25, 25, 25);
            DefaultCellStyle.ForeColor = Color.White;
            DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 140, 0);
            DefaultCellStyle.SelectionForeColor = Color.Black;

            RowTemplate.Height = 32;
            AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
        }
    }
}
