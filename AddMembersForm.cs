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
    public partial class AddMembersForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["GymManagementSystemDb"].ConnectionString;
        private int? memberIdToEdit = null;

        public AddMembersForm()
        {
            InitializeComponent();
            trainers.Items.Add(new ComboBoxItem("None", "0"));
            LoadTrainers();
            LoadMembershipTypes();
            statusDropDown.Visible = false;
            label11.Visible = false;
            if(MembershipType.Items.Count > 0)
                MembershipType.SelectedIndex = 0;
            if(trainers.Items.Count > 0)
                trainers.SelectedIndex = 0;
        }

        public AddMembersForm(int memberID)
        {
            InitializeComponent();
            memberIdToEdit = memberID;
            trainers.Items.Add(new ComboBoxItem("None", "0"));
            LoadTrainers();
            LoadMembershipTypes();
            loadMemberData(memberID);
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
           
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

        private void loadMemberData(int memberID)
        {
            string query = "SELECT * FROM members WHERE memberID = @memberID";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@memberID", memberID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBox1.Text = reader["memberName"].ToString();
                            DateTime dob = Convert.ToDateTime(reader["DateOfBirth"]);
                            dateTimePicker1.Value = dob;
                            statusDropDown.Text = reader["membershipStatus"].ToString();

                            string gender = reader["Gender"].ToString();
                            if (gender == "Male")
                                radioButton1.Checked = true;
                            else if (gender == "Female")
                                radioButton2.Checked = true;

                            textBox3.Text = reader["Phone"].ToString();

                            int membershipTypeID = Convert.ToInt32(reader["membershipTypeID"]);
                            foreach (ComboBoxItem item in MembershipType.Items)
                            {
                                if (item.Value == membershipTypeID)
                                {
                                    MembershipType.SelectedItem = item;
                                    break;
                                }
                            }

                            if (reader["trainerID"] != DBNull.Value)
                            {
                                int trainerID = Convert.ToInt32(reader["trainerID"]);
                                    foreach (ComboBoxItem item in trainers.Items)
                                    {
                                        if (item.Value == trainerID)
                                        {
                                            trainers.SelectedItem = item;
                                            break;
                                        }
                                    }
                            }
                            else
                                if(trainers.Items.Count > 0)
                                    trainers.SelectedIndex = 0;
                        }
                    }
                }
            }
            button1.Text = "Update Member";
            label1.Text = "Edit Member";
            button1.Click -= button1_Click;
            button1.Click += new EventHandler(UpdateMemberButton_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || (radioButton1.Checked==false && radioButton2.Checked==false) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please fill required fields before proceding.");
            }
            else if (!IsOver18(dateTimePicker1.Value))
            {
                MessageBox.Show("Underage for Gym Membership.\nAge requirement: 18 years (minimum)");
            }
            else if (MembershipType.Items.Count == 0)
            {
                MessageBox.Show("Membership not selected");
            }
            else
                AddMember();
        }

        private bool IsOver18(DateTime birthDate)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthDate.Year;
            if (birthDate > now.AddYears(-age)) age--;

            return age >= 18;
        }
        private void UpdateMemberButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please fill required fields before proceding.");
            }
            else if (!IsOver18(dateTimePicker1.Value))
            {
                MessageBox.Show("Underage for Gym Membership.\nAge requirement: 18 years (minimum)");
            }
            else if (MembershipType.Items.Count == 0)
            {
                MessageBox.Show("Membership not selected");
            }
            else
                UpdateMember();
        }

        private void AddMember()
        {
            string name = textBox1.Text;
            string gender = "";
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
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding member: " + ex.Message);
                    }
                }
            }
        }

        private void UpdateMember()
        {
            string name = textBox1.Text;
            string gender = "";
            string status = statusDropDown.Text;
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
            string query = "UPDATE members SET memberName = @name, DateOfBirth = @dateOfBirth, Gender = @gender, Phone = @phone, membershipTypeID = @membershipTypeID, trainerID = @trainerID, MembershipStatus=@status WHERE memberID = @memberID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@memberID", memberIdToEdit);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@membershipTypeID", membershipTypeID);
                    cmd.Parameters.AddWithValue("@trainerID", (object)trainerID ?? DBNull.Value);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Member updated successfully.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating member: " + ex.Message);
                    }
                }
            }
        }
        

        private DataTable ExecuteQuery(string query)
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
            string query = "SELECT membershipTypeID, DurationMonths FROM membershipTypes";
            DataTable table12 = ExecuteQuery(query);
            foreach (DataRow row in table12.Rows)
            {
                if (row["membershipTypeID"].ToString() == membershipTypeID)
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
