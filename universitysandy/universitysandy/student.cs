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
    public partial class student : Form{
        db mydb = new db();
        MySqlCommand cmd;
        MySqlConnection mycon;
        MySqlDataAdapter myadapter;
    
        public student()
        {
            InitializeComponent();
        }

        private void student_Load(object sender, EventArgs e)
        {
            viewdatagridview();
            List<string> myh = mydb.selectcombo2();
            foreach (var k in myh)
            {
                comboBox1.Items.Add(k);

            }
        }
        public void viewdatagridview()
        {

            try
            {
                string con = "Server= 127.0.0.1; username= root;  password = sandyy11; database= university;";
                mycon = new MySqlConnection(con);
                mycon.Open();
                cmd = new MySqlCommand();
                string query = "select * from student";
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

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Dashboard myd = new Dashboard();
            myd.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname=textBox1.Text;
            string lname = textBox2.Text;
            string middlename = textBox3.Text;
            int age =Convert.ToInt32(textBox4.Text);
            string gender = comboBox2.Text;
            string address = textBox4.Text;
            string email = textBox5.Text;
            int deptid = Convert.ToInt32 (comboBox1.Text);
            mydb.newstudent(fname, lname, middlename, age, gender, address, email, deptid);
            viewdatagridview();
        }
        
    }
}
