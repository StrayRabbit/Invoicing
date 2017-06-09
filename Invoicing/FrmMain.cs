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
            #region 状态栏
            //string url = Application.StartupPath + @"\Config.ini";
            //IniFile iniFile = new IniFile(url);
            //string username = iniFile.ReadIni("用户名字", "username", "");
            //string num = iniFile.ReadIni("版本号", "versionnumber", "");
            //this.barStaticItem1.Caption = "登录人：" + username;
            //this.barStaticItem2.Caption = "版本：" + num;
            #endregion
            #region 控件汉化代码
            //string strSkinName = Properties.Settings.Default.SkinName;//获得皮肤的值
            //UserLookAndFeel.Default.SetSkinStyle(strSkinName);//默认系统界面皮肤
            //SkinHelper.InitSkinGallery(ribbonGalleryBarItem1, true); //添加界面皮肤

            #endregion
            #region 左侧菜单加载
            //this.navBarControl1.Groups.Clear();

            #region 基础数据导入

            //NavBarGroup _navBarGroup = new NavBarGroup();
            //_navBarGroup.Name = "_navBarGroup";
            //_navBarGroup.Caption = "基础数据导入";
            ////添加子菜单
            //NavBarItem _navBarItem = new NavBarItem();
            //_navBarItem.Name = "PersonnelIndex";
            //_navBarItem.Caption = "人员展示";
            //_navBarItem.LargeImageIndex = 0;
            ////添加 点击事件
            //_navBarItem.LinkClicked += new NavBarLinkEventHandler(_navBarItem_LinkClicked);
            //_navBarGroup.ItemLinks.Add(_navBarItem);
            //////
            //NavBarItem _navBarItem0 = new NavBarItem();
            //_navBarItem0.Name = "ImportData";
            //_navBarItem0.Caption = "数据导入";
            //_navBarItem0.LargeImageIndex = 0;
            ////添加 点击事件
            //_navBarItem0.LinkClicked += new NavBarLinkEventHandler(_navBarItem_LinkClicked);
            //_navBarGroup.ItemLinks.Add(_navBarItem0);
            /////
            //navBarControl1.Groups.Add(_navBarGroup);
            //_navBarGroup.Expanded = true;
            #endregion


            #endregion
        }

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


        /// <summary>
        /// 判断是否已打开
        /// </summary>
        /// <param name="ChildTypeString"></param>
        /// <returns></returns>
        private bool ContainMDIChild(string ChildTypeString)
        {
            foreach (Form f in MdiChildren)
            {
                string a = f.Text;
                if (f.Text == ChildTypeString)
                {
                    f.Select();
                    return true;
                }
            }
            return false;
        }
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
            XtraForm xf = new XtraForm();
            xtraTabbedMdiManager1.MdiParent = this;
            xf.Text = navBarItem1.Caption;
            xf.MdiParent = this;

            PanelControl PC = new PanelControl();
            PC.Dock = DockStyle.Fill;
            xf.Controls.Add(PC);
            PC.Controls.Clear();
            PC.Controls.Add(IntoStorageManage.ItSelf);
            IntoStorageManage.ItSelf.Dock = System.Windows.Forms.DockStyle.Fill;
            
            xf.Show();
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
        }
        #endregion

        #region 基础字典
        private void navBarItem4_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            XtraForm xf = new XtraForm();
            xtraTabbedMdiManager1.MdiParent = this;
            xf.Text = "基础字典";
            xf.MdiParent = this;

            PanelControl PC = new PanelControl();
            PC.Dock = DockStyle.Fill;
            xf.Controls.Add(PC);
            PC.Controls.Clear();
            PC.Controls.Add(BasicDictionary.ItSelf);
            BasicDictionary.ItSelf.Dock = System.Windows.Forms.DockStyle.Fill;
            xf.Show();
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
        }
        #endregion 
        #endregion
    }
}
