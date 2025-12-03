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
            dataGridView1 = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 150);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(20, 190);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(250, 23);
            textBox2.TabIndex = 2;
            // 
            // textBoxSearchName
            // 
            textBoxSearchName.Location = new Point(20, 40);
            textBoxSearchName.Name = "textBoxSearchName";
            textBoxSearchName.PlaceholderText = "Otsi nime järgi...";
            textBoxSearchName.Size = new Size(250, 23);
            textBoxSearchName.TabIndex = 3;
            textBoxSearchName.TextChanged += textBoxSearchName_TextChanged;
            // 
            // textBoxSearchPhone
            // 
            textBoxSearchPhone.Location = new Point(20, 80);
            textBoxSearchPhone.Name = "textBoxSearchPhone";
            textBoxSearchPhone.PlaceholderText = "Otsi telefoni järgi...";
            textBoxSearchPhone.Size = new Size(250, 23);
            textBoxSearchPhone.TabIndex = 4;
            textBoxSearchPhone.TextChanged += textBoxSearchPhone_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(20, 230);
            button1.Name = "button1";
            button1.Size = new Size(75, 30);
            button1.TabIndex = 5;
            button1.Text = "Lisa";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(110, 230);
            button2.Name = "button2";
            button2.Size = new Size(75, 30);
            button2.TabIndex = 6;
            button2.Text = "Kustuta";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(200, 230);
            button3.Name = "button3";
            button3.Size = new Size(75, 30);
            button3.TabIndex = 7;
            button3.Text = "Uuenda";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 415);
            button4.Name = "button4";
            button4.Size = new Size(91, 23);
            button4.TabIndex = 8;
            button4.Text = "Autod";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(110, 415);
            button5.Name = "button5";
            button5.Size = new Size(125, 23);
            button5.TabIndex = 9;
            button5.Text = "Hooldus ja Teenused";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(20, 9);
            label1.Name = "label1";
            label1.Size = new Size(70, 28);
            label1.TabIndex = 10;
            label1.Text = "Otsing";
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Location = new Point(320, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(450, 350);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(20, 119);
            label2.Name = "label2";
            label2.Size = new Size(265, 28);
            label2.TabIndex = 11;
            label2.Text = "Lisa/Kustuta/Muuda andmed";
            // 
            // Form1
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Controls.Add(textBoxSearchName);
            Controls.Add(textBoxSearchPhone);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Name = "Form1";
            Text = "Autod ja Omanikud";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label2;
    }
}
