using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AutodjaOmanikud
{
    public partial class Form1 : Form
    {
        string connectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=AutoServiceDB;Trusted_Connection=True;";

        private int selectedOwnerId = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadOwners();
        }

        private void LoadOwners()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Täida DataTable kohe
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, FullName, Phone FROM Owners", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // Kustuta valitud rida ja tühjenda tekstikastid
                selectedOwnerId = -1;
                textBox1.Text = "";
                textBox2.Text = "";
            }

            // Muuda DataGridView veerud veidi ilusamaks
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }


        private void button1_Click(object sender, EventArgs e)  // Lisa
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Owners (FullName, Phone) VALUES (@FullName, @Phone)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FullName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox2.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadOwners();
            MessageBox.Show("Omanik lisatud!");
        }

        private void button2_Click_1(object sender, EventArgs e) // Kustuta
        {
            if (selectedOwnerId == -1)
            {
                MessageBox.Show("Vali rida, mida kustutada!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Owners WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", selectedOwnerId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadOwners();
            MessageBox.Show("Omanik kustutatud!");
        }

        private void button3_Click(object sender, EventArgs e) // Uuenda
        {
            if (selectedOwnerId == -1)
            {
                MessageBox.Show("Vali rida, mida uuendada!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Owners SET FullName=@FullName, Phone=@Phone WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FullName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox2.Text);
                cmd.Parameters.AddWithValue("@Id", selectedOwnerId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadOwners();
            MessageBox.Show("Andmed uuendatud!");
        }

        private void textBoxSearchName_TextChanged(object sender, EventArgs e)  // Otsing nime järgi
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, FullName, Phone FROM Owners WHERE FullName LIKE @search", con);

                da.SelectCommand.Parameters.AddWithValue("@search", "%" + textBoxSearchName.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            selectedOwnerId = -1;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBoxSearchPhone_TextChanged(object sender, EventArgs e)  // Otsing telefoni järgi
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, FullName, Phone FROM Owners WHERE Phone LIKE @search", con);

                da.SelectCommand.Parameters.AddWithValue("@search", "%" + textBoxSearchPhone.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

            selectedOwnerId = -1;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // Valitud rea laadimine
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["FullName"]?.Value?.ToString() ?? "";
                textBox2.Text = row.Cells["Phone"]?.Value?.ToString() ?? "";

                selectedOwnerId = Convert.ToInt32(row.Cells["Id"].Value);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
