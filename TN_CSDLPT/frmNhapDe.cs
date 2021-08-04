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
    public partial class frmNhapDe : Form
    {
        public int vitri;
        public frmNhapDe()
        {
            InitializeComponent();
        }

        private void bODEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsBoDe.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmNhapDe_Load(object sender, EventArgs e)
        {
            LoadTable();
        }
        private void LoadTable()
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            // TODO: This line of code loads data into the 'dS.BODE' table. You can move, or remove it, as needed.
            this.bODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.bODETableAdapter.Fill(this.dS.BODE);

            if (Program.mGroup == "COSO")
            {
                btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThem.Enabled = true;
                grcBoDe.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
            }
            else if (Program.mGroup == "GIANGVIEN")
            {
                btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThem.Enabled = true;
                grcBoDe.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
            }
            else
            {
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                btnReload.Enabled = true;
                grcBoDe.Enabled = false;
            }
        }
        private void EnableForm()
        {
            grcBoDe.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;

            btnXoa.Enabled = true;
            btnReload.Enabled = true;

            btnGhi.Enabled = false;
            btnUndo.Enabled = false;
        }

        private void DisableForm()
        {
            grcBoDe.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;

            btnXoa.Enabled = false;
            btnReload.Enabled = false;

            btnGhi.Enabled = true;
            btnUndo.Enabled = true;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsBoDe.Position;
            bdsBoDe.AddNew();

            string strLenh = "DECLARE @result int " +
                            "EXEC @result = SP_MAXCH " +
                            " SELECT 'result' = @result";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();
            speCauHoi.Value = result + 1;
            cmbTrinhDo.SelectedIndex = cmbDapAn.SelectedIndex = -1;
            txtMaGV.Text = Program.username;
            DisableForm();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {          
            if (MessageBox.Show("Bạn có thực sự muốn xóa môn học này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bdsBoDe.RemoveCurrent();

                    this.bODETableAdapter.Update(this.dS.BODE);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa Đề!\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsBoDe.Position;
            DisableForm();
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cmbMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn mã môn học!", "", MessageBoxButtons.OK);
                cmbMaMH.Focus();
                return;
            }
            if (cmbTrinhDo.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn trình độ!", "", MessageBoxButtons.OK);
                cmbTrinhDo.Focus();
                return;
            }
            if (txtNoiDung.Text.Trim() == "" || txtA.Text.Trim() == "" ||
                txtB.Text.Trim() == "" || txtC.Text.Trim() == "" || txtD.Text.Trim() == "")
            {
                MessageBox.Show("Nội dung và đáp án không được để trống!", "", MessageBoxButtons.OK);
                return;
            }
            if (cmbDapAn.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn đáp án đúng!", "", MessageBoxButtons.OK);
                cmbDapAn.Focus();
                return;
            }
            try
            {
                bdsBoDe.EndEdit();
                bdsBoDe.ResetCurrentItem();

                this.bODETableAdapter.Connection.ConnectionString = Program.connstr;
                this.bODETableAdapter.Update(this.dS.BODE);

                MessageBox.Show("Ghi câu hỏi thành công!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi câu hỏi!\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            LoadTable();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muôn tải lại danh sánh không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;
            else
                bdsBoDe.Filter = "";
            LoadTable();
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsBoDe.CancelEdit();

            if (btnThem.Enabled == false)
                LoadTable();
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
    }
}
