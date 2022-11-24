using App.Business.Sevices.Products;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.Enums;
using App.Data.Ultilities.PagingModels;
using App.Views.Models.Controls;
using App.Data.Ultilities.Catalog.Orders;
using App.Data.Ultilities.ViewModels;
using App.Views.Views.Product;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Business.Sevices.Orders;

namespace App.Views.Views.Orders
{
    public partial class OrderIndex : Form
    {
        private readonly IServiceProvider _serviceProvide;
        private readonly IOrderService _orderService;
        public GetPagingOrderRequest Request { get; set; } = new();
        public PagedResult<OderInPagingVm> Result { get; set; }
        public OrderIndex(IServiceProvider serviceProvide, IOrderService orderService)
        {
            InitializeComponent();
            _serviceProvide = serviceProvide;
            _orderService = orderService;
        }

        #region LoadForm
        public async Task LoadForm()
        {
            await LoadViewTable();
            await LoadMenuPaging();
        }
        //Load Filter
        public List<CheckBox> CheckBoxes { get; set; } = new(); // List check box trong View

        // Load data to viewtable
        public async Task LoadViewTable()
        {
            TblOrders.Controls.Clear();
            int index = 0;
            foreach (var item in Result.Items)
            {


                var BtnCancel = new VBButton();

                BtnCancel.BackColor = System.Drawing.Color.Red;
                BtnCancel.BackgroundColor = System.Drawing.Color.Red;
                BtnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
                BtnCancel.BorderRadius = 5;
                BtnCancel.BorderSize = 0;
                BtnCancel.FlatAppearance.BorderSize = 0;
                BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                BtnCancel.ForeColor = System.Drawing.Color.White;
                BtnCancel.IconChar = FontAwesome.Sharp.IconChar.X;
                BtnCancel.IconColor = System.Drawing.Color.White;
                BtnCancel.IconFont = FontAwesome.Sharp.IconFont.Solid;
                BtnCancel.IconSize = 20;
                BtnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                BtnCancel.Location = new System.Drawing.Point(1227, 6);
                BtnCancel.Margin = new System.Windows.Forms.Padding(6);
                BtnCancel.Name = "BtnCancel";
                BtnCancel.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
                BtnCancel.Size = new System.Drawing.Size(28, 28);
                BtnCancel.TabIndex = 13;
                BtnCancel.TextColor = System.Drawing.Color.White;
                BtnCancel.UseVisualStyleBackColor = false;

                var BtnEdit = new VBButton();

                BtnEdit.BackColor = System.Drawing.Color.MediumSlateBlue;
                BtnEdit.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                BtnEdit.BorderColor = System.Drawing.Color.PaleVioletRed;
                BtnEdit.BorderRadius = 5;
                BtnEdit.BorderSize = 0;
                BtnEdit.FlatAppearance.BorderSize = 0;
                BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                BtnEdit.ForeColor = System.Drawing.Color.White;
                BtnEdit.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
                BtnEdit.IconColor = System.Drawing.Color.Black;
                BtnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
                BtnEdit.IconSize = 20;
                BtnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                BtnEdit.Location = new System.Drawing.Point(1187, 6);
                BtnEdit.Margin = new System.Windows.Forms.Padding(6);
                BtnEdit.Name = "BtnEdit";
                BtnEdit.Size = new System.Drawing.Size(28, 28);
                BtnEdit.TabIndex = 12;
                BtnEdit.TextColor = System.Drawing.Color.White;
                BtnEdit.UseVisualStyleBackColor = false;
                //
                var labelType = new Label();


                labelType.Anchor = System.Windows.Forms.AnchorStyles.Left;
                labelType.AutoSize = true;
                labelType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                labelType.ForeColor = System.Drawing.Color.Black;
                labelType.Location = new System.Drawing.Point(3, 8);
                labelType.Name = "label8";
                labelType.Size = new System.Drawing.Size(19, 23);
                labelType.TabIndex = 0;
                labelType.Text = !item.IsShipping ? "Trực Tiếp" : "Đặt Hàng";
                //
                var label8 = new Label();
                label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label8.AutoSize = true;
                label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label8.ForeColor = System.Drawing.Color.Black;
                label8.Location = new System.Drawing.Point(3, 8);
                label8.Name = "label8";
                label8.Size = new System.Drawing.Size(19, 23);
                label8.TabIndex = 0;
                label8.Text = (index++).ToString(); 

                var label10 = new Label();

                label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label10.AutoSize = true;
                label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label10.ForeColor = System.Drawing.Color.Black;
                label10.Location = new System.Drawing.Point(59, 8);
                label10.Name = "label10";
                label10.Size = new System.Drawing.Size(19, 23);
                label10.TabIndex = 4;
                label10.Text = item.Id.ToString();

                var label11 = new Label();

                label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label11.AutoSize = true;
                label11.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label11.ForeColor = System.Drawing.Color.Black;
                label11.Location = new System.Drawing.Point(130, 8);
                label11.Name = "label11";
                label11.Size = new System.Drawing.Size(107, 23);
                label11.TabIndex = 5;
                label11.Text = item.CustomerName;

                var label12 = new Label();

                label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label12.AutoSize = true;
                label12.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label12.ForeColor = System.Drawing.Color.Black;
                label12.Location = new System.Drawing.Point(344, 8);
                label12.Name = "label12";
                label12.Size = new System.Drawing.Size(107, 23);
                label12.TabIndex = 7;
                label12.Text = item.UserName;

                var label16 = new Label();

                label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                label16.AutoSize = true;
                label16.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label16.ForeColor = System.Drawing.Color.Black;
                label16.Location = new System.Drawing.Point(526, 8);
                label16.Name = "label16";
                label16.Size = new System.Drawing.Size(116, 23);
                label16.TabIndex = 8;
                label16.Text = item.Status.ToString();

                var label17 = new Label();

                label17.AllowDrop = true;
                label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                label17.AutoSize = true;
                label17.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label17.ForeColor = System.Drawing.Color.Black;
                label17.Location = new System.Drawing.Point(648, 8);
                label17.Name = "label17";
                label17.Size = new System.Drawing.Size(336, 23);
                label17.TabIndex = 9;
                label17.Text = item.Created.ToString();
                label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                var label18 = new Label();

                label18.Anchor = System.Windows.Forms.AnchorStyles.None;
                label18.AutoSize = true;
                label18.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label18.ForeColor = System.Drawing.Color.Black;
                label18.Location = new System.Drawing.Point(1002, 8);
                label18.Name = "label18";
                label18.Size = new System.Drawing.Size(124, 23);
                label18.TabIndex = 10;
                label18.Text = item.Total.ToString()+" vnđ";

                var BtnInfo = new VBButton();

                BtnInfo.BackColor = System.Drawing.Color.MediumSlateBlue;
                BtnInfo.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                BtnInfo.BorderColor = System.Drawing.Color.PaleVioletRed;
                BtnInfo.BorderRadius = 5;
                BtnInfo.BorderSize = 0;
                BtnInfo.FlatAppearance.BorderSize = 0;
                BtnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                BtnInfo.ForeColor = System.Drawing.Color.White;
                BtnInfo.IconChar = FontAwesome.Sharp.IconChar.Info;
                BtnInfo.IconColor = System.Drawing.Color.Black;
                BtnInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
                BtnInfo.IconSize = 20;
                BtnInfo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                BtnInfo.Location = new System.Drawing.Point(1147, 6);
                BtnInfo.Margin = new System.Windows.Forms.Padding(6);
                BtnInfo.Name = "BtnInfo";
                BtnInfo.Size = new System.Drawing.Size(28, 28);
                BtnInfo.TabIndex = 11;
                BtnInfo.TextColor = System.Drawing.Color.White;
                BtnInfo.UseVisualStyleBackColor = false;
                //
                var tblOrder = new TableLayoutPanel();
                tblOrder.BackColor = System.Drawing.Color.White;
                tblOrder.ColumnCount = 11;
                tblOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
                tblOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
                tblOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
                tblOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
                tblOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
                tblOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
                tblOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tblOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
                tblOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tblOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tblOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tblOrder.Controls.Add(BtnCancel, 10, 0);
                tblOrder.Controls.Add(BtnEdit, 9, 0);
                tblOrder.Controls.Add(label8, 0, 0);
                tblOrder.Controls.Add(label10, 1, 0);
                tblOrder.Controls.Add(label11, 2, 0);
                tblOrder.Controls.Add(label12, 3, 0);
                tblOrder.Controls.Add(labelType, 4, 0);
                tblOrder.Controls.Add(label16, 5, 0);
                tblOrder.Controls.Add(label17, 6, 0);
                tblOrder.Controls.Add(label18, 7, 0);
                tblOrder.Controls.Add(BtnInfo, 8, 0);
                tblOrder.Location = new System.Drawing.Point(0, 0);
                tblOrder.Margin = new System.Windows.Forms.Padding(0);
                tblOrder.Name = "tblOrder";
                tblOrder.RowCount = 1;
                tblOrder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                tblOrder.Size = new System.Drawing.Size(1261, 40);
                tblOrder.TabIndex = 2;
                //
                BtnInfo.Click += async (o, s) =>
                {
                    await BtnDetail_Click(item.Id);
                };
                BtnEdit.Click += async(o, s) =>
                {
                    await BtnEdit_Click(item.Id);
                };
                TblOrders.Controls.Add(tblOrder);
            }
            lblResult.Text = Result.TotalRecords.ToString() + " Kết quả";
        }
        public async Task LoadMenuPaging()
        {
            try
            {

                TxtPageIndex.Text = Result.PageIndex.ToString();
                LblPageLastIndex.Text = "/" + Result.PageCount.ToString();
            }
            catch
            {

            }
        }
        #endregion

