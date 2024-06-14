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
        }

        private void AnalysisForm_Load(object sender, EventArgs e)
        {
            string query = "select count(m.MemberID) as Members, e.TypeName from Members m\r\ninner join MembershipTypes e on m.MembershipTypeID=e.MembershipTypeID\r\ngroup by e.TypeName";
            DataTable dataTable = ExecuteQuery(query);

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
            MembershipChart.Series.Clear();
            MembershipChart.Titles.Clear();
            MembershipChart.Titles.Add("Membership Types Distribution");

            Series series = new Series
            {
                Name = "Membership Type",
                //IsVisibleInLegend = true,
                ChartType = SeriesChartType.Pie
            };

            MembershipChart.Series.Add(series);

            foreach (DataRow row in dataTable.Rows)
            {
                series.Points.AddXY(row["TypeName"], row["Members"]);
            }

            MembershipChart.Invalidate();
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
