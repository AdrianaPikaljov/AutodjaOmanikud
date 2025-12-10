using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutodjaOmanikud
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private ModernTextBox textBox1;          // FullName
        private ModernTextBox textBox2;          // Phone
        private ModernTextBox textBoxSearchName;
        private ModernTextBox textBoxSearchPhone;

        private ModernButton button1; // Lisa
        private ModernButton button2; // Kustuta
        private ModernButton button3; // Uuenda
        private ModernButton button4; // Autod
        private ModernButton button5; // Hooldus ja Teenused

        private Label label1;
        private Label label2;

        private DarkDataGridView dataGridView1;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            textBox1 = new ModernTextBox();
            textBox2 = new ModernTextBox();
            textBoxSearchName = new ModernTextBox();
            textBoxSearchPhone = new ModernTextBox();

            button1 = new ModernButton();
            button2 = new ModernButton();
            button3 = new ModernButton();
            button4 = new ModernButton();
            button5 = new ModernButton();

            label1 = new Label();
            label2 = new Label();

            dataGridView1 = new DarkDataGridView();

            SuspendLayout();

            // ===== FORM =====
            BackColor = Color.FromArgb(30, 30, 30);
            ForeColor = Color.White;
            ClientSize = new Size(950, 550);
            Font = new Font("Segoe UI", 10F);
            Text = "Omanikud";
            StartPosition = FormStartPosition.CenterScreen;

            // ===== LABELS =====
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(30, 10);
            label1.Text = "Otsing";

            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(30, 150);
            label2.Text = "Lisa / Kustuta / Muuda andmed";

            // ===== SEARCH TEXTBOXES =====
            textBoxSearchName.Location = new Point(30, 60);
            textBoxSearchName.Size = new Size(280, 30);
            textBoxSearchName.PlaceholderText = "Otsi nime järgi...";
            textBoxSearchName.ForeColor = Color.White;

            textBoxSearchPhone.Location = new Point(30, 100);
            textBoxSearchPhone.Size = new Size(280, 30);
            textBoxSearchPhone.PlaceholderText = "Otsi telefoni järgi...";
            textBoxSearchPhone.ForeColor = Color.White;

            textBoxSearchName.TextChanged += textBoxSearchName_TextChanged;
            textBoxSearchPhone.TextChanged += textBoxSearchPhone_TextChanged;

            // ===== INPUT TEXTBOXES =====
            textBox1.Location = new Point(30, 190);
            textBox1.Size = new Size(280, 30);
            textBox1.PlaceholderText = "Täisnimi";
            textBox1.ForeColor = Color.White;

            textBox2.Location = new Point(30, 230);
            textBox2.Size = new Size(280, 30);
            textBox2.PlaceholderText = "Telefon";
            textBox2.ForeColor = Color.White;

            // ===== BUTTON BASE STYLE =====
            void StyleButton(ModernButton btn, Color bg)
            {
                btn.BackColor = bg;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
            }

            // ===== CRUD BUTTONS =====

            button1.Location = new Point(31, 280);
            button1.Size = new Size(89, 40);
            button1.Text = "Lisa";
            StyleButton(button1, Color.FromArgb(0, 150, 136));
            button1.Click += button1_Click;

            button2.Location = new Point(126, 280);
            button2.Size = new Size(90, 40);
            button2.Text = "Kustuta";
            StyleButton(button2, Color.FromArgb(244, 67, 54));
            button2.Click += button2_Click_1;

            button3.Location = new Point(222, 280);
            button3.Size = new Size(88, 40);
            button3.Text = "Uuenda";
            StyleButton(button3, Color.FromArgb(33, 150, 243));
            button3.Click += button3_Click;

            // ===== NAVIGATION BUTTONS =====

            button4.Location = new Point(30, 400);
            button4.Size = new Size(129, 40);
            button4.Text = "Autod";
            StyleButton(button4, Color.FromArgb(96, 125, 139));
            button4.Click += button4_Click;

            button5.Location = new Point(178, 400);
            button5.Size = new Size(163, 40);
            button5.Text = "Hooldus ja Teenused";
            StyleButton(button5, Color.FromArgb(96, 125, 139));
            button5.Click += button5_Click;

            // ===== DATAGRID =====
            dataGridView1.Location = new Point(350, 60);
            dataGridView1.Size = new Size(570, 450);
            dataGridView1.CellClick += dataGridView1_CellClick;

            // ===== ADD CONTROLS =====
            Controls.Add(label1);
            Controls.Add(label2);

            Controls.Add(textBoxSearchName);
            Controls.Add(textBoxSearchPhone);

            Controls.Add(textBox1);
            Controls.Add(textBox2);

            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button5);

            Controls.Add(dataGridView1);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
