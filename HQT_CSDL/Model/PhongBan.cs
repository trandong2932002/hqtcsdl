namespace HQT_CSDL.Model
{
    public class PhongBan
    {
        public PhongBan(string maPB, string maCN, string tenPB)
        {
            MaPB = maPB;
            MaCN = maCN;
            TenPB = tenPB;
        }

        public string MaPB { get; set; }
        public string MaCN { get; set; }
        public string TenPB { get; set; }
    }
}
