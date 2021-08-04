using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace TN_CSDLPT
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            //btnVatTu.Enabled = btnTaoTaiKhoan.Enabled = btnNhanVien.Enabled = false;
            //btnLoaiHang.Enabled = btnNCC.Enabled = btnKho.Enabled = btnKhachHang.Enabled = false;
            //btnDDH.Enabled = btnPN.Enabled = btnPX.Enabled = btnCungCap.Enabled = false;
            //btnINDSNV.Enabled = btnINDSMH.Enabled = btnBKNX.Enabled = btnBKTC.Enabled = false;
            btnDangXuat.Enabled = btnTaoTK.Enabled= btnMonHoc.Enabled = false;           
        }         

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
            else
                return;
        }

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDangNhap));
            if (frm != null) frm.Activate();
            else
            {
                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn chắc có muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Program.frmChinh.MA.Text = " Mã: " + null;
                Program.frmChinh.HOTEN.Text = " Họ Tên: " + null;
                Program.frmChinh.NHOM.Text = " Nhóm: " + null;
                
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm.ShowInTaskbar)
                        frm.Close();
                }

                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;
                f.Show();
                btnDangXuat.Enabled = btnTaoTK.Enabled = btnMonHoc.Enabled = false;
                btnDangNhap.Enabled = true;
            } 
            else
                return;
        }

        private void btnMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmMonHoc));
            if (frm != null) frm.Activate();
            else
            {
                frmMonHoc f = new frmMonHoc();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTaoTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmTaoTK));
            if (frm != null) frm.Activate();
            else
            {
                frmTaoTK f = new frmTaoTK();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnGV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmKhoa));
            if (frm != null) frm.Activate();
            else
            {
                frmKhoa f = new frmKhoa();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmLop));
            if (frm != null) frm.Activate();
            else
            {
                frmLop f = new frmLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBoDe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmNhapDe));
            if (frm != null) frm.Activate();
            else
            {
                frmNhapDe f = new frmNhapDe();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCBT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmChuanBiThi));
            if (frm != null) frm.Activate();
            else
            {
                frmChuanBiThi f = new frmChuanBiThi();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnThi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmThi));
            if (frm != null) frm.Activate();
            else
            {
                frmThi f = new frmThi();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmBDMH));
            if (frm != null) frm.Activate();
            else
            {
                frmBDMH f = new frmBDMH();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
