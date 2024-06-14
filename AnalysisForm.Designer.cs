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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalysisForm));
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
            this.MembershipChart.BorderlineColor = System.Drawing.Color.AntiqueWhite;
            chartArea1.Name = "ChartArea1";
            this.MembershipChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.MembershipChart.Legends.Add(legend1);
            this.MembershipChart.Location = new System.Drawing.Point(32, 119);
            this.MembershipChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MembershipChart.Name = "MembershipChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.MembershipChart.Series.Add(series1);
            this.MembershipChart.Size = new System.Drawing.Size(493, 324);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(75)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(152)))), ((int)(((byte)(97)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.chartdatagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.chartdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(152)))), ((int)(((byte)(97)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.chartdatagrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.chartdatagrid.EnableHeadersVisualStyles = false;
            this.chartdatagrid.GridColor = System.Drawing.Color.BurlyWood;
            this.chartdatagrid.Location = new System.Drawing.Point(562, 157);
            this.chartdatagrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartdatagrid.Name = "chartdatagrid";
            this.chartdatagrid.ReadOnly = true;
            this.chartdatagrid.RowHeadersVisible = false;
            this.chartdatagrid.RowHeadersWidth = 51;
            this.chartdatagrid.RowTemplate.Height = 24;
            this.chartdatagrid.Size = new System.Drawing.Size(355, 275);
            this.chartdatagrid.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Membership Types",
            "Training Types"});
            this.comboBox1.Location = new System.Drawing.Point(47, 70);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(248, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Analytics for:";
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(958, 486);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chartdatagrid);
            this.Controls.Add(this.MembershipChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnalysisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analytics";
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