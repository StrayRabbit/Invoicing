namespace Invoicing.FormUI
{
    partial class OutStorage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Brand = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Type = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Supplier = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Cost = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lue_SalePerson = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_Sales = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Select = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_SalePerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Select.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(189, 323);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 26;
            this.btn_Save.Text = "保存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(51, 113);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 31;
            this.labelControl5.Text = "供货商：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(295, 113);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 30;
            this.labelControl4.Text = "成本：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(63, 32);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "串码：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(295, 75);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "型号：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(63, 75);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 27;
            this.labelControl1.Text = "品牌：";
            // 
            // lbl_Brand
            // 
            this.lbl_Brand.Location = new System.Drawing.Point(105, 75);
            this.lbl_Brand.Name = "lbl_Brand";
            this.lbl_Brand.Size = new System.Drawing.Size(24, 14);
            this.lbl_Brand.TabIndex = 32;
            this.lbl_Brand.Text = "品牌";
            // 
            // lbl_Type
            // 
            this.lbl_Type.Location = new System.Drawing.Point(337, 75);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(24, 14);
            this.lbl_Type.TabIndex = 33;
            this.lbl_Type.Text = "型号";
            // 
            // lbl_Supplier
            // 
            this.lbl_Supplier.Location = new System.Drawing.Point(105, 113);
            this.lbl_Supplier.Name = "lbl_Supplier";
            this.lbl_Supplier.Size = new System.Drawing.Size(36, 14);
            this.lbl_Supplier.TabIndex = 34;
            this.lbl_Supplier.Text = "供货商";
            // 
            // lbl_Cost
            // 
            this.lbl_Cost.Location = new System.Drawing.Point(337, 113);
            this.lbl_Cost.Name = "lbl_Cost";
            this.lbl_Cost.Size = new System.Drawing.Size(24, 14);
            this.lbl_Cost.TabIndex = 35;
            this.lbl_Cost.Text = "金额";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(51, 155);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 14);
            this.labelControl6.TabIndex = 36;
            this.labelControl6.Text = "销售员：";
            // 
            // lue_SalePerson
            // 
            this.lue_SalePerson.Location = new System.Drawing.Point(105, 152);
            this.lue_SalePerson.Name = "lue_SalePerson";
            this.lue_SalePerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_SalePerson.Size = new System.Drawing.Size(100, 20);
            this.lue_SalePerson.TabIndex = 37;
            // 
            // txt_Sales
            // 
            this.txt_Sales.Location = new System.Drawing.Point(337, 152);
            this.txt_Sales.Name = "txt_Sales";
            this.txt_Sales.Size = new System.Drawing.Size(79, 20);
            this.txt_Sales.TabIndex = 38;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(271, 155);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 39;
            this.labelControl7.Text = "出库金额：";
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(105, 29);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btn_Select.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btn_Select.Size = new System.Drawing.Size(171, 20);
            this.btn_Select.TabIndex = 41;
            this.btn_Select.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btn_Select_ButtonClick);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(63, 232);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 14);
            this.labelControl8.TabIndex = 42;
            this.labelControl8.Text = "备注：";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(105, 196);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AutoHeight = false;
            this.textEdit1.Size = new System.Drawing.Size(311, 86);
            this.textEdit1.TabIndex = 43;
            // 
            // OutStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 383);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.txt_Sales);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.lue_SalePerson);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.lbl_Cost);
            this.Controls.Add(this.lbl_Supplier);
            this.Controls.Add(this.lbl_Type);
            this.Controls.Add(this.lbl_Brand);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutStorage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加出库";
            this.Load += new System.EventHandler(this.OutStorage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lue_SalePerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Select.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_Brand;
        private DevExpress.XtraEditors.LabelControl lbl_Type;
        private DevExpress.XtraEditors.LabelControl lbl_Supplier;
        private DevExpress.XtraEditors.LabelControl lbl_Cost;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit lue_SalePerson;
        private DevExpress.XtraEditors.TextEdit txt_Sales;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ButtonEdit btn_Select;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit textEdit1;
    }
}