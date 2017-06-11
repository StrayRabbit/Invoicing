namespace Invoicing.FormUI
{
    partial class IntoStorage
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
            this.lue_Supplier = new DevExpress.XtraEditors.LookUpEdit();
            this.lue_Type = new DevExpress.XtraEditors.LookUpEdit();
            this.lue_Brand = new DevExpress.XtraEditors.LookUpEdit();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_Cost = new DevExpress.XtraEditors.TextEdit();
            this.txt_IMEI = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Remarks = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lue_Supplier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_Type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_Brand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Cost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_IMEI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Remarks.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lue_Supplier
            // 
            this.lue_Supplier.Location = new System.Drawing.Point(102, 91);
            this.lue_Supplier.Name = "lue_Supplier";
            this.lue_Supplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_Supplier.Size = new System.Drawing.Size(100, 20);
            this.lue_Supplier.TabIndex = 3;
            // 
            // lue_Type
            // 
            this.lue_Type.Location = new System.Drawing.Point(334, 34);
            this.lue_Type.Name = "lue_Type";
            this.lue_Type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_Type.Size = new System.Drawing.Size(100, 20);
            this.lue_Type.TabIndex = 2;
            // 
            // lue_Brand
            // 
            this.lue_Brand.Location = new System.Drawing.Point(102, 37);
            this.lue_Brand.Name = "lue_Brand";
            this.lue_Brand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_Brand.Size = new System.Drawing.Size(100, 20);
            this.lue_Brand.TabIndex = 1;
            this.lue_Brand.EditValueChanged += new System.EventHandler(this.lue_Brand_EditValueChanged);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(205, 320);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "保存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_Cost
            // 
            this.txt_Cost.Location = new System.Drawing.Point(334, 91);
            this.txt_Cost.Name = "txt_Cost";
            this.txt_Cost.Size = new System.Drawing.Size(100, 20);
            this.txt_Cost.TabIndex = 4;
            // 
            // txt_IMEI
            // 
            this.txt_IMEI.Location = new System.Drawing.Point(102, 147);
            this.txt_IMEI.Name = "txt_IMEI";
            this.txt_IMEI.Size = new System.Drawing.Size(311, 20);
            this.txt_IMEI.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(48, 94);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 20;
            this.labelControl5.Text = "供货商：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(292, 94);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "金额：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(60, 150);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "串码：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(292, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 17;
            this.labelControl2.Text = "型号：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(60, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "品牌：";
            // 
            // txt_Remarks
            // 
            this.txt_Remarks.Location = new System.Drawing.Point(102, 198);
            this.txt_Remarks.Name = "txt_Remarks";
            this.txt_Remarks.Size = new System.Drawing.Size(311, 96);
            this.txt_Remarks.TabIndex = 6;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(60, 242);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 14);
            this.labelControl8.TabIndex = 44;
            this.labelControl8.Text = "备注：";
            // 
            // IntoStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 383);
            this.Controls.Add(this.txt_Remarks);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.lue_Supplier);
            this.Controls.Add(this.lue_Type);
            this.Controls.Add(this.lue_Brand);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_Cost);
            this.Controls.Add(this.txt_IMEI);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IntoStorage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加入库";
            this.Load += new System.EventHandler(this.IntoStorageV1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lue_Supplier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_Type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_Brand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Cost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_IMEI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Remarks.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lue_Supplier;
        private DevExpress.XtraEditors.LookUpEdit lue_Type;
        private DevExpress.XtraEditors.LookUpEdit lue_Brand;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.TextEdit txt_Cost;
        private DevExpress.XtraEditors.TextEdit txt_IMEI;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txt_Remarks;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}