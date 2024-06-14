using System.Windows.Forms;

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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MembershipChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartdatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MembershipChart
            // 
            this.MembershipChart.BackColor = System.Drawing.Color.AntiqueWhite;
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
            this.MembershipChart.Size = new System.Drawing.Size(555, 405);
            this.MembershipChart.TabIndex = 0;
            this.MembershipChart.Text = "chart1";
            // 
            // chartdatagrid
            // 
            this.chartdatagrid.AllowUserToAddRows = false;
            this.chartdatagrid.AllowUserToDeleteRows = false;
            this.chartdatagrid.AllowUserToResizeColumns = false;
            this.chartdatagrid.AllowUserToResizeRows = false;
            this.chartdatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.chartdatagrid.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.chartdatagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chartdatagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.chartdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chartdatagrid.EnableHeadersVisualStyles = false;
            this.chartdatagrid.GridColor = System.Drawing.Color.BurlyWood;
            this.chartdatagrid.Location = new System.Drawing.Point(700, 190);
            this.chartdatagrid.Name = "chartdatagrid";
            this.chartdatagrid.ReadOnly = true;
            this.chartdatagrid.RowHeadersVisible = false;
            this.chartdatagrid.RowHeadersWidth = 51;
            this.chartdatagrid.RowTemplate.Height = 24;
            this.chartdatagrid.Size = new System.Drawing.Size(366, 283);
            this.chartdatagrid.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Membership Types",
            "Training Types"});
            this.comboBox1.Location = new System.Drawing.Point(80, 89);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(219, 28);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Category";
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1078, 607);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chartdatagrid);
            this.Controls.Add(this.MembershipChart);
            this.Name = "AnalysisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AnalysisForm";
            ((System.ComponentModel.ISupportInitialize)(this.MembershipChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartdatagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart MembershipChart;
        private System.Windows.Forms.DataGridView chartdatagrid;
        private ComboBox comboBox1;
        private Label label1;
    }
}