        private async void TxtPageIndex_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var index = Convert.ToInt32(TxtPageIndex.Text);
                if (index > 0 && index < Result.PageSize)
                {
                    Result.PageIndex = index;
                }
                else
                {
                    TxtPageIndex.Text = Result.PageIndex.ToString();
                    MessageBox.Show("Số trang phải lớn hơn 0 và nhỏ hơn hoặc bằng tổng số lượng trang!");
                }
            }
            catch
            {
                TxtPageIndex.Text = Result.PageIndex.ToString();
            }
        }

        private async void btn_next_Click(object sender, EventArgs e)
        {
            if (Result.PageIndex < Result.PageSize)
            {
            }
            else
            {
                MessageBox.Show("Đã là trang cuối!");
            }
        }

        private async void btn_last_Click(object sender, EventArgs e)
        {
            if (Result.PageIndex < Result.PageSize)
            {
            }
            else
            {
                MessageBox.Show("Đã là trang cuối!");
            }
        }

        private void TxtPageIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được phép nhập số !");
            }
        }

        private async Task BtnDetail_Click(int Id)
        {
            var frmDetail = _serviceProvide.GetRequiredService<OderDetail>();
            frmDetail.TopLevel = false;
            frmDetail.Order = await _orderService.GetOrderVmById(Id);
            this.Controls.Add(frmDetail);
            frmDetail.FormClosed +=  async(o, s) =>
            {
                this.Controls[0].Visible = true;
                Result = await _orderService.GetPagingOrder(Request);
                await LoadViewTable();
            };
            this.Controls[0].Visible = false;
            frmDetail.Show();
        }
        private async Task BtnEdit_Click(int Id)
        {
            var frmDetail = _serviceProvide.GetRequiredService<EditOrder>();
            frmDetail.TopLevel = false;
            frmDetail.Order = await _orderService.GetOrderById(Id);
            this.Controls.Add(frmDetail);
            frmDetail.FormClosed +=async (o, s) =>
            {
                this.Controls[0].Visible = true;
                Result = await _orderService.GetPagingOrder(Request);
                await LoadViewTable();
            };
            this.Controls[0].Visible = false;
            
            frmDetail.Show();
        }

        private async void OrderIndex_Load(object sender, EventArgs e)
        {
            Result = await _orderService.GetPagingOrder(Request);
            await LoadViewTable();
        }
    }
}
