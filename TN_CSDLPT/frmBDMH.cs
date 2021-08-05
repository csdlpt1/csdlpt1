using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
namespace TN_CSDLPT
{
    public partial class frmBDMH : Form
    {
        public frmBDMH()
        {
            InitializeComponent();
        }

        private void sINHVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sINHVIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmBDMH_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rpBangDiemMonHoc report = new rpBangDiemMonHoc(this.cmbMaLop.SelectedValue.ToString(), 
                        this.cmbMaMH.SelectedValue.ToString(), Int32.Parse(this.txtLanThi.Text.ToString()));
            report.xtTenLop.Text = cmbMaLop.Text;
            report.xtTenMH.Text = cmbMaMH.Text;
            report.xtLanThi.Text = txtLanThi.Text;

            ReportPrintTool print = new ReportPrintTool(report);
            MessageBox.Show(cmbMaLop.Text);
            print.ShowPreviewDialog();
        }
    }
}
