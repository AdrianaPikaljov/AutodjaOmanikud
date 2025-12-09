using System.Windows.Forms;

namespace AutodjaOmanikud
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxBrand;
        private TextBox textBoxModel;
        private TextBox textBoxRegistrationNumber;
        private ComboBox comboBoxOwner;
        private Button buttonAddCar;
        private Button buttonDeleteCar;
        private Button buttonUpdateCar;
        private DataGridView dataGridView1;

        private TextBox textBoxSearch;

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            textBoxBrand = new TextBox();
            textBoxModel = new TextBox();
            textBoxRegistrationNumber = new TextBox();
            comboBoxOwner = new ComboBox();
            buttonAddCar = new Button();
            buttonDeleteCar = new Button();
            buttonUpdateCar = new Button();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            textBoxSearch = new TextBox();

            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // --- textBoxBrand ---
            textBoxBrand.BackColor = Color.White;
            textBoxBrand.BorderStyle = BorderStyle.FixedSingle;
            textBoxBrand.Font = new Font("Segoe UI", 10F);
            textBoxBrand.Location = new Point(20, 50);
            textBoxBrand.Name = "textBoxBrand";
            textBoxBrand.PlaceholderText = "Mark";
            textBoxBrand.Size = new Size(280, 25);
            textBoxBrand.TabIndex = 0;

            // --- textBoxModel ---
            textBoxModel.BackColor = Color.White;
            textBoxModel.BorderStyle = BorderStyle.FixedSingle;
            textBoxModel.Font = new Font("Segoe UI", 10F);
            textBoxModel.Location = new Point(20, 95);
            textBoxModel.Name = "textBoxModel";
            textBoxModel.PlaceholderText = "Mudelinimi";
            textBoxModel.Size = new Size(280, 25);
            textBoxModel.TabIndex = 1;

            // --- textBoxRegistrationNumber ---
            textBoxRegistrationNumber.BackColor = Color.White;
            textBoxRegistrationNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxRegistrationNumber.Font = new Font("Segoe UI", 10F);
            textBoxRegistrationNumber.Location = new Point(20, 140);
            textBoxRegistrationNumber.Name = "textBoxRegistrationNumber";
            textBoxRegistrationNumber.PlaceholderText = "Registreerimisnumber";
            textBoxRegistrationNumber.Size = new Size(280, 25);
            textBoxRegistrationNumber.TabIndex = 2;

            // --- comboBoxOwner ---
            comboBoxOwner.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOwner.Font = new Font("Segoe UI", 10F);
            comboBoxOwner.Location = new Point(20, 185);
            comboBoxOwner.Name = "comboBoxOwner";
            comboBoxOwner.Size = new Size(280, 25);
            comboBoxOwner.TabIndex = 3;

            // --- buttonAddCar ---
            buttonAddCar.BackColor = Color.FromArgb(0, 150, 136);
            buttonAddCar.FlatAppearance.BorderSize = 0;
            buttonAddCar.FlatStyle = FlatStyle.Flat;
            buttonAddCar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonAddCar.ForeColor = Color.White;
            buttonAddCar.Location = new Point(20, 235);
            buttonAddCar.Name = "buttonAddCar";
            buttonAddCar.Size = new Size(82, 40);
            buttonAddCar.TabIndex = 4;
            buttonAddCar.Text = "Lisa";
            buttonAddCar.UseVisualStyleBackColor = false;
            buttonAddCar.Click += buttonAddCar_Click;

            // --- buttonDeleteCar ---
            buttonDeleteCar.BackColor = Color.FromArgb(244, 67, 54);
            buttonDeleteCar.FlatAppearance.BorderSize = 0;
            buttonDeleteCar.FlatStyle = FlatStyle.Flat;
            buttonDeleteCar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonDeleteCar.ForeColor = Color.White;
            buttonDeleteCar.Location = new Point(108, 235);
            buttonDeleteCar.Name = "buttonDeleteCar";
            buttonDeleteCar.Size = new Size(89, 40);
            buttonDeleteCar.TabIndex = 5;
            buttonDeleteCar.Text = "Kustuta";
            buttonDeleteCar.UseVisualStyleBackColor = false;
            buttonDeleteCar.Click += buttonDeleteCar_Click;

            // --- buttonUpdateCar ---
            buttonUpdateCar.BackColor = Color.FromArgb(33, 150, 243);
            buttonUpdateCar.FlatAppearance.BorderSize = 0;
            buttonUpdateCar.FlatStyle = FlatStyle.Flat;
            buttonUpdateCar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonUpdateCar.ForeColor = Color.White;
            buttonUpdateCar.Location = new Point(203, 235);
            buttonUpdateCar.Name = "buttonUpdateCar";
            buttonUpdateCar.Size = new Size(97, 40);
            buttonUpdateCar.TabIndex = 6;
            buttonUpdateCar.Text = "Uuenda";
            buttonUpdateCar.UseVisualStyleBackColor = false;
            buttonUpdateCar.Click += buttonUpdateCar_Click;

            // --- dataGridView1 ---
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(320, 50);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(450, 400);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellClick += dataGridView1_CellClick;

            // --- button1 ---
            button1.BackColor = Color.FromArgb(96, 125, 139);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(20, 460);
            button1.Name = "button1";
            button1.Size = new Size(122, 30);
            button1.TabIndex = 8;
            button1.Text = "Omanikud";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;

            // --- button2 ---
            button2.BackColor = Color.FromArgb(96, 125, 139);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(148, 460);
            button2.Name = "button2";
            button2.Size = new Size(157, 30);
            button2.TabIndex = 9;
            button2.Text = "Hooldus ja Teenused";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;

            // --- textBoxSearch (alla) ---
            textBoxSearch.BackColor = Color.White;
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 10F);
            textBoxSearch.Location = new Point(320, 460);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Otsi autot...";
            textBoxSearch.Size = new Size(450, 25);
            textBoxSearch.TabIndex = 10;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;

            // --- Form2 ---
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(800, 500);
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
            Controls.Add(textBoxSearch); // lisa otsingu box lõpuks
            Font = new Font("Segoe UI", 10F);
            Name = "Form2";
            Text = "Autod";

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        private Button button1;
        private Button button2;
    }
}
