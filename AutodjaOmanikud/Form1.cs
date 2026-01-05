using System;
using System.Linq;
using System.Windows.Forms;
using AutodjaOmanikud;
using Microsoft.EntityFrameworkCore;

namespace AutojaOmanikud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // -------- Owners (Omanik) --------
            btnOwnerAdd.Click += btnOwnerAdd_Click;
            btnOwnerDelete.Click += btnOwnerKustuta_Click;
            btnOwnerUpdate.Click += btnOwnerUuenda_Click;
            dgvOwners.CellClick += dgvOwners_CellClick;

            // -------- Cars (Auto) --------
            btnCarAdd.Click += btnCarAdd_Click;
            btnCarDelete.Click += btnCarKustuta_Click;
            btnCarUpdate.Click += btnCarUuenda_Click;
            dgvCars.CellClick += dgvCars_CellClick;

            // -------- Services (Teenus) --------
            btnServiceAdd.Click += btnServiceAdd_Click;
            btnServiceDelete.Click += btnServiceKustuta_Click;
            btnServiceUpdate.Click += btnServiceUuenda_Click;
            dgvServices.CellClick += dgvServices_CellClick;

            // -------- Hooldus (CarService) --------
            // ВАЖНО: эти контролы должны существовать на форме с такими Name
            // dgvHooldus, cbHooldusCar, cbHooldusService, dtpHooldusDate, numHooldusMileage
            // btnHooldusAdd, btnHooldusDelete, btnHooldusUpdate
            btnHooldusAdd.Click += btnHooldusAdd_Click;
            btnHooldusDelete.Click += btnHooldusDelete_Click;
            btnHooldusUpdate.Click += btnHooldusUpdate_Click;
            dgvCarServices.CellClick += dgvHooldus_CellClick;

            // Чтобы нельзя было писать руками в ComboBox
            cbHooldusCar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbHooldusService.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadAll();
        }

        private void LoadAll()
        {
            LoadOwners();
            LoadOwnersToCombo();
            LoadCars();
            LoadServices();

            LoadHooldusCombos();
            LoadHooldusGrid();
        }

        // ===================== OWNERS =====================

        private void LoadOwners()
        {
            using var db = new AutoDbContext();
            dgvOwners.AutoGenerateColumns = true;
            dgvOwners.DataSource = db.Owners.AsNoTracking().ToList();
        }

        private void dgvOwners_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOwners.CurrentRow?.DataBoundItem is not Owner owner) return;

            txtOwnerName.Text = owner.FullName;
            txtOwnerPhone.Text = owner.Phone;
        }

        private void btnOwnerAdd_Click(object sender, EventArgs e)
        {
            var name = txtOwnerName.Text.Trim();
            var phone = txtOwnerPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите имя владельца (FullName)");
                return;
            }

            using var db = new AutoDbContext();
            db.Owners.Add(new Owner { FullName = name, Phone = phone });
            db.SaveChanges();

            txtOwnerName.Clear();
            txtOwnerPhone.Clear();

            LoadAll();
        }

        private void btnOwnerKustuta_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow?.DataBoundItem is not Owner selected) return;

            using var db = new AutoDbContext();
            var owner = db.Owners.FirstOrDefault(o => o.Id == selected.Id);
            if (owner == null) return;

            db.Owners.Remove(owner);
            db.SaveChanges();

            LoadAll();
        }

        private void btnOwnerUuenda_Click(object sender, EventArgs e)
        {
            if (dgvOwners.CurrentRow?.DataBoundItem is not Owner selected) return;

            var name = txtOwnerName.Text.Trim();
            var phone = txtOwnerPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите имя владельца (FullName)");
                return;
            }

            using var db = new AutoDbContext();
            var owner = db.Owners.FirstOrDefault(o => o.Id == selected.Id);
            if (owner == null) return;

            owner.FullName = name;
            owner.Phone = phone;

            db.SaveChanges();
            LoadAll();
        }

        // ComboBox owners for cars
        private void LoadOwnersToCombo()
        {
            using var db = new AutoDbContext();
            var owners = db.Owners.AsNoTracking()
                .Select(o => new { o.Id, o.FullName })
                .ToList();

            cbCarOwner.DisplayMember = "FullName";
            cbCarOwner.ValueMember = "Id";
            cbCarOwner.DataSource = owners;
        }

        // ===================== CARS =====================

        private void LoadCars()
        {
            using var db = new AutoDbContext();

            dgvCars.AutoGenerateColumns = true;
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
        }

        private void dgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;

            txtCarBrand.Text = Convert.ToString(dgvCars.CurrentRow.Cells["Brand"].Value);
            txtCarModel.Text = Convert.ToString(dgvCars.CurrentRow.Cells["Model"].Value);
            txtCarReg.Text = Convert.ToString(dgvCars.CurrentRow.Cells["RegistrationNumber"].Value);

            var ownerIdObj = dgvCars.CurrentRow.Cells["OwnerId"].Value;
            if (ownerIdObj != null)
                cbCarOwner.SelectedValue = Convert.ToInt32(ownerIdObj);
        }

        private void btnCarAdd_Click(object sender, EventArgs e)
        {
            if (cbCarOwner.SelectedValue == null)
            {
                MessageBox.Show("Выберите владельца");
                return;
            }

            var brand = txtCarBrand.Text.Trim();
            var model = txtCarModel.Text.Trim();
            var reg = txtCarReg.Text.Trim();

            if (string.IsNullOrWhiteSpace(brand) ||
                string.IsNullOrWhiteSpace(model) ||
                string.IsNullOrWhiteSpace(reg))
            {
                MessageBox.Show("Заполните Brand / Model / RegistrationNumber");
                return;
            }

            int ownerId = (int)cbCarOwner.SelectedValue;

            using var db = new AutoDbContext();
            db.Cars.Add(new Car
            {
                Brand = brand,
                Model = model,
                RegistrationNumber = reg,
                OwnerId = ownerId
            });
            db.SaveChanges();

            txtCarBrand.Clear();
            txtCarModel.Clear();
            txtCarReg.Clear();

            LoadCars();
        }

        private void btnCarKustuta_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;

            var idObj = dgvCars.CurrentRow.Cells["Id"].Value;
            if (idObj == null) return;

            int carId = Convert.ToInt32(idObj);

            using var db = new AutoDbContext();
            var car = db.Cars.FirstOrDefault(c => c.Id == carId);
            if (car == null) return;

            db.Cars.Remove(car);
            db.SaveChanges();

            LoadCars();
        }

        private void btnCarUuenda_Click(object sender, EventArgs e)
        {
            if (dgvCars.CurrentRow == null) return;

            var idObj = dgvCars.CurrentRow.Cells["Id"].Value;
            if (idObj == null) return;

            int carId = Convert.ToInt32(idObj);

            if (cbCarOwner.SelectedValue == null)
            {
                MessageBox.Show("Выберите владельца");
                return;
            }

            var brand = txtCarBrand.Text.Trim();
            var model = txtCarModel.Text.Trim();
            var reg = txtCarReg.Text.Trim();

            if (string.IsNullOrWhiteSpace(brand) ||
                string.IsNullOrWhiteSpace(model) ||
                string.IsNullOrWhiteSpace(reg))
            {
                MessageBox.Show("Заполните Brand / Model / RegistrationNumber");
                return;
            }

            int ownerId = (int)cbCarOwner.SelectedValue;

            using var db = new AutoDbContext();
            var car = db.Cars.FirstOrDefault(c => c.Id == carId);
            if (car == null) return;

            car.Brand = brand;
            car.Model = model;
            car.RegistrationNumber = reg;
            car.OwnerId = ownerId;

            db.SaveChanges();
            LoadCars();
        }

        // ===================== SERVICES =====================

        private void LoadServices()
        {
            using var db = new AutoDbContext();
            dgvServices.AutoGenerateColumns = true;
            dgvServices.DataSource = db.Services.AsNoTracking().ToList();
        }

        private void dgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServices.CurrentRow?.DataBoundItem is not Service s) return;

            txtServiceName.Text = s.Name;
            numServicePrice.Value = s.Price;
        }

        private void btnServiceAdd_Click(object sender, EventArgs e)
        {
            var name = txtServiceName.Text.Trim();
            var price = numServicePrice.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите название услуги (Name)");
                return;
            }

            using var db = new AutoDbContext();
            db.Services.Add(new Service { Name = name, Price = price });
            db.SaveChanges();

            txtServiceName.Clear();
            numServicePrice.Value = 0;

            LoadServices();
            LoadHooldusCombos(); // чтобы ComboBox услуг на Hooldus сразу обновился
        }

        private void btnServiceKustuta_Click(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow?.DataBoundItem is not Service selected) return;

            using var db = new AutoDbContext();
            var service = db.Services.FirstOrDefault(s => s.Id == selected.Id);
            if (service == null) return;

            db.Services.Remove(service);
            db.SaveChanges();

            LoadServices();
            LoadHooldusCombos();
        }

        private void btnServiceUuenda_Click(object sender, EventArgs e)
        {
            if (dgvServices.CurrentRow?.DataBoundItem is not Service selected) return;

            var name = txtServiceName.Text.Trim();
            var price = numServicePrice.Value;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите название услуги (Name)");
                return;
            }

            using var db = new AutoDbContext();
            var service = db.Services.FirstOrDefault(s => s.Id == selected.Id);
            if (service == null) return;

            service.Name = name;
            service.Price = price;

            db.SaveChanges();
            LoadServices();
            LoadHooldusCombos();
        }

        // ===================== HOOLDUS (CarService) =====================

        private void LoadHooldusCombos()
        {
            using var db = new AutoDbContext();

            var cars = db.Cars.AsNoTracking()
                .Select(c => new
                {
                    c.Id,
                    Title = c.Brand + " " + c.Model + " (" + c.RegistrationNumber + ")"
                })
                .ToList();

            cbHooldusCar.DisplayMember = "Title";
            cbHooldusCar.ValueMember = "Id";
            cbHooldusCar.DataSource = cars;

            var services = db.Services.AsNoTracking()
                .Select(s => new { s.Id, s.Name })
                .ToList();

            cbHooldusService.DisplayMember = "Name";
            cbHooldusService.ValueMember = "Id";
            cbHooldusService.DataSource = services;
        }

        private void LoadHooldusGrid()
        {
            using var db = new AutoDbContext();

            dgvCarServices.AutoGenerateColumns = true;
            dgvCarServices.DataSource = db.CarServices
                .Include(cs => cs.Car)
                .Include(cs => cs.Service)
                .AsNoTracking()
                .Select(cs => new
                {
                    cs.Id,
                    Car = cs.Car.Brand + " " + cs.Car.Model,
                    cs.Car.RegistrationNumber,
                    Service = cs.Service.Name,
                    cs.DateOfService,
                    cs.Mileage,
                    cs.CarId,
                    cs.ServiceId
                })
                .ToList();
        }

        private void btnHooldusAdd_Click(object sender, EventArgs e)
        {
            if (cbHooldusCar.SelectedValue == null || cbHooldusService.SelectedValue == null)
            {
                MessageBox.Show("Выберите авто и услугу");
                return;
            }

            int carId = (int)cbHooldusCar.SelectedValue;
            int serviceId = (int)cbHooldusService.SelectedValue;

            using var db = new AutoDbContext();
            db.CarServices.Add(new CarService
            {
                CarId = carId,
                ServiceId = serviceId,
                DateOfService = dtpHooldusDate.Value,
                Mileage = (int)numHooldusMileage.Value
            });

            db.SaveChanges();
            LoadHooldusGrid();
        }

        private void btnHooldusDelete_Click(object sender, EventArgs e)
        {
            if (dgvCarServices.CurrentRow == null) return;

            var idObj = dgvCarServices.CurrentRow.Cells["Id"].Value;
            if (idObj == null) return;

            int id = Convert.ToInt32(idObj);

            using var db = new AutoDbContext();
            var cs = db.CarServices.FirstOrDefault(x => x.Id == id);
            if (cs == null) return;

            db.CarServices.Remove(cs);
            db.SaveChanges();

            LoadHooldusGrid();
        }

        private void btnHooldusUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCarServices.CurrentRow == null) return;

            var idObj = dgvCarServices.CurrentRow.Cells["Id"].Value;
            if (idObj == null) return;

            int id = Convert.ToInt32(idObj);

            if (cbHooldusCar.SelectedValue == null || cbHooldusService.SelectedValue == null)
            {
                MessageBox.Show("Выберите авто и услугу");
                return;
            }

            int carId = (int)cbHooldusCar.SelectedValue;
            int serviceId = (int)cbHooldusService.SelectedValue;

            using var db = new AutoDbContext();
            var cs = db.CarServices.FirstOrDefault(x => x.Id == id);
            if (cs == null) return;

            cs.CarId = carId;
            cs.ServiceId = serviceId;
            cs.DateOfService = dtpHooldusDate.Value;
            cs.Mileage = (int)numHooldusMileage.Value;

            db.SaveChanges();
            LoadHooldusGrid();
        }

        private void dgvHooldus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCarServices.CurrentRow == null) return;

            var carIdObj = dgvCarServices.CurrentRow.Cells["CarId"].Value;
            var serviceIdObj = dgvCarServices.CurrentRow.Cells["ServiceId"].Value;

            if (carIdObj != null) cbHooldusCar.SelectedValue = Convert.ToInt32(carIdObj);
            if (serviceIdObj != null) cbHooldusService.SelectedValue = Convert.ToInt32(serviceIdObj);

            var dateObj = dgvCarServices.CurrentRow.Cells["DateOfService"].Value;
            if (dateObj != null) dtpHooldusDate.Value = Convert.ToDateTime(dateObj);

            var milObj = dgvCarServices.CurrentRow.Cells["Mileage"].Value;
            if (milObj != null)
            {
                var m = Convert.ToInt32(milObj);
                if (m < (int)numHooldusMileage.Minimum) m = (int)numHooldusMileage.Minimum;
                if (m > (int)numHooldusMileage.Maximum) m = (int)numHooldusMileage.Maximum;
                numHooldusMileage.Value = m;
            }
        }
    }
}
