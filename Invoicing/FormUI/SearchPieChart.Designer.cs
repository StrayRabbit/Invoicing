namespace Invoicing.FormUI
{
    partial class SearchPieChart
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
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lbl_Date = new DevExpress.XtraEditors.LabelControl();
            this.txt_Date = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cb_Type = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Date.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lbl_Date);
            this.panelControl1.Controls.Add(this.txt_Date);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.cb_Type);
            this.panelControl1.Location = new System.Drawing.Point(13, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(959, 31);
            this.panelControl1.TabIndex = 4;
            // 
            // lbl_Date
            // 
            this.lbl_Date.Location = new System.Drawing.Point(207, 9);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(60, 14);
            this.lbl_Date.TabIndex = 3;
            this.lbl_Date.Text = "选择月份：";
            this.lbl_Date.Visible = false;
            // 
            // txt_Date
            // 
            this.txt_Date.EditValue = null;
            this.txt_Date.Location = new System.Drawing.Point(273, 6);
            this.txt_Date.Name = "txt_Date";
            this.txt_Date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_Date.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_Date.Properties.DisplayFormat.FormatString = "yyyy-MM";
            this.txt_Date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txt_Date.Properties.Mask.EditMask = "yyyy-MM";
            this.txt_Date.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txt_Date.Size = new System.Drawing.Size(100, 20);
            this.txt_Date.TabIndex = 2;
            this.txt_Date.Visible = false;
            this.txt_Date.EditValueChanged += new System.EventHandler(this.txt_Date_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "统计类型：";
            // 
            // cb_Type
            // 
            this.cb_Type.Location = new System.Drawing.Point(70, 6);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cb_Type.Properties.Items.AddRange(new object[] {
            "月度统计",
            "年度统计"});
            this.cb_Type.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cb_Type.Size = new System.Drawing.Size(100, 20);
            this.cb_Type.TabIndex = 0;
            this.cb_Type.SelectedIndexChanged += new System.EventHandler(this.cb_Type_SelectedIndexChanged);
            // 
            // chartControl1
            // 
            this.chartControl1.Location = new System.Drawing.Point(13, 42);
            this.chartControl1.Name = "chartControl1";
            series1.Name = "Series 1";
            series1.View = pieSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(959, 452);
            this.chartControl1.TabIndex = 3;
            chartTitle1.Text = "";
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // SearchPieChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.chartControl1);
            this.Name = "SearchPieChart";
            this.Size = new System.Drawing.Size(1014, 499);
            this.Load += new System.EventHandler(this.SearchPieChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Date.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_Date;
        private DevExpress.XtraEditors.DateEdit txt_Date;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cb_Type;
        private DevExpress.XtraCharts.ChartControl chartControl1;
    }
}
