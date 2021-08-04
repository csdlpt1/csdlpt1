using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace TN_CSDLPT
{
    public partial class rpBangDiemMonHoc : DevExpress.XtraReports.UI.XtraReport
    {
        public rpBangDiemMonHoc(String MALOP, String MAMH, int LAN)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = MALOP;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = MAMH;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = LAN;
            this.sqlDataSource1.Fill();

        }

    }
}
