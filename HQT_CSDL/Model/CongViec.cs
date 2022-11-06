namespace HQT_CSDL.Model
{
    public class CongViec
    {
        public CongViec(string maCV, string tenCV, string moTaCV)
        {
            MaCV = maCV;
            TenCV = tenCV;
            MoTaCV = moTaCV;
        }

        public string MaCV { get; set; }
        public string TenCV { get; set; }
        public string MoTaCV { get; set; }
    }
}
