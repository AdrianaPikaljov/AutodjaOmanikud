using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AutodjaOmanikud
{
    public partial class Form2 : Form
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=AutoServiceDB;Trusted_Connection=True;";
        private int selectedCarId = -1;

        public Form2()
        {
            InitializeComponent();
            this.Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                LoadOwners();
                LoadCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Viga laadimisel: " + ex.Message);
            }
        }

        private void LoadCars(string searchTerm = "")
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Cars.Id, Cars.Brand, Cars.Model, Cars.RegistrationNumber, Owners.FullName AS Owner " +
                               "FROM Cars INNER JOIN Owners ON Cars.OwnerId = Owners.Id";

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " WHERE Cars.Brand LIKE @Search OR Cars.Model LIKE @Search OR Cars.RegistrationNumber LIKE @Search OR Owners.FullName LIKE @Search";
                }

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    da.SelectCommand.Parameters.AddWithValue("@Search", "%" + searchTerm + "%");
                }

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
            }

            selectedCarId = -1;
            textBoxBrand.Text = "";
            textBoxModel.Text = "";
            textBoxRegistrationNumber.Text = "";
        }

        private void LoadOwners()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, FullName FROM Owners", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxOwner.DataSource = dt;
                comboBoxOwner.DisplayMember = "FullName";
                comboBoxOwner.ValueMember = "Id";
                comboBoxOwner.SelectedIndex = -1;
            }
        }

        private void buttonAddCar_Click(object sender, EventArgs e)
        {
            if (comboBoxOwner.SelectedValue == null)
            {
                MessageBox.Show("Palun vali omanik!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Cars (Brand, Model, RegistrationNumber, OwnerId) VALUES (@Brand, @Model, @RegNumber, @OwnerId)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Brand", textBoxBrand.Text);
                cmd.Parameters.AddWithValue("@Model", textBoxModel.Text);
                cmd.Parameters.AddWithValue("@RegNumber", textBoxRegistrationNumber.Text);
                cmd.Parameters.AddWithValue("@OwnerId", comboBoxOwner.SelectedValue);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadCars();
            MessageBox.Show("Auto lisatud!");
        }

        private void buttonDeleteCar_Click(object sender, EventArgs e)
        {
            if (selectedCarId == -1)
            {
                MessageBox.Show("Vali auto, mida kustutada!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Cars WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", selectedCarId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadCars();
            MessageBox.Show("Auto kustutatud!");
        }

        private void buttonUpdateCar_Click(object sender, EventArgs e)
        {
            if (selectedCarId == -1)
            {
                MessageBox.Show("Vali auto, mida uuendada!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Cars SET Brand=@Brand, Model=@Model, RegistrationNumber=@RegNumber, OwnerId=@OwnerId WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Brand", textBoxBrand.Text);
                cmd.Parameters.AddWithValue("@Model", textBoxModel.Text);
                cmd.Parameters.AddWithValue("@RegNumber", textBoxRegistrationNumber.Text);
                cmd.Parameters.AddWithValue("@OwnerId", comboBoxOwner.SelectedValue);
                cmd.Parameters.AddWithValue("@Id", selectedCarId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadCars();
            MessageBox.Show("Auto andmed uuendatud!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBoxBrand.Text = row.Cells["Brand"].Value.ToString();
                textBoxModel.Text = row.Cells["Model"].Value.ToString();
                textBoxRegistrationNumber.Text = row.Cells["RegistrationNumber"].Value.ToString();
                selectedCarId = Convert.ToInt32(row.Cells["Id"].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        // Otsingu TextBox sündmus
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCars(textBoxSearch.Text);
        }
    }
}
