namespace Invoicing.FormUI
{
    partial class BasicDictionary
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tl_BaseDic = new DevExpress.XtraTreeList.TreeList();
            this.ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.MenuName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ParentID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.Tag = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.txt_rootName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Order = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_AddChild = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tl_BaseDic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_rootName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Order.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tl_BaseDic
            // 
            this.tl_BaseDic.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ID,
            this.MenuName,
            this.ParentID,
            this.Tag});
            this.tl_BaseDic.Location = new System.Drawing.Point(3, 3);
            this.tl_BaseDic.Name = "tl_BaseDic";
            this.tl_BaseDic.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.tl_BaseDic.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.tl_BaseDic.Size = new System.Drawing.Size(210, 418);
            this.tl_BaseDic.TabIndex = 0;
            this.tl_BaseDic.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tl_BaseDic_FocusedNodeChanged);
            // 
            // ID
            // 
            this.ID.Caption = "编号";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 192;
            // 
            // MenuName
            // 
            this.MenuName.Caption = "名称";
            this.MenuName.FieldName = "MenuName";
            this.MenuName.Name = "MenuName";
            this.MenuName.Visible = true;
            this.MenuName.VisibleIndex = 0;
            // 
            // ParentID
            // 
            this.ParentID.Caption = "父级节点";
            this.ParentID.FieldName = "ParentID";
            this.ParentID.Name = "ParentID";
            // 
            // Tag
            // 
            this.Tag.Caption = "节点对象";
            this.Tag.FieldName = "Tag";
            this.Tag.Name = "Tag";
            // 
            // txt_rootName
            // 
            this.txt_rootName.Location = new System.Drawing.Point(428, 79);
            this.txt_rootName.Name = "txt_rootName";
            this.txt_rootName.Properties.ReadOnly = true;
            this.txt_rootName.Size = new System.Drawing.Size(100, 20);
            this.txt_rootName.TabIndex = 10;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(361, 82);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "父级节点：";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(428, 118);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(100, 20);
            this.txt_Name.TabIndex = 12;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(361, 121);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "节点名称：";
            // 
            // txt_Order
            // 
            this.txt_Order.Location = new System.Drawing.Point(428, 155);
            this.txt_Order.Name = "txt_Order";
            this.txt_Order.Size = new System.Drawing.Size(100, 20);
            this.txt_Order.TabIndex = 14;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(385, 161);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "排序：";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(399, 210);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 15;
            this.btn_Save.Text = "保存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(234, 13);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(94, 23);
            this.btn_Add.TabIndex = 16;
            this.btn_Add.Text = "新增根节点";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(638, 13);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 17;
            this.btn_Delete.Text = "删除";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_AddChild
            // 
            this.btn_AddChild.Location = new System.Drawing.Point(344, 13);
            this.btn_AddChild.Name = "btn_AddChild";
            this.btn_AddChild.Size = new System.Drawing.Size(94, 23);
            this.btn_AddChild.TabIndex = 18;
            this.btn_AddChild.Text = "新增子节点";
            this.btn_AddChild.Click += new System.EventHandler(this.btn_AddChild_Click);
            // 
            // BasicDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_AddChild);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_Order);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txt_rootName);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.tl_BaseDic);
            this.Name = "BasicDictionary";
            this.Size = new System.Drawing.Size(725, 424);
            this.Load += new System.EventHandler(this.BasicDictionary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tl_BaseDic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_rootName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Order.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tl_BaseDic;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn MenuName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ParentID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn Tag;
        private DevExpress.XtraEditors.TextEdit txt_rootName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_Order;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_Add;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_AddChild;
    }
}
