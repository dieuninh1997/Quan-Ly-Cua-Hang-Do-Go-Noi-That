using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class SqlDataProvider
    {

        private SqlConnection conn = null;
        public static string sqlCon = @"server=DIEUNINH\SQLEXPRESS; database=QuanLyBanHangGo; Integrated Security=True";//chú ý đoạn này phải có Security

        public SqlDataProvider()
        {
            if (conn == null)
            {
                conn = new SqlConnection(sqlCon);
            }
        }

        public DataTable GetDataTable(string strSQL)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable GetDataTable(string procName, SqlParameter[]param)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            if (param != null)
                cmd.Parameters.AddRange(param);
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public int ExcuteSQL(string strSQL)
        {
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            conn.Close();
            return row;
        }
        public int ExcuteSQL(string procName, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            if (param != null)
                cmd.Parameters.AddRange(param);
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            conn.Close();
            return row;
        }

    }
}
