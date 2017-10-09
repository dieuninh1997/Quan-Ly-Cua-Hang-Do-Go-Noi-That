using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;


namespace BUS
{
    class NhomQuyenBUS
    {

        NhomQuyenDAL dal = new NhomQuyenDAL();
        public DataTable GetData()
        {
            return dal.GetData();
        }
        public DataTable GetDataByID(int IDNhom)
        {
            return dal.GetDataByID(IDNhom);
        }
        public DataTable GetDataNotInPhanQuyen()
        {
            return dal.GetDataNotInPhanQuyen();
        }
        public DataTable GetDataInPhanQuyen()
        {
            return dal.GetDataInPhanQuyen();
        }
        public int Insert(NhomQuyenInfo obj)
        {
            return dal.Insert(obj);
        }
        public int Update(NhomQuyenInfo obj)
        {
            return dal.Update(obj);
        }
        public int Delete(int IDNhom)
        {
            return dal.Delete(IDNhom);
        }
    }
}
