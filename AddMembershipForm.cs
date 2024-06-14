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
    public partial class AddMembership : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["GymManagementSystemDb"].ConnectionString;
        private int? IdToEdit = null;

        public AddMembership()
        {
            InitializeComponent();
        }

        public AddMembership(int membershipID)
        {
            InitializeComponent();
            loadMembershipData(membershipID);
            IdToEdit = membershipID;
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {

        }

        private void loadMembershipData(int membershipID)
        {
            string query = "SELECT * FROM MembershipTypes WHERE MembershipTypeID = @membershipID";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@membershipID", membershipID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox1.Text = reader["TypeName"].ToString();
                            textBox3.Text = reader["Description"].ToString();
                            textBox2.Text = reader["DurationMonths"].ToString();
                            textBox4.Text = reader["Price"].ToString();
                        }
                    }
                }
            }
            button1.Text = "Update Membership";
            label1.Text = "Edit Membership";
            button1.Click -= button1_Click;
            button1.Click += new EventHandler(UpdateMembershipButton_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please fill required fields before proceding.");
            }
            else
                AddMembershiptoDB();
        }
        private void UpdateMembershipButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please fill required fields before proceding.");
            }
            else
                UpdateMembership();
        }

        private void AddMembershiptoDB()
        {
            string name = textBox1.Text;
            string description = textBox3.Text;
            int duration = int.Parse(textBox2.Text);
            decimal price = decimal.Parse(textBox4.Text);

            string query = "INSERT INTO MembershipTypes (TypeName, Description, DurationMonths, Price) " +
                    "VALUES (@name, @description, @duration, @price)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Parameters.AddWithValue("@price", price);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Membership added successfully.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding membership: " + ex.Message);
                    }
                }
            }
        }

        private void UpdateMembership()
        {
            string name = textBox1.Text;
            string description = textBox3.Text;
            int duration = int.Parse(textBox2.Text);
            decimal price = decimal.Parse(textBox4.Text);

            string query = "UPDATE MembershipTypes SET TypeName = @name, Description = @description, DurationMonths=@duration, Price=@price WHERE MembershipTypeID = @membershipID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@membershipID", IdToEdit);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Parameters.AddWithValue("@price", price);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Membership updated successfully.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating membership: " + ex.Message);
                    }
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; 
                return;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
