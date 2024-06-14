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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MembershipChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartdatagrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.MembershipChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartdatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MembershipChart
            // 
            chartArea1.Name = "ChartArea1";
            this.MembershipChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.MembershipChart.Legends.Add(legend1);
            this.MembershipChart.Location = new System.Drawing.Point(63, 150);
            this.MembershipChart.Name = "MembershipChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.MembershipChart.Series.Add(series1);
            this.MembershipChart.Size = new System.Drawing.Size(491, 350);
            this.MembershipChart.TabIndex = 0;
            this.MembershipChart.Text = "chart1";
            // 
            // chartdatagrid
            // 
            this.chartdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chartdatagrid.Location = new System.Drawing.Point(704, 220);
            this.chartdatagrid.Name = "chartdatagrid";
            this.chartdatagrid.RowHeadersVisible = false;
            this.chartdatagrid.RowHeadersWidth = 62;
            this.chartdatagrid.RowTemplate.Height = 28;
            this.chartdatagrid.Size = new System.Drawing.Size(326, 227);
            this.chartdatagrid.TabIndex = 1;
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 607);
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