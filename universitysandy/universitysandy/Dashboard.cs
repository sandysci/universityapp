using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace universitysandy
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnfaculty_Click(object sender, EventArgs e)
        {
            facu myf = new facu();
            this.Hide();
            myf.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 myfd = new Form1();
            this.Hide();
            myfd.ShowDialog();
            this.Close();
        }

        private void btndept_Click(object sender, EventArgs e)
        {
            department myfd = new department();
            this.Hide();
            myfd.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            student myfd = new student();
            this.Hide();
            myfd.ShowDialog();
            this.Close();
        }
    }
}
