using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PhanQuyenDAL
    {
        SqlDataProvider db = new SqlDataProvider();

        public DataTable GetDataByMaNhom(int IDNhom)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MaNhom", IDNhom)
            };
            return db.GetDataTable("sp_PhanQuyen_Select_ByMaNhom", param);
        }
        public DataTable GetDataByIDNhomAndIDChucNang(int IDNhom, string MaCV)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MaNhom", IDNhom),
                new SqlParameter("MaCV",MaCV)
            };
            return db.GetDataTable("sp_PhanQuyen_Select_ByMaNhomAndMaCV", param);
        }
        public int Insert(PhanQuyenInfo obj)
        {
            SqlParameter[] param =
            {
               new SqlParameter("MaNhom", obj.MaNhom),
                new SqlParameter("MaCV", obj.MaCV),
                new SqlParameter("Xem", obj.Xem),
                new SqlParameter("Them", obj.Them),
                new SqlParameter("Sua", obj.Sua),
                new SqlParameter("Xoa", obj.Xoa)
            };
            return db.ExcuteSQL("sp_PhanQuyen_Insert", param);
        }
        public int Update(PhanQuyenInfo obj)
        {
            SqlParameter[] param =
            {
                 new SqlParameter("MaNhom", obj.MaNhom),
                new SqlParameter("MaCV", obj.MaCV),
                new SqlParameter("Xem", obj.Xem),
                new SqlParameter("Them", obj.Them),
                new SqlParameter("Sua", obj.Sua),
                new SqlParameter("Xoa", obj.Xoa)
            };
            return db.ExcuteSQL("sp_PhanQuyen_Update", param);
        }

        public int Delete(int IDNhom)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MaNhom", IDNhom)
            };
            return db.ExcuteSQL("sp_PhanQuyen_Delete", param);
        }
    }
}
