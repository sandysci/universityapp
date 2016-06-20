using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace universitysandy
{
    class db
    {
        MySqlDataAdapter myadapter;
  
      public  MySqlConnection mycon;
   MySqlCommand cmd= new MySqlCommand();
   person p = new person();
   
        public void openconnection() {
           
            string con = "Server= 127.0.0.1; username= root;  password = sandyy11; database= university;";
            mycon = new MySqlConnection(con);
            try
            {
                mycon.Open();
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        
        }
        public void closeconnection() {

            mycon.Close();
        }

        
        
        
        public HashSet<string>adminselect (string user, string password)
        {
            HashSet<string> myh = new HashSet<string> { };
            openconnection();
           
                string query = "SELECT *  FROM admin WHERE Username ='" + user + "' and password ='" + password + "' ";
                cmd.CommandText = query;
                cmd.Connection = mycon;
                MySqlDataReader reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    string id = reader["adminid"].ToString();
                    string use = reader["Username"].ToString();
                    string pas = reader["password"].ToString();
                
                    myh.Add(use);
                    myh.Add(pas);
                }



                return myh;
               
        }


        public void newfaculty(string facu) {

           

            openconnection();
            string query = "INSERT INTO faculty VALUES('',@facu)";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@facu",facu);
            cmd.Connection = mycon;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Inserted");

            closeconnection();
        }

        public void delfac(string fac) {


            openconnection();
            string query = "DELETE FROM faculty where facultyname= @fac";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@fac", fac);
            cmd.Connection = mycon;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted");

            closeconnection();
        
        }
        public List<string> searchupdate(string face) {
            openconnection();
            List<string> myh = new List<string> { };
            string query = "SELECT *  FROM faculty WHERE facultyname ='" + face +"' ";
            cmd.CommandText = query;
            cmd.Connection = mycon;
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                string id = reader["facultyid"].ToString();
                string fac = reader["facultyname"].ToString();
               
                myh.Add(fac);
               
            }
            return myh;

        }
        public void updatefac(string getfacna,string setfacna) {
            openconnection();
            cmd.Parameters.AddWithValue("@getfac", getfacna);
            cmd.Parameters.AddWithValue("@setfac", setfacna);
            string query = "update  faculty SET facultyname= @setfac WHERE facultyname= @getfac";
            cmd.CommandText = query;
           
            cmd.Connection = mycon;
            cmd.ExecuteNonQuery();
           

            closeconnection();
        }
        public List<string> selectcombo() {

            openconnection();
            string query = "SELECT * from faculty";
            cmd.CommandText = query;
            cmd.Connection = mycon;

            List<string> myh = new List<string> { };
           
            MySqlDataReader myreader = cmd.ExecuteReader();
            while (myreader.Read()) {
      
             string facultyname  = myreader["facultyname"].ToString();
             string facultyid = myreader["facultyid"].ToString();
            
             myh.Add(facultyid);
            

          

            }

            return myh;
        }

            public void newdept(string deptname, int deptcapacity, string facuid) {

                try
                {

                    openconnection();
                    string query = "INSERT INTO department VALUES('',@deptn,@deptc,@facuid)";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@deptn", deptname);
                    cmd.Parameters.AddWithValue("@deptc", deptcapacity);
                    cmd.Parameters.AddWithValue("@facuid", facuid);
                    cmd.Connection = mycon;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted");

                    closeconnection();
                }
                catch(MySqlException ex){
                MessageBox.Show(ex.Message);
                }
        }

            public void deldept(string fac)
            {


                openconnection();
                string query = "DELETE FROM department where departmentname= @fac";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@fac", fac);
                cmd.Connection = mycon;
                cmd.ExecuteNonQuery();
               
                closeconnection();

            }


            public HashSet<person> upsearchdept(string depname) {
                openconnection();
                HashSet<person> myh = new HashSet<person> {};
                string query = "SELECT * FROM department where departmentname =@depname ";
                cmd.Connection = mycon;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@depname", depname);
                MySqlDataReader myreader = cmd.ExecuteReader();
                while (myreader.Read()) {
                    p.deptname = myreader["departmentname"].ToString();
                    p.depcap = (int)myreader["departmentcapacity"];
                    p.facid = (int)myreader["facultyid"];
                    myh.Add(p);
                
                
                
                }

                return myh;
          
            
            }
            public void updatedept( string dept1,string deptname, int deptcap, int facid)
            {



                openconnection();
                string query = "UPDATE department SET departmentname=@deptname,departmentcapacity=@deptcap ,facultyid= @facid WHERE departmentname='"+dept1+"'";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@dept1", dept1);
                cmd.Parameters.AddWithValue("@deptname", deptname);
                cmd.Parameters.AddWithValue("@deptcap", deptcap);
                cmd.Parameters.AddWithValue("@facid", facid);
                cmd.Connection = mycon;

                cmd.ExecuteNonQuery();
                MessageBox.Show("updated");

                closeconnection();
            }
            
        
        
    
     public List<string> selectcombo2() {

            openconnection();
            string query = "SELECT * from student";
            cmd.CommandText = query;
            cmd.Connection = mycon;

            List<string> myh = new List<string> { };
           
            MySqlDataReader myreader = cmd.ExecuteReader();
            while (myreader.Read()) {
      
             string deptid = myreader["deptid"].ToString();
            
             myh.Add(deptid);
            

          

            }

            return myh;
        }
     public void newstudent(string fname,string lname, string middlename, int age,string gender, string address, string email, int deptid)
     {

         try
         {

             openconnection();
             string query = "INSERT INTO student VALUES('',@fname,@lname,@middlename,@age,@gender,@address,@email,@deptid)";
             cmd.CommandText = query;
             cmd.Parameters.AddWithValue("@fname", fname);
             cmd.Parameters.AddWithValue("@lname", lname);
             cmd.Parameters.AddWithValue("@middlename", middlename);
             cmd.Parameters.AddWithValue("@age", age);
             cmd.Parameters.AddWithValue("@gender", gender);
             cmd.Parameters.AddWithValue("@address", address);
             cmd.Parameters.AddWithValue("@email", email);
             cmd.Parameters.AddWithValue("@deptid", deptid);
             cmd.Connection = mycon;
             cmd.ExecuteNonQuery();
             MessageBox.Show("Inserted");

             closeconnection();
         }
         catch (MySqlException ex)
         {
             MessageBox.Show(ex.Message);
         }
     }

      



}
  


public class person {

   public string deptname
    {
        get;
        set;
    }

   public int depcap
    {
        get;
        set;
    }
   public int facid
    {
        get;
        set;
    }
}
}