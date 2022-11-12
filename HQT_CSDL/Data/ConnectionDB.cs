using System.Data;
using System.Data.SqlClient;

namespace HQT_CSDL.Data
{
    public static class ConnectionDB
    {
        private static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-RF7863D;Initial Catalog=QUANLYLUONGNV;Integrated Security=True");

        public static DataTable LoadTable(string query)
        {
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            conn.Close();
            return dataTable;
        }
    }
}
