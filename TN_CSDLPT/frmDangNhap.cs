using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string chuoiketnoi = "Data Source=DESKTOP-SCSH5OT;Initial Catalog=" + Program.database + ";Integrated Security=True";
            Program.conn.ConnectionString = chuoiketnoi;
            Program.conn.Open();
            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH");
            Program.bds_dspm.DataSource = dt;
            tENCNComboBox.DataSource = dt;
            tENCNComboBox.DisplayMember = "TENCS";
            tENCNComboBox.ValueMember = "TENSERVER";
            tENCNComboBox.SelectedIndex = -1;
            tENCNComboBox.SelectedIndex = 0;
            rdGV.Checked = true;
        }

        private void rdGV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGV.Checked == true)
            {
                txtPass.Enabled = true;
            }
        }

        private void rdSV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSV.Checked == true)
            {
                txtPass.Clear();
                txtPass.Enabled = false;
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
                    MessageBox.Show("Login name không được trống", "", MessageBoxButtons.OK);
                    return;
                }
                Program.mlogin = "SV"; Program.password = "123456";
                if (Program.KetNoi() == 0) return;
                Program.mCoSo = tENCNComboBox.SelectedIndex;
                string strLenh = "EXEC SP_SV '" + txtLogin.Text + "'";

                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader == null) return;
                Program.username = txtLogin.Text;
                Program.myReader.Read();
                try
                {
                    Program.mHoten = Program.myReader.GetString(0);
                }
                catch (Exception)
                {
                    MessageBox.Show("Không tồn tại sinh viên này", "", MessageBoxButtons.OK);
                    return;
                }
                Program.mGroup = "SINHVIEN";
                Program.frmChinh = new frmMain();
                Program.frmChinh.Activate();
                Program.frmChinh.Show();
                Program.frmDN.Visible = false;


               
                Program.frmChinh.MA.Text = "Mã: " + Program.username;
                Program.frmChinh.HOTEN.Text = "Họ và Tên: " + Program.mHoten;
                Program.frmChinh.NHOM.Text = "Nhóm: " + Program.mGroup;
                Program.conn.Close();

                
            }
            else
            {
                if (txtLogin.Text.Trim() == "" || txtPass.Text.Trim() == "")
                {
                    MessageBox.Show("Login name và mật mã không được trống", "", MessageBoxButtons.OK);
                    return;
                }
                Program.mlogin = txtLogin.Text; Program.password = txtPass.Text;
                if (Program.KetNoi() == 0) return;

                Program.mCoSo = tENCNComboBox.SelectedIndex;

                Program.mloginDN = Program.mlogin;
                Program.passwordDN = Program.password;
                string strLenh = "EXEC SP_DANGNHAP_GV '" + Program.mlogin + "'";

                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();


                Program.username = Program.myReader.GetString(0);
                if (Convert.IsDBNull(Program.username))
                {
                    MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username, password", "", MessageBoxButtons.OK);
                    return;
                }
                Program.mHoten = Program.myReader.GetString(1);
                Program.mGroup = Program.myReader.GetString(2);
                Program.myReader.Close();
                Program.conn.Close();

                Program.frmChinh = new frmMain();
                Program.frmChinh.Activate();
                Program.frmChinh.Show();
                Program.frmDN.Visible = false;

                if (Program.mGroup != "SINHVIEN")
                {
                    Program.frmChinh.MA.Text = "Mã: " + Program.username;
                    Program.frmChinh.HOTEN.Text = "Họ và Tên: " + Program.mHoten;
                    Program.frmChinh.NHOM.Text = "Nhóm: " + Program.mGroup;
                }
            }
            MessageBox.Show("Đăng nhập thành công!", "", MessageBoxButtons.OK);

       
            this.SetVisibleCore(false);
            Program.frmChinh.Activate();
            Program.myReader.Close();
            Program.conn.Close();
            Program.frmChinh.Show();
            
        }
    }
}
