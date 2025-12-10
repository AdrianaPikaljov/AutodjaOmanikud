using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutodjaOmanikud
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        private ModernTextBox textBoxBrand;
        private ModernTextBox textBoxModel;
        private ModernTextBox textBoxRegistrationNumber;
        private ComboBox comboBoxOwner;

        private ModernButton buttonAddCar;
        private ModernButton buttonDeleteCar;
        private ModernButton buttonUpdateCar;

        private DarkDataGridView dataGridView1;

        private ModernTextBox textBoxSearch;

        private ModernButton button1; // Omanikud
        private ModernButton button2; // Hooldus ja teenused



        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            textBoxBrand = new ModernTextBox();
            textBoxModel = new ModernTextBox();
            textBoxRegistrationNumber = new ModernTextBox();
            comboBoxOwner = new ComboBox();

            buttonAddCar = new ModernButton();
            buttonDeleteCar = new ModernButton();
            buttonUpdateCar = new ModernButton();

            button1 = new ModernButton();
            button2 = new ModernButton();

            dataGridView1 = new DarkDataGridView();
            textBoxSearch = new ModernTextBox();

            SuspendLayout();

            // ======== FORM =========
            BackColor = Color.FromArgb(30, 30, 30);
            ForeColor = Color.White;
            ClientSize = new Size(800, 500);
            Font = new Font("Segoe UI", 10F);
            Text = "Autod";
            StartPosition = FormStartPosition.CenterScreen;

            // ======== INPUT FIELDS =========

            textBoxBrand.Location = new Point(20, 50);
            textBoxBrand.Size = new Size(280, 30);
            textBoxBrand.PlaceholderText = "Mark";

            textBoxModel.Location = new Point(20, 95);
            textBoxModel.Size = new Size(280, 30);
            textBoxModel.PlaceholderText = "Mudelinimi";

            textBoxRegistrationNumber.Location = new Point(20, 140);
            textBoxRegistrationNumber.Size = new Size(280, 30);
            textBoxRegistrationNumber.PlaceholderText = "Registreerimisnumber";

            comboBoxOwner.Location = new Point(20, 185);
            comboBoxOwner.Size = new Size(280, 30);
            comboBoxOwner.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOwner.BackColor = Color.FromArgb(45, 45, 45);
            comboBoxOwner.ForeColor = Color.White;

            // ======== BUTTON STYLE FUNCTION ========

            void StyleButton(ModernButton btn, Color bg)
            {
                btn.BackColor = bg;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
            }

            // ======== CRUD BUTTONS ==========

            buttonAddCar.Location = new Point(20, 235);
            buttonAddCar.Size = new Size(82, 40);
            buttonAddCar.Text = "Lisa";
            StyleButton(buttonAddCar, Color.FromArgb(0, 150, 136));
            buttonAddCar.Click += buttonAddCar_Click;

            buttonDeleteCar.Location = new Point(108, 235);
            buttonDeleteCar.Size = new Size(89, 40);
            buttonDeleteCar.Text = "Kustuta";
            StyleButton(buttonDeleteCar, Color.FromArgb(244, 67, 54));
            buttonDeleteCar.Click += buttonDeleteCar_Click;

            buttonUpdateCar.Location = new Point(203, 235);
            buttonUpdateCar.Size = new Size(97, 40);
            buttonUpdateCar.Text = "Uuenda";
            StyleButton(buttonUpdateCar, Color.FromArgb(33, 150, 243));
            buttonUpdateCar.Click += buttonUpdateCar_Click;

            // ======== GRID =========

            dataGridView1.Location = new Point(320, 50);
            dataGridView1.Size = new Size(450, 400);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.CellClick += dataGridView1_CellClick;

            // ======== NAV BUTTONS =========

            button1.Location = new Point(20, 460);
            button1.Size = new Size(122, 30);
            button1.Text = "Omanikud";
            StyleButton(button1, Color.FromArgb(96, 125, 139));
            button1.Click += button1_Click;

            button2.Location = new Point(148, 460);
            button2.Size = new Size(157, 30);
            button2.Text = "Hooldus ja Teenused";
            StyleButton(button2, Color.FromArgb(96, 125, 139));
            button2.Click += button2_Click;

            // ======== SEARCH BOX =========

            textBoxSearch.Location = new Point(320, 460);
            textBoxSearch.Size = new Size(450, 30);
            textBoxSearch.PlaceholderText = "Otsi autot...";
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;

            // ======== ADD TO FORM =========

            Controls.Add(textBoxBrand);
            Controls.Add(textBoxModel);
            Controls.Add(textBoxRegistrationNumber);
            Controls.Add(comboBoxOwner);

            Controls.Add(buttonAddCar);
            Controls.Add(buttonDeleteCar);
            Controls.Add(buttonUpdateCar);

            Controls.Add(dataGridView1);

            Controls.Add(button1);
            Controls.Add(button2);

            Controls.Add(textBoxSearch);

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
