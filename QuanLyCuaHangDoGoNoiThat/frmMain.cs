using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using QuanLyCuaHangDoGoNoiThat.QLDangNhap;


namespace QuanLyCuaHangDoGoNoiThat
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public bool checkDangXuat = false;
        static public string MaNV { get; set; }
        static public int MaNhom { get; set; }
        QuerySQLBUS query = new QuerySQLBUS();


        public frmMain()
        {
            InitializeComponent();
            DisEndableMenuLogin(true, "");

        }
        public void DisEndableMenuLogin(bool e, string _idLogin)
        {
            btnLogIn.Enabled = e;
            btnChangePass.Enabled = !e;
            btnLogOut.Enabled = !e;
            btnPhanQuyen.Enabled = !e;
            btnBackUp.Enabled = !e;
            btnRestore.Enabled = !e;
            btnNhatKyHoatDong.Enabled = !e;
        }

        public void skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "Money Twins";//tên giao diện (background) muốn hiển thị lúc form khở động, tên này phân biệt hoa thường nhé

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            skins();
           
        }
      
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //khai báo thư viện DevExpress.XtraEditors
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn thoát? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr==DialogResult.No)
            {
                e.Cancel = true;

            }


            timer.Start();
            //user login label
            NhanVienBUS busNV = new NhanVienBUS();
            var dt = busNV.GetDataByID(MaNV);
            //    this.txtUserLogin.Caption = " Tài khoản đang đăng nhập: " + dt.Rows[0]["HoTen"].ToString() + " (" +
            //                            dt.Rows[0]["TaiKhoan"].ToString() + ")";


            //check quyen han
            PhanQuyenBUS busPQ = new PhanQuyenBUS();
            dt = busPQ.GetDataByIDNhom(MaNhom);
            foreach (DataRow item in dt.Rows)
            {
                if (item["MaCV"].Equals("banhang") && Convert.ToInt32(item["Xem"]) == 1)
                {
                   // btn
                }
                if (item["MaCV"].Equals("baocao") && Convert.ToInt32(item["Xem"]) == 1)
                {
                   // btnBCBanHang.Enabled = true;
                   // btnBCSanPham.Enabled = true;
                  //  btnBCKhachHang.Enabled = true;
                  //  btnBCNhaCungCap.Enabled = true;
                  //  btnBCNhanVien.Enabled = true;
                }
                if (item["MaCV"].Equals("donvitinh") && Convert.ToInt32(item["Xem"]) == 1)
                //    btnDonViTinh.Enabled = true;
                if (item["MaCV"].Equals("khachhang") && Convert.ToInt32(item["Xem"]) == 1)
                 //   btnKhachHang.Enabled = true;
                if (item["MaCV"].Equals("loaihang") && Convert.ToInt32(item["Xem"]) == 1)
                 //   btnLoaiHang.Enabled = true;
                if (item["MaCV"].Equals("nhacungcap") && Convert.ToInt32(item["Xem"]) == 1)
                 //   btnNhaCungCap.Enabled = true;
                if (item["MaCV"].Equals("nhaphang") && Convert.ToInt32(item["Xem"]) == 1)
                 //   btnNhapHang.Enabled = true;
                if (item["MaCV"].Equals("qlbanhang") && Convert.ToInt32(item["Xem"]) == 1)
                  //  btnQLBanHang.Enabled = true;
                if (item["MaCV"].Equals("qlnhaphang") && Convert.ToInt32(item["Xem"]) == 1)
                  //  btnQLKhoHang.Enabled = true;
                if (item["MaCV"].Equals("sanpham") && Convert.ToInt32(item["Xem"]) == 1)
                {

                }
                   // btnSanPham.Enabled = true;
            }
            if (MaNhom == 1)
            {
              //  btnNhanVien.Enabled = true;
              //  btnNhomQuyen.Enabled = true;
              //  btnPhanQuyen.Enabled = true;
            }


        }

        private void btnLogIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //add thư viện QuanLyCuaHangDoGoNoiThat.GUI;
        
       }

      
        private void btnLogOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Close();
                this.checkDangXuat = true;
            }


        }

        private void btnChangePass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.MaNV = MaNV;
            frm.ShowDialog();
        }
    }
}
