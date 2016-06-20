using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace universitysandy
{
    public partial class facu : Form
    {
        db mydb = new db();
        MySqlCommand cmd;
        MySqlConnection mycon;
        MySqlDataAdapter myadapter;
       
        public facu()
        {
            InitializeComponent();
        }

       

      

        private void facu_Load(object sender, EventArgs e)
        {
            viewdatagridview();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string facultyname = textBox1.Text;
            if (facultyname=="")
            {
                MessageBox.Show("Cant be empty enter a valid faculty name");
            }

            else{


            mydb.newfaculty(facultyname);
            textBox1.Text = "";
            viewdatagridview();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard myd = new Dashboard();
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
                string query = "select * from faculty";
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

        private void btndel_Click(object sender, EventArgs e)


        {

             mydb.openconnection();
            MySqlCommand del = new MySqlCommand();
            string facultyname = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
         
            if (dataGridView1.Rows.Count > 1 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            {
                mydb.delfac(facultyname);
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                viewdatagridview();
               

            }
            else if (dataGridView1.Rows.Count == 1) {

                MessageBox.Show("table cant be empty");
            
            }
        
              
           
          
            
        }

        private void btnupd_Click(object sender, EventArgs e)
        {
            string fac = textBox1.Text;
            List<string> myl = mydb.searchupdate(fac);
            if (fac == "") {
                MessageBox.Show("Enter a faculty name");
            }
            else if( !myl.Contains(fac)) {
                MessageBox.Show("not found !! enter a valid name");
           }
            else{
            
             dataGridView1.Visible = false;
            groupBox1.Visible = true;
           
          
           foreach (var k in myl)
           {
               textBox2.Text = k;
           }

            }
          

            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fac = textBox1.Text;
            string fac2= textBox2.Text;
            if (fac == "")
            {
                MessageBox.Show("enter a faculty name");
            }
            else if (fac == "" && fac2 == "") {
                MessageBox.Show("cant be empty");

            }
            else if (fac == "" || fac2 == "")
            {
                MessageBox.Show("check ur field well");
            }
            else
            {
                mydb.updatefac(fac, fac2);
                groupBox1.Visible = false;
                MessageBox.Show("updated");
                viewdatagridview();
                dataGridView1.Visible = true;
                textBox1.Text = "";
            }
        }
        
    }
}
