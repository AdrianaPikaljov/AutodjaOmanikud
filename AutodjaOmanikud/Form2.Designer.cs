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

        private void InitializeComponent()
        {
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBoxBrand
            // 
            textBoxBrand.Location = new Point(20, 50);
            textBoxBrand.Name = "textBoxBrand";
            textBoxBrand.PlaceholderText = "Mark";
            textBoxBrand.Size = new Size(250, 23);
            textBoxBrand.TabIndex = 1;
            // 
            // textBoxModel
            // 
            textBoxModel.Location = new Point(20, 90);
            textBoxModel.Name = "textBoxModel";
            textBoxModel.PlaceholderText = "Mudelinimi";
            textBoxModel.Size = new Size(250, 23);
            textBoxModel.TabIndex = 2;
            // 
            // textBoxRegistrationNumber
            // 
            textBoxRegistrationNumber.Location = new Point(20, 130);
            textBoxRegistrationNumber.Name = "textBoxRegistrationNumber";
            textBoxRegistrationNumber.PlaceholderText = "Registreerimisnumber";
            textBoxRegistrationNumber.Size = new Size(250, 23);
            textBoxRegistrationNumber.TabIndex = 3;
            // 
            // comboBoxOwner
            // 
            comboBoxOwner.Location = new Point(20, 170);
            comboBoxOwner.Name = "comboBoxOwner";
            comboBoxOwner.Size = new Size(250, 23);
            comboBoxOwner.TabIndex = 4;
            comboBoxOwner.SelectedIndexChanged += comboBoxOwner_SelectedIndexChanged;
            // 
            // buttonAddCar
            // 
            buttonAddCar.Location = new Point(20, 210);
            buttonAddCar.Name = "buttonAddCar";
            buttonAddCar.Size = new Size(75, 30);
            buttonAddCar.TabIndex = 5;
            buttonAddCar.Text = "Lisa";
            buttonAddCar.UseVisualStyleBackColor = true;
            buttonAddCar.Click += buttonAddCar_Click;
            // 
            // buttonDeleteCar
            // 
            buttonDeleteCar.Location = new Point(120, 210);
            buttonDeleteCar.Name = "buttonDeleteCar";
            buttonDeleteCar.Size = new Size(75, 30);
            buttonDeleteCar.TabIndex = 6;
            buttonDeleteCar.Text = "Kustuta";
            buttonDeleteCar.UseVisualStyleBackColor = true;
            buttonDeleteCar.Click += buttonDeleteCar_Click;
            // 
            // buttonUpdateCar
            // 
            buttonUpdateCar.Location = new Point(220, 210);
            buttonUpdateCar.Name = "buttonUpdateCar";
            buttonUpdateCar.Size = new Size(75, 30);
            buttonUpdateCar.TabIndex = 7;
            buttonUpdateCar.Text = "Uuenda";
            buttonUpdateCar.UseVisualStyleBackColor = true;
            buttonUpdateCar.Click += buttonUpdateCar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Location = new Point(300, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(450, 350);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // button1
            // 
            button1.Location = new Point(12, 415);
            button1.Name = "button1";
            button1.Size = new Size(98, 23);
            button1.TabIndex = 8;
            button1.Text = "Omanikud";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(116, 415);
            button2.Name = "button2";
            button2.Size = new Size(130, 23);
            button2.TabIndex = 9;
            button2.Text = "Hooldus ja Teenused";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form2
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(buttonUpdateCar);
            Controls.Add(buttonDeleteCar);
            Controls.Add(buttonAddCar);
            Controls.Add(comboBoxOwner);
            Controls.Add(textBoxRegistrationNumber);
            Controls.Add(textBoxModel);
            Controls.Add(textBoxBrand);
            Name = "Form2";
            Text = "Autod";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button button1;
        private Button button2;
    }
}
