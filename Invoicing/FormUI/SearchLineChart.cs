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
using DevExpress.XtraCharts;

namespace Invoicing.FormUI
{
    public partial class SearchLineChart : DevExpress.XtraEditors.XtraUserControl
    {
        public SearchLineChart()
        {
            InitializeComponent();
        }

        private void SearchLineChart_Load(object sender, EventArgs e)
        {
            chartControl1.Width = this.Width;

            //DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            //this.chartControl1.Series[0].View = lineSeriesView1; 

            //DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView1 = new DevExpress.XtraCharts.StackedBarSeriesView();
            //this.chartControl1.Series[0].View = stackedBarSeriesView1;  

            chartControl1.DataSource = GetData_Month(DateTime.Now);

            Series s1 = this.chartControl1.Series[0];//新建一个series类并给控件赋值  
            s1.ArgumentDataMember = "Date";        //绑定图表的横坐标
            s1.ValueDataMembers[0] = "Count";        //绑定图表的纵坐标
            s1.LegendText = "个数";//设置图例文字 就是右上方的小框框   
        }

        private DataTable GetData_Month(DateTime time)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Count", typeof(int));       //个数
            dt.Columns.Add("Date", typeof(string));      //日期

            DataRow dr;
            try
            {
                Service.IService.IMobilePhone service = new Service.ServiceImp.MobilePhone();
                var firstDay = Convert.ToDateTime(time.Year + "-" + time.Month + "-01");
                var lastDay = Convert.ToDateTime(Convert.ToDateTime(time.AddMonths(1).ToString("yyyy-MM-01")).AddDays(-1).ToString("yyyy-MM-dd 23:59"));
                var list = service.LoadListAll(p => p.MobileOutTime >= firstDay && p.MobileOutTime < lastDay);

                for (int i = 1; i <= DateTime.DaysInMonth(time.Year, time.Month); i++)
                {
                    dr = dt.NewRow();
                    dr["Date"] = Convert.ToDateTime(time.Year + "-" + time.Month + "-" + i).ToString("yyyy-MM-dd");
                    dr["Count"] = list.Where(p => p.MobileOutTime >= Convert.ToDateTime(dr["Date"].ToString()) && p.MobileOutTime < Convert.ToDateTime(dr["Date"].ToString() + " 23:59")).ToList().Count;
                    dt.Rows.Add(dr);
                }
            }
            catch (Exception)
            {
                throw;
            }


            return dt;
        }
    }
}
