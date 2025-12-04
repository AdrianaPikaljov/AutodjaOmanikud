namespace AutodjaOmanikud
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxService;
        private System.Windows.Forms.ComboBox comboBoxCar;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Button buttonAddCarService;
        private System.Windows.Forms.Button buttonDeleteService;
        private System.Windows.Forms.DateTimePicker dateTimePickerServiceDate;
        private System.Windows.Forms.NumericUpDown numericUpDownMileage;
        private System.Windows.Forms.TextBox textBoxServiceName;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBoxService = new System.Windows.Forms.ComboBox();
            this.comboBoxCar = new System.Windows.Forms.ComboBox();
            this.buttonAddService = new System.Windows.Forms.Button();
            this.buttonAddCarService = new System.Windows.Forms.Button();
            this.buttonDeleteService = new System.Windows.Forms.Button();
            this.dateTimePickerServiceDate = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownMileage = new System.Windows.Forms.NumericUpDown();
            this.textBoxServiceName = new System.Windows.Forms.TextBox();
            this.numericUpDownPrice = new System.Windows.Forms.NumericUpDown();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMileage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();

            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(760, 300);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            // 
            // comboBoxService
            // 
            this.comboBoxService.FormattingEnabled = true;
            this.comboBoxService.Location = new System.Drawing.Point(12, 25);
            this.comboBoxService.Name = "comboBoxService";
            this.comboBoxService.Size = new System.Drawing.Size(200, 21);
            this.comboBoxService.TabIndex = 1;
            this.comboBoxService.SelectedIndexChanged += new System.EventHandler(this.comboBoxService_SelectedIndexChanged);

            // 
            // comboBoxCar
            // 
            this.comboBoxCar.FormattingEnabled = true;
            this.comboBoxCar.Location = new System.Drawing.Point(12, 60);
            this.comboBoxCar.Name = "comboBoxCar";
            this.comboBoxCar.Size = new System.Drawing.Size(200, 21);
            this.comboBoxCar.TabIndex = 2;
            this.comboBoxCar.SelectedIndexChanged += new System.EventHandler(this.comboBoxCar_SelectedIndexChanged);

            // 
            // buttonAddService
            // 
            this.buttonAddService.Location = new System.Drawing.Point(220, 25);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Size = new System.Drawing.Size(100, 23);
            this.buttonAddService.TabIndex = 3;
            this.buttonAddService.Text = "Lisa teenus";
            this.buttonAddService.UseVisualStyleBackColor = true;
            this.buttonAddService.Click += new System.EventHandler(this.buttonAddService_Click);

            // 
            // buttonAddCarService
            // 
            this.buttonAddCarService.Location = new System.Drawing.Point(220, 60);
            this.buttonAddCarService.Name = "buttonAddCarService";
            this.buttonAddCarService.Size = new System.Drawing.Size(100, 23);
            this.buttonAddCarService.TabIndex = 4;
            this.buttonAddCarService.Text = "Lisa teenus autole";
            this.buttonAddCarService.UseVisualStyleBackColor = true;
            this.buttonAddCarService.Click += new System.EventHandler(this.buttonAddCarService_Click);

            // 
            // buttonDeleteService
            // 
            this.buttonDeleteService.Location = new System.Drawing.Point(220, 95);
            this.buttonDeleteService.Name = "buttonDeleteService";
            this.buttonDeleteService.Size = new System.Drawing.Size(100, 23);
            this.buttonDeleteService.TabIndex = 5;
            this.buttonDeleteService.Text = "Kustuta teenus";
            this.buttonDeleteService.UseVisualStyleBackColor = true;
            this.buttonDeleteService.Click += new System.EventHandler(this.buttonDeleteService_Click);

            // 
            // dateTimePickerServiceDate
            // 
            this.dateTimePickerServiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerServiceDate.Location = new System.Drawing.Point(12, 95);
            this.dateTimePickerServiceDate.Name = "dateTimePickerServiceDate";
            this.dateTimePickerServiceDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerServiceDate.TabIndex = 6;

            // 
            // numericUpDownMileage
            // 
            this.numericUpDownMileage.Location = new System.Drawing.Point(12, 120);
            this.numericUpDownMileage.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numericUpDownMileage.Name = "numericUpDownMileage";
            this.numericUpDownMileage.Size = new System.Drawing.Size(200, 20);
            this.numericUpDownMileage.TabIndex = 7;

            // 
            // textBoxServiceName
            // 
            this.textBoxServiceName.Location = new System.Drawing.Point(220, 125);
            this.textBoxServiceName.Name = "textBoxServiceName";
            this.textBoxServiceName.Size = new System.Drawing.Size(200, 20);
            this.textBoxServiceName.TabIndex = 8;

            // 
            // numericUpDownPrice
            // 
            this.numericUpDownPrice.Location = new System.Drawing.Point(220, 155);
            this.numericUpDownPrice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numericUpDownPrice.Name = "numericUpDownPrice";
            this.numericUpDownPrice.Size = new System.Drawing.Size(200, 20);
            this.numericUpDownPrice.TabIndex = 9;

            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxService);
            this.Controls.Add(this.comboBoxCar);
            this.Controls.Add(this.buttonAddService);
            this.Controls.Add(this.buttonAddCarService);
            this.Controls.Add(this.buttonDeleteService);
            this.Controls.Add(this.dateTimePickerServiceDate);
            this.Controls.Add(this.numericUpDownMileage);
            this.Controls.Add(this.textBoxServiceName);
            this.Controls.Add(this.numericUpDownPrice);
            this.Name = "Form3";
            this.Text = "Teenuste Ajalugu";
            this.Load += new System.EventHandler(this.Form3_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMileage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
