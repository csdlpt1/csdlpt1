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
    public partial class frmGiangVien : Form
    {
        public int vitri;
        public bool flagAdd = false;
        public delegate void GETDATA(string ma, string ho, string ten, string diaChi);
        public GETDATA mydata;
        public string magv = "", hogv, tengv, ngaysinhgv, diachigv, maKH;

        private void btnUndo_Click(object sender, EventArgs e)
        {
            flagAdd = false;
            Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (check())
            {
                mydata(txtMaGV.Text, txtHo.Text, txtTen.Text, txtDiaChi.Text);
                flagAdd = true;
                Close();
            }
        }

        public frmGiangVien()
        {
            InitializeComponent();
        }

        private void gIAOVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.GIAOVIEN' table. You can move, or remove it, as needed.
            this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);

            txtMaGV.Text = magv;
            txtHo.Text = hogv;
            txtTen.Text = tengv;
            txtDiaChi.Text = diachigv;
            txtMaKH.Text = maKH;
            txtMaKH.ReadOnly = true;
        }

        private bool check()
        {
            if (txtMaGV.Text.Trim() == "")
            {
                MessageBox.Show("Mã giáo viên không được để trống!", "", MessageBoxButtons.OK);
                return false;
            }
            if (txtTen.Text.Trim() == "" || txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ và Tên giáo viên không được để trống!", "", MessageBoxButtons.OK);
                return false;
            }

            string strLenh = "DECLARE @result int " +
            "EXEC @result = SP_KTMAGV '" + txtMaGV.Text + "'" +
            " SELECT 'result' = @result";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return false;
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();

            if (result == 1 && (magv.Trim().CompareTo(txtMaGV.Text.Trim()) != 0))
            {
                MessageBox.Show("Mã giáo viên đã tồn tại!", "", MessageBoxButtons.OK);
                return false;
            }

            return true;

        }
    }
}
