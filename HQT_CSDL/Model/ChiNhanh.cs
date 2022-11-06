namespace HQT_CSDL.Model
{
    public class ChiNhanh
    {
        public ChiNhanh(string maCN, string diaChi, string soDT)
        {
            MaCN = maCN;
            DiaChi = diaChi;
            SoDT = soDT;
        }

        public string MaCN { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }
    }
}
