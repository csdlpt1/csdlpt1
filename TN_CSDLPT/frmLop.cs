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
    public partial class frmLop : Form
    {
        public int vitri;
        public int vitriSV;
        public frmLop()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmLop_Load(object sender, EventArgs e)
        {           
            LoadTable();           
        }
        private void LoadTable()
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.KHOA' table. You can move, or remove it, as needed.
            this.kHOATableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOATableAdapter.Fill(this.dS.KHOA);
            // TODO: This line of code loads data into the 'dS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);
            // TODO: This line of code loads data into the 'dS.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
            // TODO: This line of code loads data into the 'dS.BANGDIEM' table. You can move, or remove it, as needed.
            this.bANGDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.bANGDIEMTableAdapter.Fill(this.dS.BANGDIEM);
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);

            if (Program.mGroup == "COSO")
            {
                btnSua.Enabled = btnXoa.Enabled = btnReload.Enabled = btnThem.Enabled = true;
                grbLop.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
            }
            else
            {
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnUndo.Enabled = false;
                btnReload.Enabled = true;
                grbLop.Enabled = btnSuaSV.Enabled = btnThemSV.Enabled = btnXoaSV.Enabled = false;
            }           
        }

        private void EnableForm()
        {
            grbLop.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;

            btnXoa.Enabled = true;
            btnReload.Enabled = true;

            btnGhi.Enabled = false;
            btnUndo.Enabled = false;
        }

        private void DisableForm()
        {
            grbLop.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;

            btnXoa.Enabled = false;
            btnReload.Enabled = false;

            btnGhi.Enabled = true;
            btnUndo.Enabled = true;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLop.Position;
            bdsLop.AddNew();
            DisableForm();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsGV_DK.Count > 0)
            {
                MessageBox.Show("Đã có giảng viên đã đăng ký Không thể xóa!", "", MessageBoxButtons.OK);
                return;
            }
            if (bdsSV.Count > 0)
            {
                MessageBox.Show("Đã có Sinh Viên Trong lớp không thể xóa!", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn xóa môn học này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bdsLop.RemoveCurrent();

                    this.lOPTableAdapter.Update(this.dS.LOP);
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
            vitri = bdsLop.Position;
            DisableForm();
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp không được để trống!", "", MessageBoxButtons.OK);
                txtMaLop.Focus();
                return;
            }
            if (txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Tên lớp không được để trống!", "", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return;
            }
            if (cmbKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn mã khoa!", "", MessageBoxButtons.OK);
                cmbKhoa.Focus();
                return;
            }
            string strLenh = "DECLARE @result int " +
                            "EXEC @result = SP_KTMALOP '" + txtMaLop.Text + "', N'" + txtTenLop.Text.Trim() + "' " +
                            " SELECT 'result' = @result";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();
            int positionMALOP = bdsLop.Find("MALOP", txtMaLop.Text);
            int positionTenLOP = bdsLop.Find("TENLOP", txtTenLop.Text);
            if (result == 1 && (bdsLop.Position != positionMALOP))
            {
                MessageBox.Show("Mã lớp đã tồn tại!", "", MessageBoxButtons.OK);
                txtMaLop.Focus();
                return;
            }
            if (result == 2 && (bdsLop.Position != positionTenLOP))
            {
                MessageBox.Show("Tên lớp đã tồn tại!", "", MessageBoxButtons.OK);
                txtTenLop.Focus();
                return;
            }
            try
            {
                bdsLop.EndEdit();
                bdsLop.ResetCurrentItem();
                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Update(this.dS.LOP);

                MessageBox.Show("Ghi lớp thành công!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm lớp!\n" + ex.Message, "", MessageBoxButtons.OK);
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
                bdsLop.Filter = "";
            LoadTable();
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLop.CancelEdit();

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

        public string maSV, hoSV, tenSV, ngaySinhSV, diaChiSV;
        public void getValue(string ma, string ho, string ten, string ngaySinh, string diaChi)
        {
            maSV = ma;
            hoSV = ho;
            tenSV = ten;
            ngaySinhSV = ngaySinh;
            diaChiSV = diaChi;
        }

        private void ghiSV()
        {
            try
            {
                ((DataRowView)bdsSV[bdsSV.Position])["MASV"] = maSV;
                ((DataRowView)bdsSV[bdsSV.Position])["HO"] = hoSV;
                ((DataRowView)bdsSV[bdsSV.Position])["TEN"] = tenSV;
                ((DataRowView)bdsSV[bdsSV.Position])["NGAYSINH"] = ngaySinhSV;
                ((DataRowView)bdsSV[bdsSV.Position])["DIACHI"] = diaChiSV;
                ((DataRowView)bdsSV[bdsSV.Position])["MALOP"] = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString();
                bdsSV.EndEdit();
                bdsSV.ResetCurrentItem();
                bdsLop.Position = vitri;
                bdsSV.Position = vitriSV;
                this.sINHVIENTableAdapter.Update(this.dS.SINHVIEN);

                MessageBox.Show("Ghi sinh viên thành công!", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sinh viên!\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }
        private void btnThemSV_Click(object sender, EventArgs e)
        {
            vitri = bdsLop.Position;
            vitriSV = bdsSV.Position;
            bdsSV.AddNew();
            frmSV frm = new frmSV();
            frm.maLop = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString();
            frm.mydata = new frmSV.GETDATA(getValue);
            frm.ShowDialog();

            if (frm.flagAdd)
            {
                ghiSV();
            }
            else
            {

                bdsSV.CancelEdit();
                bdsSV.Position = vitriSV;

            }
        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            if (bdsBangDiem.Count > 0)
            {
                MessageBox.Show("Không thể xóa sinh viên đã làm bài thi!", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có thực sự muốn xóa sinh viên này?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bdsSV.RemoveCurrent();
                    this.sINHVIENTableAdapter.Update(this.dS.SINHVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa sinh viên!\n" + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        private void btnSuaSV_Click(object sender, EventArgs e)
        {
            vitri= bdsLop.Position;
            vitriSV = bdsSV.Position;
            frmSV frm = new frmSV();
            frm.masv = ((DataRowView)bdsSV[bdsSV.Position])["MASV"].ToString();
            frm.hosv = ((DataRowView)bdsSV[bdsSV.Position])["HO"].ToString();
            frm.tensv = ((DataRowView)bdsSV[bdsSV.Position])["TEN"].ToString();
            frm.ngaysinh = ((DataRowView)bdsSV[bdsSV.Position])["NGAYSINH"].ToString();
            frm.diachisv = ((DataRowView)bdsSV[bdsSV.Position])["DIACHI"].ToString();
            frm.maLop = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString();
            frm.mydata = new frmSV.GETDATA(getValue);
            frm.ShowDialog();
            if (frm.flagAdd)
            {
                ghiSV();
            }
            else
            {
                bdsSV.Position = vitriSV;
                bdsSV.CancelEdit();
            }
        }
    }   
}
