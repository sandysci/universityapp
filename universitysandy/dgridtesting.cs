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
    public partial class dgridtesting : Form
    {
        db mydb = new db();
        public dgridtesting()
        {
            InitializeComponent();
        }

        private void dgridtesting_Load(object sender, EventArgs e)
        {
            mydb.openconnection();
            MySqlDataAdapter mydata = new MySqlDataAdapter("select * from admin", mydb.mycon);
            DataTable dt = new DataTable();
            mydata.Fill(dt);
            dataGridView1.DataSource = dt;
            

            
            mydb.closeconnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mydb.openconnection();
            MySqlCommand del = new MySqlCommand();
            if (dataGridView1.Rows.Count > 1 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            {
                string query = "DELETE FROM admin where adminid=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "";
                del.CommandText = query;
                del.Connection = mydb.mycon;
                del.ExecuteNonQuery();
                MessageBox.Show("deleted");
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                mydb.closeconnection();

            }
            else if (dataGridView1.Rows.Count == 1) {

                MessageBox.Show("table cant be empty");
            
            }
        }
    }
}
