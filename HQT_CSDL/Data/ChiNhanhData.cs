using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HQT_CSDL.Model;
using System.Data.SqlClient;

namespace HQT_CSDL.Data
{
    public class ChiNhanhData
    {
        public static DataTable Load()
        {
            DataTable dt = ConnectionDB.ExecStoredProduceTable("getDataChiNhanh");
            return dt;
        }

        public static string AddChiNhanh(string id, string diachi, string sdt)
        {
            string query = "sp_addChiNhanh";
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaCN", id));
            parameters.Add(new SqlParameter("@DiaChi", diachi));
            parameters.Add(new SqlParameter("@SoDT", sdt));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }

        public static string UpdateChiNhanh(string id, string diachi, string sdt)
        {
            string query = "sp_updateChiNhanh";
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaCN", id));
            parameters.Add(new SqlParameter("@DiaChi", diachi));
            parameters.Add(new SqlParameter("@SoDT", sdt));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }

        public static string DeleteChiNhanh(string id)
        {
            string query = "sp_delChiNhanh";

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaCN", id));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }
    }


}
