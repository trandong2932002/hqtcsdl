using HQT_CSDL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HQT_CSDL.Data
{
    public static class TimeCheckingDB
    {
        public static IEnumerable<ChamCong> Load()
        {
            string query = "getDataChamCong";
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@NgayChamCong", DateTime.Now.ToString("yyyy'-'MM'-'dd")));
            //parameters.Add(new SqlParameter("@NgayChamCong", "2022-06-01"));
            DataTable dataTable = ConnectionDB.ExecStoredProduceTable(query, parameters);
            
            foreach (DataRow row in dataTable.Rows)
            {
                string maNV = row["MaNV"].ToString().Trim();
                string maPB = row["MaPB"].ToString();
                string maCV = row["MaCV"].ToString();
                string tenNV = row["TenNV"].ToString();
                int thoiGian = int.Parse(row["ThoiGianLamDonVi"].ToString());
                int tangCa = int.Parse(row["TangCa"].ToString());

                ChamCong chamCong = new ChamCong(maNV, maPB, maCV, tenNV, thoiGian, tangCa);
                yield return chamCong;
            }
        }
        public static string Check(ChamCong timeChecking)
        {
            string query = "sp_ChamCong";
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaNV", timeChecking.MaNV));
            parameters.Add(new SqlParameter("@ThoiGian", timeChecking.ThoiGianLamDonVi));
            parameters.Add(new SqlParameter("@TangCa", timeChecking.TangCa));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }
    }
}
