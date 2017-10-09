using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;


namespace BUS
{
    public class ChucVuBUS
    {
        ChucVuDAL dal = new ChucVuDAL();
        public DataTable GetData()
        {
            return dal.GetData();
        }
        public DataTable GetDataByID(string IDChucVu)
        {
            return dal.GetDataByID(IDChucVu);
        }
    }
}
