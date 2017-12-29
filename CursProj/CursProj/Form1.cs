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
    }
}
