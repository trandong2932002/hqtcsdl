using HQT_CSDL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HQT_CSDL.Data
{
    public static class SalaryDB
    {
        public static IEnumerable<TinhLuong> Load()
        {
            string query = "getDataTinhLuong";
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@NgayTinhLuong", DateTime.Now.ToString("yyyy'-'MM'-'dd")));
            //parameters.Add(new SqlParameter("@NgayTinhLuong", "2022-06-01"));
            DataTable dataTable = ConnectionDB.ExecStoredProduceTable(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                string maNV = row["MaNV"].ToString().Trim();
                int tienTheoDonVi = int.Parse(row["TienTheoDonVi"].ToString());
                string loaiLaoDong = row["LoaiLaoDong"].ToString();
                int thoiGianLamDonVi = int.Parse(row["ThoiGianLamDonVi"].ToString());
                int tangCa = int.Parse(row["TangCa"].ToString());
                double tienLuong = double.Parse(row["TienLuong"].ToString());

                TinhLuong tinhLuong = new TinhLuong(maNV, tienTheoDonVi, loaiLaoDong, thoiGianLamDonVi, tangCa, tienLuong);
                yield return tinhLuong;
            }
        }
    }
}
