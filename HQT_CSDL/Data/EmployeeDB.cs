using HQT_CSDL.Model;
using System.Collections.Generic;
using System.Data;

namespace HQT_CSDL.Data
{
    public static class EmployeeDB
    {
        public static IEnumerable<NhanVien> Load()
        {
            DataTable dataTable = ConnectionDB.LoadTable("select * from nhanvien order by manv");
            foreach (DataRow row in dataTable.Rows)
            {
                string maNV = row["MaNV"].ToString();
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
    }
}
