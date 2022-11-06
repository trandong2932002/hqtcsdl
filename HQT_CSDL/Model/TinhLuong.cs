using System;

namespace HQT_CSDL.Model
{
    public class TinhLuong
    {
        public TinhLuong(string maNV, int tongLuong, DateTime thoiGianThang)
        {
            MaNV = maNV;
            TongLuong = tongLuong;
            ThoiGianThang = thoiGianThang;
        }

        public string MaNV { get; set; }
        public int TongLuong { get; set; }
        public DateTime ThoiGianThang { get; set; }

    }
}
