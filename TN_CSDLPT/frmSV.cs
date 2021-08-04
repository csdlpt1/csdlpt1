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
    public partial class frmSV : Form
    {
        public int vitri;
        public bool flagAdd = false;
        public string masv = "", hosv, tensv, ngaysinh, diachisv, maLop;

        private void btnUndo_Click(object sender, EventArgs e)
        {
            flagAdd = false;
            Close();

        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (check())
            {
                mydata(txtMaSV.Text, txtHoSV.Text, txtTenSV.Text, dateNgaySinh.Text, txtDiaChi.Text);
                flagAdd = true;
                Close();
            }
        }

        public frmSV()
        {
            InitializeComponent();
        }

        private void sINHVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sINHVIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        public delegate void GETDATA(string maSV, string ho, string ten, string ngaySinh, string diaChi);
        public GETDATA mydata;

        private void frmSV_Load(object sender, EventArgs e)
        {
 
            dS.EnforceConstraints = false;
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);

            txtMaSV.Text = masv;
            txtHoSV.Text = hosv;
            txtTenSV.Text = tensv;
            txtDiaChi.Text = diachisv;
            dateNgaySinh.Text = ngaysinh;
            txtMaLop.Text = maLop;
        }

        private bool check()
        {
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được để trống!", "", MessageBoxButtons.OK);
                txtMaSV.Focus();
                return false;
            }
            if (txtTenSV.Text.Trim() == "" || txtHoSV.Text.Trim() == "")
            {
                MessageBox.Show("Họ và Tên sinh viên không được để trống!", "", MessageBoxButtons.OK);
                txtTenSV.Focus();
                return false;
            }

            string strLenh = "DECLARE @result int " +
            "EXEC @result = SP_KTMASV '" + txtMaSV.Text + "'" +
            " SELECT 'result' = @result";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return false;
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();


            if (result == 1 && (masv.Trim().CompareTo(txtMaSV.Text.Trim()) != 0))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "", MessageBoxButtons.OK);
                txtMaSV.Focus();
                return false;
            }

            return true;

        }
    }
}
