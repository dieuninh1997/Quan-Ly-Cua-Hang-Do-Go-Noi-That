using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BUS
{
    public class PhanQuyenBUS
    {
        PhanQuyenDAL dal = new PhanQuyenDAL();

        public DataTable GetDataByIDNhom(int IDNhom)
        {
            return dal.GetDataByMaNhom(IDNhom);
        }
        public DataTable GetDataByIDNhomAndIDChucNang(int IDNhom, string IDChucNhang)
        {
            return dal.GetDataByIDNhomAndIDChucNang(IDNhom, IDChucNhang);
        }
        public int Insert(PhanQuyenInfo obj)
        {
            return dal.Insert(obj);
        }
        public int Update(PhanQuyenInfo obj)
        {
            return dal.Update(obj);
        }
        public int Delete(int IDNhom)
        {
            return dal.Delete(IDNhom);
        }
    }
}
