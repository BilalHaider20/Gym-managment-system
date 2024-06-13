using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Manager
{
    public partial class AddTrainer : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["GymManagementSystemDb"].ConnectionString;
        private int? trainerIdToEdit = null;

        public AddTrainer()
        {
            InitializeComponent();
        }

        public AddTrainer(int trainerID)
        {
            InitializeComponent();
            loadTrainerData(trainerID);
            trainerIdToEdit = trainerID;
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {

        }

        private void loadTrainerData(int trainerID)
        {
            string query = "SELECT * FROM staff WHERE StaffID = @trainerID";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@trainerID", trainerID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox1.Text = reader["Staff_Name"].ToString();
                            textBox3.Text = reader["Phone"].ToString();
                            textBox2.Text = reader["Position"].ToString();

                        }
                    }
                }
            }
            button1.Text = "Update Trainer";
            label1.Text = "Edit Trainer";
            button1.Click -= button1_Click;
            button1.Click += new EventHandler(UpdateTrainerButton_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) ||  string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please fill required fields before proceding.");
            }
            else
                AddTrainertoDB();
        }
        private void UpdateTrainerButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please fill required fields before proceding.");
            }
            else
                UpdateTrainer();
        }

        private void AddTrainertoDB()
        {
            string name = textBox1.Text;
            string phone = textBox3.Text;
            string position = textBox2.Text;

            string query = "INSERT INTO staff (Staff_Name, Phone, Position) " +
                    "VALUES (@name, @phone, @position)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@position", position);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Trainer added successfully.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding trainer: " + ex.Message);
                    }
                }
            }
        }

        private void UpdateTrainer()
        {
            string name = textBox1.Text;
            string phone = textBox3.Text;
            string position = textBox2.Text;
            
            string query = "UPDATE staff SET staff_Name = @name, Phone = @phone, Position=@position WHERE staffID = @staffID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@staffID", trainerIdToEdit);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@position", position);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Trainer updated successfully.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating trainer: " + ex.Message);
                    }
                }
            }
        }
    }
}
