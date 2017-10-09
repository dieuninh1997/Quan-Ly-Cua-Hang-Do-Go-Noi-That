using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using DAL;

namespace QuanLyCuaHangDoGoNoiThat.QLDangNhap
{
    public partial class frmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {

        public string MaNV { get; set; }
        NhanVienInfo obj = new NhanVienInfo();
        NhanVienBUS bus = new NhanVienBUS();
        md5Convert md5 = new md5Convert();


        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}