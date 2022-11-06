using HQT_CSDL.Model;
using System.Collections.Generic;
using System.Data;

namespace HQT_CSDL.Data
{
    public static class JobDB
    {
        public static IEnumerable<CongViec> Load()
        {
            DataTable dataTable = ConnectionDB.LoadTable("select * from congviec order by macv");
            foreach (DataRow row in dataTable.Rows)
            {
                string maCV = row["MaCV"].ToString();
                string tenCV = row["TenCV"].ToString();
                string moTaCV = row["MoTaCV"].ToString();

                CongViec congViec = new CongViec(maCV, tenCV, moTaCV);
                yield return congViec;
            }
        }
    }
}
