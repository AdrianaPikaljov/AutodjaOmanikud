using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AutodjaOmanikud;
using Microsoft.EntityFrameworkCore;

namespace AutojaOmanikud
{
    public partial class Form1US : Form
    {
        // ===================== LIGHT-BLUE UI THEME COLORS =====================
        private readonly Color _bg = Color.FromArgb(241, 246, 255);        // very light blue
        private readonly Color _card = Color.White;                        // card background
        private readonly Color _border = Color.FromArgb(209, 225, 255);    // light border
        private readonly Color _primary = Color.FromArgb(59, 130, 246);    // blue
        private readonly Color _primaryDark = Color.FromArgb(37, 99, 235); // darker blue
        private readonly Color _danger = Color.FromArgb(239, 68, 68);      // red
        private readonly Color _text = Color.FromArgb(17, 24, 39);         // dark text
        private readonly Color _header = Color.FromArgb(225, 236, 255);    // header light blue
        private readonly Color _select = Color.FromArgb(219, 234, 254);    // selection light blue

        // ===================== SEARCH SOURCES (to avoid row.Visible crash) =====================
        private object? _ownersSource;
        private object? _carsSource;
        private object? _servicesSource;
        private object? _carServicesSource;
        private object? _paymentsSource;

        public Form1US()
        {
            InitializeComponent();

            ApplyEnglishUiTexts();

            ApplyUiTheme();
            InitPlaceholders();
            InitLanguageCombo();

            // Owners
            btnOwnerAdd.Click += btnOwnerAdd_Click;
            btnOwnerDelete.Click += btnOwnerDelete_Click;
            btnOwnerUpdate.Click += btnOwnerUpdate_Click;
            dgvOwners.CellClick += dgvOwners_CellClick;

            // Cars
            btnCarAdd.Click += btnCarAdd_Click;
            btnCarDelete.Click += btnCarDelete_Click;
            btnCarUpdate.Click += btnCarUpdate_Click;
            dgvCars.CellClick += dgvCars_CellClick;

            // Services
            btnServiceAdd.Click += btnServiceAdd_Click;
            btnServiceDelete.Click += btnServiceDelete_Click;
            btnServiceUpdate.Click += btnServiceUpdate_Click;
            dgvServices.CellClick += dgvServices_CellClick;

            // Maintenance
            btnHooldusAdd.Click += btnHooldusAdd_Click;
            btnHooldusDelete.Click += btnHooldusDelete_Click;
            btnHooldusUpdate.Click += btnHooldusUpdate_Click;
            dgvCarServices.CellClick += dgvHooldus_CellClick;

            // Payments
            btnPaymentAdd.Click += btnPaymentAdd_Click;
            btnPaymentUpdate.Click += btnPaymentUpdate_Click;
            btnPaymentDelete.Click += btnPaymentDelete_Click;
            dgvPayments.CellClick += dgvPayments_CellClick;

            cbHooldusCar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbHooldusService.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPaymentCarService.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTeenus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCarOwner.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;

            // ✅ Hook up the 5 search textboxes (same naming as EST form)
            txtSearch.TextChanged += txtSearch_TextChanged;   // owners
            txtSearch2.TextChanged += txtSearch2_TextChanged; // cars
            txtSearch3.TextChanged += txtSearch3_TextChanged; // services
            txtSearch4.TextChanged += txtSearch4_TextChanged; // maintenance
            txtSearch5.TextChanged += txtSearch5_TextChanged; // payments

            LoadAll();
        }

        // ===================== SEARCH HELPERS =====================

        private void CacheSource(DataGridView dgv, ref object? store)
        {
            if (dgv.DataSource != null)
                store = dgv.DataSource;
        }

        private void ApplySearchRebind(DataGridView dgv, object? originalSource, string search)
        {
            if (originalSource == null) return;

            if (string.IsNullOrWhiteSpace(search))
            {
                dgv.DataSource = originalSource;
                return;
            }

            search = search.Trim().ToLowerInvariant();

            if (originalSource is not System.Collections.IEnumerable enumerable)
                return;

            var filtered = enumerable
                .Cast<object>()
                .Where(item =>
                {
                    if (item == null) return false;

                    foreach (var p in item.GetType().GetProperties())
                    {
                        var val = p.GetValue(item);
                        if (val == null) continue;

                        if (val.ToString()!.ToLowerInvariant().Contains(search))
                            return true;
                    }
                    return false;
                })
                .ToList();

            dgv.DataSource = filtered;
        }

