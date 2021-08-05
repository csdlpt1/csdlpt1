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
    public partial class frmLamBaiThi : Form
    {
        public frmLamBaiThi()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {

                CreateParams param = base.CreateParams;

                param.ClassStyle = param.ClassStyle | 0x200;

                return param;

            }

        }
        public string maMH, maLop, tenLop, tenSV, trinhDo, ngayThi;
        private int b, c;

        private void dgvDETHI_Click(object sender, EventArgs e)
        {

        }

        private double Diem;

        private void frmLamBaiThi_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.CT_BAITHI' table. You can move, or remove it, as needed.
            this.cT_BAITHITableAdapter.Connection.ConnectionString = Program.connstr;
            this.cT_BAITHITableAdapter.Fill(this.dS.CT_BAITHI);

            txtMALOP.Text = maLop;
            txtTenLop.Text = tenLop;
            txtHoTen.Text = tenSV;

            for (int i = 0; i < dgvDETHI.Rows.Count; i++)
            {
                dgvDETHI.Rows[i].Cells["dataGridViewTextBoxColumn4"].Value = i + 1;
            }
            lbPhut.Text = thoiGian.ToString();
            timerTHI.Start();

        }

        private void cT_BAITHIBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDETHI.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        
        public int soCau, thoiGian;
        public decimal lan;
    }
}
