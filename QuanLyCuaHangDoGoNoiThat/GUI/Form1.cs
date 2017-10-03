using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyCuaHangDoGoNoiThat.GUI;


namespace QuanLyCuaHangDoGoNoiThat
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public static string user;
        public static string id_login;
        //bien manv_login: sau nay sd de phan quyen
       

        public frmMain()
        {
            InitializeComponent();
            DisEndableMenuLogin(true, id_login);

        }
        public void DisEndableMenuLogin(bool e, string _idLogin)
        {
            btnLogIn.Enabled = e;
            btnChangePass.Enabled = !e;
            btnLogOut.Enabled = !e;
            btnPhanQuyen.Enabled = !e;
            btnBackUp.Enabled = !e;
            btnRestore.Enabled = !e;
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
        }

        private void btnLogIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //add thư viện QuanLyCuaHangDoGoNoiThat.GUI;
            ShowLoginDialog();
          
       }

        public void ShowLoginDialog()
        {
         
            frmLogin login = null;
            Check_Login:
            if (login==null || login.IsDisposed)
                login=new frmLogin();

          //  login.BringToFront();
            if (login.ShowDialog() == DialogResult.OK)
            {
                if (login.txtUser.Text == "")
                {
                    XtraMessageBox.Show("Hãy nhập vào tài khoản!");
                    goto Check_Login;
                }
                if (login.txtPass.Text == "")
                {
                    XtraMessageBox.Show("Hãy nhập vào mật khẩu!");
                    goto Check_Login;
                }
                string check = "";
                user = login.txtUser.Text;
                //mật khẩu thì sẽ sd hàm mã hóa SHA256 
                //  string pass = DA.UserControl.SHA256(login.txtPass.Text);

                string pass = login.txtPass.Text;
                check = BUS.LoginBUS.CheckDanhNhap(user, pass);
                if (check == "")
                {
                    XtraMessageBox.Show("Đăng nhập thất bại. Kiểm tra lại tài khoản hoặc mật khẩu!");
                    goto Check_Login;
                }
                else
                {
                    DisEndableMenuLogin(false, id_login);
                }


            }
        }

        private void btnLogOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {

            }


        }
    }
}
