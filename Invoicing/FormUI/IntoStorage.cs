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
    public partial class IntoStorage : DevExpress.XtraEditors.XtraForm
    {
        public int Id;      //区别修改还是添加

        public IntoStorage()
        {
            InitializeComponent();
        }

        #region 数据加载
        private void IntoStorageV1_Load(object sender, EventArgs e)
        {
            InitLookUpEdit(lue_Brand, 2);       //加载品牌
            InitLookUpEdit(lue_Supplier, 4);     //加载供应商

            InitDataById(Id);
        }
        #endregion

        #region 加载类型
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
                        InitLookUpEdit(lue_Type, id);       //加载类型
                    }
                    else
                    {
                        lue_Type.Properties.DataSource = null;
                    }
                }
                else
                {
                    lue_Type.Properties.NullText = "请选择";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("加载类型出错！" + ex.Message);
            }
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

        #region 清空数据
        private void InitDataById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                lue_Brand.ItemIndex = 0;
                lue_Type.ItemIndex = 0;

            }
        }
        #endregion

        #region 保存
        private void btn_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(lue_Brand.Text) || lue_Brand.Text == "请选择")
                {
                    XtraMessageBox.Show("请您选择品牌!");
                    return;
                }

                if (string.IsNullOrEmpty(lue_Type.Text) || lue_Type.Text == "请选择")
                {
                    XtraMessageBox.Show("请您选择型号!");
                    return;
                }

                if (string.IsNullOrEmpty(lue_Supplier.Text) || lue_Supplier.Text == "请选择")
                {
                    XtraMessageBox.Show("请您选择供应商!");
                    return;
                }

                if (string.IsNullOrEmpty(txt_IMEI.Text.Trim()))
                {
                    XtraMessageBox.Show("请您填写串号!");
                    return;
                }

                if (string.IsNullOrEmpty(txt_Cost.Text.Trim()))
                {
                    XtraMessageBox.Show("请您填写金额!");
                    return;
                }
                else
                {
                    if (!Common.Tools.IsNumber(txt_Cost.Text.Trim()))
                    {
                        XtraMessageBox.Show("金额格式不正确!");
                        return;
                    }
                }



                Service.IService.IMobilePhone phone = new Service.ServiceImp.MobilePhone();
                Domain.MobilePhone mobile = new Domain.MobilePhone();

                if (Id <= 0)
                {
                    //保存
                    if (phone.IsExist(p => p.MobileIMEI == txt_IMEI.Text.Trim()))
                    {
                        XtraMessageBox.Show("该串码已经存在!");
                        return;
                    }
                }
                else
                {
                    mobile = phone.Get(p => p.ID == Id);

                    if (mobile.MobileIMEI != txt_IMEI.Text.Trim() && phone.IsExist(p => p.MobileIMEI == txt_IMEI.Text.Trim()))
                    {
                        XtraMessageBox.Show("该串码已经存在!");
                        return;
                    }
                }

                mobile.MobileBrandId = Convert.ToInt32(lue_Brand.EditValue);     //品牌ID
                mobile.MobileModelId = Convert.ToInt32(lue_Type.EditValue);     //型号ID
                mobile.MobileIMEI = txt_IMEI.Text.Trim();       //串码
                mobile.MobileCost = Convert.ToDecimal(txt_Cost.Text.Trim());        //成本
                mobile.MobileSupplierId = Convert.ToInt32(lue_Supplier.EditValue);  //供应商
                mobile.MobileInTime = Id > 0 ? mobile.MobileInTime : DateTime.Now;
                mobile.MobileState = 0;     //0 表示未出库
                mobile.MobileRemarks = txt_Remarks.Text.Trim();     //备注

                if (phone.SaveOrUpdate(mobile, Id > 0))
                {
                    XtraMessageBox.Show("保存成功!");
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("保存失败!");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("保存失败!" + ex.Message);
            }
        }
        #endregion

        #region 根据ID加载数据
        private void InitDataById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return;
                }

                Service.IService.IMobilePhone phone = new Service.ServiceImp.MobilePhone();
                var model = phone.Get(p => p.ID == id);

                lue_Brand.EditValue = model.MobileBrandId;     //品牌ID
                lue_Type.EditValue = model.MobileModelId;     //型号ID
                txt_IMEI.Text = model.MobileIMEI;       //串码
                txt_Cost.Text = model.MobileCost.ToString();        //成本
                lue_Supplier.EditValue = model.MobileSupplierId;  //供应商
                txt_Remarks.Text = model.MobileRemarks;     //备注
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("根据ID加载数据出错!" + ex.Message);
            }
        }
        #endregion
    }
}