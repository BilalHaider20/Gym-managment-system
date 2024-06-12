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
    public partial class Form1 : Form
    {
        public Form1()
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

        private void viewMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewMembers ViewMembersForm = new viewMembers();
            ViewMembersForm.ShowDialog();
        }

        private void viewFaculityMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewStaff ViewStaffForm = new viewStaff();
            ViewStaffForm.ShowDialog();

        }
    }
}
