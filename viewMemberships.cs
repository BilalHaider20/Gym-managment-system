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
    public partial class viewMemberships : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["GymManagementSystemDb"].ConnectionString;

        public viewMemberships()
        {
            InitializeComponent();
        }

        private void GymMembersForms_Load(object sender, EventArgs e)
        {
            LoadTrainersData();
        }

        private void LoadTrainersData()
        {
            dataGridView1.DataSource = ExecuteQuery("select MembershipTypeID as ID, TypeName as Membership, Description, DurationMonths as 'Duration (months)', Price as 'Price (PKR)' from membershipTypes;");
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
    }
}
