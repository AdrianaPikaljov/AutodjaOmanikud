using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace AutodjaOmanikud
{
    // Ümar oranž neon nupp
    public class ModernButton : Button
    {
        public ModernButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(30, 30, 30);
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(Parent?.BackColor ?? Color.FromArgb(30, 30, 30));

            int radius = 10;
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = GetRoundedRectangle(rect, radius))
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 140, 0))) // neon orange
            using (Pen borderPen = new Pen(Color.FromArgb(255, 180, 80), 1))
            {
                pevent.Graphics.FillPath(brush, path);
                pevent.Graphics.DrawPath(borderPen, path);
            }

            TextRenderer.DrawText(
                pevent.Graphics,
                Text,
                Font,
                rect,
                Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            BackColor = Color.FromArgb(60, 60, 60);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = Color.FromArgb(30, 30, 30);
            Invalidate();
        }

        private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }

    // Tume ümar tekstikast
    public class ModernTextBox : TextBox
    {
        public ModernTextBox()
        {
            BorderStyle = BorderStyle.None;
            BackColor = Color.FromArgb(45, 45, 45);
            ForeColor = Color.FromArgb(220, 220, 220);
            Font = new Font("Segoe UI", 10);
            Padding = new Padding(5);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Height = 28;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x000F && Parent != null) // WM_PAINT
            {
                using (Graphics g = Parent.CreateGraphics())
                {
                    Rectangle rect = new Rectangle(Left - 2, Top - 2, Width + 4, Height + 4);
                    using (Pen p = new Pen(Color.FromArgb(80, 80, 80)))
                    using (SolidBrush b = new SolidBrush(Color.FromArgb(45, 45, 45)))
                    {
                        g.FillRectangle(b, rect);
                        g.DrawRectangle(p, rect);
                    }
                }
            }
        }
    }

    // Tume DataGridView
    public class DarkDataGridView : DataGridView
    {
        public DarkDataGridView()
        {
            EnableHeadersVisualStyles = false;
            BackgroundColor = Color.FromArgb(30, 30, 30);
            BorderStyle = BorderStyle.None;
            GridColor = Color.FromArgb(60, 60, 60);

            ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 220);
            ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
            DefaultCellStyle.ForeColor = Color.FromArgb(230, 230, 230);
            DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 140, 0); // neon orange
            DefaultCellStyle.SelectionForeColor = Color.Black;

            AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);

            RowHeadersVisible = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
