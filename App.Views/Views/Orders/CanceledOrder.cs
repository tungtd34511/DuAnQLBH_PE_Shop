using App.Business.Sevices.Orders;
using App.Data.Entities;
using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Views.Views.Orders
{
    public partial class CanceledOrder : Form
    {
        private readonly IOrderService _orderService;
        public int OrderId { get; set; }
        public Data.Entities.Order Order { get; set; }
        public OrderHistory history { get; set; } = new();
        public Data.Entities.User User { get; set; }
        public CanceledOrder(IOrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var txt = await Validate();
            if (txt != "")
            {
                MessageBox.Show(txt);
            }
            else
            {
                Order.Status = Data.Ultilities.Enums.OrderStatus.Canceled;
                history = new OrderHistory() { Details = LblNote.Text, Status = OrderStatus.Canceled, Edited = DateTime.Now, EditorName = (await _orderService.GetDetailByuserID(User.Id)).Name, OderId = Order.Id, OderName = "admin" };
                if (await _orderService.CanceledOrder(Order, history))
                {
                    MessageBox.Show("Hủy đơn thành công !");
                    Close();
                }
                else
                {
                    MessageBox.Show("Hủy đơn thất bại !");
                }
            }
        }
        private async Task<string> Validate()
        {
            var txt = "";
            if (String.IsNullOrEmpty(LblNote.Text))
            {
                txt += "Mời bạn nhập lý do!";
            }
            return txt;
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void CanceledOrder_Load(object sender, EventArgs e)
        {
            Order = await _orderService.GetOrderById(OrderId);
        }
    }
}
