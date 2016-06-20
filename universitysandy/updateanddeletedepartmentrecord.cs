using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace universitysandy
{
    public partial class updateanddeletedepartmentrecord : Form
    {
        db mydb = new db();
        MySqlCommand cmd;
        MySqlConnection mycon;
        MySqlDataAdapter myadapter;
      
      
        public updateanddeletedepartmentrecord()
        {
            InitializeComponent();
        }

        private void updateanddeletedepartmentrecord_Load(object sender, EventArgs e)
        {
            viewdatagridview();  
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            string delname = textBox1.Text;

            mydb.deldept(delname);
            MessageBox.Show("deleted");
            viewdatagridview();
            textBox1.Text = "";
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
            string deptname = textBox1.Text;
            HashSet<person> myh = mydb.upsearchdept(deptname);
            HashSet<string> myh1 = new HashSet<string> { }; 
               
            foreach (person x in myh) {
                myh1.Add(x.deptname);

            }
          
           
           
          
            if (deptname == "")
            {
                MessageBox.Show("cant be empty");
            }
            

            else if(!myh1.Contains(deptname)){
            
             MessageBox.Show("name not found! Enter a valid name");
            }
                
            
            else{
           
           
            dataGridView1.Visible = false;
            groupBox1.Visible = true;

            foreach (var k in myh) {

                textBox3.Text = k.deptname;
                textBox2.Text =k.depcap.ToString();
                comboBox1.Text = k.facid.ToString();
            }
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dept1 = textBox1.Text;
            string deptname = textBox3.Text;
            int deptcap = Convert.ToInt32(textBox2.Text);
            int facid = Convert.ToInt32(comboBox1.Text);
            if (dept1 == "" && deptname == "" && textBox2.Text == "" && comboBox1.Text == "") {

                MessageBox.Show("cant be empty");
            }
            else if (dept1 == "" || deptname == "" || textBox2.Text == "" || comboBox1.Text == "")
            {

                MessageBox.Show("check input well");
            }
            else
            {
                if (Regex.IsMatch(textBox2.Text, @"[0-9]")) {

                    mydb.updatedept(dept1, deptname, deptcap, facid);
                    groupBox1.Visible = false;

                    viewdatagridview();
                    textBox1.Text = "";
                    dataGridView1.Visible = true;
                }

               
            }
        }

        private void btndel_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            department myd = new department();
            myd.ShowDialog();
            this.Close();
        }

       

    }
}
