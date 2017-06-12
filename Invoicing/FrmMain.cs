using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using Invoicing.FormUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Invoicing
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private int ChildFormWidth;      //子菜单宽度

        #region FrmMain_Load
        private void FrmMain_Load(object sender, EventArgs e)
        {
            ChildFormWidth = this.Width - dockPanel1.Width - 40;

            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
        }
        #endregion

        #region 菜单树 和table 页签
        /// <summary>
        /// 菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //void _navBarItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        //{
        //    //获取菜单名
        //    NavBarItem _navBarItem = (NavBarItem)sender;
        //    //判断是否已新建窗体
        //    if (ContainMDIChild(_navBarItem.Caption))
        //    {

        //    }
        //    else
        //    {
        //        XtraForm xf = new XtraForm();
        //        xtraTabbedMdiManager1.MdiParent = this;
        //        xf.Text = _navBarItem.Caption;
        //        xf.MdiParent = this;
        //        //根据备注添加用户控件
        //        if (_navBarItem.Name == "PersonnelIndex")
        //        {
        //            //PersonnelIndex user = new PersonnelIndex();
        //            PanelControl PC = new PanelControl();
        //            PC.Dock = DockStyle.Fill;
        //            xf.Controls.Add(PC);
        //            PC.Controls.Clear();
        //            PC.Controls.Add(PersonnelIndex.ItSelf);

        //            //xf.Controls.Add(user);
        //            PersonnelIndex.ItSelf.Dock = System.Windows.Forms.DockStyle.Fill;
        //        }
        //        else if (_navBarItem.Name == "TheReport")
        //        {
        //            //PeportIndex user = new PeportIndex();
        //            //xf.Controls.Add(user);
        //            PanelControl PC = new PanelControl();
        //            PC.Dock = DockStyle.Fill;
        //            xf.Controls.Add(PC);
        //            PC.Controls.Clear();
        //            PC.Controls.Add(PeportIndex.ItSelf);
        //            PeportIndex.ItSelf.Dock = System.Windows.Forms.DockStyle.Fill;
        //        }
        //        else if (_navBarItem.Name == "TheTrayToPrint")
        //        {
        //            //TrayPrint user = new TrayPrint();
        //            //xf.Controls.Add(user);
        //            PanelControl PC = new PanelControl();
        //            PC.Dock = DockStyle.Fill;
        //            xf.Controls.Add(PC);
        //            PC.Controls.Clear();
        //            PC.Controls.Add(TrayPrint.ItSelf);
        //            TrayPrint.ItSelf.Dock = System.Windows.Forms.DockStyle.Fill;
        //        }

        //        else if (_navBarItem.Name == "ImportData")
        //        {

        //            PanelControl PC = new PanelControl();
        //            PC.Dock = DockStyle.Fill;
        //            xf.Controls.Add(PC);
        //            PC.Controls.Clear();
        //            PC.Controls.Add(ImportData.ItSelf);
        //            ImportData.ItSelf.Dock = System.Windows.Forms.DockStyle.Fill;

        //        }
        //        else if (_navBarItem.Name == "PrintTemplate")
        //        {
        //            PanelControl PC = new PanelControl();
        //            PC.Dock = DockStyle.Fill;
        //            xf.Controls.Add(PC);
        //            PC.Controls.Clear();
        //            PC.Controls.Add(PrintTemplate.ItSelf);
        //            PrintTemplate.ItSelf.Dock = System.Windows.Forms.DockStyle.Fill;
        //        }
        //        else if (_navBarItem.Name == "MatPrint")
        //        {
        //            PanelControl PC = new PanelControl();
        //            PC.Dock = DockStyle.Fill;
        //            xf.Controls.Add(PC);
        //            PC.Controls.Clear();
        //            PC.Controls.Add(MatPrint.ItSelf);
        //            PrintTemplate.ItSelf.Dock = System.Windows.Forms.DockStyle.Fill;
        //        }





        //        ///控件分布

        //        xf.Show();
        //        ///
        //        //xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[xf];
        //        this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;

        //    }

        //}



        #endregion

        #region 皮肤
        private void ribbonGalleryBarItem1_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            //string caption = string.Empty;
            //if (ribbonGalleryBarItem1.Gallery == null) return;
            //caption = ribbonGalleryBarItem1.Gallery.GetCheckedItems()[0].Caption;//主题的描述
            //caption = caption.Replace("主题：", "");

            //if (XtraMessageBox.Show("你确定要保存当前皮肤吗?", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            //{
            //    Properties.Settings.Default.SkinName = caption;
            //    Properties.Settings.Default.Save();
            //}

        }
        #endregion

        #region 关闭按钮
        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtomExit_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("你确认需要退出吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        #endregion

        #region 菜单加载

        #region 入库管理
        /// <summary>
        /// 入库管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarItem1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var fm = new IntoStorageManage();
            fm.Width = ChildFormWidth;
            AddChildForm(fm, navBarItem1.Caption);
        }
        #endregion

        #region 出库管理
        private void navBarItem2_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var fm = new OutStorageManage();
            fm.Width = ChildFormWidth;
            AddChildForm(fm, navBarItem2.Caption);
        }
        #endregion

        #region 基础字典
        private void navBarItem5_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            AddChildForm(new BasicDictionary(), navBarItem4.Caption);
        }
        #endregion

        #region 销售查询
        private void navBarItem4_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var fm = new SearchSales();
            fm.Width = ChildFormWidth;
            AddChildForm(fm, navBarItem4.Caption);
        }
        #endregion

        #region 折线图
        private void navBarItem3_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var fm = new SearchLineChart();
            fm.Width = ChildFormWidth;
            AddChildForm(fm, navBarItem3.Caption);
        }
        #endregion

        #endregion

        #region 添加子窗体
        /// <summary>
        /// 添加子窗体
        /// </summary>
        /// <param name="c">子窗体</param>
        /// <param name="caption">窗体名字</param>
        private void AddChildForm(Control c, string caption)
        {
            //判断窗体是否打开
            if (ContainMDIChild(caption))
            {
                return;
            }

            XtraForm xf = new XtraForm();
            xtraTabbedMdiManager1.MdiParent = this;     //设置控件的父表单
            xf.MdiParent = this;        //设置新建窗体的父表单为当前活动窗口
            PanelControl pc = new PanelControl();
            pc.Dock = DockStyle.Fill;
            pc.Controls.Add(c);
            xf.Text = caption;
            xf.Controls.Add(pc);
            xf.Show();
        }
        #endregion

        #region 判断是否已打开
        /// <summary>
        /// 判断是否已打开
        /// </summary>
        /// <param name="ChildTypeString"></param>
        /// <returns></returns>
        private bool ContainMDIChild(string ChildTypeString)
        {
            foreach (XtraForm f in MdiChildren)
            {
                if (f.Text == ChildTypeString)
                {
                    //xfs.Remove(f);
                    //f.Close();
                    //break;

                    f.Select();
                    return true;
                }
            }
            return false;
        }
        #endregion

       




    }
}
