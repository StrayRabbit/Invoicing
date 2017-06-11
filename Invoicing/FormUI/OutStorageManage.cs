using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Invoicing.FormUI
{
    public partial class OutStorageManage : DevExpress.XtraEditors.XtraUserControl
    {
        public OutStorageManage()
        {
            InitializeComponent();
        }

        #region Load
        private void OutStorageManage_Load(object sender, EventArgs e)
        {
            groupBox1.Width = this.Width - 4;
            gd_MobileList.Width = this.Width - 4;
            panelControl1.Width = this.Width - 4;


        } 
        #endregion

        #region 新增
        private void btn_Add_Click(object sender, EventArgs e)
        {
            OutStorage xf = new OutStorage();
            if (DialogResult.OK == xf.ShowDialog())
            {
                OutStorageManage_Load(null, null);
            }
        } 
        #endregion
    }
}
