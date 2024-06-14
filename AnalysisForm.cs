using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gym_Manager
{
    public partial class AnalysisForm : Form
    {
        string connectionString = "Server=DESKTOP-T14PAJA\\SQLEXPRESS;Database=Gym-Database;Integrated Security=True";
        
        public AnalysisForm()
        {
            InitializeComponent();
            Load += AnalysisForm_Load;
            comboBox1.SelectedIndex = 0;
        }

         private void AnalysisForm_Load(object sender, EventArgs e)
        {
            Chart_creation();
        }
        private void Chart_creation()
        {
            string query="";
            DataTable dataTable = new DataTable();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                 query = "select count(m.MemberID) as Members, e.TypeName from Members m\r\ninner join MembershipTypes e on m.MembershipTypeID=e.MembershipTypeID\r\ngroup by e.TypeName";
                 dataTable = ExecuteQuery(query);
                    break;
                case 1:
                query = "select count(m.MemberID) as Total_Members,s.Position from Staff s\r\ninner join members m on StaffID=TrainerID\r\ngroup by s.Position";
                dataTable = ExecuteQuery(query);
                    break;

            }

            if (dataTable != null)
            {
                PopulateChart(dataTable);
                PopulateDataGridView(dataTable);
            }
        }
        private void PopulateDataGridView(DataTable dataTable)
        {
            chartdatagrid.DataSource = dataTable;
        }
        private void PopulateChart(DataTable dataTable)
        {
            if (comboBox1.SelectedIndex == 0)
            {


                MembershipChart.Series.Clear();
                MembershipChart.Titles.Clear();
                MembershipChart.Titles.Add("Membership Types Distribution");

                Series series = new Series
                {
                    Name = "Membership Type",
                    IsVisibleInLegend = true,
                    ChartType = SeriesChartType.Pie
                };

                MembershipChart.Series.Add(series);

                foreach (DataRow row in dataTable.Rows)
                {
                    series.Points.AddXY(row["TypeName"], row["Members"]);
                }

                MembershipChart.Invalidate();
            }
            else if(comboBox1.SelectedIndex==1)
            {

                MembershipChart.Series.Clear();
                MembershipChart.Titles.Clear();
                MembershipChart.Titles.Add("Training Types Distribution");

                Series series = new Series
                {
                    Name = "Training Type",
                    IsVisibleInLegend = true,
                    ChartType = SeriesChartType.Bar
                };

                MembershipChart.Series.Add(series);

                foreach (DataRow row in dataTable.Rows)
                {
                    series.Points.AddXY(row["Position"], row["Total_members"]);
                }

                MembershipChart.Invalidate();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chart_creation();
        }
    }

    }
