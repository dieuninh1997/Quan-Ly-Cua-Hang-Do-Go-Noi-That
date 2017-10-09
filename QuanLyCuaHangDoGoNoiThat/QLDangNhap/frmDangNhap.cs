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
using System.Data.SqlClient;

namespace QuanLyCuaHangDoGoNoiThat
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {


        NhanVienInfo obj = new NhanVienInfo();
        NhanVienBUS bus = new NhanVienBUS();
      //  md5Convert md5 = new md5Convert();


        public frmDangNhap()
        {
            InitializeComponent();
        }

        private bool checkValidateData()
        {
            //  string strConnect = Convert.ToString(QuanLyCuaHangDoGoNoiThat.Properties.Settings.Default.strConnectDAL);
            string strConnect = @"server=DIEUNINH\SQLEXPRESS; database=QuanLyBanHangGo; Integrated Security=True";
            MessageBox.Show(strConnect);
            SqlConnection sqlcon = new SqlConnection(strConnect);

            try
            {
                if(this.txtTaiKhoan.Text.Trim().Equals(string.Empty))
                {
                    this.txtTaiKhoan.Focus();
                    XtraMessageBox.Show("Bạn chưa nhập tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }else if(this.txtMatKhau.Text.Trim().Equals(string.Empty))
                {
                    this.txtMatKhau.Focus();
                    XtraMessageBox.Show("Bạn chưa nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;    
                }
                sqlcon.Open();
                sqlcon.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối!");
                sqlcon.Close();
                return false;
            }
            return true;
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(checkValidateData())
            {
                DataTable dt = bus.GetDataByUserName(txtTaiKhoan.Text.Trim());
                if(dt.Rows.Count==1)
                {
                    // if(md5.md5(txtMatKhau.Text).Equals(dt.Rows[0]["MatKhau"].ToString()))
                    if(txtMatKhau.Text.Equals(dt.Rows[0]["MatKhau"].ToString()))
                    {
                        if(Convert.ToInt32(dt.Rows[0]["TrangThai"])==1)
                        {
                            this.Hide();
                            frmMain frm_main = new frmMain();
                            frmMain.MaNV = dt.Rows[0]["MaNV"].ToString();
                            frmMain.MaNhom = Convert.ToInt32(dt.Rows[0]["MaNhom"].ToString());

                            XtraMessageBox.Show("Bạn đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            frm_main.ShowDialog();


                            if (frm_main.checkDangXuat)
                            {
                                this.Show();
                                txtTaiKhoan.Text = string.Empty;
                                txtMatKhau.Text = string.Empty;
                                txtTaiKhoan.Focus();
                            }
                            else
                                this.Close();

                        }
                        else
                        {
                            XtraMessageBox.Show("Bạn không có quyền truy cập vào hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMatKhau.Text = string.Empty;
                        }
                    }else
                    {
                        XtraMessageBox.Show("Mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhau.Text = string.Empty;
                    }
                }else
                {
                    XtraMessageBox.Show("Tài khoản " + txtTaiKhoan.Text + " không tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaiKhoan.Text = string.Empty;
                    txtMatKhau.Text = string.Empty;
                }
            }

        }

        private void txtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDangNhap.PerformClick();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDangNhap.PerformClick();
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}