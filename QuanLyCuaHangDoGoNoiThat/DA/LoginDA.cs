using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCuaHangDoGoNoiThat.DA
{
    class LoginDA:SqlDataProvider
    {
        protected string user { get; set; }
        protected string pass { get; set; }

        //biến status: trang thai
        protected bool status { get; set; }

        //ham khoi tao 2 doi so: user,pass de kiem tra dang nhap
        public LoginDA(string _user, string _pass)
        {
            this.user = _user;
            this.pass = _pass;
        }

        //ham check dang nhap
        public string CheckDangNhap()
        {
            string str = "";

            string[] para = new string[2] { "@MaNV", "@MatKhau" };
            object[] value = new object[2] { user, pass };
            str = DA.SqlDataProvider.ExcuteScalar("sp_checkDangNhap",CommandType.StoredProcedure,para,value);         
            return str;
        }
     
    }
}
