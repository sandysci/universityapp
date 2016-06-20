using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace universitysandy
{
    public partial class department : Form
    {
        db mydb = new db();
        MySqlCommand cmd;
        MySqlConnection mycon;
        MySqlDataAdapter myadapter;
       
        public department()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
           
            string deptname = textBox1.Text;
            int deptcapacity = Convert.ToInt32(textBox2.Text);
            string facno = comboBox1.Text;
            mydb.newdept(deptname,deptcapacity,facno);
            textBox1.Text = "";
            textBox2.Text = "";
            viewdatagridview();
        }

        private void department_Load(object sender, EventArgs e)
        {
            viewdatagridview();
            List<string> myh = mydb.selectcombo();
            foreach (var k in myh)
            {
                comboBox1.Items.Add(k);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard myd = new Dashboard();
            this.Hide();
            myd.ShowDialog();
            this.Close();
        }

        public void viewdatagridview()
        {

            try
            {
                string con = "Server= 127.0.0.1; username= root;  password = sandyy11; database= university;";
                mycon = new MySqlConnection(con);
                mycon.Open();
                cmd = new MySqlCommand();
                string query = "select * from department";
                cmd.CommandText = query;
                cmd.Connection = mycon;
                myadapter = new MySqlDataAdapter(cmd);
                DataSet myset = new DataSet();
                myadapter.Fill(myset);
                dataGridView1.DataSource = myset.Tables[0].DefaultView;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnupd_Click(object sender, EventArgs e)
        {
            updateanddeletedepartmentrecord myup = new updateanddeletedepartmentrecord();
            this.Hide();
            myup.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      

    }
}
