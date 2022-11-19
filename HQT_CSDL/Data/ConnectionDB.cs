using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HQT_CSDL.View;
namespace HQT_CSDL.Data
{
    public class ConnectionDB
    {

        private static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-RF7863D;Initial Catalog=QUANLYLUONGNV;Integrated Security=True");
        //public static string ConnString;
        //private static SqlConnection conn = new SqlConnection(ConnString);
        //private static SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QUANLYLUONGNV;Integrated Security=True");
        //private static SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QUANLYLUONGNV;User ID=" + login.name + ";Password=" + login.password + ";");



        public static DataTable LoadTable(string query)
        {
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                conn.Close();
                return dataTable;
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static string ExecStoredProduce(string query, List<SqlParameter> parameters)
        {
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                command.ExecuteNonQuery();
                conn.Close();
                return null;
            }
            catch (SqlException e)
            {
                conn.Close();
                return e.Message;
            }
        }

        public static DataTable ExecStoredProduceTable(string query, List<SqlParameter> parameters)
        {
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(query, conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    adapter.SelectCommand.Parameters.Add(parameter);
                }
                DataTable table = new DataTable();
                adapter.Fill(table);

                conn.Close();
                return table;
            }
            catch (SqlException e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
