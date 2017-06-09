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
using Common.ToolsHelper;
using Domain;

namespace Invoicing.FormUI
{
    public partial class BasicDictionary : BaseUserControl
    {
        Service.IService.IPropTypeBase prop = new Service.ServiceImp.PropTypeBase();
        bool IsAdd = false;     //是否新增
        bool IsAddChild = false;        //是否新增子节点

        public BasicDictionary()
        {
            InitializeComponent();
        }

        #region 封装页面属性
        private static BasicDictionary _ItSelf;
        public static BasicDictionary ItSelf
        {
            get
            {
                if (_ItSelf == null || _ItSelf.IsDisposed)
                {
                    _ItSelf = new BasicDictionary();
                }
                return _ItSelf;
            }
        }
        #endregion

        #region 加载数据
        private void BasicDictionary_Load(object sender, EventArgs e)
        {
            //Service.IService.IPropTypeBase prop = new Service.ServiceImp.PropTypeBase();
            var list = prop.LoadListAll(null);

            if (list.Count <= 0)
                return;

            //绑定树
            List<TreeListModel> treeList = new List<TreeListModel>();
            //if (tl_BaseDic.Nodes.Count > 0)
            //    tl_BaseDic.Nodes.Clear();
            foreach (var item in list)
            {
                TreeListModel temp = new TreeListModel();
                temp.ID = item.PROPID;
                temp.MenuName = item.PROPNAME;
                temp.ParentID = int.Parse(item.PROPPARENT.ToString());
                temp.Tag = item;

                treeList.Add(temp);
            }

            tl_BaseDic.KeyFieldName = "ID";
            tl_BaseDic.ParentFieldName = "ParentID";
            tl_BaseDic.DataSource = treeList;
            tl_BaseDic.ExpandAll();
            tl_BaseDic.RefreshDataSource();
        } 
        #endregion

        #region 单击事件
        private void tl_BaseDic_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                int id = int.Parse(this.tl_BaseDic.FocusedNode.GetValue("ID").ToString());
                int parentId = int.Parse(this.tl_BaseDic.FocusedNode.GetValue("ParentID").ToString());

                PROPTYPEBASE prop_Parent = prop.Get(p => p.PROPID == parentId);
                PROPTYPEBASE prop_Curr = prop.Get(p => p.PROPID == id);

                txt_Name.Text = this.tl_BaseDic.FocusedNode.GetValue("MenuName").ToString();
                txt_rootName.Text = prop_Parent == null ? "" : prop_Parent.PROPNAME;
                txt_Order.Text = prop_Curr.PROPORDER.ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        } 
        #endregion

        #region 保存
        private void btn_Save_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.tl_BaseDic.FocusedNode.GetValue("ID").ToString());
            int parentId = int.Parse(this.tl_BaseDic.FocusedNode.GetValue("ParentID").ToString());

            if (string.IsNullOrEmpty(txt_Name.Text.Trim()))
            {
                XtraMessageBox.Show("节点名称不能为空！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txt_Order.Text.Trim()))
            {
                XtraMessageBox.Show("排序不能为空！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Common.Tools.IsInt(txt_Order.Text.Trim()))
            {
                XtraMessageBox.Show("排序必须为正整数！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PROPTYPEBASE prop_Curr = new PROPTYPEBASE();
            if (IsAdd)
            {
                if (IsAddChild)
                {
                    prop_Curr.PROPPARENT = id;
                }
                else
                {
                    prop_Curr.PROPPARENT = parentId;
                }
            }
            else
            {
                prop_Curr = prop.Get(p => p.PROPID == id);
            }

            prop_Curr.PROPNAME = txt_Name.Text.Trim();
            prop_Curr.PROPORDER = Convert.ToInt32(txt_Order.Text.Trim());

            if (prop.SaveOrUpdate(prop_Curr, !IsAdd))
            {
                XtraMessageBox.Show("操作成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BasicDictionary_Load(null, null);
            }
            else
            {
                XtraMessageBox.Show("操作失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            IsAdd = false;
            IsAddChild = false;
        }
        #endregion

        #region 新增
        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                IsAdd = true;
                PROPTYPEBASE propType = new PROPTYPEBASE();
                int parrentId = int.Parse(this.tl_BaseDic.FocusedNode.GetValue("ParentID").ToString());
                txt_rootName.Text = prop.Get(p => p.PROPID == parrentId).PROPNAME;
                txt_Name.Text = string.Empty;
                txt_Order.Text = "1";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("新增失败！" + ex.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 删除
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.tl_BaseDic.FocusedNode.GetValue("ID").ToString());
            PROPTYPEBASE propType = prop.Get(p => p.PROPID == id);
            if (DialogResult.Yes == XtraMessageBox.Show("您确定要删除吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                if (prop.IsExist(p => p.PROPPARENT == id))
                {
                    XtraMessageBox.Show("该节点名称存在子节点，不能删除！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    prop.Delete(p => p.PROPID == id);
                    BasicDictionary_Load(null, null);
                }
            }
        }
        #endregion

        #region 新增子节点
        private void btn_AddChild_Click(object sender, EventArgs e)
        {
            try
            {
                IsAdd = true;
                IsAddChild = true;
                PROPTYPEBASE propType = new PROPTYPEBASE();
                int id = int.Parse(this.tl_BaseDic.FocusedNode.GetValue("ID").ToString());
                txt_rootName.Text = prop.Get(p => p.PROPID == id).PROPNAME;
                txt_Name.Text = string.Empty;
                txt_Order.Text = "1";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("新增失败！" + ex.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }


}
