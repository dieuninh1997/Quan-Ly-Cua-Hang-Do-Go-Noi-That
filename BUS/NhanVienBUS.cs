using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAL;


namespace BUS
{
    public class NhanVienBUS
    {
        NhanVienDAL dal = new NhanVienDAL();
        public DataTable GetData()
        {
            return dal.GetData();
        }

        public DataTable GetDataByID(string IDNhanVien)
        {
            return dal.GetDataByID(IDNhanVien);
        }

        public DataTable GetDataByUserName(string TaiKhoan)
        {
            return dal.GetDataByUserName(TaiKhoan);
        }

        public int Insert(NhanVienInfo obj)
        {
            return dal.Insert(obj);
        }
        public int Update(NhanVienInfo obj)
        {
            return dal.Update(obj);
        }
        public int UpdatePassword(string IDNhanVien, string MatKhau)
        {
            return dal.UpdatePassword(IDNhanVien, MatKhau);
        }
        public int Delete(string IDNhanVien)
        {
            return dal.Delete(IDNhanVien);
        }
    }
}
