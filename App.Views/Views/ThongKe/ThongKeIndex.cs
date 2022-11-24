using App.Business.Sevices.ThongKes;
using App.Data.Ultilities.Catalog.Orders;
using App.Data.Ultilities.ViewModels;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Views.Views.ThongKe
{
    public partial class ThongKeIndex : Form
    {
        private readonly IThongKeServices _thongKeServices;
        public GetThongKeRequest Request { get; set; } = new();
        public ThongKeViewModel Result { get; set; }

        public ThongKeIndex(IThongKeServices thongKeServices)
        {
            InitializeComponent();
            _thongKeServices = thongKeServices;
        }
        private Func<ChartPoint, string> labelPoint = charpoint =>
            string.Format("{0}({1:P})", charpoint.Y, charpoint.Participation);
        private async Task LoadThongke()
        {
            Result = await _thongKeServices.GetThongKe(Request);
            DgridLowStocks.DataSource = null;
            DgridLowStocks.DataSource = Result.LowStocks;
            lblTotalOrder.Text = Result.TotalOrders.ToString();
            LblCanceled.Text = Result.TotalOrderCanceleds.ToString();
            LblOrderConfirms.Text = Result.TotalOrderConfirms.ToString();
            LblShipping.Text = Result.TotalOrderShippings.ToString();
            LblRevenues.Text = Result.Revenues.Sum().ToString() + "VNĐ";
            LblSucces.Text = Result.TotalOrderSuccesss.ToString();
            var titles = new List<string>();
            for (DateTime i = Request.Started.Date; i <= Request.Ended.Date; i = i.AddDays(1))
            {
                titles.Add(i.ToString("dd/MM/yyyy"));
            }
            ChartRevenues.AxisY.Clear();
            ChartRevenues.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Doanh thu ",
            });
            ChartRevenues.AxisX.Clear();
            ChartRevenues.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Ngày",
                Labels = titles.ToArray()
            });
            PieTop5.Series.Clear();
            foreach (var x in Result.TopFive)
            {
                PieTop5.Series.Add(new PieSeries()
                {
                    Title = x.Name,
                    Values = new ChartValues<double>() { x.Count },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }
            PieTop5.LegendLocation = LegendLocation.Bottom;
            ChartRevenues.Series.Clear();
            int j = 0;
            var chart = new ChartValues<decimal>();
            chart.AddRange(Result.Revenues);
            ChartRevenues.Series.Add(new LineSeries()
            {
                Title = "Doanh thu",
                Values = chart
            });
        }
        private async void ThongKeIndex_Load(object sender, EventArgs e)
        {
            await AcctiveButton(BtnDay);
            Request.Ended = DateTime.Now;
            Request.Started = DateTime.Now.AddDays(-1);
            await LoadThongke();
        }

        private async void dateEnded_ValueChanged(object sender, EventArgs e)
        {
            if(dateStarted.Value>dateEnded.Value)
            {
                dateStarted.Value = dateEnded.Value.AddDays(-1);
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày thúc");
            }
            else
            {
                Request.Ended = dateEnded.Value;
                Request.Started = dateStarted.Value;
                await LoadThongke();
            }
        }
        public Button BtnActive { get; set; } = new();
        private async  Task AcctiveButton(Button button)
        {
            BtnActive.BackColor = Color.White;
            BtnActive.ForeColor = Color.FromArgb(90, 76, 219);
            BtnActive = button;
            BtnActive.ForeColor = Color.White;
            BtnActive.BackColor = Color.FromArgb(90, 76, 219);
            if (BtnActive == BtnCustom)
            {
                dateStarted.Enabled= true;
                dateEnded.Enabled = true;
            }
            else
            {
                dateStarted.Enabled = false;
                dateEnded.Enabled = false;
            }
        }
        private async void BtnDay_Click(object sender, EventArgs e)
        {
            await AcctiveButton(BtnDay);
            Request.Ended = DateTime.Now;
            Request.Started = DateTime.Now.AddDays(-1);
            await LoadThongke();
        }

        private async void BtnWeek_Click(object sender, EventArgs e)
        {
            await AcctiveButton(BtnWeek);
            Request.Ended = DateTime.Now;
            Request.Started = DateTime.Now.AddDays(-7);
            await LoadThongke();
        }

        private async void BtnMonth_Click(object sender, EventArgs e)
        {
            await AcctiveButton(BtnMonth);
            Request.Ended = DateTime.Now;
            Request.Started = DateTime.Now.AddDays(-30);
            await LoadThongke();
        }

        private async void BtnYear_Click(object sender, EventArgs e)
        {
            await AcctiveButton(BtnYear);
            Request.Ended = DateTime.Now;
            Request.Started = DateTime.Now.AddDays(-365);
            await LoadThongke();
        }

        private async void BtnCustom_Click(object sender, EventArgs e)
        {
            await AcctiveButton(BtnCustom);
            Request.Ended = dateEnded.Value;
            Request.Started = dateStarted.Value;
            await LoadThongke();
        }
    }

}
