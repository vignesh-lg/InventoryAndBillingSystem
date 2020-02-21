using System;
using OnlineInventoryAndBillingSystem.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace OnlineInventoryAndBillingSystem.DAL
{
    public class UserRepository
    {
        public string sqlConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public static List<String> stateList = new List<String>();
        public static List<String> tamilnaducityList = new List<String>();
        public static List<String> andhracityList = new List<String>();
        public static List<String> banglorecityList = new List<String>();
        static UserRepository()
        {
            stateList.Add("Tamil Nadu" );
            stateList.Add("Andhra Pradesh");
            stateList.Add("Bangalore");
            tamilnaducityList.Add("Salem");
            tamilnaducityList.Add("Chennai");
            tamilnaducityList.Add("Coimbatore");
            andhracityList.Add("Tirupathi");
            andhracityList.Add("Hydreabad");
            banglorecityList.Add("Mysore");
            banglorecityList.Add("Manglore");

        }
        public static IEnumerable<String> GetDetails()
        {
            return stateList;
        }
        public static IEnumerable<String> GetTamilNaduDetails()
        {
            return tamilnaducityList;
        }
        public static IEnumerable<String> GetAndhraDetails()
        {
            return andhracityList;
        }
        public static IEnumerable<String> GetBangloreDetails()
        {
            return banglorecityList;
        }
        public bool GetCustomerDetails(User user)
        {
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                string sql = "UserData_Procedure";
                SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@CustomerFirstName", user.CustomerFirstName));
                sqlCommand.Parameters.AddWithValue("@CustomerSecondName", user.CustomerSecondName);
                sqlCommand.Parameters.AddWithValue("@Gender", user.gender);
                sqlCommand.Parameters.AddWithValue("@State", user.State);
                sqlCommand.Parameters.AddWithValue("@City", user.City);
                sqlCommand.Parameters.AddWithValue("@PermenantAddress", user.Address);
                sqlCommand.Parameters.AddWithValue("@PinCode", user.PinCode);
                sqlCommand.Parameters.AddWithValue("@CellNumber", user.CellNumber);
                sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                sqlCommand.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                int limit = sqlCommand.ExecuteNonQuery();
                if (limit >= 1)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }
        public bool ToLogin(User user)
        {
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                string query = "User_Procedure_Login";
                SqlCommand sqlCommand = new SqlCommand(query, myConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserName1", user.UserName);
                sqlCommand.Parameters.AddWithValue("@Password1", user.Password);
                sqlCommand.Parameters.Add("@Error", SqlDbType.VarChar, 100);
                sqlCommand.Parameters["@Error"].Direction = ParameterDirection.Output;
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public DataTable ToSearch(User user)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                string sql = "User_Procedure_Search";
                SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", user.Search);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }

        }
        public DataTable ToBind()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                string sql = "User_Procedure";
                SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        public bool UpdateCustomerDetails(User user)
        {
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                string sql = "UserData_Procedure_Update";
                SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserName", user.UserName);
                sqlCommand.Parameters.Add(new SqlParameter("@CustomerFirstName", user.CustomerFirstName));
                sqlCommand.Parameters.AddWithValue("@CustomerSecondName", user.CustomerSecondName);
                sqlCommand.Parameters.AddWithValue("@Gender", user.gender);
                sqlCommand.Parameters.AddWithValue("@State", user.State);
                sqlCommand.Parameters.AddWithValue("@City", user.City);
                sqlCommand.Parameters.AddWithValue("@PermenantAddress", user.Address);
                sqlCommand.Parameters.AddWithValue("@PinCode", user.PinCode);
                sqlCommand.Parameters.AddWithValue("@CellNumber", user.CellNumber);
                sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                sqlCommand.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);

                sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                sqlCommand.Parameters.AddWithValue("@id", user.UserId);
                int limit = sqlCommand.ExecuteNonQuery();
                if (limit >= 1)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }
        public bool DeleteCustomer(User user)
        {
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                string sql = "UserData_Procedure_Delete";
                SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", user.UserId);
                int limit = sqlCommand.ExecuteNonQuery();
                if (limit >= 1)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }
        public string GenereteUserName(User user)
        {
            Random random = new Random();
            user.UserName = user.CustomerFirstName + random.Next(100);
            return user.UserName;//return the username
        }
    }
}


