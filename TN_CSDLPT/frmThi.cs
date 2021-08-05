using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace TN_CSDLPT
{
    public partial class frmThi : Form
    {
        public frmThi()
        {
            InitializeComponent();
        }

        private void gIAOVIEN_DANGKYBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsGVDK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmThi_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            // TODO: This line of code loads data into the 'dS.GIAOVIEN_DANGKY' table. You can move, or remove it, as needed.
            this.gIAOVIEN_DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gIAOVIEN_DANGKYTableAdapter.Fill(this.dS.GIAOVIEN_DANGKY);        

            if (Program.mGroup == "SINHVIEN")
            {
                txtHoTen.Text = Program.mHoten;
                string strLenh = "EXEC SP_LAYLOP '" + Program.username + "'";

                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader == null) return;
                Program.myReader.Read();
                cmbLOP.SelectedItem = Program.myReader.GetString(0);
                txtTenLop.Text = Program.myReader.GetString(1);
                Program.myReader.Close();
                cmbLOP.Enabled = false;
            }
        }
        private bool ktraDaThi()
        {
            if (Program.mGroup == "SINHVIEN")
            {
                string strLenh = "DECLARE @result int " +
                            "EXEC @result = SP_KTDATHI '" + Program.username + "', N'" + txtMH.Text + "', '" + seLanThi.Value + "' " +
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
            }
            return true;
        }

        private void btnBATĐAU_Click(object sender, EventArgs e)
        {
            if (!ktraDaThi())
            {
                MessageBox.Show("Sinh viên đã hoàn thành kỳ thi này!", "", MessageBoxButtons.OK);
                return;
            }
            //string date = ((DataRowView)bdsGVDK[bdsGVDK.Position])["NGAYTHI"].ToString();
            //string[] temp = date.Split(' ');
            //MessageBox.Show(DateTime.Today.ToString());
            //MessageBox.Show(date.ToString());

            //if (DateTime.ParseExact(temp[0], "dd-MM-yyyy", CultureInfo.InvariantCulture) < DateTime.Today)
            //{
            //    MessageBox.Show("Kỳ thi này đã kết thúc!", "", MessageBoxButtons.OK);
            //    return;
            //}
            //if (DateTime.ParseExact(temp[0], "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.Today)
            //{
            //    MessageBox.Show("Kỳ thi này chưa bắt đầu!", "", MessageBoxButtons.OK);
            //    return;
            //}
            else
            {
                frmLamBaiThi l = new frmLamBaiThi();
                l.tenSV = txtHoTen.Text;
                l.maLop = cmbLOP.Text;
                l.tenLop = txtTenLop.Text;
                l.maMH = txtMH.Text;
                l.lan = seLanThi.Value;
                l.trinhDo = ((DataRowView)bdsGVDK[bdsGVDK.Position])["TRINHDO"].ToString();
                l.soCau = int.Parse(((DataRowView)bdsGVDK[bdsGVDK.Position])["SOCAUTHI"].ToString());
                l.ngayThi = ((DataRowView)bdsGVDK[bdsGVDK.Position])["NGAYTHI"].ToString();
                l.thoiGian = int.Parse(((DataRowView)bdsGVDK[bdsGVDK.Position])["THOIGIAN"].ToString());
                l.ShowDialog();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }    
}
