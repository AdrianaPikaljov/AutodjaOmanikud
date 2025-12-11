using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AutodjaOmanikud
{
    public partial class Form3 : Form
    {
        // CONNECTION
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=AutoServiceDB;Trusted_Connection=True;";

        // TAB 1 SELECTED RECORD
        private int selectedCarServiceId = -1;

        // TAB 2 SELECTED PAYMENT
        private int selectedPaymentId = -1;

        // TAB 3 SELECTED BOOKING
        private int selectedBookingId = -1;


        public Form3()
        {
            InitializeComponent();
            this.Load += Form3_Load;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Инициализация фильтра платежей
            if (comboBoxPaymentFilter != null)
            {
                comboBoxPaymentFilter.Items.Clear();
                comboBoxPaymentFilter.Items.Add("Kõik");
                comboBoxPaymentFilter.Items.Add("Makstud");
                comboBoxPaymentFilter.Items.Add("Maksmata");
                comboBoxPaymentFilter.SelectedIndex = 0;
            }

            LoadCars();
            LoadServices();
            LoadCarServices();
            LoadCarServicesForPayment();
            LoadPayments();
            LoadBookings();
        }

        // ============================================================
        // LOAD CARS + SERVICES
        // ============================================================

        private void LoadCars()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Brand + ' ' + Model AS CarName FROM Cars", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxCar.DataSource = dt;
                comboBoxCar.DisplayMember = "CarName";
                comboBoxCar.ValueMember = "Id";

                comboBoxBookingCar.DataSource = dt.Copy();
                comboBoxBookingCar.DisplayMember = "CarName";
                comboBoxBookingCar.ValueMember = "Id";
            }
        }

        private void LoadServices()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Name FROM Services", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxService.DataSource = dt;
                comboBoxService.DisplayMember = "Name";
                comboBoxService.ValueMember = "Id";

                comboBoxBookingService.DataSource = dt.Copy();
                comboBoxBookingService.DisplayMember = "Name";
                comboBoxBookingService.ValueMember = "Id";
            }
        }

        // ============================================================
        // TAB 1 – CAR SERVICES CRUD
        // ============================================================

        private void LoadCarServices()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT cs.Id,
                           cs.CarId,
                           c.Brand + ' ' + c.Model AS Car,
                           cs.ServiceId,
                           s.Name AS Service,
                           cs.DateOfService,
                           cs.Mileage
                    FROM CarServices cs
                    INNER JOIN Cars c ON cs.CarId = c.Id
                    INNER JOIN Services s ON cs.ServiceId = s.Id";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewCarServices.DataSource = dt;

                dataGridViewCarServices.Columns["Id"].Visible = false;
                dataGridViewCarServices.Columns["CarId"].Visible = false;
                dataGridViewCarServices.Columns["ServiceId"].Visible = false;
            }

            selectedCarServiceId = -1;
            textBoxMileage.Text = "";
        }

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            if (comboBoxCar.SelectedValue == null ||
                comboBoxService.SelectedValue == null ||
                string.IsNullOrWhiteSpace(textBoxMileage.Text))
            {
                MessageBox.Show("Täida kõik väljad!");
                return;
            }

            if (!int.TryParse(textBoxMileage.Text, out int mileage))
            {
                MessageBox.Show("Läbisõit peab olema number!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO CarServices (CarId, ServiceId, DateOfService, Mileage)
                                 VALUES (@CarId, @ServiceId, @Date, @Mileage)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CarId", comboBoxCar.SelectedValue);
                cmd.Parameters.AddWithValue("@ServiceId", comboBoxService.SelectedValue);
                cmd.Parameters.AddWithValue("@Date", dateTimePickerServiceDate.Value.Date);
                cmd.Parameters.AddWithValue("@Mileage", mileage);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadCarServices();
            LoadCarServicesForPayment();
            MessageBox.Show("Teenuse kirje lisatud!");
        }

        private void dataGridViewCarServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewCarServices.Rows[e.RowIndex];

                selectedCarServiceId = Convert.ToInt32(row.Cells["Id"].Value);

                comboBoxCar.SelectedValue = Convert.ToInt32(row.Cells["CarId"].Value);
                comboBoxService.SelectedValue = Convert.ToInt32(row.Cells["ServiceId"].Value);
                dateTimePickerServiceDate.Value = Convert.ToDateTime(row.Cells["DateOfService"].Value);
                textBoxMileage.Text = row.Cells["Mileage"].Value.ToString();
            }
        }

        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            if (selectedCarServiceId == -1)
            {
                MessageBox.Show("Vali rida!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd =
                    new SqlCommand("DELETE FROM CarServices WHERE Id=@Id", con);

                cmd.Parameters.AddWithValue("@Id", selectedCarServiceId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadCarServices();
            LoadCarServicesForPayment();
            MessageBox.Show("Kustutatud!");
        }


        // ============================================================
        // TAB 2 – PAYMENTS CRUD + FILTER + PHONE
        // ============================================================

        private void LoadCarServicesForPayment()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = @"SELECT Id, 'ID ' + CAST(Id AS VARCHAR(10)) AS Name FROM CarServices";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxPaymentCarService.DataSource = dt;
                comboBoxPaymentCarService.DisplayMember = "Name";
                comboBoxPaymentCarService.ValueMember = "Id";
            }
        }

        private void LoadPayments()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string where = "";

                if (comboBoxPaymentFilter != null && comboBoxPaymentFilter.SelectedIndex >= 0)
                {
                    if (comboBoxPaymentFilter.SelectedIndex == 1)       // Makstud
                        where = "WHERE p.IsPaid = 1";
                    else if (comboBoxPaymentFilter.SelectedIndex == 2)  // Maksmata
                        where = "WHERE p.IsPaid = 0";
                }

                string sql = $@"
                    SELECT 
                        p.Id,
                        p.CarServiceId,
                        c.Brand + ' ' + c.Model AS Car,
                        o.FullName AS Owner,
                        o.Phone,
                        p.Amount,
                        p.IsPaid,
                        p.PaymentDate
                    FROM Payments p
                    JOIN CarServices cs ON p.CarServiceId = cs.Id
                    JOIN Cars c ON cs.CarId = c.Id
                    JOIN Owners o ON c.OwnerId = o.Id
                    {where}";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewPayments.DataSource = dt;

                dataGridViewPayments.Columns["Id"].Visible = false;
                dataGridViewPayments.Columns["CarServiceId"].HeaderText = "Teenuse ID";
                dataGridViewPayments.Columns["Car"].HeaderText = "Auto";
                dataGridViewPayments.Columns["Owner"].HeaderText = "Omanik";
                dataGridViewPayments.Columns["Phone"].HeaderText = "Telefon";
                dataGridViewPayments.Columns["Amount"].HeaderText = "Summa";
                dataGridViewPayments.Columns["IsPaid"].HeaderText = "Makstud?";
                dataGridViewPayments.Columns["PaymentDate"].HeaderText = "Kuupäev";
            }
        }

        private void comboBoxPaymentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPayments();
        }

        private void buttonAddPayment_Click(object sender, EventArgs e)
        {
            if (comboBoxPaymentCarService.SelectedValue == null ||
                string.IsNullOrWhiteSpace(textBoxPaymentAmount.Text))
            {
                MessageBox.Show("Täida kõik väljad!");
                return;
            }

            if (!decimal.TryParse(textBoxPaymentAmount.Text, out decimal amount))
            {
                MessageBox.Show("Summa peab olema number!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO Payments
                    (CarServiceId, Amount, IsPaid, PaymentDate)
                    VALUES (@csId, @amount, @paid, @date)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@csId", comboBoxPaymentCarService.SelectedValue);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@paid", checkBoxPaymentPaid.Checked);
                cmd.Parameters.AddWithValue("@date", dateTimePickerPayment.Value.Date);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadPayments();
        }

        private void dataGridViewPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var r = dataGridViewPayments.Rows[e.RowIndex];

                selectedPaymentId = Convert.ToInt32(r.Cells["Id"].Value);

                comboBoxPaymentCarService.SelectedValue =
                    Convert.ToInt32(r.Cells["CarServiceId"].Value);

                textBoxPaymentAmount.Text =
                    r.Cells["Amount"].Value.ToString();

                checkBoxPaymentPaid.Checked =
                    Convert.ToBoolean(r.Cells["IsPaid"].Value);

                if (r.Cells["PaymentDate"].Value != DBNull.Value)
                    dateTimePickerPayment.Value =
                        Convert.ToDateTime(r.Cells["PaymentDate"].Value);
            }
        }

        private void buttonDeletePayment_Click(object sender, EventArgs e)
        {
            if (selectedPaymentId == -1)
            {
                MessageBox.Show("Vali makse!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd =
                    new SqlCommand("DELETE FROM Payments WHERE Id=@Id", con);

                cmd.Parameters.AddWithValue("@Id", selectedPaymentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadPayments();
        }


        // ============================================================
        // TAB 3 – BOOKINGS CRUD + PHONE
        // ============================================================

        private void LoadBookings()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT 
                        b.Id,
                        b.CarId,
                        c.Brand + ' ' + c.Model AS Car,
                        o.FullName AS Owner,
                        o.Phone,
                        b.ServiceId,
                        s.Name AS Service,
                        b.BookingDate,
                        b.IsCancelled
                    FROM ServiceBookings b
                    INNER JOIN Cars c ON b.CarId = c.Id
                    INNER JOIN Owners o ON c.OwnerId = o.Id
                    INNER JOIN Services s ON b.ServiceId = s.Id";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewBookings.DataSource = dt;

                dataGridViewBookings.Columns["Id"].Visible = false;
                dataGridViewBookings.Columns["CarId"].Visible = false;
                dataGridViewBookings.Columns["ServiceId"].Visible = false;

                dataGridViewBookings.Columns["Car"].HeaderText = "Auto";
                dataGridViewBookings.Columns["Owner"].HeaderText = "Omanik";
                dataGridViewBookings.Columns["Phone"].HeaderText = "Telefon";
                dataGridViewBookings.Columns["Service"].HeaderText = "Teenuse";
                dataGridViewBookings.Columns["BookingDate"].HeaderText = "Kuupäev";
                dataGridViewBookings.Columns["IsCancelled"].HeaderText = "Tühistatud";
            }
        }

        private void buttonAddBooking_Click(object sender, EventArgs e)
        {
            if (comboBoxBookingCar.SelectedValue == null ||
                comboBoxBookingService.SelectedValue == null)
            {
                MessageBox.Show("Täida väljad!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO ServiceBookings
                    (CarId, ServiceId, BookingDate, IsCancelled)
                    VALUES (@car, @serv, @dt, @cancel)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@car", comboBoxBookingCar.SelectedValue);
                cmd.Parameters.AddWithValue("@serv", comboBoxBookingService.SelectedValue);
                cmd.Parameters.AddWithValue("@dt", dateTimePickerBooking.Value);
                cmd.Parameters.AddWithValue("@cancel", false);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadBookings();
        }

        private void dataGridViewBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewBookings.Rows[e.RowIndex];

                selectedBookingId = Convert.ToInt32(row.Cells["Id"].Value);
                comboBoxBookingCar.SelectedValue = Convert.ToInt32(row.Cells["CarId"].Value);
                comboBoxBookingService.SelectedValue = Convert.ToInt32(row.Cells["ServiceId"].Value);
                dateTimePickerBooking.Value = Convert.ToDateTime(row.Cells["BookingDate"].Value);
                checkBoxBookingCancelled.Checked = Convert.ToBoolean(row.Cells["IsCancelled"].Value);
            }
        }

        private void buttonCancelBooking_Click(object sender, EventArgs e)
        {
            if (selectedBookingId == -1)
            {
                MessageBox.Show("Vali broneering!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE ServiceBookings
                               SET IsCancelled = 1
                               WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Id", selectedBookingId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadBookings();
        }

        // NAVIGATION BUTTONS
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
