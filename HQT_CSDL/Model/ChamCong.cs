using System;

namespace HQT_CSDL.Model
{
    public class ChamCong
    {
        public ChamCong(string maNV, string maPB, string maCV, string tenNV, int thoiGianLamDonVi, int tangCa)
        {
            MaNV = maNV;
            MaPB = maPB;
            MaCV = maCV;
            TenNV = tenNV;
            ThoiGianLamDonVi = thoiGianLamDonVi;
            TangCa = tangCa;
            if (thoiGianLamDonVi == 0 && tangCa == 0) IsChecked = false;
            else IsChecked = true;
        }

        public ChamCong() { }

        public string MaNV { get; set; }
        public string MaPB { get; set; }
        public string MaCV { get; set; }
        public string TenNV { get; set; }
        private int thoiGianLamDonVi;
        public int ThoiGianLamDonVi
        {
            get { return thoiGianLamDonVi; }
            set
            {
                thoiGianLamDonVi = value;
                if (value != 0) IsChecked = true;
            }
        }
        private int tangCa;
        public int TangCa
        {
            get { return tangCa; }
            set
            {
                tangCa = value;
                if (value != 0) IsChecked = true;
            }
        }
        public bool IsChecked { get; set; }
    }
}
