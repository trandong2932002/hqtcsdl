using System;

namespace HQT_CSDL.Model
{
    public class ChamCong
    {
        public ChamCong(string maNV, int thoiGianLamDonVi, int tangCa, DateTime ngayChamCong)
        {
            MaNV = maNV;
            ThoiGianLamDonVi = thoiGianLamDonVi;
            TangCa = tangCa;
            NgayChamCong = ngayChamCong;
        }

        public string MaNV { get; set; }
        public int ThoiGianLamDonVi { get; set; }
        public int TangCa { get; set; }
        public DateTime NgayChamCong { get; set; }
    }
}
