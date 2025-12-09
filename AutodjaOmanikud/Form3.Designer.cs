namespace AutodjaOmanikud
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewCarServices;
        private System.Windows.Forms.ComboBox comboBoxCar;
        private System.Windows.Forms.ComboBox comboBoxService;
        private System.Windows.Forms.DateTimePicker dateTimePickerServiceDate;
        private System.Windows.Forms.TextBox textBoxMileage;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Button buttonDeleteService;
        private System.Windows.Forms.Label labelCar;
        private System.Windows.Forms.Label labelService;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelMileage;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewCarServices = new DataGridView();
            comboBoxCar = new ComboBox();
            comboBoxService = new ComboBox();
            dateTimePickerServiceDate = new DateTimePicker();
            textBoxMileage = new TextBox();
            buttonAddService = new Button();
            buttonDeleteService = new Button();
            labelCar = new Label();
            labelService = new Label();
            labelDate = new Label();
            labelMileage = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarServices).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewCarServices
            // 
            dataGridViewCarServices.AllowUserToAddRows = false;
            dataGridViewCarServices.AllowUserToDeleteRows = false;
            dataGridViewCarServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCarServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarServices.Location = new Point(18, 15);
            dataGridViewCarServices.Name = "dataGridViewCarServices";
            dataGridViewCarServices.ReadOnly = true;
            dataGridViewCarServices.RowHeadersWidth = 51;
            dataGridViewCarServices.RowTemplate.Height = 29;
            dataGridViewCarServices.Size = new Size(700, 250);
            dataGridViewCarServices.TabIndex = 0;
            dataGridViewCarServices.CellClick += dataGridViewCarServices_CellClick;
            // 
            // comboBoxCar
            // 
            comboBoxCar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCar.Location = new Point(100, 280);
            comboBoxCar.Name = "comboBoxCar";
            comboBoxCar.Size = new Size(200, 23);
            comboBoxCar.TabIndex = 1;
            // 
            // comboBoxService
            // 
            comboBoxService.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxService.Location = new Point(100, 320);
            comboBoxService.Name = "comboBoxService";
            comboBoxService.Size = new Size(200, 23);
            comboBoxService.TabIndex = 2;
            // 
            // dateTimePickerServiceDate
            // 
            dateTimePickerServiceDate.Format = DateTimePickerFormat.Short;
            dateTimePickerServiceDate.Location = new Point(100, 360);
            dateTimePickerServiceDate.Name = "dateTimePickerServiceDate";
            dateTimePickerServiceDate.Size = new Size(200, 23);
            dateTimePickerServiceDate.TabIndex = 3;
            // 
            // textBoxMileage
            // 
            textBoxMileage.Location = new Point(100, 400);
            textBoxMileage.Name = "textBoxMileage";
            textBoxMileage.Size = new Size(200, 23);
            textBoxMileage.TabIndex = 4;
            // 
            // buttonAddService
            // 
            buttonAddService.Location = new Point(350, 280);
            buttonAddService.Name = "buttonAddService";
            buttonAddService.Size = new Size(120, 30);
            buttonAddService.TabIndex = 5;
            buttonAddService.Text = "Lisa teenus";
            buttonAddService.UseVisualStyleBackColor = true;
            buttonAddService.Click += buttonAddService_Click;
            // 
            // buttonDeleteService
            // 
            buttonDeleteService.Location = new Point(350, 320);
            buttonDeleteService.Name = "buttonDeleteService";
            buttonDeleteService.Size = new Size(120, 30);
            buttonDeleteService.TabIndex = 6;
            buttonDeleteService.Text = "Kustuta teenus";
            buttonDeleteService.UseVisualStyleBackColor = true;
            buttonDeleteService.Click += buttonDeleteService_Click;
            // 
            // labelCar
            // 
            labelCar.AutoSize = true;
            labelCar.Location = new Point(12, 283);
            labelCar.Name = "labelCar";
            labelCar.Size = new Size(36, 15);
            labelCar.TabIndex = 8;
            labelCar.Text = "Auto:";
            // 
            // labelService
            // 
            labelService.AutoSize = true;
            labelService.Location = new Point(12, 323);
            labelService.Name = "labelService";
            labelService.Size = new Size(53, 15);
            labelService.TabIndex = 9;
            labelService.Text = "Teenuse:";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(12, 363);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(56, 15);
            labelDate.TabIndex = 10;
            labelDate.Text = "Kuupäev:";
            // 
            // labelMileage
            // 
            labelMileage.AutoSize = true;
            labelMileage.Location = new Point(12, 403);
            labelMileage.Name = "labelMileage";
            labelMileage.Size = new Size(51, 15);
            labelMileage.TabIndex = 11;
            labelMileage.Text = "Läbisõit:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(750, 482);
            tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridViewCarServices);
            tabPage1.Controls.Add(comboBoxCar);
            tabPage1.Controls.Add(comboBoxService);
            tabPage1.Controls.Add(dateTimePickerServiceDate);
            tabPage1.Controls.Add(textBoxMileage);
            tabPage1.Controls.Add(buttonAddService);
            tabPage1.Controls.Add(buttonDeleteService);
            tabPage1.Controls.Add(labelCar);
            tabPage1.Controls.Add(labelService);
            tabPage1.Controls.Add(labelDate);
            tabPage1.Controls.Add(labelMileage);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(742, 454);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Teenused";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(742, 454);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(12, 523);
            button2.Name = "button2";
            button2.Size = new Size(97, 23);
            button2.TabIndex = 15;
            button2.Text = "Autod";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(115, 523);
            button3.Name = "button3";
            button3.Size = new Size(97, 23);
            button3.TabIndex = 16;
            button3.Text = "Omanikud";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form3
            // 
            ClientSize = new Size(884, 558);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(tabControl1);
            Name = "Form3";
            Text = "Autode Teenused";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarServices).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }
        private Button button2;
        private Button button3;
    }
}
