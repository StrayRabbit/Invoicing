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
    public partial class OutStorage : DevExpress.XtraEditors.XtraForm
    {
        public int SelectId;        //选择串号ID

        public bool IsSee;      //是否查看

        public OutStorage()
        {
            InitializeComponent();
        }

        #region Load
        private void OutStorage_Load(object sender, EventArgs e)
        {
            InitLookUpEdit(lue_SalePerson, 5);      //销售员

            if (SelectId > 0)
            {
                btn_Select.Enabled = false;
                InitDataById(SelectId);
            }

            //隐藏保存按钮
            if (IsSee)
            {
                btn_Save.Visible = false;
            }
        }
        #endregion

        #region 加载下拉列表
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

                var list = prop.LoadListAll(p => p.PROPPARENT == parentId).Select(x => new { x.PROPID, x.PROPNAME }).ToArray();       //品牌

                if (list.Length > 0)
                {
                    lue.Properties.NullText = "请选择";
                    lue.EditValue = "PROPID";
                    lue.Properties.ValueMember = "PROPID";
                    lue.Properties.DisplayMember = "PROPNAME";
                    lue.Properties.ShowHeader = false;
                    lue.ItemIndex = 0;        //选择第一项
                    lue.Properties.DataSource = list;

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
        #endregion

        #region 保存
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectId <= 0 || string.IsNullOrEmpty(btn_Select.Text.Trim()))
                {
                    XtraMessageBox.Show("请您选择串号!");
                    return;
                }

                if (string.IsNullOrEmpty(lue_SalePerson.Text) || lue_SalePerson.Text == "请选择")
                {
                    XtraMessageBox.Show("请您选择销售员!");
                    return;
                }

                if (string.IsNullOrEmpty(txt_Sales.Text.Trim()))
                {
                    XtraMessageBox.Show("请您填写出库金额!");
                    return;
                }
                else
                {
                    if (!Common.Tools.IsNumber(txt_Sales.Text.Trim()))
                    {
                        XtraMessageBox.Show("出库金额格式不正确!");
                        return;
                    }
                }

                Service.IService.IMobilePhone service = new Service.ServiceImp.MobilePhone();
                var model = service.Get(p => p.ID == SelectId);

                model.MobileSales = Convert.ToDecimal(txt_Sales.Text.Trim());       //出库金额
                model.MobileSalesPersonId = Convert.ToInt32(lue_SalePerson.EditValue);      //销售员
                //如果有出库时间，则不修改出库时间
                model.MobileOutTime = model.MobileState == 0 ? DateTime.Now : model.MobileOutTime;
                model.MobileState = 1;
                model.MobileProfit = model.MobileSales - model.MobileCost;      //利润
                model.MobileOutRemarks = txt_Remarks.Text.Trim();       //备注

                if (service.Update(model))
                {
                    DialogResult = DialogResult.OK;
                    XtraMessageBox.Show("保存成功!");
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("保存失败!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 选择串号
        private void btn_Select_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                StockList f = new StockList();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    if (f.SelectId <= 0)
                        return;

                    SelectId = f.SelectId;
                    InitDataById(SelectId);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("选择串码出错!" + ex.Message);
            }
        }
        #endregion

        #region 根据ID加载数据
        private void InitDataById(int id)
        {
            try
            {
                Service.IService.IMobilePhone service = new Service.ServiceImp.MobilePhone();
                var model = service.Get(p => p.ID == id);
                btn_Select.Text = model.MobileIMEI;     //串码
                lbl_Brand.Text = model.MobileBrand.PROPNAME;        //品牌
                lbl_Type.Text = model.MobileModel.PROPNAME;     //型号
                lbl_Supplier.Text = model.MobileSupplier.PROPNAME;      //供应商
                lbl_Cost.Text = model.MobileCost.ToString();       //成本

                txt_Remarks.Text = model.MobileOutRemarks;      //备注
                lue_SalePerson.EditValue = model.MobileSalesPersonId;       //销售员
                txt_Sales.Text = model.MobileSales.ToString();      //出库金额
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("加载数据出错!" + ex.Message);
            }
        }
        #endregion
    }
}