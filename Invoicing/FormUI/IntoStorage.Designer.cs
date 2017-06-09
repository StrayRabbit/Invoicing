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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txt_IMEI = new DevExpress.XtraEditors.TextEdit();
            this.txt_Cost = new DevExpress.XtraEditors.TextEdit();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.lue_Brand = new DevExpress.XtraEditors.LookUpEdit();
            this.lue_Type = new DevExpress.XtraEditors.LookUpEdit();
            this.lue_Supplier = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_IMEI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Cost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_Brand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_Type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_Supplier.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "品牌：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(260, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "型号：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(28, 91);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "串码：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(260, 91);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "金额：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(16, 156);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "供货商：";
            // 
            // txt_IMEI
            // 
            this.txt_IMEI.Location = new System.Drawing.Point(70, 88);
            this.txt_IMEI.Name = "txt_IMEI";
            this.txt_IMEI.Size = new System.Drawing.Size(100, 20);
            this.txt_IMEI.TabIndex = 7;
            // 
            // txt_Cost
            // 
            this.txt_Cost.Location = new System.Drawing.Point(302, 88);
            this.txt_Cost.Name = "txt_Cost";
            this.txt_Cost.Size = new System.Drawing.Size(100, 20);
            this.txt_Cost.TabIndex = 8;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(178, 237);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 10;
            this.btn_Save.Text = "保存";
            // 
            // lue_Brand
            // 
            this.lue_Brand.Location = new System.Drawing.Point(70, 26);
            this.lue_Brand.Name = "lue_Brand";
            this.lue_Brand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_Brand.Size = new System.Drawing.Size(100, 20);
            this.lue_Brand.TabIndex = 13;
            this.lue_Brand.EditValueChanged += new System.EventHandler(this.lue_Brand_EditValueChanged);
            // 
            // lue_Type
            // 
            this.lue_Type.Location = new System.Drawing.Point(302, 23);
            this.lue_Type.Name = "lue_Type";
            this.lue_Type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_Type.Size = new System.Drawing.Size(100, 20);
            this.lue_Type.TabIndex = 14;
            // 
            // lue_Supplier
            // 
            this.lue_Supplier.Location = new System.Drawing.Point(70, 153);
            this.lue_Supplier.Name = "lue_Supplier";
            this.lue_Supplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_Supplier.Size = new System.Drawing.Size(100, 20);
            this.lue_Supplier.TabIndex = 15;
            // 
            // IntoStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "IntoStorage";
            this.Size = new System.Drawing.Size(430, 328);
            this.Load += new System.EventHandler(this.IntoStorage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_IMEI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Cost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_Brand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_Type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_Supplier.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txt_IMEI;
        private DevExpress.XtraEditors.TextEdit txt_Cost;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.LookUpEdit lue_Brand;
        private DevExpress.XtraEditors.LookUpEdit lue_Type;
        private DevExpress.XtraEditors.LookUpEdit lue_Supplier;
    }
}
