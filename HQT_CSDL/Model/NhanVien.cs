namespace HQT_CSDL.Model
{
    public class NhanVien
    {
        public NhanVien(string maNV, string maPB, string maCV, string tenNV, string gioiTinh, string soDT, string loaiLaoDong, int tienTheoDonVi)
        {
            MaNV = maNV;
            MaPB = maPB;
            MaCV = maCV;
            TenNV = tenNV;
            GioiTinh = gioiTinh;
            SoDT = soDT;
            LoaiLaoDong = loaiLaoDong;
            TienTheoDonVi = tienTheoDonVi;
        }

        public string MaNV { get; set; }
        public string MaPB { get; set; }
        public string MaCV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }

        public string SoDT { get; set; }
        public string LoaiLaoDong { get; set; }
        public int TienTheoDonVi { get; set; }

    }
}
