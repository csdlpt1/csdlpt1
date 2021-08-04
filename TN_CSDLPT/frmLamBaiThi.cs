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
        private double Diem;
        public int soCau, thoiGian;
        public decimal lan;
    }
}
