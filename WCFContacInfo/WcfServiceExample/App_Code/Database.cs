using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServiceExample
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
            SqlConnection _conn = null;
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
                        _UsersList.Add(new User
                        {
                            UserId = (int)uRow["userId"],
                            FirstName = uRow["firstName"].ToString()
                            ,
                            LastName = uRow["lastName"].ToString()
                            ,
                            City = uRow["city"].ToString()
                            ,
                            State = uRow["state"].ToString()
                            ,
                            Country = uRow["country"].ToString()
                        });
                    }
                }
            }
            catch (SqlException ex)
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
            catch (SqlException sex)
            {
                throw new Exception(sex.Message);
                
            }
            finally
            {
                con.Close();
               
            }

            return false;

        }


    }
}