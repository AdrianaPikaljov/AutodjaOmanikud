namespace AutojaOmanikud
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            Omanik = new TabPage();
            btnOwnerUpdate = new Button();
            btnOwnerDelete = new Button();
            btnOwnerAdd = new Button();
            txtOwnerPhone = new TextBox();
            txtOwnerName = new TextBox();
            dgvOwners = new DataGridView();
            Auto = new TabPage();
            cbCarOwner = new ComboBox();
            txtCarReg = new TextBox();
            btnCarUpdate = new Button();
            btnCarDelete = new Button();
            btnCarAdd = new Button();
            txtCarModel = new TextBox();
            txtCarBrand = new TextBox();
            dgvCars = new DataGridView();
            Teenus = new TabPage();
            cbTeenus = new ComboBox();
            numServicePrice = new NumericUpDown();
            btnServiceUpdate = new Button();
            btnServiceDelete = new Button();
            btnServiceAdd = new Button();
            txtServiceName = new TextBox();
            dgvServices = new DataGridView();
            HoolduseKirje = new TabPage();
            cbHooldusCar = new ComboBox();
            btnHooldusUpdate = new Button();
            btnHooldusDelete = new Button();
            btnHooldusAdd = new Button();
            dgvCarServices = new DataGridView();
            cbHooldusService = new ComboBox();
            dtpHooldusDate = new DateTimePicker();
            numHooldusMileage = new NumericUpDown();
            tabControl1.SuspendLayout();
            Omanik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOwners).BeginInit();
            Auto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            Teenus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numServicePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            HoolduseKirje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarServices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHooldusMileage).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Omanik);
            tabControl1.Controls.Add(Auto);
            tabControl1.Controls.Add(Teenus);
            tabControl1.Controls.Add(HoolduseKirje);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // Omanik
            // 
            Omanik.Controls.Add(btnOwnerUpdate);
            Omanik.Controls.Add(btnOwnerDelete);
            Omanik.Controls.Add(btnOwnerAdd);
            Omanik.Controls.Add(txtOwnerPhone);
            Omanik.Controls.Add(txtOwnerName);
            Omanik.Controls.Add(dgvOwners);
            Omanik.Location = new Point(4, 24);
            Omanik.Name = "Omanik";
            Omanik.Padding = new Padding(3);
            Omanik.Size = new Size(792, 422);
            Omanik.TabIndex = 0;
            Omanik.Text = "Omanik";
            Omanik.UseVisualStyleBackColor = true;
            // 
            // btnOwnerUpdate
            // 
            btnOwnerUpdate.Location = new Point(170, 257);
            btnOwnerUpdate.Name = "btnOwnerUpdate";
            btnOwnerUpdate.Size = new Size(75, 23);
            btnOwnerUpdate.TabIndex = 5;
            btnOwnerUpdate.Text = "Uuenda";
            btnOwnerUpdate.UseVisualStyleBackColor = true;
            // 
            // btnOwnerDelete
            // 
            btnOwnerDelete.Location = new Point(89, 257);
            btnOwnerDelete.Name = "btnOwnerDelete";
            btnOwnerDelete.Size = new Size(75, 23);
            btnOwnerDelete.TabIndex = 4;
            btnOwnerDelete.Text = "Kustuta";
            btnOwnerDelete.UseVisualStyleBackColor = true;
            // 
            // btnOwnerAdd
            // 
            btnOwnerAdd.Location = new Point(8, 257);
            btnOwnerAdd.Name = "btnOwnerAdd";
            btnOwnerAdd.Size = new Size(75, 23);
            btnOwnerAdd.TabIndex = 3;
            btnOwnerAdd.Text = "Lisa";
            btnOwnerAdd.UseVisualStyleBackColor = true;
            // 
            // txtOwnerPhone
            // 
            txtOwnerPhone.Location = new Point(8, 215);
            txtOwnerPhone.Name = "txtOwnerPhone";
            txtOwnerPhone.Size = new Size(156, 23);
            txtOwnerPhone.TabIndex = 2;
            // 
            // txtOwnerName
            // 
            txtOwnerName.Location = new Point(8, 176);
            txtOwnerName.Name = "txtOwnerName";
            txtOwnerName.Size = new Size(156, 23);
            txtOwnerName.TabIndex = 1;
            // 
            // dgvOwners
            // 
            dgvOwners.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOwners.Dock = DockStyle.Top;
            dgvOwners.Location = new Point(3, 3);
            dgvOwners.Name = "dgvOwners";
            dgvOwners.Size = new Size(786, 150);
            dgvOwners.TabIndex = 0;
            // 
            // Auto
            // 
            Auto.Controls.Add(cbCarOwner);
            Auto.Controls.Add(txtCarReg);
            Auto.Controls.Add(btnCarUpdate);
            Auto.Controls.Add(btnCarDelete);
            Auto.Controls.Add(btnCarAdd);
            Auto.Controls.Add(txtCarModel);
            Auto.Controls.Add(txtCarBrand);
            Auto.Controls.Add(dgvCars);
            Auto.Location = new Point(4, 24);
            Auto.Name = "Auto";
            Auto.Padding = new Padding(3);
            Auto.Size = new Size(792, 422);
            Auto.TabIndex = 1;
            Auto.Text = "Auto";
            Auto.UseVisualStyleBackColor = true;
            // 
            // cbCarOwner
            // 
            cbCarOwner.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCarOwner.FormattingEnabled = true;
            cbCarOwner.Location = new Point(8, 246);
            cbCarOwner.Name = "cbCarOwner";
            cbCarOwner.Size = new Size(121, 23);
            cbCarOwner.TabIndex = 13;
            // 
            // txtCarReg
            // 
            txtCarReg.Location = new Point(8, 217);
            txtCarReg.Name = "txtCarReg";
            txtCarReg.Size = new Size(156, 23);
            txtCarReg.TabIndex = 12;
            // 
            // btnCarUpdate
            // 
            btnCarUpdate.Location = new Point(170, 285);
            btnCarUpdate.Name = "btnCarUpdate";
            btnCarUpdate.Size = new Size(75, 23);
            btnCarUpdate.TabIndex = 11;
            btnCarUpdate.Text = "Uuenda";
            btnCarUpdate.UseVisualStyleBackColor = true;
            // 
            // btnCarDelete
            // 
            btnCarDelete.Location = new Point(89, 285);
            btnCarDelete.Name = "btnCarDelete";
            btnCarDelete.Size = new Size(75, 23);
            btnCarDelete.TabIndex = 10;
            btnCarDelete.Text = "Kustuta";
            btnCarDelete.UseVisualStyleBackColor = true;
            // 
            // btnCarAdd
            // 
            btnCarAdd.Location = new Point(8, 285);
            btnCarAdd.Name = "btnCarAdd";
            btnCarAdd.Size = new Size(75, 23);
            btnCarAdd.TabIndex = 9;
            btnCarAdd.Text = "Lisa";
            btnCarAdd.UseVisualStyleBackColor = true;
            // 
            // txtCarModel
            // 
            txtCarModel.Location = new Point(8, 188);
            txtCarModel.Name = "txtCarModel";
            txtCarModel.Size = new Size(156, 23);
            txtCarModel.TabIndex = 8;
            // 
            // txtCarBrand
            // 
            txtCarBrand.Location = new Point(8, 159);
            txtCarBrand.Name = "txtCarBrand";
            txtCarBrand.Size = new Size(156, 23);
            txtCarBrand.TabIndex = 7;
            // 
            // dgvCars
            // 
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Dock = DockStyle.Top;
            dgvCars.Location = new Point(3, 3);
            dgvCars.Name = "dgvCars";
            dgvCars.Size = new Size(786, 150);
            dgvCars.TabIndex = 6;
            // 
            // Teenus
            // 
            Teenus.Controls.Add(cbTeenus);
            Teenus.Controls.Add(numServicePrice);
            Teenus.Controls.Add(btnServiceUpdate);
            Teenus.Controls.Add(btnServiceDelete);
            Teenus.Controls.Add(btnServiceAdd);
            Teenus.Controls.Add(txtServiceName);
            Teenus.Controls.Add(dgvServices);
            Teenus.Location = new Point(4, 24);
            Teenus.Name = "Teenus";
            Teenus.Padding = new Padding(3);
            Teenus.Size = new Size(792, 422);
            Teenus.TabIndex = 2;
            Teenus.Text = "Teenus";
            Teenus.UseVisualStyleBackColor = true;
            // 
            // cbTeenus
            // 
            cbTeenus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTeenus.FormattingEnabled = true;
            cbTeenus.Location = new Point(3, 159);
            cbTeenus.Name = "cbTeenus";
            cbTeenus.Size = new Size(156, 23);
            cbTeenus.TabIndex = 23;
            // 
            // numServicePrice
            // 
            numServicePrice.DecimalPlaces = 2;
            numServicePrice.Location = new Point(165, 189);
            numServicePrice.Name = "numServicePrice";
            numServicePrice.Size = new Size(120, 23);
            numServicePrice.TabIndex = 22;
            // 
            // btnServiceUpdate
            // 
            btnServiceUpdate.Location = new Point(165, 218);
            btnServiceUpdate.Name = "btnServiceUpdate";
            btnServiceUpdate.Size = new Size(75, 23);
            btnServiceUpdate.TabIndex = 19;
            btnServiceUpdate.Text = "Uuenda";
            btnServiceUpdate.UseVisualStyleBackColor = true;
            // 
            // btnServiceDelete
            // 
            btnServiceDelete.Location = new Point(84, 217);
            btnServiceDelete.Name = "btnServiceDelete";
            btnServiceDelete.Size = new Size(75, 23);
            btnServiceDelete.TabIndex = 18;
            btnServiceDelete.Text = "Kustuta";
            btnServiceDelete.UseVisualStyleBackColor = true;
            // 
            // btnServiceAdd
            // 
            btnServiceAdd.Location = new Point(3, 217);
            btnServiceAdd.Name = "btnServiceAdd";
            btnServiceAdd.Size = new Size(75, 23);
            btnServiceAdd.TabIndex = 17;
            btnServiceAdd.Text = "Lisa";
            btnServiceAdd.UseVisualStyleBackColor = true;
            // 
            // txtServiceName
            // 
            txtServiceName.Location = new Point(3, 188);
            txtServiceName.Name = "txtServiceName";
            txtServiceName.Size = new Size(156, 23);
            txtServiceName.TabIndex = 15;
            // 
            // dgvServices
            // 
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServices.Dock = DockStyle.Top;
            dgvServices.Location = new Point(3, 3);
            dgvServices.Name = "dgvServices";
            dgvServices.Size = new Size(786, 150);
            dgvServices.TabIndex = 14;
            // 
            // HoolduseKirje
            // 
            HoolduseKirje.Controls.Add(numHooldusMileage);
            HoolduseKirje.Controls.Add(dtpHooldusDate);
            HoolduseKirje.Controls.Add(cbHooldusService);
            HoolduseKirje.Controls.Add(cbHooldusCar);
            HoolduseKirje.Controls.Add(btnHooldusUpdate);
            HoolduseKirje.Controls.Add(btnHooldusDelete);
            HoolduseKirje.Controls.Add(btnHooldusAdd);
            HoolduseKirje.Controls.Add(dgvCarServices);
            HoolduseKirje.Location = new Point(4, 24);
            HoolduseKirje.Name = "HoolduseKirje";
            HoolduseKirje.Padding = new Padding(3);
            HoolduseKirje.Size = new Size(792, 422);
            HoolduseKirje.TabIndex = 3;
            HoolduseKirje.Text = "Hoolduse Kirje";
            HoolduseKirje.UseVisualStyleBackColor = true;
            // 
            // cbHooldusCar
            // 
            cbHooldusCar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbHooldusCar.FormattingEnabled = true;
            cbHooldusCar.Location = new Point(3, 159);
            cbHooldusCar.Name = "cbHooldusCar";
            cbHooldusCar.Size = new Size(156, 23);
            cbHooldusCar.TabIndex = 30;

            // 
            // btnHooldusUpdate
            // 
            btnHooldusUpdate.Location = new Point(165, 218);
            btnHooldusUpdate.Name = "btnHooldusUpdate";
            btnHooldusUpdate.Size = new Size(75, 23);
            btnHooldusUpdate.TabIndex = 28;
            btnHooldusUpdate.Text = "Uuenda";
            btnHooldusUpdate.UseVisualStyleBackColor = true;

            // 
            // btnHooldusDelete
            // 
            btnHooldusDelete.Location = new Point(84, 217);
            btnHooldusDelete.Name = "btnHooldusDelete";
            btnHooldusDelete.Size = new Size(75, 23);
            btnHooldusDelete.TabIndex = 27;
            btnHooldusDelete.Text = "Kustuta";
            btnHooldusDelete.UseVisualStyleBackColor = true;

            // 
            // btnHooldusAdd
            // 
            btnHooldusAdd.Location = new Point(3, 217);
            btnHooldusAdd.Name = "btnHooldusAdd";
            btnHooldusAdd.Size = new Size(75, 23);
            btnHooldusAdd.TabIndex = 26;
            btnHooldusAdd.Text = "Lisa";
            btnHooldusAdd.UseVisualStyleBackColor = true;

            // 
            // dgvCarServices
            // 
            dgvCarServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarServices.Dock = DockStyle.Top;
            dgvCarServices.Location = new Point(3, 3);
            dgvCarServices.Name = "dgvCarServices";
            dgvCarServices.Size = new Size(786, 150);
            dgvCarServices.TabIndex = 24;

            // 
            // cbHooldusService
            // 
            cbHooldusService.DropDownStyle = ComboBoxStyle.DropDownList;
            cbHooldusService.FormattingEnabled = true;
            cbHooldusService.Location = new Point(3, 188);
            cbHooldusService.Name = "cbHooldusService";
            cbHooldusService.Size = new Size(156, 23);
            cbHooldusService.TabIndex = 31;
            // 
            // dtpHooldusDate
            // 
            dtpHooldusDate.Location = new Point(175, 159);
            dtpHooldusDate.Name = "dtpHooldusDate";
            dtpHooldusDate.Size = new Size(200, 23);
            dtpHooldusDate.TabIndex = 32;
            // 
            // numHooldusMileage
            // 
            numHooldusMileage.Location = new Point(175, 189);
            numHooldusMileage.Name = "numHooldusMileage";
            numHooldusMileage.Size = new Size(120, 23);
            numHooldusMileage.TabIndex = 33;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            Omanik.ResumeLayout(false);
            Omanik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOwners).EndInit();
            Auto.ResumeLayout(false);
            Auto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            Teenus.ResumeLayout(false);
            Teenus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numServicePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            HoolduseKirje.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarServices).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHooldusMileage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Omanik;
        private TabPage Auto;
        private TabPage Teenus;
        private Button btnOwnerAdd;
        private TextBox txtOwnerPhone;
        private TextBox txtOwnerName;
        private DataGridView dgvOwners;
        private Button btnOwnerUpdate;
        private Button btnOwnerDelete;
        private ComboBox cbCarOwner;
        private TextBox txtCarReg;
        private Button btnCarUpdate;
        private Button btnCarDelete;
        private Button btnCarAdd;
        private TextBox txtCarModel;
        private TextBox txtCarBrand;
        private DataGridView dgvCars;
        private DataGridView dgvServices;
        private ComboBox cbTeenus;
        private NumericUpDown numServicePrice;
        private Button btnServiceUpdate;
        private Button btnServiceDelete;
        private Button btnServiceAdd;
        private TextBox txtServiceName;
        private TabPage HoolduseKirje;
        private ComboBox cbHooldusCar;
        private Button btnHooldusUpdate;
        private Button btnHooldusDelete;
        private Button btnHooldusAdd;
        private DataGridView dgvCarServices;
        private ComboBox cbHooldusService;
        private NumericUpDown numHooldusMileage;
        private DateTimePicker dtpHooldusDate;
    }
}