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
    public partial class MembersForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["GymManagementSystemDb"].ConnectionString;

        public MembersForm()
        {
            InitializeComponent();
            trainers.Items.Add(new ComboBoxItem("None","0"));
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            LoadTrainers();
            LoadMembershipTypes();
        }

        private void LoadTrainers()
        {
            string query = "SELECT staffID, staff_name, position FROM staff";
            DataTable trainersTable = ExecuteQuery(query);
            foreach (DataRow row in trainersTable.Rows)
            {
                string display_name = (row["staff_name"].ToString() + " (" + row["position"].ToString() + ")");
                trainers.Items.Add(new ComboBoxItem(display_name, row["staffID"].ToString()));
            }
        }

        private void LoadMembershipTypes()
        {
            string query = "SELECT membershipTypeID, TypeName FROM membershipTypes";
            DataTable membershipTypesTable = ExecuteQuery(query);
            foreach (DataRow row in membershipTypesTable.Rows)
            {
                MembershipType.Items.Add(new ComboBoxItem(row["TypeName"].ToString(), row["membershipTypeID"].ToString()));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMember();
        }

        private void AddMember()
        {
            string name = textBox1.Text;
            string gender="";
            if (radioButton1.Checked)
            {
                gender = "Male";
            }
            else if (radioButton2.Checked)
            {
                gender = "Female";
            }
            string phone = textBox3.Text;
            DateTime dateOfBirth = dateTimePicker1.Value;
            int membershipTypeID = (MembershipType.SelectedItem as ComboBoxItem).Value;
            int? trainerID = (trainers.SelectedItem as ComboBoxItem)?.Value;
            if (trainerID == 0)
            {
                trainerID = null;
            }
            int duration = int.Parse(label9.Text);
            string status = "Active";

            string query = "INSERT INTO members (memberName, DateOfBirth, Gender, Phone, membershipTypeID, trainerID, membershipStartDate, membershipEndDate, MembershipStatus) " +
                    "VALUES (@name, @dateOfBirth, @gender, @phone, @membershipTypeID, @trainerID, getdate(), DATEADD(month, @duration, getdate()), @status)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@membershipTypeID", membershipTypeID);
                    cmd.Parameters.AddWithValue("@trainerID", (object)trainerID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@duration", duration);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Member added successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding member: " + ex.Message);
                    }
                }
            }
            
        }

        public DataTable ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable table = new DataTable();
                            table.Load(reader);
                            return table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void MembershipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string membershipTypeID = (MembershipType.SelectedItem as ComboBoxItem).Value.ToString();
            string query = "SELECT membershipTypeID, DurationMonths from membershipTypes";
            DataTable table12 = ExecuteQuery(query);
            foreach (DataRow row in table12.Rows)
            {
                if (row["membershipTypeID"].ToString()==membershipTypeID)
                    label9.Text = row["DurationMonths"].ToString();
            }
        }
    }

    public class ComboBoxItem
    {
        public string Display { get; set; }
        public int Value { get; set; }

        public ComboBoxItem(string display, string value)
        {
            Display = display;
            Value = int.Parse(value);
        }

        public override string ToString()
        {
            return Display;
        }
    }
}
