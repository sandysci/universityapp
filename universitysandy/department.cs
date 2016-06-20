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
            
           
         
            string match =Convert.ToString(textBox2.Text);
            string facno = comboBox1.Text;
            if (((string.IsNullOrEmpty (deptname)) && (Convert.ToString(comboBox1.Text) == string.Empty)) &&(string.IsNullOrEmpty(match)) )
            {
                MessageBox.Show("cant be empty");
            }

            else if (((string.IsNullOrEmpty(deptname)) || (Convert.ToString(comboBox1.Text) == string.Empty)) || (string.IsNullOrEmpty(match)))
            {
                MessageBox.Show("Check your form before submitting");
            }
           
            
            else
             {
                 if (Regex.IsMatch(textBox2.Text.Trim(), @"[0-9]"))
                 {
                     int deptcapacity = Convert.ToInt32(textBox2.Text);
                     mydb.newdept(deptname, deptcapacity, facno);
                     textBox1.Text = "";
                     textBox2.Text = "";
                     viewdatagridview();
                 }
                 else {
                     MessageBox.Show("Enter a number in your department capacity field");
                 }
             }
        }

        private void department_Load(object sender, EventArgs e)
        {
            viewdatagridview();
            HashSet<string> myh = mydb.selectcombo();
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

        private void btndel_Click(object sender, EventArgs e)
        {
            string depid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            if (dataGridView1.Rows.Count > 1 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            {
                mydb.delfac(depid);
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                viewdatagridview();


            }
            else if (dataGridView1.Rows.Count == 1)
            {

                MessageBox.Show("table cant be empty");

            }

        }

      

    }
}
