using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ChucVuDAL
    {
        SqlDataProvider db = new SqlDataProvider();

        public DataTable GetData()
        {
            return db.GetDataTable("sp_ChucVu_Select_All", null);
        }
        public DataTable GetDataByID(string IDChucNang)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MaCV", IDChucNang)
            };
            return db.GetDataTable("sp_ChucVu_Select_ByID", param);
        }

    }
}
