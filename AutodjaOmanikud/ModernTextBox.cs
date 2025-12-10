using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutodjaOmanikud.UI
{
    public class ModernTextBox : TextBox
    {
        private bool isFocused = false;
        public string Placeholder { get; set; } = "";

        public ModernTextBox()
        {
            BorderStyle = BorderStyle.None;
            BackColor = Color.FromArgb(35, 35, 35);
            ForeColor = Color.FromArgb(230, 230, 230);
            Font = new Font("Segoe UI", 10);

            Padding = new Padding(7);
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            isFocused = true;
            Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            isFocused = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Pen borderPen = new Pen(
                isFocused ? Color.FromArgb(255, 140, 0) : Color.FromArgb(90, 90, 90),
                2
            );

            g.DrawRectangle(borderPen, rect);

            if (!isFocused && Text.Length == 0 && !string.IsNullOrEmpty(Placeholder))
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    Placeholder,
                    Font,
                    rect,
                    Color.Gray,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter
                );
            }
        }
    }
}
