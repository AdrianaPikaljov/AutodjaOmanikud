using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AutodjaOmanikud
{
    public partial class Form3 : Form
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=AutoServiceDB;Trusted_Connection=True;";
        private int selectedCarId = -1;
        private int selectedServiceId = -1;
        private DateTime selectedServiceDate;

        public Form3()
        {
            InitializeComponent();
            this.Load += Form3_Load;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadCars();
            LoadServices();
            LoadCarServices();
        }

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
                comboBoxCar.SelectedIndex = -1;
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
                comboBoxService.SelectedIndex = -1;
            }
        }

        private void LoadCarServices()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT cs.CarId, c.Brand + ' ' + c.Model AS Car, 
                                        cs.ServiceId, s.Name AS Service,
                                        cs.DateOfService, cs.Mileage
                                 FROM CarServices cs
                                 INNER JOIN Cars c ON cs.CarId = c.Id
                                 INNER JOIN Services s ON cs.ServiceId = s.Id";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewCarServices.DataSource = dt;

                // Näita veerunimesid selgelt
                dataGridViewCarServices.Columns["CarId"].Visible = false;
                dataGridViewCarServices.Columns["ServiceId"].Visible = false;
                dataGridViewCarServices.Columns["Car"].HeaderText = "Auto";
                dataGridViewCarServices.Columns["Service"].HeaderText = "Teenuse nimi";
                dataGridViewCarServices.Columns["DateOfService"].HeaderText = "Kuupäev";
                dataGridViewCarServices.Columns["Mileage"].HeaderText = "Läbisõit km";
            }

            selectedCarId = -1;
            selectedServiceId = -1;
            textBoxMileage.Text = "";
        }

        private void buttonAddService_Click(object sender, EventArgs e)
        {
            if (comboBoxCar.SelectedValue == null || comboBoxService.SelectedValue == null || string.IsNullOrWhiteSpace(textBoxMileage.Text))
            {
                MessageBox.Show("Täida kõik väljad!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO CarServices (CarId, ServiceId, DateOfService, Mileage)
                                 VALUES (@CarId, @ServiceId, @DateOfService, @Mileage)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CarId", comboBoxCar.SelectedValue);
                cmd.Parameters.AddWithValue("@ServiceId", comboBoxService.SelectedValue);
                cmd.Parameters.AddWithValue("@DateOfService", dateTimePickerServiceDate.Value.Date);
                cmd.Parameters.AddWithValue("@Mileage", int.Parse(textBoxMileage.Text));

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Teenuse kirje lisatud!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Viga lisamisel: " + ex.Message);
                }
            }

            LoadCarServices();
        }

        private void dataGridViewCarServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewCarServices.Rows[e.RowIndex];

                selectedCarId = Convert.ToInt32(row.Cells["CarId"].Value);
                selectedServiceId = Convert.ToInt32(row.Cells["ServiceId"].Value);
                selectedServiceDate = Convert.ToDateTime(row.Cells["DateOfService"].Value);

                comboBoxCar.SelectedValue = selectedCarId;
                comboBoxService.SelectedValue = selectedServiceId;
                dateTimePickerServiceDate.Value = selectedServiceDate;
                textBoxMileage.Text = row.Cells["Mileage"].Value.ToString();
            }
        }

        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            if (selectedCarId == -1 || selectedServiceId == -1)
            {
                MessageBox.Show("Vali teenuse kirje, mida kustutada!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM CarServices 
                                 WHERE CarId=@CarId AND ServiceId=@ServiceId AND DateOfService=@DateOfService";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CarId", selectedCarId);
                cmd.Parameters.AddWithValue("@ServiceId", selectedServiceId);
                cmd.Parameters.AddWithValue("@DateOfService", selectedServiceDate);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadCarServices();
            MessageBox.Show("Teenuse kirje kustutatud!");
        }




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
