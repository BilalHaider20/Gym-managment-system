namespace Gym_Manager
{
    partial class AnalysisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MembershipChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartdatagrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.MembershipChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartdatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MembershipChart
            // 
            chartArea2.Name = "ChartArea1";
            this.MembershipChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.MembershipChart.Legends.Add(legend2);
            this.MembershipChart.Location = new System.Drawing.Point(56, 91);
            this.MembershipChart.Name = "MembershipChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.MembershipChart.Series.Add(series2);
            this.MembershipChart.Size = new System.Drawing.Size(300, 300);
            this.MembershipChart.TabIndex = 0;
            this.MembershipChart.Text = "chart1";
            // 
            // chartdatagrid
            // 
            this.chartdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chartdatagrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.chartdatagrid.Location = new System.Drawing.Point(522, 0);
            this.chartdatagrid.Name = "chartdatagrid";
            this.chartdatagrid.RowHeadersWidth = 62;
            this.chartdatagrid.RowTemplate.Height = 28;
            this.chartdatagrid.Size = new System.Drawing.Size(474, 450);
            this.chartdatagrid.TabIndex = 1;
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 450);
            this.Controls.Add(this.chartdatagrid);
            this.Controls.Add(this.MembershipChart);
            this.Name = "AnalysisForm";
            this.Text = "AnalysisForm";
            ((System.ComponentModel.ISupportInitialize)(this.MembershipChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartdatagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart MembershipChart;
        private System.Windows.Forms.DataGridView chartdatagrid;
    }
}