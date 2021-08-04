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
    public partial class frmChuanBiThi : Form
    {
        public int vitri;
        public frmChuanBiThi()
        {
            InitializeComponent();
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGVDK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmChuanBiThi_Load(object sender, EventArgs e)
        {
            LoadTable();          
        }
        private void LoadTable()
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            // TODO: This line of code loads data into the 'dS.GIAOVIEN' table. You can move, or remove it, as needed.
            this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);
            // TODO: This line of code loads data into the 'dS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);

            cmbTrinhDo.SelectedIndex = 0;
            if (Program.mGroup == "COSO")
            {
                btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThem.Enabled = true;
                grbGVDK.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
            }
            else
            {
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                btnReload.Enabled = true;
                grbGVDK.Enabled = false;
            }
        }
        private void EnableForm()
        {
            grbGVDK.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;

            btnXoa.Enabled = true;
            btnReload.Enabled = true;

            btnGhi.Enabled = false;
            btnUndo.Enabled = false;
        }

        private void DisableForm()
        {
            grbGVDK.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;

            btnXoa.Enabled = false;
            btnReload.Enabled = false;

            btnGhi.Enabled = true;
            btnUndo.Enabled = true;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsGVDK.Position;
            bdsGVDK.AddNew();
            seLan.Value = 1;
            seSoCau.Value = 10;
            seThoiGian.Value = 15;
            DisableForm();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa môn học này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bdsGVDK.RemoveCurrent();

                    this.gIAOVIEN_DANGKYTableAdapter.Update(this.dS.GIAOVIEN_DANGKY);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa đăng k!\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsGVDK.Position;
            DisableForm();
        }

        private bool checkExists()
        {
            string strLenh = "DECLARE @result int " +
                           "EXEC @result = SP_DANGKYTHI N'" + cmbMaMH.SelectedValue.ToString() + "', N'"
                           + cmbMaLop.SelectedValue.ToString() + "', N'"
                           + seLan.Value + "' " +
                           " SELECT 'result' = @result";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return false;
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();
            if (result == 1)
            {
                return false;
            }
            else
                return true;

        }

        private bool checkSLCH()
        {
            string str = "DECLARE @result int " +
                           "EXEC @result = SP_KTSLCAUHOI N'" + cmbMaMH.SelectedValue.ToString() + "', N'"
                           + cmbTrinhDo.SelectedItem.ToString() + "', "
                           + seSoCau.Value + " SELECT 'result' = @result";
            Program.myReader = Program.ExecSqlDataReader(str);
            if (Program.myReader == null) return false;
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();
            if (result == 1)
            {
                return false;
            }
            else
                return true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cmbMaGV.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã giảng viên!", "", MessageBoxButtons.OK);
                cmbMaGV.Focus();
                return;
            }
            if (cmbMaMH.Text == null)
            {
                MessageBox.Show("Vui lòng chọn mã môn học!", "", MessageBoxButtons.OK);
                cmbMaMH.Focus();
                return;
            }
            if (cmbMaLop.Text == null)
            {
                MessageBox.Show("Vui lòng chọn mã lớp!", "", MessageBoxButtons.OK);
                cmbMaLop.Focus();
                return;
            }
            if (cmbTrinhDo.Text.Trim() == null)
            {
                MessageBox.Show("Vui lòng chọn trình độ!", "", MessageBoxButtons.OK);
                cmbTrinhDo.Focus();
                return;
            }
            if (dateNgayThi.Value < DateTime.Today)
            {
                MessageBox.Show("Không thể chọn ngày thi ở quá khứ!", "", MessageBoxButtons.OK);
                dateNgayThi.Focus();
                return;
            }
            if (seLan.Value > 2 || seLan.Value < 1)
            {
                MessageBox.Show("Lần thi phải lớn hơn hoặc bằng 1 và nhỏ hơn hoặc bằng 2!", "", MessageBoxButtons.OK);
                seLan.Focus();
                return;
            }
            if (seSoCau.Value < 10 || seSoCau.Value > 100)
            {
                MessageBox.Show("Số câu thi phải lớn hơn hoặc bằng 10 và nhỏ hơn hoặc bằng 100!", "", MessageBoxButtons.OK);
                seSoCau.Focus();
                return;
            }
            if (seThoiGian.Value > 60 || seThoiGian.Value < 15)
            {
                MessageBox.Show("Thời gian thi phải từ 15 đến 60 phút!", "", MessageBoxButtons.OK);
                seThoiGian.Focus();
                return;
            }

            if (!checkExists())
            {
                MessageBox.Show("Lỗi! Môn học " + cmbMaMH.Text + " đã được đăng ký cho lớp " + cmbMaLop.Text
                    + " thi lần " + seLan.Value + " trước đó", "", MessageBoxButtons.OK);
                LoadTable();
                return;               
            }
            if (!checkSLCH())
            {
                MessageBox.Show("Số lượng câu hỏi trong CSDL không đáp ứng đủ cho đề thi này!", "", MessageBoxButtons.OK);
                return;
            }
            try
            {
                ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAGV"] = cmbMaGV.Text;
                ((DataRowView)bdsGVDK[bdsGVDK.Position])["MAMH"] = cmbMaMH.SelectedValue.ToString();
                ((DataRowView)bdsGVDK[bdsGVDK.Position])["MALOP"] = cmbMaLop.SelectedValue.ToString();
                ((DataRowView)bdsGVDK[bdsGVDK.Position])["TRINHDO"] = cmbTrinhDo.Text;
                ((DataRowView)bdsGVDK[bdsGVDK.Position])["NGAYTHI"] = dateNgayThi.Value.ToString("dd/MM/yyyy");
                ((DataRowView)bdsGVDK[bdsGVDK.Position])["LAN"] = seLan.Value;
                ((DataRowView)bdsGVDK[bdsGVDK.Position])["SOCAUTHI"] = seSoCau.Value;
                ((DataRowView)bdsGVDK[bdsGVDK.Position])["THOIGIAN"] = seThoiGian.Value;
                bdsGVDK.EndEdit();
                bdsGVDK.ResetCurrentItem();
                bdsGVDK.Position = vitri;

                this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr; 
                this.gIAOVIEN_DANGKYTableAdapter.Update(this.dS.GIAOVIEN_DANGKY);

                MessageBox.Show("Ghi bản đăng ký thành công!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm bản đăng ký!\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }

            EnableForm();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muôn tải lại danh sánh không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;
            else
                bdsGV.Filter = "";
            LoadTable();
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsGVDK.CancelEdit();

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
