using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HQT_CSDL.Data
{
    public static class PhongBanData
    {
        public static DataTable Load()
        {
            DataTable dt = ConnectionDB.ExecStoredProduceTable("getDataPhongBan");
            return dt;
        }

        public static string AddPhongBan(string MaPB, string MaCN, string TenPB)
        {
            string query = "sp_addPhongBan";
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaPB", MaPB));
            parameters.Add(new SqlParameter("@MaCN", MaCN));
            parameters.Add(new SqlParameter("@TenPB", TenPB));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }

        public static string UpdatePhongBan(string MaPB, string MaCN, string TenPB)
        {
            string query = "sp_updatePhongBan";
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaPB", MaPB));
            parameters.Add(new SqlParameter("@MaCN", MaCN));
            parameters.Add(new SqlParameter("@TenPB", TenPB));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }

        public static string DeletePhongBan(string id)
        {
            string query = "sp_delPhongBan";

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaPB", id));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }
    }
}
