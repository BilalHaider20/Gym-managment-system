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
    public partial class viewTrainersForm: Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["GymManagementSystemDb"].ConnectionString;

        public viewTrainersForm()
        {
            InitializeComponent();
        }

        private void GymMembersForms_Load(object sender, EventArgs e)
        {
            LoadTrainersData();
            AddButtonColumns();
        }

        private void LoadTrainersData()
        {
            dataGridView1.DataSource = ExecuteQuery("select staffID as ID, staff_Name as Name, Phone, Position from staff;");
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
                    int staffID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                    EditTrainer(staffID);
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    int staffID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                    DeleteTrainer(staffID);
                }
            }
        }

        private void EditTrainer(int staffId)
        {
            AddTrainer editForm = new AddTrainer(staffId);
            editForm.ShowDialog();
            LoadTrainersData();
            colorizeButtons();
        }

        private void DeleteTrainer(int staffID)
        {
            string checkMembersQuery = "SELECT COUNT(*) FROM members WHERE TrainerID = @staffID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand checkMembersCmd = new SqlCommand(checkMembersQuery, con))
                {
                    checkMembersCmd.Parameters.AddWithValue("@staffID", staffID);
                    int memberCount = (int)checkMembersCmd.ExecuteScalar();

                    if (memberCount > 0)
                    {
                        MessageBox.Show($"Trainer cannot be deleted because they are currently associated with {memberCount} members.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                var result = MessageBox.Show("Are you sure you want to delete this Trainer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string del_query = "DELETE FROM staff WHERE staffID = @staffID";

                    using (SqlCommand cmd = new SqlCommand(del_query, con))
                    {
                        cmd.Parameters.AddWithValue("@staffID", staffID);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Trainer deleted successfully.");
                            LoadTrainersData();
                            colorizeButtons();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting trainer: " + ex.Message);
                        }
                    }
                }
            }
        }

    }
}
