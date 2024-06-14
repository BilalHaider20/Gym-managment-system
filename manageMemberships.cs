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
    public partial class manageMemberships : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["GymManagementSystemDb"].ConnectionString;

        public manageMemberships()
        {
            InitializeComponent();
        }

        private void GymMembersForms_Load(object sender, EventArgs e)
        {
            LoadMembershipsData();
            AddButtonColumns();
        }

        private void LoadMembershipsData()
        {
            dataGridView1.DataSource = ExecuteQuery("select MembershipTypeID as ID, TypeName as Membership, Description, DurationMonths as 'Duration (months)', Price from membershipTypes;");
        }

        private void AddButtonColumns()
        {
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "Edit";
            editButtonColumn.Text = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;
            editButtonColumn.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            deleteButtonColumn.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(deleteButtonColumn);
            colorizeButtons();
        }
        private void colorizeButtons()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["Edit"].Style.BackColor = Color.DarkGreen;
                row.Cells["Edit"].Style.ForeColor = Color.White;
                row.Cells["Delete"].Style.BackColor = Color.DarkRed;
                row.Cells["Delete"].Style.ForeColor = Color.White;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    int membershipID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                    EditMembership(membershipID);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    int membershipID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                    DeleteMembership(membershipID);
                }
            }
        }

        private void EditMembership(int membershipID)
        {
            AddMembership editForm = new AddMembership(membershipID);
            editForm.ShowDialog();
            LoadMembershipsData();
            colorizeButtons();
        }

        private void DeleteMembership(int membershipID)
        {
            string checkMembersQuery = "SELECT COUNT(*) FROM members WHERE MembershipTypeID = @membershipID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand checkMembersCmd = new SqlCommand(checkMembersQuery, con))
                {
                    checkMembersCmd.Parameters.AddWithValue("@membershipID", membershipID);
                    int memberCount = (int)checkMembersCmd.ExecuteScalar();

                    if (memberCount > 0)
                    {
                        MessageBox.Show($"Membership cannot be deleted because {memberCount} members have subscribed to it.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                var result = MessageBox.Show("Are you sure you want to delete this Membership?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string del_query = "DELETE FROM membershipTypes WHERE MembershipTypeID = @membershipID";

                    using (SqlCommand cmd = new SqlCommand(del_query, con))
                    {
                        cmd.Parameters.AddWithValue("@membershipID", membershipID);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Membership deleted successfully.");
                            LoadMembershipsData();
                            colorizeButtons();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting membership: " + ex.Message);
                        }
                    }
                }
            }
        }

    }
}
