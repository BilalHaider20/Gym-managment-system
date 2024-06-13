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
    public partial class GymMembersForms : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["GymManagementSystemDb"].ConnectionString;

        public GymMembersForms()
        {
            InitializeComponent();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Active")
            {
                dataGridView1.DataSource = ExecuteQuery("SELECT  a.MemberID AS ID, a.MemberName AS Name, DATEDIFF(year, a.DateOfBirth, GETDATE()) AS Age, a.Gender, a.Phone as 'Contact No.', c.staff_name AS 'Trainer Name', d.TypeName AS 'Membership Type', d.DurationMonths as 'Duration (months)', FORMAT(a.MembershipStartDate, 'dd/MM/yyyy') as 'Membership Start Date',   FORMAT(a.MembershipEndDate, 'dd/MM/yyyy') as 'Membership End Date', a.membershipStatus as 'Status' FROM    members a LEFT JOIN   staff c ON a.trainerID = c.staffID JOIN   membershipTypes d ON a.membershipTypeID = d.membershipTypeID where a.membershipStatus = 'Active';");
            } 
            else if(comboBox1.Text == "Terminated")
            {
                dataGridView1.DataSource = ExecuteQuery("SELECT  a.MemberID AS ID, a.MemberName AS Name, DATEDIFF(year, a.DateOfBirth, GETDATE()) AS Age, a.Gender, a.Phone as 'Contact No.', c.staff_name AS 'Trainer Name', d.TypeName AS 'Membership Type', d.DurationMonths as 'Duration (months)', FORMAT(a.MembershipStartDate, 'dd/MM/yyyy') as 'Membership Start Date',   FORMAT(a.MembershipEndDate, 'dd/MM/yyyy') as 'Membership End Date', a.membershipStatus as 'Status' FROM    members a LEFT JOIN   staff c ON a.trainerID = c.staffID JOIN   membershipTypes d ON a.membershipTypeID = d.membershipTypeID where a.membershipStatus = 'Terminated';");
            } 
            else if(comboBox1.Text == "Expired Memberships")
            {
                dataGridView1.DataSource = ExecuteQuery("SELECT  a.MemberID AS ID, a.MemberName AS Name, DATEDIFF(year, a.DateOfBirth, GETDATE()) AS Age, a.Gender, a.Phone as 'Contact No.', c.staff_name AS 'Trainer Name', d.TypeName AS 'Membership Type', d.DurationMonths as 'Duration (months)', FORMAT(a.MembershipStartDate, 'dd/MM/yyyy') as 'Membership Start Date',   FORMAT(a.MembershipEndDate, 'dd/MM/yyyy') as 'Membership End Date', a.membershipStatus as 'Status' FROM    members a LEFT JOIN   staff c ON a.trainerID = c.staffID JOIN   membershipTypes d ON a.membershipTypeID = d.membershipTypeID where a.membershipStatus = 'Expired';");
            }
            else {
                dataGridView1.DataSource = ExecuteQuery("SELECT  a.MemberID AS ID, a.MemberName AS Name, DATEDIFF(year, a.DateOfBirth, GETDATE()) AS Age, a.Gender, a.Phone as 'Contact No.', c.staff_name AS 'Trainer Name', d.TypeName AS 'Membership Type', d.DurationMonths as 'Duration (months)', FORMAT(a.MembershipStartDate, 'dd/MM/yyyy') as 'Membership Start Date',   FORMAT(a.MembershipEndDate, 'dd/MM/yyyy') as 'Membership End Date', a.membershipStatus as 'Status' FROM    members a LEFT JOIN   staff c ON a.trainerID = c.staffID JOIN   membershipTypes d ON a.membershipTypeID = d.membershipTypeID;") ;
            }
        }

        private void GymMembersForms_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ExecuteQuery("SELECT  a.MemberID AS ID, a.MemberName AS Name, DATEDIFF(year, a.DateOfBirth, GETDATE()) AS Age, a.Gender, a.Phone as 'Contact No.', c.staff_name AS 'Trainer Name', d.TypeName AS 'Membership Type', d.DurationMonths as 'Duration (months)', FORMAT(a.MembershipStartDate, 'dd/MM/yyyy') as 'Membership Start Date',   FORMAT(a.MembershipEndDate, 'dd/MM/yyyy') as 'Membership End Date', a.membershipStatus as 'Status' FROM    members a LEFT JOIN   staff c ON a.trainerID = c.staffID JOIN   membershipTypes d ON a.membershipTypeID = d.membershipTypeID;");
        }
    }

}
