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
            HashSet<person> myh = new HashSet<person>{};
           
            string deptname = textBox1.Text;
            myh=mydb.upsearchdept(deptname);
            dataGridView1.Visible = false;
            groupBox1.Visible = true;

            foreach (var k in myh) {

                textBox3.Text = k.deptname;
                textBox2.Text =k.depcap.ToString();
                comboBox1.Text = k.facid.ToString();
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dept1 = textBox1.Text;
            string deptname = textBox3.Text;
            int deptcap = Convert.ToInt32(textBox2.Text);
            int facid = Convert.ToInt32(comboBox1.Text);

            mydb.updatedept(dept1,deptname, deptcap, facid);
            groupBox1.Visible = false;

            viewdatagridview();
            textBox1.Text = "";
            dataGridView1.Visible = true;
        }

    }
}
