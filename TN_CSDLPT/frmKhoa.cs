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
    public partial class frmKhoa : Form
    {
        public int vitri;
        public int vitriGV;
        public string macs = "";
        public frmKhoa()
        {
            InitializeComponent();
        }

        private void kHOABindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKhoa.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmKhoa_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.BODE' table. You can move, or remove it, as needed.
            this.bODETableAdapter.Connection.ConnectionString = Program.connstr;
            this.bODETableAdapter.Fill(this.dS.BODE);
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
            // TODO: This line of code loads data into the 'dS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);
            // TODO: This line of code loads data into the 'dS.GIAOVIEN' table. You can move, or remove it, as needed.
            this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIENTableAdapter.Fill(this.dS.GIAOVIEN);

            // TODO: This line of code loads data into the 'dS.KHOA' table. You can move, or remove it, as needed.
            this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOATableAdapter.Fill(this.dS.KHOA);

            //macs = ((DataRowView)bdsKhoa[0])["MACS"].ToString();
            
            if (Program.mGroup == "COSO")
            {
                btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThem.Enabled = true;
                grbKhoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
            }
            else
            {
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                btnReload.Enabled = true;
                grbKhoa.Enabled =btnSuaGV.Enabled = btnThemGV.Enabled= btnXoaGV.Enabled =false;
            }
        }

        private void EnableForm()
        {
            grbKhoa.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;

            btnXoa.Enabled = true;
            btnReload.Enabled = true;

            btnGhi.Enabled = false;
            btnUndo.Enabled = false;
        }

        private void DisableForm()
        {
            grbKhoa.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;

            btnXoa.Enabled = false;
            btnReload.Enabled = false;

            btnGhi.Enabled = true;
            btnUndo.Enabled = true;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsKhoa.Position;
            bdsKhoa.AddNew();
            txtMaCS.Text = macs;
            txtMaCS.ReadOnly = true;
            DisableForm();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsGV.Count > 0)
            {
                MessageBox.Show("Đã có giảng viên trong Khoa Không thể xóa!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsLop.Count > 0)
            {
                MessageBox.Show("Khoa đã mở lớp không thể xóa!", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn xóa môn học này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bdsKhoa.RemoveCurrent();

                    this.kHOATableAdapter.Update(this.dS.KHOA);
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
            vitri = bdsKhoa.Position;
            DisableForm();
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp không được để trống!", "", MessageBoxButtons.OK);
                txtMaKhoa.Focus();
                return;
            }
            if (txtTenKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Tên lớp không được để trống!", "", MessageBoxButtons.OK);
                txtTenKhoa.Focus();
                return;
            }
            if (txtMaCS.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn mã khoa!", "", MessageBoxButtons.OK);
                txtMaCS.Focus();
                return;
            }
            string strLenh = "DECLARE @result int " +
                            "EXEC @result = SP_KTMAKHOA '" + txtMaKhoa.Text + "', N'" + txtTenKhoa.Text.Trim() + "' " +
                            " SELECT 'result' = @result";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();
            int positionMAKH = bdsKhoa.Find("MAKH", txtMaKhoa.Text);
            int positionTenKH = bdsKhoa.Find("TENKH", txtTenKhoa.Text);
            if (result == 1 && (bdsKhoa.Position != positionMAKH))
            {
                MessageBox.Show("Mã Khoa đã tồn tại!", "", MessageBoxButtons.OK);
                txtMaKhoa.Focus();
                return;
            }
            if (result == 2 && (bdsKhoa.Position != positionTenKH))
            {
                MessageBox.Show("Tên Khoa đã tồn tại!", "", MessageBoxButtons.OK);
                txtTenKhoa.Focus();
                return;
            }
            try
            {
                bdsKhoa.EndEdit();
                bdsKhoa.ResetCurrentItem();
                this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
                this.kHOATableAdapter.Update(this.dS.KHOA);

                MessageBox.Show("Ghi Khoa thành công!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm Khoa!\n" + ex.Message, "", MessageBoxButtons.OK);
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
                bdsKhoa.Filter = "";
            LoadTable();
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKhoa.CancelEdit();

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

        public string maGV, hoGV, tenGV, diaChiGV;
        public void getValue(string ma, string ho, string ten, string diaChi)
        {
            maGV = ma;
            hoGV = ho;
            tenGV = ten;
            diaChiGV = diaChi;
        }

        private void btnXoaGV_Click(object sender, EventArgs e)
        {
            if (bdsGV_DK.Count > 0)
            {
                MessageBox.Show("Không thể xóa giáo viên đã đăng ký thi!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsBoDe.Count > 0)
            {
                MessageBox.Show("Không thể xóa giáo viên đã lập bộ đề!", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có thực sự muốn xóa giáo viên này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bdsGV.RemoveCurrent();
                    this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.gIAOVIENTableAdapter.Update(this.dS.GIAOVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa giáo viên!\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void btnSuaGV_Click(object sender, EventArgs e)
        {
            vitri = bdsKhoa.Position;
            vitriGV = bdsGV.Position;
            frmGiangVien frm = new frmGiangVien();
            frm.magv = ((DataRowView)bdsGV[bdsGV.Position])["MAGV"].ToString();
            frm.hogv = ((DataRowView)bdsGV[bdsGV.Position])["HO"].ToString();
            frm.tengv = ((DataRowView)bdsGV[bdsGV.Position])["TEN"].ToString();
            frm.diachigv = ((DataRowView)bdsGV[bdsGV.Position])["DIACHI"].ToString();
            frm.maKH = ((DataRowView)bdsKhoa[bdsKhoa.Position])["MAKH"].ToString();
            frm.mydata = new frmGiangVien.GETDATA(getValue);
            frm.ShowDialog();
            if (frm.flagAdd)
            {
                ghiGV();
            }
            else
            {
                bdsGV.Position = vitriGV;
                bdsGV.CancelEdit();
            }
        }

        private void btnThemGV_Click(object sender, EventArgs e)
        {
            vitri = bdsLop.Position;
            vitriGV = bdsGV.Position;
            bdsGV.AddNew();
            frmGiangVien frm = new frmGiangVien();
            frm.maKH = ((DataRowView)bdsKhoa[bdsKhoa.Position])["MAKH"].ToString();
            frm.mydata = new frmGiangVien.GETDATA(getValue);
            frm.ShowDialog();

            if (frm.flagAdd)
            {
                ghiGV();
            }
            else
            {

                bdsGV.CancelEdit();
                bdsGV.Position = vitriGV;

            }
        }       

        private void ghiGV()
        {
            try
            {
                ((DataRowView)bdsGV[bdsGV.Position])["MAGV"] = maGV;
                ((DataRowView)bdsGV[bdsGV.Position])["HO"] = hoGV;
                ((DataRowView)bdsGV[bdsGV.Position])["TEN"] = tenGV;
                ((DataRowView)bdsGV[bdsGV.Position])["DIACHI"] = diaChiGV;
                ((DataRowView)bdsGV[bdsGV.Position])["MAKH"] = ((DataRowView)bdsKhoa[bdsKhoa.Position])["MAKH"].ToString();
                bdsGV.EndEdit();
                bdsGV.ResetCurrentItem();
                bdsKhoa.Position = vitri;
                bdsGV.Position = vitriGV;
                this.gIAOVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gIAOVIENTableAdapter.Update(this.dS.GIAOVIEN);

                MessageBox.Show("Ghi giáo viên thành công!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm giáo viên!\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
