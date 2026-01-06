namespace AutojaOmanikud
{
    partial class Form1US
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1US));
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
            numHooldusMileage = new NumericUpDown();
            dtpHooldusDate = new DateTimePicker();
            cbHooldusService = new ComboBox();
            cbHooldusCar = new ComboBox();
            btnHooldusUpdate = new Button();
            btnHooldusDelete = new Button();
            btnHooldusAdd = new Button();
            dgvCarServices = new DataGridView();
            tabPage1 = new TabPage();
            chkIsPaid = new CheckBox();
            numPaymentAmount = new NumericUpDown();
            btnPaymentAdd = new Button();
            dtpPaymentDate = new DateTimePicker();
            cbPaymentCarService = new ComboBox();
            btnPaymentUpdate = new Button();
            btnPaymentDelete = new Button();
            dgvPayments = new DataGridView();
            cbLanguage = new ComboBox();
            txtSearch = new TextBox();
            txtSearch2 = new TextBox();
            txtSearch3 = new TextBox();
            txtSearch4 = new TextBox();
            txtSearch5 = new TextBox();
            tabControl1.SuspendLayout();
            Omanik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOwners).BeginInit();
            Auto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            Teenus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numServicePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            HoolduseKirje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHooldusMileage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarServices).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPaymentAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Omanik);
            tabControl1.Controls.Add(Auto);
            tabControl1.Controls.Add(Teenus);
            tabControl1.Controls.Add(HoolduseKirje);
            tabControl1.Controls.Add(tabPage1);
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            // 
            // Omanik
            // 
            Omanik.Controls.Add(txtSearch);
            Omanik.Controls.Add(btnOwnerUpdate);
            Omanik.Controls.Add(btnOwnerDelete);
            Omanik.Controls.Add(btnOwnerAdd);
            Omanik.Controls.Add(txtOwnerPhone);
            Omanik.Controls.Add(txtOwnerName);
            Omanik.Controls.Add(dgvOwners);
            resources.ApplyResources(Omanik, "Omanik");
            Omanik.Name = "Omanik";
            Omanik.UseVisualStyleBackColor = true;
            // 
            // btnOwnerUpdate
            // 
            resources.ApplyResources(btnOwnerUpdate, "btnOwnerUpdate");
            btnOwnerUpdate.Name = "btnOwnerUpdate";
            btnOwnerUpdate.UseVisualStyleBackColor = true;
            // 
            // btnOwnerDelete
            // 
            resources.ApplyResources(btnOwnerDelete, "btnOwnerDelete");
            btnOwnerDelete.Name = "btnOwnerDelete";
            btnOwnerDelete.UseVisualStyleBackColor = true;
            // 
            // btnOwnerAdd
            // 
            resources.ApplyResources(btnOwnerAdd, "btnOwnerAdd");
            btnOwnerAdd.Name = "btnOwnerAdd";
            btnOwnerAdd.UseVisualStyleBackColor = true;
            // 
            // txtOwnerPhone
            // 
            resources.ApplyResources(txtOwnerPhone, "txtOwnerPhone");
            txtOwnerPhone.Name = "txtOwnerPhone";
            // 
            // txtOwnerName
            // 
            resources.ApplyResources(txtOwnerName, "txtOwnerName");
            txtOwnerName.Name = "txtOwnerName";
            // 
            // dgvOwners
            // 
            dgvOwners.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dgvOwners, "dgvOwners");
            dgvOwners.Name = "dgvOwners";
            // 
            // Auto
            // 
            Auto.Controls.Add(txtSearch2);
            Auto.Controls.Add(cbCarOwner);
            Auto.Controls.Add(txtCarReg);
            Auto.Controls.Add(btnCarUpdate);
            Auto.Controls.Add(btnCarDelete);
            Auto.Controls.Add(btnCarAdd);
            Auto.Controls.Add(txtCarModel);
            Auto.Controls.Add(txtCarBrand);
            Auto.Controls.Add(dgvCars);
            resources.ApplyResources(Auto, "Auto");
            Auto.Name = "Auto";
            Auto.UseVisualStyleBackColor = true;
            // 
            // cbCarOwner
            // 
            cbCarOwner.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCarOwner.FormattingEnabled = true;
            resources.ApplyResources(cbCarOwner, "cbCarOwner");
            cbCarOwner.Name = "cbCarOwner";
            // 
            // txtCarReg
            // 
            resources.ApplyResources(txtCarReg, "txtCarReg");
            txtCarReg.Name = "txtCarReg";
            // 
            // btnCarUpdate
            // 
            resources.ApplyResources(btnCarUpdate, "btnCarUpdate");
            btnCarUpdate.Name = "btnCarUpdate";
            btnCarUpdate.UseVisualStyleBackColor = true;
            // 
            // btnCarDelete
            // 
            resources.ApplyResources(btnCarDelete, "btnCarDelete");
            btnCarDelete.Name = "btnCarDelete";
            btnCarDelete.UseVisualStyleBackColor = true;
            // 
            // btnCarAdd
            // 
            resources.ApplyResources(btnCarAdd, "btnCarAdd");
            btnCarAdd.Name = "btnCarAdd";
            btnCarAdd.UseVisualStyleBackColor = true;
            // 
            // txtCarModel
            // 
            resources.ApplyResources(txtCarModel, "txtCarModel");
            txtCarModel.Name = "txtCarModel";
            // 
            // txtCarBrand
            // 
            resources.ApplyResources(txtCarBrand, "txtCarBrand");
            txtCarBrand.Name = "txtCarBrand";
            // 
            // dgvCars
            // 
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dgvCars, "dgvCars");
            dgvCars.Name = "dgvCars";
            // 
            // Teenus
            // 
            Teenus.Controls.Add(txtSearch3);
            Teenus.Controls.Add(cbTeenus);
            Teenus.Controls.Add(numServicePrice);
            Teenus.Controls.Add(btnServiceUpdate);
            Teenus.Controls.Add(btnServiceDelete);
            Teenus.Controls.Add(btnServiceAdd);
            Teenus.Controls.Add(txtServiceName);
            Teenus.Controls.Add(dgvServices);
            resources.ApplyResources(Teenus, "Teenus");
            Teenus.Name = "Teenus";
            Teenus.UseVisualStyleBackColor = true;
            // 
            // cbTeenus
            // 
            cbTeenus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTeenus.FormattingEnabled = true;
            resources.ApplyResources(cbTeenus, "cbTeenus");
            cbTeenus.Name = "cbTeenus";
            // 
            // numServicePrice
            // 
            numServicePrice.DecimalPlaces = 2;
            resources.ApplyResources(numServicePrice, "numServicePrice");
            numServicePrice.Name = "numServicePrice";
            // 
            // btnServiceUpdate
            // 
            resources.ApplyResources(btnServiceUpdate, "btnServiceUpdate");
            btnServiceUpdate.Name = "btnServiceUpdate";
            btnServiceUpdate.UseVisualStyleBackColor = true;
            // 
            // btnServiceDelete
            // 
            resources.ApplyResources(btnServiceDelete, "btnServiceDelete");
            btnServiceDelete.Name = "btnServiceDelete";
            btnServiceDelete.UseVisualStyleBackColor = true;
            // 
            // btnServiceAdd
            // 
            resources.ApplyResources(btnServiceAdd, "btnServiceAdd");
            btnServiceAdd.Name = "btnServiceAdd";
            btnServiceAdd.UseVisualStyleBackColor = true;
            // 
            // txtServiceName
            // 
            resources.ApplyResources(txtServiceName, "txtServiceName");
            txtServiceName.Name = "txtServiceName";
            // 
            // dgvServices
            // 
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dgvServices, "dgvServices");
            dgvServices.Name = "dgvServices";
            // 
            // HoolduseKirje
            // 
            HoolduseKirje.Controls.Add(txtSearch4);
            HoolduseKirje.Controls.Add(numHooldusMileage);
            HoolduseKirje.Controls.Add(dtpHooldusDate);
            HoolduseKirje.Controls.Add(cbHooldusService);
            HoolduseKirje.Controls.Add(cbHooldusCar);
            HoolduseKirje.Controls.Add(btnHooldusUpdate);
            HoolduseKirje.Controls.Add(btnHooldusDelete);
            HoolduseKirje.Controls.Add(btnHooldusAdd);
            HoolduseKirje.Controls.Add(dgvCarServices);
            resources.ApplyResources(HoolduseKirje, "HoolduseKirje");
            HoolduseKirje.Name = "HoolduseKirje";
            HoolduseKirje.UseVisualStyleBackColor = true;
            // 
            // numHooldusMileage
            // 
            resources.ApplyResources(numHooldusMileage, "numHooldusMileage");
            numHooldusMileage.Name = "numHooldusMileage";
            // 
            // dtpHooldusDate
            // 
            resources.ApplyResources(dtpHooldusDate, "dtpHooldusDate");
            dtpHooldusDate.Name = "dtpHooldusDate";
            // 
            // cbHooldusService
            // 
            cbHooldusService.DropDownStyle = ComboBoxStyle.DropDownList;
            cbHooldusService.FormattingEnabled = true;
            resources.ApplyResources(cbHooldusService, "cbHooldusService");
            cbHooldusService.Name = "cbHooldusService";
            // 
            // cbHooldusCar
            // 
            cbHooldusCar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbHooldusCar.FormattingEnabled = true;
            resources.ApplyResources(cbHooldusCar, "cbHooldusCar");
            cbHooldusCar.Name = "cbHooldusCar";
            // 
            // btnHooldusUpdate
            // 
            resources.ApplyResources(btnHooldusUpdate, "btnHooldusUpdate");
            btnHooldusUpdate.Name = "btnHooldusUpdate";
            btnHooldusUpdate.UseVisualStyleBackColor = true;
            // 
            // btnHooldusDelete
            // 
            resources.ApplyResources(btnHooldusDelete, "btnHooldusDelete");
            btnHooldusDelete.Name = "btnHooldusDelete";
            btnHooldusDelete.UseVisualStyleBackColor = true;
            // 
            // btnHooldusAdd
            // 
            resources.ApplyResources(btnHooldusAdd, "btnHooldusAdd");
            btnHooldusAdd.Name = "btnHooldusAdd";
            btnHooldusAdd.UseVisualStyleBackColor = true;
            // 
            // dgvCarServices
            // 
            dgvCarServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dgvCarServices, "dgvCarServices");
            dgvCarServices.Name = "dgvCarServices";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtSearch5);
            tabPage1.Controls.Add(chkIsPaid);
            tabPage1.Controls.Add(numPaymentAmount);
            tabPage1.Controls.Add(btnPaymentAdd);
            tabPage1.Controls.Add(dtpPaymentDate);
            tabPage1.Controls.Add(cbPaymentCarService);
            tabPage1.Controls.Add(btnPaymentUpdate);
            tabPage1.Controls.Add(btnPaymentDelete);
            tabPage1.Controls.Add(dgvPayments);
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkIsPaid
            // 
            resources.ApplyResources(chkIsPaid, "chkIsPaid");
            chkIsPaid.Name = "chkIsPaid";
            chkIsPaid.UseVisualStyleBackColor = true;
            // 
            // numPaymentAmount
            // 
            numPaymentAmount.DecimalPlaces = 2;
            resources.ApplyResources(numPaymentAmount, "numPaymentAmount");
            numPaymentAmount.Name = "numPaymentAmount";
            // 
            // btnPaymentAdd
            // 
            resources.ApplyResources(btnPaymentAdd, "btnPaymentAdd");
            btnPaymentAdd.Name = "btnPaymentAdd";
            btnPaymentAdd.UseVisualStyleBackColor = true;
            // 
            // dtpPaymentDate
            // 
            resources.ApplyResources(dtpPaymentDate, "dtpPaymentDate");
            dtpPaymentDate.Name = "dtpPaymentDate";
            // 
            // cbPaymentCarService
            // 
            cbPaymentCarService.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPaymentCarService.FormattingEnabled = true;
            resources.ApplyResources(cbPaymentCarService, "cbPaymentCarService");
            cbPaymentCarService.Name = "cbPaymentCarService";
            // 
            // btnPaymentUpdate
            // 
            resources.ApplyResources(btnPaymentUpdate, "btnPaymentUpdate");
            btnPaymentUpdate.Name = "btnPaymentUpdate";
            btnPaymentUpdate.UseVisualStyleBackColor = true;
            // 
            // btnPaymentDelete
            // 
            resources.ApplyResources(btnPaymentDelete, "btnPaymentDelete");
            btnPaymentDelete.Name = "btnPaymentDelete";
            btnPaymentDelete.UseVisualStyleBackColor = true;
            // 
            // dgvPayments
            // 
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dgvPayments, "dgvPayments");
            dgvPayments.Name = "dgvPayments";
            // 
            // cbLanguage
            // 
            cbLanguage.FormattingEnabled = true;
            resources.ApplyResources(cbLanguage, "cbLanguage");
            cbLanguage.Name = "cbLanguage";
            // 
            // txtSearch
            // 
            resources.ApplyResources(txtSearch, "txtSearch");
            txtSearch.Name = "txtSearch";
            // 
            // txtSearch2
            // 
            resources.ApplyResources(txtSearch2, "txtSearch2");
            txtSearch2.Name = "txtSearch2";
            // 
            // txtSearch3
            // 
            resources.ApplyResources(txtSearch3, "txtSearch3");
            txtSearch3.Name = "txtSearch3";
            // 
            // txtSearch4
            // 
            resources.ApplyResources(txtSearch4, "txtSearch4");
            txtSearch4.Name = "txtSearch4";
            // 
            // txtSearch5
            // 
            resources.ApplyResources(txtSearch5, "txtSearch5");
            txtSearch5.Name = "txtSearch5";
            // 
            // Form1US
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cbLanguage);
            Controls.Add(tabControl1);
            Name = "Form1US";
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
            HoolduseKirje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numHooldusMileage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarServices).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPaymentAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
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
        private TabPage tabPage1;
        private Button btnPaymentAdd;
        private DateTimePicker dtpPaymentDate;
        private ComboBox cbPaymentCarService;
        private Button btnPaymentUpdate;
        private Button btnPaymentDelete;
        private DataGridView dgvPayments;
        private CheckBox chkIsPaid;
        private NumericUpDown numPaymentAmount;
        private ComboBox cbLanguage;
        private TextBox txtSearch;
        private TextBox txtSearch2;
        private TextBox txtSearch3;
        private TextBox txtSearch4;
        private TextBox txtSearch5;
    }
}