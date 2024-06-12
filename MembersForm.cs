using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Manager
{
    public partial class MembersForm : Form
    {
        private string connection_string="";
        public MembersForm()
        {
            InitializeComponent();
            MembershipType.Items.Add("Basic");
            MembershipType.Items.Add("Premium");
            MembershipType.Items.Add("Gold");
            MembershipType.Items.Add("Student");

            TrainingType.Items.Add("Weigth Gain");
            TrainingType.Items.Add("Weigth Loss");
            TrainingType.Items.Add("Strength Training");
            TrainingType.Items.Add("Cardio");
            TrainingType.Items.Add("Legs Training");
            TrainingType.Items.Add("Sports Training");
            TrainingType.Items.Add("Rehabilition Training");
            TrainingType.Items.Add("Core Abs Training");      
        }

       
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Add("MemberID","ID");
            dataGridView1.Columns.Add("Name","Name");
            dataGridView1.Columns.Add("Age","Age");
            dataGridView1.Columns.Add("Gender","Gender");
            dataGridView1.Columns.Add("MembershipType","MemberShip");
            dataGridView1.Columns.Add("TrainingType","TrainingType");
            dataGridView1.Columns.Add("Trainer","Trainer");
            dataGridView1.Columns.Add("Duration","Duration");

            
        }
        private void MemberForm_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
