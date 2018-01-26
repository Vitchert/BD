using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CursProj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            GroupListWindow gr = new GroupListWindow();
            gr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaskComplition tc = new TaskComplition();
            tc.ShowDialog();
        }

        private void TeacherButton_Click(object sender, EventArgs e)
        {
            TeacherList tl = new TeacherList();
            tl.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Attendance at = new Attendance();
            at.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rating rt = new Rating();
            rt.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LateStudents ls = new LateStudents();
            ls.ShowDialog();
        }
    }
}
