namespace AutodjaOmanikud
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBox1;          // FullName muudetav
        private System.Windows.Forms.TextBox textBox2;          // Phone muudetav
        private System.Windows.Forms.TextBox textBoxSearchName; // Otsing FullName
        private System.Windows.Forms.TextBox textBoxSearchPhone;// Otsing Phone
        private System.Windows.Forms.Button button1; // Lisa
        private System.Windows.Forms.Button button2; // Kustuta
        private System.Windows.Forms.Button button3; // Uuenda
        private System.Windows.Forms.Button button4; // Autod
        private System.Windows.Forms.Button button5; // Hooldus ja Teenused
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBoxSearchName = new TextBox();
            textBoxSearchPhone = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            label1 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.Location = new Point(30, 190);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(280, 25);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.White;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 10F);
            textBox2.Location = new Point(30, 230);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(280, 25);
            textBox2.TabIndex = 3;
            // 
            // textBoxSearchName
            // 
            textBoxSearchName.BackColor = Color.White;
            textBoxSearchName.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearchName.Font = new Font("Segoe UI", 10F);
            textBoxSearchName.Location = new Point(30, 60);
            textBoxSearchName.Name = "textBoxSearchName";
            textBoxSearchName.PlaceholderText = "Otsi nime järgi...";
            textBoxSearchName.Size = new Size(280, 25);
            textBoxSearchName.TabIndex = 4;
            textBoxSearchName.TextChanged += textBoxSearchName_TextChanged;
            // 
            // textBoxSearchPhone
            // 
            textBoxSearchPhone.BackColor = Color.White;
            textBoxSearchPhone.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearchPhone.Font = new Font("Segoe UI", 10F);
            textBoxSearchPhone.Location = new Point(30, 100);
            textBoxSearchPhone.Name = "textBoxSearchPhone";
            textBoxSearchPhone.PlaceholderText = "Otsi telefoni järgi...";
            textBoxSearchPhone.Size = new Size(280, 25);
            textBoxSearchPhone.TabIndex = 5;
            textBoxSearchPhone.TextChanged += textBoxSearchPhone_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 150, 136);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(31, 280);
            button1.Name = "button1";
            button1.Size = new Size(89, 40);
            button1.TabIndex = 6;
            button1.Text = "Lisa";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(244, 67, 54);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(126, 280);
            button2.Name = "button2";
            button2.Size = new Size(90, 40);
            button2.TabIndex = 7;
            button2.Text = "Kustuta";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(33, 150, 243);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(222, 280);
            button3.Name = "button3";
            button3.Size = new Size(88, 40);
            button3.TabIndex = 8;
            button3.Text = "Uuenda";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(96, 125, 139);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(30, 400);
            button4.Name = "button4";
            button4.Size = new Size(129, 40);
            button4.TabIndex = 9;
            button4.Text = "Autod";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(96, 125, 139);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Location = new Point(178, 400);
            button5.Name = "button5";
            button5.Size = new Size(163, 40);
            button5.TabIndex = 10;
            button5.Text = "Hooldus ja Teenused";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(50, 50, 50);
            label1.Location = new Point(30, 10);
            label1.Name = "label1";
            label1.Size = new Size(101, 37);
            label1.TabIndex = 0;
            label1.Text = "Otsing";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(50, 50, 50);
            label2.Location = new Point(30, 150);
            label2.Name = "label2";
            label2.Size = new Size(311, 28);
            label2.TabIndex = 1;
            label2.Text = "Lisa / Kustuta / Muuda andmed";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(350, 60);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(570, 450);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(950, 550);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Controls.Add(textBoxSearchName);
            Controls.Add(textBoxSearchPhone);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 10F);
            Name = "Form1";
            Text = "Omanikud";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        private Label label2;
    }
}
