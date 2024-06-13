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

    public partial class MainDashboard : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["GymManagementSystemDb"].ConnectionString;

        public MainDashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            countMembers();
        }

        private void attendenceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            addToolStripMenuItem_Click(sender,e);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            viewMembersToolStripMenuItem_Click_1(sender, e);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMembersForm form = new AddMembersForm();
            form.ShowDialog();
            countMembers();
        }
        private void viewMembersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GymMembersForms form = new GymMembersForms();
            form.ShowDialog();
            countMembers();
        }
        public void countMembers()
        {
            int totalMembers = Execute_Count("select * from members where membershipStatus != 'Expired'");
            int ActiveMembers = Execute_Count("select * from members where membershipStatus = 'Active'");
            int trainers = Execute_Count("select * from staff");

            if (totalMembers < 10)
            {
                label5.Text = "0" + totalMembers.ToString();
            }
            else
                label5.Text = totalMembers.ToString();
            if (ActiveMembers < 10)
            {
                label4.Text = "0" + ActiveMembers.ToString();
            }
            else
                label4.Text = ActiveMembers.ToString();
            if (trainers < 10)
            {
                label6.Text = "0" + trainers.ToString();
            }
            else
                label6.Text = trainers.ToString();
        }
  
        private int Execute_Count(string query)
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
                            return table.Rows.Count;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        
    }
}