        // ===================== ONLY TEXTS IN ENGLISH =====================

        private void ApplyEnglishUiTexts()
        {
            try
            {
                Omanik.Text = "Owners";
                Auto.Text = "Cars";
                Teenus.Text = "Services";
                HoolduseKirje.Text = "Maintenance";
                tabPage1.Text = "Payments";
            }
            catch { }

            btnOwnerAdd.Text = "Add";
            btnOwnerUpdate.Text = "Update";
            btnOwnerDelete.Text = "Delete";

            btnCarAdd.Text = "Add";
            btnCarUpdate.Text = "Update";
            btnCarDelete.Text = "Delete";

            btnServiceAdd.Text = "Add";
            btnServiceUpdate.Text = "Update";
            btnServiceDelete.Text = "Delete";

            btnHooldusAdd.Text = "Add";
            btnHooldusUpdate.Text = "Update";
            btnHooldusDelete.Text = "Delete";

            btnPaymentAdd.Text = "Add";
            btnPaymentUpdate.Text = "Update";
            btnPaymentDelete.Text = "Delete";

            chkIsPaid.Text = "Paid";
        }

        // ===================== PLACEHOLDERS =====================

        private void InitPlaceholders()
        {
            SetPlaceholder(txtOwnerName, "Name");
            SetPlaceholder(txtOwnerPhone, "Phone");

            SetPlaceholder(txtCarBrand, "Brand");
            SetPlaceholder(txtCarModel, "Model");
            SetPlaceholder(txtCarReg, "Reg. No.");

            SetPlaceholder(txtServiceName, "Service name");
        }

        private void SetPlaceholder(TextBox tb, string placeholder)
        {
            tb.Tag = placeholder;

            if (string.IsNullOrWhiteSpace(tb.Text) || tb.Text == placeholder)
            {
                tb.Text = placeholder;
                tb.ForeColor = SystemColors.ScrollBar;
            }

            tb.Enter -= TextBox_Enter;
            tb.Leave -= TextBox_Leave;
            tb.Enter += TextBox_Enter;
            tb.Leave += TextBox_Leave;
        }

        private void TextBox_Enter(object? sender, EventArgs e)
        {
            if (sender is not TextBox tb) return;
            if (tb.Text == (string?)tb.Tag)
            {
                tb.Text = "";
                tb.ForeColor = _text;
            }
        }

        private void TextBox_Leave(object? sender, EventArgs e)
        {
            if (sender is not TextBox tb) return;

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = (string?)tb.Tag;
                tb.ForeColor = SystemColors.ScrollBar;
            }
            else
            {
                tb.ForeColor = _text;
            }
        }

        private string GetText(TextBox tb)
            => tb.Text == (string?)tb.Tag ? "" : tb.Text.Trim();

