using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyCuaHangDoGoNoiThat.BUS
{
    class LoginBUS
    {
        public static string CheckDanhNhap(string _user, string _pass)
        {
            try
            {
                DA.LoginDA login = new DA.LoginDA(_user, _pass);
                return login.CheckDangNhap();

            }catch
            {
                return "";
            }
        }
    }
}
