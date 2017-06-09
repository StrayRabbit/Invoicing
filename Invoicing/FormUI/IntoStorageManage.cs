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
using DevExpress.XtraLayout;

namespace Invoicing.FormUI
{
    public partial class IntoStorageManage : BaseUserControl
    {
        private int pageSize = 10;      //一页多少条
        private int pageIndex = 1;      //当前页数

        List<Domain.MobilePhone> list;      //全部数据

        Service.IService.IMobilePhone service = new Service.ServiceImp.MobilePhone();

        public IntoStorageManage()
        {
            InitializeComponent();

            //加载所有
            list = service.LoadListAll(null).OrderByDescending(p => p.MobileInTime).ToList();
            InitData();
        }

        #region 封装页面属性
        private static IntoStorageManage _ItSelf;
        public static IntoStorageManage ItSelf
        {
            get
            {
                if (_ItSelf == null || _ItSelf.IsDisposed)
                {
                    _ItSelf = new IntoStorageManage();
                }
                return _ItSelf;
            }
        }
        #endregion

        #region 功能按钮
        #region 新增
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //XtraForm xf = new XtraForm();
            //xf.Text = "添加入库";

            //PanelControl PC = new PanelControl();
            //PC.Dock = DockStyle.Fill;
            //xf.Controls.Add(PC);
            //PC.Controls.Clear();
            //PC.Controls.Add(IntoStorage.ItSelf);
            //IntoStorage.ItSelf.Dock = System.Windows.Forms.DockStyle.Fill;
            //xf.ShowDialog();

            IntoStorageV1 xf = new IntoStorageV1();
            xf.ShowDialog();
        }
        #endregion
        #endregion

        #region 加载列表
        private void InitData()
        {
            //加载页数
            InitPageCount(list.Count);

            if (list.Count > 0)
            {
                gd_MobileList.DataSource = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(); ;
                gd_MobileList.Refresh();
                gd_MobileList.RefreshDataSource();

                this.gridView1.BestFitColumns();        //自动调整所有字段宽度
                gridView1.IndicatorWidth = 30;//设置显示行号的列宽

                //设置奇、偶行交替颜色
                gridView1.OptionsView.EnableAppearanceEvenRow = true;
                gridView1.OptionsView.EnableAppearanceOddRow = true;
                gridView1.Appearance.EvenRow.BackColor = Color.GhostWhite;
                gridView1.Appearance.OddRow.BackColor = Color.White;

                //view行中值居左
                this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                //view列标题居左
                this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            }
        }
        #endregion

        #region 递增列
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = ((e.RowHandle + 1) + ((pageIndex - 1) * pageSize)).ToString();
            }
        }
        #endregion

        #region 格式化字段
        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "MobileState" && e.Column.FieldName != "MobileInTime") return;

            //状态
            if (e.Column.FieldName == "MobileState")
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    e.DisplayText = "未出库";
                }
                else if (Convert.ToInt32(e.Value) == 1)
                {
                    e.DisplayText = "已出库";
                }
                else
                {
                    e.DisplayText = "异常";
                }
            }

            //时间
            if (e.Column.FieldName == "MobileInTime")
            {
                e.Column.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            }
        }
        #endregion

        #region grid下拉事件
        private void gridView1_TopRowChanged(object sender, EventArgs e)
        {
            //var list = service.LoadListAll(null).OrderByDescending(p => p.MobileInTime).ToList();
        }
        #endregion

        #region 加载页数
        private void InitPageCount(int count)
        {
            if (cmbPageNum.Properties.Items.Count > 0)
                cmbPageNum.Properties.Items.Clear();

            if (count <= 0)
            {
                cmbPageNum.Properties.Items.Add(1);
            }
            else
            {
                int num = 1;
                for (int i = 0; i <= count; i += pageSize)
                {
                    cmbPageNum.Properties.Items.Add(num);
                    num++;
                }
            }

            cmbPageNum.SelectedIndex = 0;       //默认选择第一页
        }
        #endregion

        private void btn_MoveNext_Click(object sender, EventArgs e)
        {
            pageIndex++;
            cmbPageNum.EditValue = pageIndex.ToString();
            InitData();
        }
    }
}
