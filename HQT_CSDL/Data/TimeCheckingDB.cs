using HQT_CSDL.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HQT_CSDL.Data
{
    public static class TimeCheckingDB
    {
        public static string Check(string empID, int workingTime, int overTime)
        {
            string query = "sp_ChamCong";
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@MaNV", empID));
            parameters.Add(new SqlParameter("@MaNV", workingTime));
            parameters.Add(new SqlParameter("@MaNV", overTime));

            return ConnectionDB.ExecStoredProduce(query, parameters);
        }
    }
}
