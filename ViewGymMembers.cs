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
    public partial class ViewGymMembers : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["GymManagementSystemDb"].ConnectionString;

        public ViewGymMembers()
        {
            InitializeComponent();
        }

        private void GymMembersForms_Load(object sender, EventArgs e)
        {
            LoadMemberData();
            if(comboBox1.Items.Count>0)
                comboBox1.SelectedIndex = 0;
        }

        private void LoadMemberData()
        {
            dataGridView1.DataSource = ExecuteQuery("SELECT a.MemberID AS 'Member ID', a.MemberName AS Name, DATEDIFF(year, a.DateOfBirth, GETDATE()) AS Age, a.Gender, a.Phone AS 'Contact No.', c.staff_name AS 'Trainer Name', d.TypeName AS 'Membership Type', d.DurationMonths AS 'Duration (months)', FORMAT(a.MembershipStartDate, 'dd/MM/yyyy') AS 'Membership Start Date', FORMAT(a.MembershipEndDate, 'dd/MM/yyyy') AS 'Membership End Date', a.membershipStatus AS 'Status' FROM members a LEFT JOIN staff c ON a.trainerID = c.staffID JOIN membershipTypes d ON a.membershipTypeID = d.membershipTypeID;");
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
            string status = comboBox1.Text;
            string query = "SELECT a.MemberID AS 'Member ID', a.MemberName AS Name, DATEDIFF(year, a.DateOfBirth, GETDATE()) AS Age, a.Gender, a.Phone AS 'Contact No.', c.staff_name AS 'Trainer Name', d.TypeName AS 'Membership Type', d.DurationMonths AS 'Duration (months)', FORMAT(a.MembershipStartDate, 'dd/MM/yyyy') AS 'Membership Start Date', FORMAT(a.MembershipEndDate, 'dd/MM/yyyy') AS 'Membership End Date', a.membershipStatus AS 'Status' FROM members a LEFT JOIN staff c ON a.trainerID = c.staffID JOIN membershipTypes d ON a.membershipTypeID = d.membershipTypeID";

            if (status == "Active")
            {
                query += " WHERE a.membershipStatus = 'Active'";
            }
            else if (status == "Terminated")
            {
                query += " WHERE a.membershipStatus = 'Terminated'";
            }
            else if (status == "Expired Memberships")
            {
                query += " WHERE a.membershipStatus = 'Expired'";
            }

            dataGridView1.DataSource = ExecuteQuery(query);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    int memberId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    int memberId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                }
            }
        }    
    }
}
