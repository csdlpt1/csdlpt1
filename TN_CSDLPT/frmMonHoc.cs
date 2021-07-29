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
    public partial class frmMonHoc : Form
    {
        public int vitri;
        public frmMonHoc()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            LoadTable();
        }
        private void LoadTable()
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter1.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter1.Fill(this.dS.MONHOC);
            // TODO: This line of code loads data into the 'dS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);
            // TODO: This line of code loads data into the 'dS.BODE' table. You can move, or remove it, as needed.
            this.bODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.bODETableAdapter.Fill(this.dS.BODE);
            // TODO: This line of code loads data into the 'dS.BANGDIEM' table. You can move, or remove it, as needed.
            this.bANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.bANGDIEMTableAdapter.Fill(this.dS.BANGDIEM);
           
            if (Program.mGroup == "COSO")
            {
                btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThem.Enabled = true;
                grbMonHoc.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
            }
            else
            {
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                btnReload.Enabled = true;
                grbMonHoc.Enabled = false;
            }
        }

        private void EnableForm()
        {
            grbMonHoc.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;

            btnXoa.Enabled = true;
            btnReload.Enabled = true;

            btnGhi.Enabled = false;
            btnUndo.Enabled = false;
        }

        private void DisableForm()
        {
            grbMonHoc.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;

            btnXoa.Enabled = false;
            btnReload.Enabled = false;

            btnGhi.Enabled = true;
            btnUndo.Enabled = true;
        }


        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsMonHoc.Position;
            bdsMonHoc.AddNew();
            DisableForm();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsBangDiem.Count > 0)
            {
                MessageBox.Show("Không thể xóa môn học đã lập bảng điểm!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsBoDe.Count > 0)
            {
                MessageBox.Show("Không thể xóa môn học đã lập bộ đề!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsGV_DK.Count > 0)
            {
                MessageBox.Show("Không thể xóa môn học đã nhập giáo viên đăng ký!", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn xóa môn học này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bdsMonHoc.RemoveCurrent();

                    this.mONHOCTableAdapter1.Update(this.dS.MONHOC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa môn học!\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsMonHoc.Position;
            DisableForm();
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không được để trống!", "", MessageBoxButtons.OK);
                txtMaMH.Focus();
                return;
            }
            if (txtTenMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn học không được để trống!", "", MessageBoxButtons.OK);
                txtTenMH.Focus();
                return;
            }
            string strLenh = "DECLARE @result int " +
                            "EXEC @result = SP_KTMAMH '" + txtMaMH.Text + "', N'" + txtTenMH.Text.Trim() + "' " +
                            " SELECT 'result' = @result";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();
            int positionMAMH = bdsMonHoc.Find("MAMH", txtMaMH.Text);
            int positionTenMH = bdsMonHoc.Find("TENMH", txtTenMH.Text);
            if (result == 1 && (bdsMonHoc.Position != positionMAMH))
            {
                MessageBox.Show("Mã môn học đã tồn tại!", "", MessageBoxButtons.OK);
                txtMaMH.Focus();

                return;
            }
            if (result == 2 && (bdsMonHoc.Position != positionTenMH))
            {
                MessageBox.Show("Tên môn học đã tồn tại!", "", MessageBoxButtons.OK);
                txtMaMH.Focus();

                return;
            }

            try
            {
                bdsMonHoc.EndEdit();
                bdsMonHoc.ResetCurrentItem();

                this.mONHOCTableAdapter1.Connection.ConnectionString = Program.connstr;
                this.mONHOCTableAdapter1.Update(this.dS.MONHOC);

                MessageBox.Show("Ghi môn học thành công!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm môn học!\n" + ex.Message, "", MessageBoxButtons.OK);
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
                bdsMonHoc.Filter = "";
            LoadTable();
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsMonHoc.CancelEdit();

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
