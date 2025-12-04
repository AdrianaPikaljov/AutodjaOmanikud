using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace AutodjaOmanikud
{
    public partial class Form3 : Form
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=AutoServiceDB;Trusted_Connection=True;";
        private int selectedServiceId = -1;
        private int selectedCarId = -1;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadServices(); // Laadige teenused
            LoadCars(); // Laadige autod
            LoadCarServices(); // Laadige teenuste ajalugu
        }

        private void LoadServices()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Name, Price FROM Services", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxService.DataSource = dt;
                comboBoxService.DisplayMember = "Name";
                comboBoxService.ValueMember = "Id";
            }
        }

        private void LoadCars()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, RegistrationNumber FROM Cars", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxCar.DataSource = dt;
                comboBoxCar.DisplayMember = "RegistrationNumber";
                comboBoxCar.ValueMember = "Id";
            }
        }

        private void LoadCarServices()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        cs.CarId, 
                        c.RegistrationNumber AS [Registreerimisnumber], 
                        s.Name AS [Teenus], 
                        cs.ServiceId, 
                        cs.DateOfService AS [Teenus kuupäev], 
                        cs.Mileage AS [Läbisõit]
                    FROM CarServices cs
                    INNER JOIN Cars c ON cs.CarId = c.Id
                    INNER JOIN Services s ON cs.ServiceId = s.Id
                    ORDER BY cs.DateOfService DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        // Teenuse lisamise funktsioon
        private void buttonAddService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxServiceName.Text) || numericUpDownPrice.Value <= 0)
            {
                MessageBox.Show("Palun sisesta teenuse nimi ja hind!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Services (Name, Price) VALUES (@Name, @Price)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", textBoxServiceName.Text);
                cmd.Parameters.AddWithValue("@Price", numericUpDownPrice.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadServices(); // Laadige teenused uuesti
            MessageBox.Show("Teenus lisatud!");
        }

        // Auto teenuse lisamise funktsioon
        private void buttonAddCarService_Click(object sender, EventArgs e)
        {
            if (selectedCarId == -1 || selectedServiceId == -1)
            {
                MessageBox.Show("Palun vali auto ja teenus!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO CarServices (CarId, ServiceId, DateOfService, Mileage) VALUES (@CarId, @ServiceId, @DateOfService, @Mileage)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CarId", selectedCarId);
                cmd.Parameters.AddWithValue("@ServiceId", selectedServiceId);
                cmd.Parameters.AddWithValue("@DateOfService", dateTimePickerServiceDate.Value);
                cmd.Parameters.AddWithValue("@Mileage", numericUpDownMileage.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadCarServices(); // Laadige teenuste ajalugu uuesti
            MessageBox.Show("Teenus lisatud autole!");
        }

        // Teenuse kustutamise funktsioon
        private void buttonDeleteService_Click(object sender, EventArgs e)
        {
            if (selectedServiceId == -1)
            {
                MessageBox.Show("Vali teenus, mida kustutada!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Services WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", selectedServiceId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadServices(); // Laadige teenused uuesti
            LoadCarServices(); // Laadige teenuste ajalugu uuesti
            MessageBox.Show("Teenus kustutatud!");
        }

        // ComboBoxi muudatused teenuse ja auto valimiseks
        // ComboBoxi muudatused teenuse ja auto valimiseks
        private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxService.SelectedValue != null)
            {
                // Kontrollime, kas valitud teenus on õige tüübiga
                selectedServiceId = Convert.ToInt32(comboBoxService.SelectedValue);
            }
        }

        private void comboBoxCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCar.SelectedValue != null)
            {
                // Kontrollime, kas valitud auto on õige tüübiga
                selectedCarId = Convert.ToInt32(comboBoxCar.SelectedValue);
            }
        }


        // DataGridView ridade valimine
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                selectedCarId = Convert.ToInt32(row.Cells["CarId"].Value);
                selectedServiceId = Convert.ToInt32(row.Cells["ServiceId"].Value);
            }
        }
    }
}