        private void SetText(TextBox tb, string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                tb.Text = (string?)tb.Tag;
                tb.ForeColor = SystemColors.ScrollBar;
            }
            else
            {
                tb.Text = value;
                tb.ForeColor = _text;
            }
        }

        // ===================== UI THEME =====================

        private void ApplyUiTheme()
        {
            Font = new Font("Segoe UI", 10f);
            BackColor = _bg;

            foreach (Control c in Controls)
            {
                if (c is TabControl tc)
                {
                    tc.BackColor = _bg;
                    foreach (TabPage tp in tc.TabPages)
                        tp.BackColor = _bg;
                }
            }

            StyleGrid(dgvOwners);
            StyleGrid(dgvCars);
            StyleGrid(dgvServices);
            StyleGrid(dgvCarServices);
            StyleGrid(dgvPayments);

            StyleTextBox(txtOwnerName);
            StyleTextBox(txtOwnerPhone);
            StyleTextBox(txtCarBrand);
            StyleTextBox(txtCarModel);
            StyleTextBox(txtCarReg);
            StyleTextBox(txtServiceName);

            StyleCombo(cbCarOwner);
            StyleCombo(cbTeenus);
            StyleCombo(cbHooldusCar);
            StyleCombo(cbHooldusService);
            StyleCombo(cbPaymentCarService);
            StyleCombo(cbLanguage);

            StyleNumeric(numServicePrice);
            StyleNumeric(numHooldusMileage);
            StyleNumeric(numPaymentAmount);

            StyleDate(dtpHooldusDate);
            StyleDate(dtpPaymentDate);

            StyleBtnPrimary(btnOwnerAdd);
            StyleBtnGhost(btnOwnerUpdate);
            StyleBtnDanger(btnOwnerDelete);

            StyleBtnPrimary(btnCarAdd);
            StyleBtnGhost(btnCarUpdate);
            StyleBtnDanger(btnCarDelete);

            StyleBtnPrimary(btnServiceAdd);
            StyleBtnGhost(btnServiceUpdate);
            StyleBtnDanger(btnServiceDelete);

            StyleBtnPrimary(btnHooldusAdd);
            StyleBtnGhost(btnHooldusUpdate);
            StyleBtnDanger(btnHooldusDelete);

            StyleBtnPrimary(btnPaymentAdd);
            StyleBtnGhost(btnPaymentUpdate);
            StyleBtnDanger(btnPaymentDelete);

            chkIsPaid.ForeColor = _text;
            chkIsPaid.BackColor = _bg;
        }

        private void StyleGrid(DataGridView g)
        {
            g.BackgroundColor = _card;
            g.BorderStyle = BorderStyle.None;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = _border;

            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersDefaultCellStyle.BackColor = _header;
            g.ColumnHeadersDefaultCellStyle.ForeColor = _text;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            g.ColumnHeadersHeight = 36;

            g.DefaultCellStyle.BackColor = _card;
            g.DefaultCellStyle.ForeColor = _text;
            g.DefaultCellStyle.SelectionBackColor = _select;
            g.DefaultCellStyle.SelectionForeColor = _text;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 10f);

            g.RowHeadersVisible = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;
            g.ReadOnly = true;

            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;

            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.RowTemplate.Height = 30;
        }

        private void StyleTextBox(TextBox t)
        {
            t.BorderStyle = BorderStyle.FixedSingle;
            t.BackColor = _card;
            t.Font = new Font("Segoe UI", 10f);
        }

        private void StyleCombo(ComboBox c)
        {
            c.FlatStyle = FlatStyle.Flat;
            c.BackColor = _card;
            c.ForeColor = _text;
            c.Font = new Font("Segoe UI", 10f);
            c.IntegralHeight = false;
            c.DropDownHeight = 220;
        }

        private void StyleNumeric(NumericUpDown n)
        {
            n.BorderStyle = BorderStyle.FixedSingle;
            n.BackColor = _card;
            n.ForeColor = _text;
            n.Font = new Font("Segoe UI", 10f);
            n.Maximum = 10000000;
        }

        private void StyleDate(DateTimePicker d)
        {
            d.Font = new Font("Segoe UI", 10f);
            d.CalendarForeColor = _text;
            d.CalendarMonthBackground = _card;
        }

        private void StyleBtnPrimary(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = _primary;
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.Height = 34;

            b.MouseEnter -= BtnPrimary_MouseEnter;
            b.MouseLeave -= BtnPrimary_MouseLeave;
            b.MouseEnter += BtnPrimary_MouseEnter;
            b.MouseLeave += BtnPrimary_MouseLeave;
        }

        private void BtnPrimary_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button b) b.BackColor = _primaryDark;
        }

        private void BtnPrimary_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button b) b.BackColor = _primary;
        }

        private void StyleBtnGhost(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = _border;
            b.BackColor = _card;
            b.ForeColor = _text;
            b.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.Height = 34;
        }

        private void StyleBtnDanger(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = _danger;
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.Height = 34;
        }

        // ===================== LANGUAGE SWITCH =====================

        private void InitLanguageCombo()
        {
            cbLanguage.Items.Clear();
            cbLanguage.Items.Add("EST");
            cbLanguage.Items.Add("ENG");

            cbLanguage.SelectedIndexChanged -= cbLanguage_SelectedIndexChanged;
            cbLanguage.SelectedItem = "ENG";
            cbLanguage.SelectedIndexChanged += cbLanguage_SelectedIndexChanged;
        }

        private void cbLanguage_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cbLanguage.SelectedItem == null) return;

            string selected = cbLanguage.SelectedItem.ToString()!;
            if (selected == "EST")
            {
                var f = new Form1();
                f.StartPosition = FormStartPosition.Manual;
                f.Location = this.Location;
                f.Show();
                this.Hide();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // ===================== LOAD ALL =====================

        private void LoadAll()
        {
            LoadOwners();
            LoadOwnersToCombo();

            LoadCars();

            LoadServices();
            LoadTeenusedToCombo();

            LoadHooldusCombos();
            LoadHooldusGrid();

            LoadPaymentCarServiceCombo();
            LoadPaymentsGrid();
        }

        // ===================== GRID COLUMN FIXERS (EN) =====================

        private void RenameCol(DataGridView grid, string colName, string header, bool hide = false)
        {
            if (!grid.Columns.Contains(colName)) return;
            var c = grid.Columns[colName];
            c.HeaderText = header;
            c.Visible = !hide;
        }

        private void FixOwnersGridColumns_EN()
        {
            if (dgvOwners.Columns.Count == 0) return;

            RenameCol(dgvOwners, "Id", "ID", hide: true);
            RenameCol(dgvOwners, "FullName", "Name");
            RenameCol(dgvOwners, "Phone", "Phone");

            RenameCol(dgvOwners, "Cars", "Cars", hide: true);
            RenameCol(dgvOwners, "CarServices", "CarServices", hide: true);
            RenameCol(dgvOwners, "Payments", "Payments", hide: true);
        }

        private void FixCarsGridColumns_EN()
        {
            if (dgvCars.Columns.Count == 0) return;

            RenameCol(dgvCars, "Id", "ID", hide: true);
            RenameCol(dgvCars, "Brand", "Brand");
            RenameCol(dgvCars, "Model", "Model");
            RenameCol(dgvCars, "RegistrationNumber", "Reg. No.");
            RenameCol(dgvCars, "Owner", "Owner");
            RenameCol(dgvCars, "OwnerId", "OwnerId", hide: true);

            RenameCol(dgvCars, "OwnerNavigation", "Owner", hide: true);
            RenameCol(dgvCars, "CarServices", "CarServices", hide: true);
            RenameCol(dgvCars, "Payments", "Payments", hide: true);
        }

        private void FixServicesGridColumns_EN()
        {
            if (dgvServices.Columns.Count == 0) return;

            RenameCol(dgvServices, "Id", "ID", hide: true);
            RenameCol(dgvServices, "Name", "Service");
            RenameCol(dgvServices, "Price", "Price (€)");

            RenameCol(dgvServices, "CarServices", "CarServices", hide: true);
        }

        private void FixCarServicesGridColumns_EN()
        {
            if (dgvCarServices.Columns.Count == 0) return;

            RenameCol(dgvCarServices, "Id", "ID", hide: true);
            RenameCol(dgvCarServices, "Auto", "Car");
            RenameCol(dgvCarServices, "RegNr", "Reg. No.");
            RenameCol(dgvCarServices, "Teenus", "Service");
            RenameCol(dgvCarServices, "Summa", "Amount (€)");
            RenameCol(dgvCarServices, "DateOfService", "Service date");
            RenameCol(dgvCarServices, "Mileage", "Mileage");

            RenameCol(dgvCarServices, "CarId", "CarId", hide: true);
            RenameCol(dgvCarServices, "ServiceId", "ServiceId", hide: true);

            RenameCol(dgvCarServices, "Car", "Car", hide: true);
            RenameCol(dgvCarServices, "Service", "Service", hide: true);
            RenameCol(dgvCarServices, "Payments", "Payments", hide: true);
        }

        private void FixPaymentsGridColumns_EN()
        {
            if (dgvPayments.Columns.Count == 0) return;

            RenameCol(dgvPayments, "Id", "ID", hide: true);
            RenameCol(dgvPayments, "Auto", "Car");
            RenameCol(dgvPayments, "RegNr", "Reg. No.");
            RenameCol(dgvPayments, "OmanikuTelefon", "Owner phone");
            RenameCol(dgvPayments, "Teenus", "Service");
            RenameCol(dgvPayments, "Summa", "Amount (€)");
            RenameCol(dgvPayments, "Makstud", "Paid");
            RenameCol(dgvPayments, "PaymentDate", "Payment date");
            RenameCol(dgvPayments, "CarServiceId", "CarServiceId", hide: true);

            RenameCol(dgvPayments, "CarService", "CarService", hide: true);
            RenameCol(dgvPayments, "Owner", "Owner", hide: true);
        }

        // ===================== OWNERS =====================

        private void LoadOwners()
        {
            using var db = new AutoDbContext();

            dgvOwners.DataSource = db.Owners.AsNoTracking()
                .Select(o => new
                {
                    o.Id,
                    FullName = o.FullName,
                    Phone = o.Phone
                })
                .ToList();

            FixOwnersGridColumns_EN();
            CacheSource(dgvOwners, ref _ownersSource);
            ApplySearchRebind(dgvOwners, _ownersSource, txtSearch.Text);
        }

        private void dgvOwners_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOwners.CurrentRow == null) return;

            SetText(txtOwnerName, dgvOwners.CurrentRow.Cells["FullName"].Value?.ToString());
            SetText(txtOwnerPhone, dgvOwners.CurrentRow.Cells["Phone"].Value?.ToString());
        }

        private void btnOwnerAdd_Click(object sender, EventArgs e)
        {
            var name = GetText(txtOwnerName);
            var phone = GetText(txtOwnerPhone);

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the owner's name.");
                return;
            }

            using var db = new AutoDbContext();
            db.Owners.Add(new Owner { FullName = name, Phone = phone });
            db.SaveChanges();

            SetText(txtOwnerName, "");
            SetText(txtOwnerPhone, "");

            LoadOwners();
            LoadOwnersToCombo();
        }

        private void btnOwnerDelete_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvOwners.CurrentRow.Cells["Id"].Value);

            using var db = new AutoDbContext();
            var owner = db.Owners.Find(id);
            if (owner == null) return;

            db.Owners.Remove(owner);
            db.SaveChanges();

            LoadOwners();
            LoadOwnersToCombo();
        }

        private void btnOwnerUpdate_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvOwners.CurrentRow.Cells["Id"].Value);

            var name = GetText(txtOwnerName);
            var phone = GetText(txtOwnerPhone);

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the owner's name.");
                return;
            }

            using var db = new AutoDbContext();
            var owner = db.Owners.Find(id);
            if (owner == null) return;

            owner.FullName = name;
            owner.Phone = phone;

            db.SaveChanges();

            LoadOwners();
            LoadOwnersToCombo();
        }

        private void LoadOwnersToCombo()
        {
            using var db = new AutoDbContext();
            cbCarOwner.DataSource = db.Owners.AsNoTracking().ToList();
            cbCarOwner.DisplayMember = "FullName";
            cbCarOwner.ValueMember = "Id";
        }

        // ===================== CARS =====================

        private void LoadCars()
        {
            using var db = new AutoDbContext();

            dgvCars.DataSource = db.Cars
                .Include(c => c.Owner)
                .AsNoTracking()
                .Select(c => new
                {
                    c.Id,
                    c.Brand,
                    c.Model,
                    c.RegistrationNumber,
                    Owner = c.Owner.FullName,
                    c.OwnerId
                })
                .ToList();

            FixCarsGridColumns_EN();
            CacheSource(dgvCars, ref _carsSource);
            ApplySearchRebind(dgvCars, _carsSource, txtSearch2.Text);
        }

        private void dgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;

            SetText(txtCarBrand, dgvCars.CurrentRow.Cells["Brand"].Value?.ToString());
            SetText(txtCarModel, dgvCars.CurrentRow.Cells["Model"].Value?.ToString());
            SetText(txtCarReg, dgvCars.CurrentRow.Cells["RegistrationNumber"].Value?.ToString());

            cbCarOwner.SelectedValue = dgvCars.CurrentRow.Cells["OwnerId"].Value;
        }

        private void btnCarAdd_Click(object sender, EventArgs e)
        {
            var brand = GetText(txtCarBrand);
            var model = GetText(txtCarModel);
            var reg = GetText(txtCarReg);

            if (string.IsNullOrWhiteSpace(brand) ||
                string.IsNullOrWhiteSpace(model) ||
                string.IsNullOrWhiteSpace(reg))
            {
                MessageBox.Show("Please fill in all car fields.");
                return;
            }

            using var db = new AutoDbContext();
            db.Cars.Add(new Car
            {
                Brand = brand,
                Model = model,
                RegistrationNumber = reg,
                OwnerId = (int)cbCarOwner.SelectedValue
            });
            db.SaveChanges();

            SetText(txtCarBrand, "");
            SetText(txtCarModel, "");
            SetText(txtCarReg, "");

            LoadCars();
            LoadHooldusCombos();
            LoadPaymentCarServiceCombo();
        }

        private void btnCarDelete_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;
            int id = (int)dgvCars.CurrentRow.Cells["Id"].Value;

            using var db = new AutoDbContext();
            var car = db.Cars.Find(id);
            if (car == null) return;

            db.Cars.Remove(car);
            db.SaveChanges();

            LoadCars();
            LoadHooldusCombos();
            LoadPaymentCarServiceCombo();
        }

        private void btnCarUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;
            int id = (int)dgvCars.CurrentRow.Cells["Id"].Value;

            var brand = GetText(txtCarBrand);
            var model = GetText(txtCarModel);
            var reg = GetText(txtCarReg);

            if (string.IsNullOrWhiteSpace(brand) ||
                string.IsNullOrWhiteSpace(model) ||
                string.IsNullOrWhiteSpace(reg))
            {
                MessageBox.Show("Please fill in all car fields.");
                return;
            }

            using var db = new AutoDbContext();
            var car = db.Cars.Find(id);
            if (car == null) return;

            car.Brand = brand;
            car.Model = model;
            car.RegistrationNumber = reg;
            car.OwnerId = (int)cbCarOwner.SelectedValue;

            db.SaveChanges();

            LoadCars();
            LoadHooldusCombos();
            LoadPaymentCarServiceCombo();
        }

        // ===================== SERVICES =====================

        private void LoadServices()
        {
            using var db = new AutoDbContext();

            dgvServices.DataSource = db.Services.AsNoTracking()
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Price
                })
                .ToList();

            FixServicesGridColumns_EN();
            CacheSource(dgvServices, ref _servicesSource);
            ApplySearchRebind(dgvServices, _servicesSource, txtSearch3.Text);
        }

        private void dgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServices.CurrentRow == null) return;

            SetText(txtServiceName, dgvServices.CurrentRow.Cells["Name"].Value?.ToString());

            var priceObj = dgvServices.CurrentRow.Cells["Price"].Value;
            if (priceObj != null)
                numServicePrice.Value = Convert.ToDecimal(priceObj);
        }

        private void btnServiceAdd_Click(object sender, EventArgs e)
        {
            var name = GetText(txtServiceName);

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a service name.");
                return;
            }

            using var db = new AutoDbContext();
            db.Services.Add(new Service { Name = name, Price = numServicePrice.Value });
            db.SaveChanges();

            SetText(txtServiceName, "");
            numServicePrice.Value = 0;

            LoadServices();
            LoadTeenusedToCombo();
            LoadHooldusCombos();
            LoadPaymentCarServiceCombo();
        }

        private void btnServiceDelete_Click(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvServices.CurrentRow.Cells["Id"].Value);

            using var db = new AutoDbContext();
            var service = db.Services.Find(id);
            if (service == null) return;

            db.Services.Remove(service);
            db.SaveChanges();

            LoadServices();
            LoadTeenusedToCombo();
            LoadHooldusCombos();
            LoadPaymentCarServiceCombo();
        }

        private void btnServiceUpdate_Click(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvServices.CurrentRow.Cells["Id"].Value);

            var name = GetText(txtServiceName);

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a service name.");
                return;
            }

            using var db = new AutoDbContext();
            var service = db.Services.Find(id);
            if (service == null) return;

            service.Name = name;
            service.Price = numServicePrice.Value;

            db.SaveChanges();

            LoadServices();
            LoadTeenusedToCombo();
            LoadHooldusCombos();
            LoadPaymentCarServiceCombo();
        }

        private void LoadTeenusedToCombo()
        {
            using var db = new AutoDbContext();
            cbTeenus.DataSource = db.Services.AsNoTracking().OrderBy(x => x.Name).ToList();
            cbTeenus.DisplayMember = "Name";
            cbTeenus.ValueMember = "Id";
        }

        // ===================== MAINTENANCE (CAR SERVICES) =====================

        private void LoadHooldusCombos()
        {
            using var db = new AutoDbContext();

            cbHooldusCar.DataSource = db.Cars
                .Select(c => new { c.Id, Title = c.Brand + " " + c.Model + " (" + c.RegistrationNumber + ")" })
                .ToList();
            cbHooldusCar.DisplayMember = "Title";
            cbHooldusCar.ValueMember = "Id";

            cbHooldusService.DataSource = db.Services
                .Select(s => new { s.Id, s.Name })
                .ToList();
            cbHooldusService.DisplayMember = "Name";
            cbHooldusService.ValueMember = "Id";
        }

        private void LoadHooldusGrid()
        {
            using var db = new AutoDbContext();

            dgvCarServices.DataSource = db.CarServices
                .Include(cs => cs.Car)
                .Include(cs => cs.Service)
                .Select(cs => new
                {
                    cs.Id,
                    Auto = cs.Car.Brand + " " + cs.Car.Model,
                    RegNr = cs.Car.RegistrationNumber,
                    Teenus = cs.Service.Name,
                    Summa = cs.Service.Price,
                    cs.DateOfService,
                    cs.Mileage,
                    cs.CarId,
                    cs.ServiceId
                })
                .ToList();

            FixCarServicesGridColumns_EN();
            CacheSource(dgvCarServices, ref _carServicesSource);
            ApplySearchRebind(dgvCarServices, _carServicesSource, txtSearch4.Text);
        }

        private void btnHooldusAdd_Click(object sender, EventArgs e)
        {
            using var db = new AutoDbContext();
            db.CarServices.Add(new CarService
            {
                CarId = (int)cbHooldusCar.SelectedValue,
                ServiceId = (int)cbHooldusService.SelectedValue,
                DateOfService = dtpHooldusDate.Value,
                Mileage = (int)numHooldusMileage.Value
            });
            db.SaveChanges();

            LoadHooldusGrid();
            LoadPaymentCarServiceCombo();
        }

        private void btnHooldusDelete_Click(object sender, EventArgs e)
        {
            if (dgvCarServices.CurrentRow == null) return;
            int id = (int)dgvCarServices.CurrentRow.Cells["Id"].Value;

            using var db = new AutoDbContext();
            var cs = db.CarServices.Find(id);
            if (cs == null) return;

            db.CarServices.Remove(cs);
            db.SaveChanges();

            LoadHooldusGrid();
            LoadPaymentCarServiceCombo();
        }

        private void btnHooldusUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCarServices.CurrentRow == null) return;
            int id = (int)dgvCarServices.CurrentRow.Cells["Id"].Value;

            using var db = new AutoDbContext();
            var cs = db.CarServices.Find(id);
            if (cs == null) return;

            cs.CarId = (int)cbHooldusCar.SelectedValue;
            cs.ServiceId = (int)cbHooldusService.SelectedValue;
            cs.DateOfService = dtpHooldusDate.Value;
            cs.Mileage = (int)numHooldusMileage.Value;

            db.SaveChanges();

            LoadHooldusGrid();
            LoadPaymentCarServiceCombo();
        }

        private void dgvHooldus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCarServices.CurrentRow == null) return;

            cbHooldusCar.SelectedValue = dgvCarServices.CurrentRow.Cells["CarId"].Value;
            cbHooldusService.SelectedValue = dgvCarServices.CurrentRow.Cells["ServiceId"].Value;

            var dateObj = dgvCarServices.CurrentRow.Cells["DateOfService"].Value;
            if (dateObj != null) dtpHooldusDate.Value = Convert.ToDateTime(dateObj);

            var milObj = dgvCarServices.CurrentRow.Cells["Mileage"].Value;
            if (milObj != null) numHooldusMileage.Value = Convert.ToDecimal(milObj);
        }

        // ===================== PAYMENTS =====================

        private void LoadPaymentCarServiceCombo()
        {
            using var db = new AutoDbContext();

            cbPaymentCarService.DataSource = db.CarServices
                .Include(cs => cs.Car)
                .Include(cs => cs.Service)
                .OrderByDescending(cs => cs.DateOfService)
                .Select(cs => new
                {
                    cs.Id,
                    Title = cs.Car.Brand + " " + cs.Car.Model + " (" + cs.Car.RegistrationNumber + ") — "
                            + cs.Service.Name + " — "
                            + cs.DateOfService.ToString("yyyy-MM-dd")
                })
                .ToList();

            cbPaymentCarService.DisplayMember = "Title";
            cbPaymentCarService.ValueMember = "Id";
        }

        private void LoadPaymentsGrid()
        {
            using var db = new AutoDbContext();

            dgvPayments.DataSource = db.Payments
                .Include(p => p.CarService).ThenInclude(cs => cs.Car).ThenInclude(c => c.Owner)
                .Include(p => p.CarService).ThenInclude(cs => cs.Service)
                .AsNoTracking()
                .OrderByDescending(p => p.Id)
                .Select(p => new
                {
                    p.Id,
                    Auto = p.CarService.Car.Brand + " " + p.CarService.Car.Model,
                    RegNr = p.CarService.Car.RegistrationNumber,
                    OmanikuTelefon = p.CarService.Car.Owner.Phone,
                    Teenus = p.CarService.Service.Name,
                    Summa = p.Amount,
                    Makstud = p.IsPaid ? "Yes" : "No",
                    p.PaymentDate,
                    p.CarServiceId
                })
                .ToList();

            FixPaymentsGridColumns_EN();
            CacheSource(dgvPayments, ref _paymentsSource);
            ApplySearchRebind(dgvPayments, _paymentsSource, txtSearch5.Text);
        }

        private void dgvPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPayments.CurrentRow == null) return;

            cbPaymentCarService.SelectedValue = dgvPayments.CurrentRow.Cells["CarServiceId"].Value;

            var amountObj = dgvPayments.CurrentRow.Cells["Summa"].Value;
            if (amountObj != null)
                numPaymentAmount.Value = Convert.ToDecimal(amountObj);

            chkIsPaid.Checked = dgvPayments.CurrentRow.Cells["Makstud"].Value?.ToString() == "Yes";

            var dateObj = dgvPayments.CurrentRow.Cells["PaymentDate"].Value;
            if (dateObj == null || dateObj == DBNull.Value)
            {
                dtpPaymentDate.Checked = false;
            }
            else
            {
                dtpPaymentDate.Checked = true;
                dtpPaymentDate.Value = Convert.ToDateTime(dateObj);
            }
        }

        private void btnPaymentAdd_Click(object sender, EventArgs e)
        {
            using var db = new AutoDbContext();
            db.Payments.Add(new Payment
            {
                CarServiceId = (int)cbPaymentCarService.SelectedValue,
                Amount = numPaymentAmount.Value,
                IsPaid = chkIsPaid.Checked,
                PaymentDate = dtpPaymentDate.Checked ? dtpPaymentDate.Value : null
            });
            db.SaveChanges();

            LoadPaymentsGrid();
        }

        private void btnPaymentUpdate_Click(object sender, EventArgs e)
        {
            if (dgvPayments.CurrentRow == null) return;
            int id = (int)dgvPayments.CurrentRow.Cells["Id"].Value;

            using var db = new AutoDbContext();
            var p = db.Payments.Find(id);
            if (p == null) return;

            p.CarServiceId = (int)cbPaymentCarService.SelectedValue;
            p.Amount = numPaymentAmount.Value;
            p.IsPaid = chkIsPaid.Checked;
            p.PaymentDate = dtpPaymentDate.Checked ? dtpPaymentDate.Value : null;

            db.SaveChanges();

            LoadPaymentsGrid();
        }

        private void btnPaymentDelete_Click(object sender, EventArgs e)
        {
            if (dgvPayments.CurrentRow == null) return;
            int id = (int)dgvPayments.CurrentRow.Cells["Id"].Value;

            using var db = new AutoDbContext();
            var p = db.Payments.Find(id);
            if (p == null) return;

            db.Payments.Remove(p);
            db.SaveChanges();

            LoadPaymentsGrid();
        }

        // ===================== SEARCH TEXTBOX EVENTS =====================
        // txtSearch  = Owners
        // txtSearch2 = Cars
        // txtSearch3 = Services
        // txtSearch4 = Maintenance
        // txtSearch5 = Payments

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplySearchRebind(dgvOwners, _ownersSource, txtSearch.Text);
            FixOwnersGridColumns_EN();
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            ApplySearchRebind(dgvCars, _carsSource, txtSearch2.Text);
            FixCarsGridColumns_EN();
        }

        private void txtSearch3_TextChanged(object sender, EventArgs e)
        {
            ApplySearchRebind(dgvServices, _servicesSource, txtSearch3.Text);
            FixServicesGridColumns_EN();
        }

        private void txtSearch4_TextChanged(object sender, EventArgs e)
        {
            ApplySearchRebind(dgvCarServices, _carServicesSource, txtSearch4.Text);
            FixCarServicesGridColumns_EN();
        }

        private void txtSearch5_TextChanged(object sender, EventArgs e)
        {
            ApplySearchRebind(dgvPayments, _paymentsSource, txtSearch5.Text);
            FixPaymentsGridColumns_EN();
        }
    }
}
