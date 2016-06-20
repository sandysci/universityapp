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
    public partial class Form1 : Form
    {
        db mydb = new db();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            string user = textBoxuser.Text;
            string pass = textBoxpass.Text;
           

            HashSet<string> myhash = mydb.adminselect(user, pass);
            if (myhash.Contains(user) && myhash.Contains(pass))
            {

                Dashboard myd = new Dashboard();
                this.Hide();
                myd.ShowDialog();
                this.Close();

            }
            else {
                MessageBox.Show("Name not found click ok and try again");
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxpass_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
