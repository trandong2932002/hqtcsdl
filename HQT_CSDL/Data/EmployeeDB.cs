using HQT_CSDL.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HQT_CSDL.Data
{
    public static class EmployeeDB
    {
        public static IEnumerable<NhanVien> Load()
        {
            DataTable dataTable = ConnectionDB.LoadTable("select * from nhanvien order by manv");
            foreach (DataRow row in dataTable.Rows)
            {
                string maNV = row["MaNV"].ToString().Trim();
                string maPB = row["MaPB"].ToString();
                string maCV = row["MaCV"].ToString();
                string tenNV = row["TenNV"].ToString();
                string gioiTinh = row["GioiTinh"].ToString();
                string soDT = row["SoDT"].ToString();
                string loaiLaoDong = row["LoaiLaoDong"].ToString();
                int tienTheoDonVi = int.Parse(row["TienTheoDonVi"].ToString());

                NhanVien nhanVien = new NhanVien(maNV, maPB, maCV, tenNV, gioiTinh, soDT, loaiLaoDong, tienTheoDonVi);
                yield return nhanVien;
            }
        }

        public static string AddEmployee(NhanVien emp)
        {
            string query = "sp_addNhanVien";
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaNV", emp.MaNV));
            parameters.Add(new SqlParameter("@MaPB", emp.MaPB));
            parameters.Add(new SqlParameter("@MaCV", emp.MaCV));
            parameters.Add(new SqlParameter("@TenNV", emp.TenNV));
            parameters.Add(new SqlParameter("@GioiTinh", emp.GioiTinh));
            parameters.Add(new SqlParameter("@SoDT", emp.SoDT));
            parameters.Add(new SqlParameter("@LoaiLaoDong", emp.LoaiLaoDong));
            parameters.Add(new SqlParameter("@LuongDonVi", emp.TienTheoDonVi));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }

        public static string UpdateEmployee(NhanVien emp)
        {
            string query = "sp_updateNhanVien";
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaNV", emp.MaNV));
            parameters.Add(new SqlParameter("@MaPB", emp.MaPB));
            parameters.Add(new SqlParameter("@MaCV", emp.MaCV));
            parameters.Add(new SqlParameter("@TenNV", emp.TenNV));
            parameters.Add(new SqlParameter("@GioiTinh", emp.GioiTinh));
            parameters.Add(new SqlParameter("@SoDT", emp.SoDT));
            parameters.Add(new SqlParameter("@LoaiLaoDong", emp.LoaiLaoDong));
            parameters.Add(new SqlParameter("@LuongDonVi", emp.TienTheoDonVi));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }

        public static string DeleteEmployee(string empID)
        {
            string query = "sp_delNhanVien";
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaNV", empID));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }
    }
}
