using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMWPF.Model
{
    public class Database
    {

        public IList<User> getUsersDataAdapter(IList<User> _UsersList)
        {
            string queryString = "SELECT * FROM USERINFO";
            string connection = "Data Source=YOURDATASOURCE;" + "" +
                                "Initial Catalog=Training;Integrated Security=True;" + 
                                "Connect Timeout=30;Encrypt=False;" + 
                                "TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                                "MultiSubnetFailover=False";
            SqlConnection _conn=null;
            SqlCommand cmd = null;
            SqlDataAdapter adp = null;
            DataSet dsUser = new DataSet();
            try
            {
                if (openConnection(connection, ref _conn))
                {
                    cmd = new SqlCommand(queryString, _conn);
                    adp = new SqlDataAdapter(cmd);
                    adp.Fill(dsUser, "UserInfo");
                    _conn.Close();
                    _UsersList = new List<User>();
                    foreach (DataRow uRow in dsUser.Tables["UserInfo"].Rows)
                    {
                        _UsersList.Add(new User {UserId=(int)uRow["userId"],
                            FirstName =uRow["firstName"].ToString()
                            ,LastName=uRow["lastName"].ToString()
                            ,City= uRow["city"].ToString()
                            ,State= uRow["state"].ToString()
                            ,Country= uRow["country"].ToString()
                        });
                    }
                }
            }
            catch (SqlException ex){

                throw new Exception(ex.Message);
            }
            

            return _UsersList;
        }

        public IList<User> getUsersDataReader(IList<User> _UsersList)
        {
            string queryString = "SELECT * FROM USERINFO";
            string connection = "Data Source=YOURDATASOURCE;" + "" +
                                "Initial Catalog=Training;Integrated Security=True;" +
                                "Connect Timeout=30;Encrypt=False;" +
                                "TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                                "MultiSubnetFailover=False";
            SqlConnection _conn = null;
            SqlCommand cmd = null;
            
            DataTable dtUser = new DataTable();
            try
            {
                if (openConnection(connection, ref _conn))
                {
                    cmd = new SqlCommand(queryString, _conn);
                    SqlDataReader adr =  cmd.ExecuteReader();
                  
                    _UsersList = new List<User>();
                    while (adr.HasRows)
                    {


                        while (adr.Read())
                        {
                            _UsersList.Add(new User
                            {
                                UserId = (int)adr["userId"],
                                FirstName = adr["firstName"].ToString()
                                ,
                                LastName = adr["lastName"].ToString()
                                ,
                                City = adr["city"].ToString()
                                ,
                                State = adr["state"].ToString()
                                ,
                                Country = adr["country"].ToString()
                            });
                        }

                        adr.NextResult();
                    }



                    _conn.Close();
                }
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


            return _UsersList;
        }

        private bool openConnection(string conString, ref SqlConnection con)
        {
            con = new SqlConnection(conString);

            try
            {
                
                con.Open();
                return true;
            }
            catch(SqlException sex)
            {
                MessageBox.Show("You failed!" + sex.Message);
                con.Close();
                return false;
            }
           

           
        }

       
    }
}
