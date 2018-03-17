using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectDatabase
{
    [TestClass]
    public class Test_Databases
    {
        //[TestMethod]
        //public void Test_DB_Sync()
        //{
        //    string connectionString;
        //    #region Assign connectionString
        //    connectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    #endregion

        //    string sqlSelect = "SELECT @@VERSION";
        //    using (var sqlConnection = new SqlConnection(connectionString))
        //    {
        //        sqlConnection.Open();
        //        using (var sqlCommand = new SqlCommand(sqlSelect, sqlConnection))
        //        {
        //            using (var reader = sqlCommand.ExecuteReader())
        //            {
        //                while(reader.Read())
        //                {
        //                    var data = reader[0].ToString();
        //                }
        //            }
        //        }
        //    }
        //}

        [TestMethod]
        public void Test_DB_ASync()
        {
            string connectionString;
            #region Assign connectionString
            connectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            #endregion

            string sqlSelect = "SELECT @@VERSION";
           

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand(sqlSelect, sqlConnection);
                var callback = new AsyncCallback(DataAvailable);
                var ar = sqlCommand.BeginExecuteReader(callback, sqlCommand);

                

                ar.AsyncWaitHandle.WaitOne();
            }
        }

        private static void DataAvailable(IAsyncResult ar)
        {
            var sqlCommand = ar.AsyncState as SqlCommand;
            using (var reader = sqlCommand.EndExecuteReader(ar))
            {
                while (reader.Read())
                {
                    var data = reader[0].ToString();
                }
            }
        }
    
    }
}
