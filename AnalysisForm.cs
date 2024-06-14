using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gym_Manager
{
    public partial class AnalysisForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["GymManagementSystemDb"].ConnectionString;

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
            string query = "";
            DataTable dataTable = new DataTable();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    query = "SELECT e.TypeName AS 'Membership Type', COUNT(m.MemberID) AS 'No. of Members' " +
                            "FROM Members m " +
                            "INNER JOIN MembershipTypes e ON m.MembershipTypeID = e.MembershipTypeID " +
                            "GROUP BY e.TypeName";
                    dataTable = ExecuteQuery(query);
                    break;
                case 1:
                    query = "SELECT s.staff_Name AS 'Trainer Name', s.Position AS 'Role', COUNT(m.MemberID) AS 'No. of Students' " +
                            "FROM Staff s " +
                            "INNER JOIN Members m ON s.StaffID = m.TrainerID " +
                            "GROUP BY s.staff_Name, s.Position";
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
            MembershipChart.Series.Clear();
            MembershipChart.Titles.Clear();

            if (comboBox1.SelectedIndex == 0)
            {
                MembershipChart.Titles.Add("Members Distribution based on Membership Type");

                Series series = new Series
                {
                    Name = "Membership Type",
                    IsVisibleInLegend = true,
                    ChartType = SeriesChartType.Pie
                };

                MembershipChart.Series.Add(series);

                foreach (DataRow row in dataTable.Rows)
                {
                    series.Points.AddXY(row["Membership Type"], row["No. of Members"]);
                }
                series["PieLabelStyle"] = "Outside";
                series.BorderWidth = 1;
                series.BorderColor = Color.Black;
                series["PieLineColor"] = "Black";
                series.LegendText = "#VALX (#PERCENT{P0})";

                MembershipChart.Legends[0].Docking = Docking.Bottom;
                MembershipChart.Legends[0].Alignment = StringAlignment.Center;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                MembershipChart.Titles.Add("Members Distribution based on Trainer's Role");

                Series series = new Series
                {
                    Name = "Trainer Type",
                    IsVisibleInLegend = true,
                    ChartType = SeriesChartType.Bar,
                    Color = Color.FromArgb(139, 95, 44),
                    BorderWidth = 1,
                    BorderColor = Color.Black
                };

                MembershipChart.Series.Add(series);

                foreach (DataRow row in dataTable.Rows)
                {
                    series.Points.AddXY(row["Role"], row["No. of Students"]);
                }

                series.IsValueShownAsLabel = true;
                series.LabelForeColor = Color.Black;
                series.LabelFormat = "0"; 

                MembershipChart.ChartAreas[0].AxisX.Title = "Role";
                MembershipChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                MembershipChart.ChartAreas[0].AxisX.Interval = 1;
                MembershipChart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8);

                MembershipChart.ChartAreas[0].AxisY.Title = "No. of Students";
                MembershipChart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                MembershipChart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 8);

                foreach (DataPoint point in series.Points)
                {
                    point.Color = Color.FromArgb(139, 95, 44);
                    point.BackSecondaryColor = Color.FromArgb(205, 175, 149);
                    point.BackGradientStyle = GradientStyle.DiagonalRight;
                }

                MembershipChart.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
                MembershipChart.ChartAreas[0].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dot;
                MembershipChart.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chart_creation();
        }
    }
}
