using System;

namespace HQT_CSDL.Model
{
    public class TinhLuong
    {
        public string MaNV { get; set; }
        public int TienTheoDonVi { get; set; }
        public string LoaiLaoDong { get; set; }
        public int ThoiGianLamDonVi { get; set; }
        public int TangCa { get; set; }
        public double TienLuong { get; set; }

        public TinhLuong(string maNV, int tienTheoDonVi, string loaiLaoDong, int thoiGianLamDonVi, int tangCa, double tienLuong)
        {
            MaNV = maNV;
            TienTheoDonVi = tienTheoDonVi;
            LoaiLaoDong = loaiLaoDong;
            ThoiGianLamDonVi = thoiGianLamDonVi;
            TangCa = tangCa;
            TienLuong = tienLuong;
        }
    }
}
