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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tN_CSDLPTDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.tN_CSDLPTDataSet.V_DS_PHANMANH);
            tENCNComboBox.SelectedIndex = 1;
            tENCNComboBox.SelectedIndex = 0;
            rdGV.Checked = true;
        }

        private void tENCNComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tENCNComboBox.SelectedValue != null)
            {
                try
                {
                    Program.servername = tENCNComboBox.SelectedValue.ToString();
                }
                catch (Exception) { }
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {           
            if (rdSV.Checked == true)
            {
                if (txtLogin.Text.Trim() == "")
                {
                    MessageBox.Show("Tên đăng nhập không được trống", "", MessageBoxButtons.OK);
                    return;
                }

                Program.mlogin = txtLogin.Text;
                Program.password = "123456";
                if (Program.KetNoi() == 0) return;

                Program.mloginDN = Program.mlogin;
                Program.passwordDN = Program.password;
                Program.mCoSo = tENCNComboBox.SelectedIndex;
                Program.bds_dspm = bdsDSPM;

                string strLenh = "EXEC SP_DANGNHAP_SV '" + Program.mlogin + "'";
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();

                try
                {
                    Program.username = Program.myReader.GetString(0);
                }
                catch (Exception)
                {
                    MessageBox.Show("Không tồn Sinh Viên này", "", MessageBoxButtons.OK);
                    return;
                }
                if (Convert.IsDBNull(Program.username))
                {
                    MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username, password", "", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                if (txtLogin.Text.Trim() == "" || txtPass.Text.Trim() == "")
                {
                    MessageBox.Show("Tên đăng nhập và mật khẩu không được trống", "", MessageBoxButtons.OK);
                    return;
                }
                Program.mlogin = txtLogin.Text;
                Program.password = txtPass.Text;
                if (Program.KetNoi() == 0) return;

                Program.mloginDN = Program.mlogin;
                Program.passwordDN = Program.password;
                Program.mCoSo = tENCNComboBox.SelectedIndex;
                Program.bds_dspm = bdsDSPM;

                string strLenh = "EXEC SP_DANGNHAP_GV '" + Program.mlogin + "'";
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();

                try
                {
                    Program.username = Program.myReader.GetString(0);
                }
                catch (Exception)
                {
                    MessageBox.Show("Không tồn Giáo Viên này", "", MessageBoxButtons.OK);
                    return;
                }

                if (Convert.IsDBNull(Program.username))
                {
                    MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username, password", "", MessageBoxButtons.OK);
                    return;
                }

                Program.mHoten = Program.myReader.GetString(1);
                Program.mGroup = Program.myReader.GetString(2);
                

                if (Program.mGroup != "SINHVIEN")
                {
                    Program.frmChinh.MA.Text = "Mã: " + Program.username;
                    Program.frmChinh.HOTEN.Text = "Họ và Tên: " + Program.mHoten;
                    Program.frmChinh.NHOM.Text = "Nhóm: " + Program.mGroup;
                }               
            }
            this.SetVisibleCore(false);
            Program.frmChinh.Activate();
            Program.myReader.Close();
            Program.conn.Close();
            Program.frmChinh.Show();
            Program.frmChinh.btnDangXuat.Enabled = Program.frmChinh.btnTaoTK.Enabled = Program.frmChinh.btnMonHoc.Enabled = true;
            Program.frmChinh.btnDangNhap.Enabled = false;

        }

        private void rdSV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSV.Checked == true)
            {
                txtPass.Clear();
                txtPass.Enabled = false;

            }
        }

        private void rdGV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGV.Checked == true)
            {
                txtPass.Enabled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
            else
                return;
        }

        //Program.mHoten = Program.myReader.GetString(1);
        //Program.mGroup = Program.myReader.GetString(2);
        //Program.myReader.Close();
        //Program.conn.Close();
        //this.SetVisibleCore(false);

        //Program.frmChinh.MA.Text = " Mã: " + Program.username;
        //Program.frmChinh.HOTEN.Text = " Họ Tên NV: " + Program.mHoten;
        //Program.frmChinh.NHOM.Text = " Nhóm: " + Program.mGroup;
        //Program.frmChinh.Show();

        //this.Hide();

        //Program.frmChinh.btnVatTu.Enabled = Program.frmChinh.btnTaoTaiKhoan.Enabled = Program.frmChinh.btnNhanVien.Enabled = true;
        //Program.frmChinh.btnLoaiHang.Enabled = Program.frmChinh.btnNCC.Enabled = Program.frmChinh.btnKho.Enabled = true;
        //Program.frmChinh.btnKhachHang.Enabled = Program.frmChinh.btnDDH.Enabled = Program.frmChinh.btnPN.Enabled = true;
        //Program.frmChinh.btnPX.Enabled = Program.frmChinh.btnCungCap.Enabled = true;
        //Program.frmChinh.btnINDSNV.Enabled = Program.frmChinh.btnINDSMH.Enabled = true;
        //Program.frmChinh.btnBKNX.Enabled = Program.frmChinh.btnBKTC.Enabled = Program.frmChinh.btnHDNV.Enabled = true;

        //if (Program.mGroup == "USER")
        //{
        //    Program.frmChinh.btnINDSNV.Enabled = Program.frmChinh.btnINDSMH.Enabled = false;
        //    Program.frmChinh.btnBKNX.Enabled = Program.frmChinh.btnBKTC.Enabled = false;
        //}
    }
}
