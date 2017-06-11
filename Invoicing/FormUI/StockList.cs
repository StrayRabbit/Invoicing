using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Invoicing.FormUI
{
    public partial class StockList : DevExpress.XtraEditors.XtraForm
    {
        private int pageSize = 10;      //一页多少条
        private int pageIndex = 1;      //当前页数

        List<Domain.MobilePhone> list;      //全部数据
        Service.IService.IMobilePhone service = new Service.ServiceImp.MobilePhone();

        public int SelectId;       //选择ID

        public StockList()
        {
            InitializeComponent();
        }

        #region Load
        private void StockList_Load(object sender, EventArgs e)
        {
            InitLookUpEdit(lue_Brand, 2);     //加载品牌
            InitLookUpEdit(lue_Model, 3);     //加载型号

            //加载所有
            list = service.LoadListAll(p => p.MobileState == 0).ToList();
            //加载页数
            InitPageCount(list.Count);
            InitData();
        }
        #endregion

        #region 加载下拉列表
        /// <summary>
        /// 加载下拉列表
        /// </summary>
        /// <param name="lue">下拉控件</param>
        /// <param name="parentId">根节点ID</param>
        private void InitLookUpEdit(LookUpEdit lue, int parentId)
        {
            try
            {
                if (parentId <= 0)
                    return;

                Service.IService.IPropTypeBase prop = new Service.ServiceImp.PropTypeBase();

                var list_lue = prop.LoadListAll(p => p.PROPPARENT == parentId);       //品牌

                if (list_lue.Count() > 0)
                {
                    Domain.PROPTYPEBASE p = new Domain.PROPTYPEBASE();
                    p.PROPID = 0;
                    p.PROPNAME = "";
                    list_lue.Insert(0, p);
                    var l = list_lue.Select(m => new { m.PROPID, m.PROPNAME }).ToList();

                    lue.Properties.NullText = "请选择";
                    lue.EditValue = "PROPID";
                    lue.Properties.ValueMember = "PROPID";
                    lue.Properties.DisplayMember = "PROPNAME";
                    lue.Properties.ShowHeader = false;
                    lue.ItemIndex = 0;        //选择第一项
                    lue.Properties.DataSource = l;

                    //自适应宽度
                    lue.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                    //填充列
                    lue.Properties.PopulateColumns();
                    //lue.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PROPID"));
                    lue.Properties.Columns[0].Visible = false;
                }
                else
                {
                    lue.Properties.NullText = "请选择";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("加载数据出错!" + ex.Message);
            }
        }
        #endregion

        #region GridView 相关
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

        #region 加载列表
        private void InitData()
        {
            if (list.Count > 0)
            {
                gd_MobileList.DataSource = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
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
            else
            {
                gd_MobileList.DataSource = null;
                gd_MobileList.Refresh();
                gd_MobileList.RefreshDataSource();
            }

            lbl_Sum.Text = string.Format("总数：{0}", list.Count);
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

        #region 分页
        #region 下一页
        private void btn_MoveNext_Click(object sender, EventArgs e)
        {
            if (pageIndex < cmbPageNum.Properties.Items.Count)
            {
                pageIndex++;
                cmbPageNum.EditValue = pageIndex.ToString();
            }
            else
            {
                cmbPageNum.EditValue = cmbPageNum.Properties.Items.Count.ToString();
            }

            InitData();
        }
        #endregion

        #region 上一页
        private void btn_Preview_Click(object sender, EventArgs e)
        {
            if (pageIndex > 1)
            {
                pageIndex--;
                cmbPageNum.EditValue = pageIndex;
            }
            else
            {
                cmbPageNum.SelectedIndex = 0;
            }

            InitData();
        }
        #endregion

        #region 末页
        private void btn_Last_Click(object sender, EventArgs e)
        {
            pageIndex = cmbPageNum.Properties.Items.Count;
            cmbPageNum.EditValue = cmbPageNum.Properties.Items.Count.ToString();

            InitData();
        }
        #endregion

        #region 首页
        private void btn_First_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            cmbPageNum.EditValue = 1;

            InitData();
        }
        #endregion

        #region 切换分页
        private void cmbPageNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageIndex = Convert.ToInt32(cmbPageNum.EditValue);

            InitData();
        }
        #endregion

        #endregion
        #endregion

        #region 查询按钮
        private void btn_Select_Click(object sender, EventArgs e)
        {
            try
            {
                list = service.LoadListAll(p => p.MobileState == 0).OrderBy(p => p.MobileInTime).ToList();

                if (!string.IsNullOrEmpty(txt_IMEI.Text.Trim()))
                {
                    list = list.Where(p => p.MobileIMEI.Contains(txt_IMEI.Text.Trim())).ToList();
                }

                if (!string.IsNullOrEmpty(lue_Brand.Text) && lue_Brand.Text != "请选择")
                {
                    list = list.Where(p => p.MobileBrandId == Convert.ToInt32(lue_Brand.EditValue)).ToList();
                }

                if (!string.IsNullOrEmpty(lue_Model.Text) && lue_Model.Text != "请选择")
                {
                    list = list.Where(p => p.MobileModelId == Convert.ToInt32(lue_Model.EditValue)).ToList();
                }

                //加载页数
                InitPageCount(list.Count);
                InitData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("查询出错！" + ex.Message);
            }
        }
        #endregion

        #region 联动加载型号
        private void lue_Brand_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lue_Brand.ItemIndex >= 0)
                {
                    int id = Convert.ToInt32(lue_Brand.EditValue.ToString());

                    Service.IService.IPropTypeBase prop = new Service.ServiceImp.PropTypeBase();
                    bool IsExist = prop.IsExist(p => p.PROPPARENT == id);
                    if (IsExist)
                    {
                        InitLookUpEdit(lue_Model, id);       //加载类型
                    }
                    else
                    {
                        lue_Model.Properties.DataSource = null;
                    }
                }
                else
                {
                    lue_Model.Properties.NullText = "请选择";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("加载类型出错！" + ex.Message);
            }
        }
        #endregion

        #region 选择GridView值
        private void btn_OK_Click(object sender, EventArgs e)
        {
            SelectId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
            DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region 双击选择GridView值
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            SelectId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
            DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}