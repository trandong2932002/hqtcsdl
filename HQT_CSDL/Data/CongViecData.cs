using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using HQT_CSDL.Data;

namespace HQT_CSDL.Data
{
    public class CongViecData
    {
        public static DataTable Load()
        {
            DataTable dt = ConnectionDB.ExecStoredProduceTable("getDataCongViec");
            return dt;
        }

        public static string AddCongViec(string id, string name, string detail)
        {
            string query = "sp_addCongViec";
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaCV", id));
            parameters.Add(new SqlParameter("@TenCV", name));
            parameters.Add(new SqlParameter("@MoTaCV", detail));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }

        public static string UpdateCongViec(string id, string name, string detail)
        {
            string query = "sp_updateCongViec";
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaCV", id));
            parameters.Add(new SqlParameter("@TenCV", name));
            parameters.Add(new SqlParameter("@MoTaCV", detail));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }

        public static string DeleteCongViec(string id)
        {
            string query = "sp_delCongViec";

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaCV", id));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }
    }
}
