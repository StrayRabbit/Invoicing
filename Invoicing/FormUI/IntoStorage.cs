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
using Domain;
using Common.ToolsHelper;

namespace Invoicing.FormUI
{
    public partial class IntoStorage : BaseUserControl
    {
        public IntoStorage()
        {
            InitializeComponent();

            InitLookUpEdit(lue_Brand, 2);       //加载品牌
            InitLookUpEdit(lue_Supplier,4);     //加载供应商
        }

        #region 封装页面属性
        private static IntoStorage _ItSelf;
        public static IntoStorage ItSelf
        {
            get
            {
                if (_ItSelf == null || _ItSelf.IsDisposed)
                {
                    _ItSelf = new IntoStorage();
                }
                return _ItSelf;
            }
        }
        #endregion

        #region 数据加载
        private void IntoStorage_Load(object sender, EventArgs e)
        {

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

                    InitLookUpEdit(lue_Type, id);       //加载类型
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
    }
}
