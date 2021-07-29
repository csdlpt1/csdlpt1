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
    public partial class frmTaoTK : Form
    {
        public frmTaoTK()
        {
            InitializeComponent();
        }

        private void gIAOVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gIAOVIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmTaoTK_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);

            if (Program.mGroup == "TRUONG")
            {
                rdCoSo.Enabled = rdGV.Enabled = false;
            }
            if (Program.mGroup == "COSO")
            {
                rdTruong.Enabled = false;
            }
            if (Program.mGroup == "GIANGVIEN")
            {
                rdCoSo.Enabled = rdTruong.Enabled = false;
            }
        }

        private void rdTruong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTruong.Checked == true)
            {
                cmbUsername.DataSource = gIAOVIENBindingSource;
                cmbUsername.DisplayMember = cmbUsername.ValueMember = "MAGV";
                txtLoginName.Text = "";
                txtLoginName.ReadOnly = false;
            }
        }

        private void rdCoSo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCoSo.Checked == true)
            {
                cmbUsername.DataSource = gIAOVIENBindingSource;
                cmbUsername.DisplayMember = cmbUsername.ValueMember = "MAGV";
                txtLoginName.Text = "";
                txtLoginName.ReadOnly = false;
            }
        }

        private void rdGV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGV.Checked == true)
            {
                cmbUsername.DataSource = gIAOVIENBindingSource;
                cmbUsername.DisplayMember = cmbUsername.ValueMember = "MAGV";
                txtLoginName.Text = "";
                txtLoginName.ReadOnly = false;
            }
        }

        private string role()
        {
            string str = "";
            if (rdTruong.Checked == true) str = "TRUONG";
            if (rdCoSo.Checked == true) str = "COSO";
            if (rdGV.Checked == true) str = "GIANGVIEN";
            return str;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (txtLoginName.Text.Trim() == null)
            {
                MessageBox.Show("Vui lòng nhập LoginName!", "", MessageBoxButtons.OK);
                txtLoginName.Focus();
                return;
            }
            if (txtPass.Text.Trim().CompareTo(txtConfirmPass.Text.Trim()) != 0)
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng!", "", MessageBoxButtons.OK);
                txtPass.Focus();
                return;
            }
            string strLenh = "DECLARE @result int " +
                            "EXEC @result = SP_TAOTAIKHOAN N'" + txtLoginName.Text + "', N'" + txtPass.Text.Trim() + "', N'" +
                            cmbUsername.Text + "', N'" + role() + "'" +
                            " SELECT 'result' = @result";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();
            if (result == 0)
            {
                MessageBox.Show("Tạo tài khoản thành công!", "", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
