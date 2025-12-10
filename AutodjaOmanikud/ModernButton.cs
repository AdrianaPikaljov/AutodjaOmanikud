using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutodjaOmanikud.UI
{
    public class ModernButton : Button
    {
        public ModernButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(30, 30, 30);
            ForeColor = Color.FromArgb(255, 140, 0);
            Font = new Font("Segoe UI", 10, FontStyle.Bold);

            Size = new Size(120, 40);
            Cursor = Cursors.Hand;

            Padding = new Padding(5);
            Margin = new Padding(5);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Pen borderPen = new Pen(Color.FromArgb(255, 140, 0), 2);

            g.DrawRectangle(borderPen, rect);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            BackColor = Color.FromArgb(255, 140, 0);
            ForeColor = Color.Black;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = Color.FromArgb(30, 30, 30);
            ForeColor = Color.FromArgb(255, 140, 0);
        }
    }
}
