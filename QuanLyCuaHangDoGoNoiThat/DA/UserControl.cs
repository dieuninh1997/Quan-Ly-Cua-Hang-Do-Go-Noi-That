using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;//add thu vien


namespace QuanLyCuaHangDoGoNoiThat.DA
{
    class UserControl
    {
        //ham ma hoa mat khau
        public static string SHA256(string pass)
        {
            try
            {
                SHA256Managed crypt = new SHA256Managed();
                string hash = string.Empty;
                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(pass), 0, Encoding.UTF8.GetByteCount(pass));
                foreach(byte bit in crypto)
                {
                    hash += bit.ToString("x2");
                }
                return hash;

            }catch
            {
                return null;
            }
        }
    }
}
