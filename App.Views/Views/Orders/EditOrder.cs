using App.Business.Sevices.Orders;
using App.Data.Entities;
using App.Data.Ultilities.Enums;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
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
    public partial class EditOrder : Form
    {
        private readonly IOrderService _orderService;
        public Order Order { get; set; }
        public EditOrder(IOrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;
        }
        private List<OrderStatus> Statuses { get; set; }
        private void EditOrder_Load(object sender, EventArgs e)
        {
            if (Order.Status == OrderStatus.Success)
            {
                Statuses = new List<OrderStatus>() { Order.Status, OrderStatus.Canceled };
                CombStatus.Items.AddRange(new object[] { Order.Status.ToString(), OrderStatus.Canceled.ToString() });
            }
            if (Order.Status == OrderStatus.Confirmed)
            {
                Statuses = new List<OrderStatus>() { Order.Status, OrderStatus.Shipping, OrderStatus.Canceled };
                CombStatus.Items.AddRange(new object[] { Order.Status.ToString(), OrderStatus.Shipping.ToString(), OrderStatus.Canceled.ToString() });
            }
            if (Order.Status == OrderStatus.Shipping)
            {
                Statuses = new List<OrderStatus>() { Order.Status, OrderStatus.Success, OrderStatus.Canceled };
                CombStatus.Items.AddRange(new object[] { Order.Status.ToString(), OrderStatus.Success.ToString(), OrderStatus.Canceled.ToString() });
            }
            LblName.Text = "Hóa đơn " + Order.Id.ToString();
            txtAddress.Text = Order.ShipAddress;
            txtCustomerName.Text = Order.ShipName;
            txtEmail.Text = Order.ShipEmail;
            txtNote.Text = Order.Description;
            txtPhoneNumber.Text = Order.ShipPhoneNumber;
            //
            CombStatus.SelectedIndex = 0;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            Order.Status = Statuses[CombStatus.SelectedIndex];
            Order.ShipAddress = txtAddress.Text;
            Order.Description = txtNote.Text;
            Order.ShipName = txtCustomerName.Text;
            Order.ShipPhoneNumber = txtPhoneNumber.Text;
            Order.ShipEmail = txtEmail.Text;
            if (MessageBox.Show("Bạn có muốn lưu thay đổi?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (await _orderService.UpdateOrder(Order, new OrderHistory() { Edited = DateTime.Now, Status = Order.Status, Details = txtOrderHistoriesDetails.Text, OderId = Order.Id ,EditorName = "Tùng",OderName="Tùng" }))
                {
                    MessageBox.Show("Cập nhật hóa đơn thành công!");
                    Close();
                }
            }
            
        }
      
        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn quay lại trang hóa đơn?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

    }
}
