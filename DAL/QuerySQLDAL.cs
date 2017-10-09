using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class QuerySQLDAL
    {
        SqlDataProvider db = new SqlDataProvider();

        public DataTable GetDataBySQL(string SQL)
        {
            return db.GetDataTable(SQL);
        }
        public int ExecuteBySQL(string SQL)
        {
            return db.ExcuteSQL(SQL);
        }
    }
}
