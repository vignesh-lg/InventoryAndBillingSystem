using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventoryAndBillingSystem.DAL
{
    public class Connections
    {
        public string sqlConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public SqlConnection GetMyConnection()
        {
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                if (myConnection != null && myConnection.State == ConnectionState.Closed)
                {
                    return myConnection;

                }
                else
                {
                    return myConnection;
                }
            }
        }
    }
}
