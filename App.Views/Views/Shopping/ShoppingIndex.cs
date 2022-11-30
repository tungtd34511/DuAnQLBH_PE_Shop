using AForge.Video.DirectShow;
using App.Business.Sevices.Shoppings;
using App.Data.Entities;
using App.Data.Ultilities.Catalog.Carts;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.ViewModels;
using App.Views.Models.Controls;
using FontAwesome.Sharp;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Timer = System.Windows.Forms.Timer;

namespace App.Views.Views.Shopping
{
    public partial class ShoppingIndex : Form
    {
        #region Fields and Property
        private readonly IShoppingService _shoppingService;
        private readonly IServiceProvider _serviceProviders;
        public IEnumerable<Customer> Customers { get; set; }
        public delegate void AddToCarts(AddToCartRequest request);
        public PagedResult<ProductInShoppingVm> Result { get; set; } = new();
        public GetPagingShoppingRequest Request { get; set; } = new() { PageSize = 12 };
        public Data.Entities.User User { get; set; }
        public Data.Entities.Customer Customer { get; set; } = new();
        public List<Cart> Carts { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public Cart CartShow { get; set; }
        public List<CheckBox> CheckBoxes { get; set; } = new();
        public Panel PanlActive { get; set; } = new(); // làm sáng hóa đơn được bật
        #endregion
        #region Constructer
        public ShoppingIndex(IShoppingService shoppingService, IServiceProvider serviceProviders)
        {
            InitializeComponent();
            _shoppingService = shoppingService;
            _serviceProviders = serviceProviders;
        }
        #endregion
        #region Mehthods
        //Loaddata to View
        private async Task LoadBill()
        {
            if (!CartItems.Any())
            {
                LblTotalprice.Text = "0";
                txtTotalBill.Text = "0";
                txtCustomerMoney.ReadOnly = true;
                txtCustomerMoney.Text = "0";
                lblmoneyover.Text = "0";
            }
            else
            {
                txtCustomerMoney.ReadOnly = false;
                var total = CartItems.Select(d => (d.Price * (100 - d.DiscountPercent) / 100) * d.Quantity).Sum();
                LblTotalprice.Text = total.ToString("#,###");
                txtTotalBill.Text = (total * 100 / 100).ToString("#,###");
                lblmoneyover.Text = (Convert.ToDecimal(txtCustomerMoney.Text) - total).ToString("#,###");
            }
        }
        private async Task LoadTblProducts()
        {
            
            LblIndex.Text = Result.PageIndex.ToString() + "/" + Result.PageIndex.ToString();
            TblProducts.Controls.Clear();
            foreach (var item in Result.Items)
            {
                var LblSale = new Label();
                LblSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                LblSale.AutoSize = true;
                LblSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(219)))));
                LblSale.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                LblSale.ForeColor = System.Drawing.Color.White;
                LblSale.Margin = new System.Windows.Forms.Padding(0);
                LblSale.Name = "LblSale";
                LblSale.Size = new System.Drawing.Size(54, 23);
                LblSale.Text = "-"+item.DiscountPercent.ToString()+"%";
                if (item.DiscountPercent == 0)
                {
                    LblSale.Visible = false;
                }
                var LblPrice = new Label();

                LblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                LblPrice.AutoSize = true;
                LblPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(219)))));
                LblPrice.ForeColor = System.Drawing.Color.White;
                LblPrice.Margin = new System.Windows.Forms.Padding(0);
                LblPrice.Name = "LblPrice";
                LblPrice.Margin = new Padding(0);
                LblPrice.Size = new System.Drawing.Size(99, 20);
                LblPrice.Text = (item.Price*(100-item.DiscountPercent)/100).ToString("#,### vnđ");

                var BtnName = new Button();

                BtnName.BackColor = System.Drawing.Color.White;
                BtnName.Dock = System.Windows.Forms.DockStyle.Fill;
                BtnName.FlatAppearance.BorderSize = 0;
                BtnName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                BtnName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
                BtnName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                BtnName.Name = "BtnName";
                BtnName.Size = new System.Drawing.Size(175, 43);
                BtnName.Margin = new Padding(0);
                BtnName.Text = item.Name;
                BtnName.UseVisualStyleBackColor = false;



                var TblProduct = new TableLayoutPanel();

                TblProduct.BackColor = System.Drawing.Color.White;
                TblProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                TblProduct.ColumnCount = 1;
                TblProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                TblProduct.Controls.Add(LblSale, 0, 0);
                TblProduct.Controls.Add(LblPrice, 0, 1);
                TblProduct.Controls.Add(BtnName, 0, 2);
                try
                {
                    if (item.ThumbailImage != null)
                    {
                        TblProduct.BackgroundImage = Image.FromFile(item.ThumbailImage);
                    }
                }
                catch
                {

                }
                TblProduct.Name = "TblProduct";
                TblProduct.RowCount = 3;
                TblProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.04301F));
                TblProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.95699F));
                TblProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
                TblProduct.Size = new System.Drawing.Size(184, 204);
                TblProduct.Click += async (o, s) =>
                {
                    await ShowAddToCart(item.Id,item.DiscountPercent);
                };
                TblProducts.Controls.Add(TblProduct);

            }
        }
        private async Task LoadCartDetail(Cart cart)
        {
            Customer = new Customer();
            TblItems.Controls.Clear();
            if (CartItems.Any())
            {
                foreach (var item in CartItems)
                {
                    await AddPanlItemCart(new AddToCartRequest()
                    {
                        ColorId = item.ColorId,
                        ColorName = item.ColorName,
                        SizeId = item.SizeId,
                        SizeName = item.Sizename,
                        productId = item.ProductId,
                        productName = item.ProductName,
                        PvId = item.PvId,
                        Quantity = item.Quantity,
                        DiscountPercent = item.DiscountPercent,
                    });
                }
            }
            await LoadCartInfo(cart);
            await LoadBill();
        }
        private async Task LoadCartInfo(Cart cart)
        {
            txtAddress.Text = cart.ShipAddress;
            txtCustomerMoney.Text = cart.CustomerMoney.ToString();
            txtCustomerName.Text = cart.CustomerName;
            txtAddress.Text = cart.ShipAddress;
            txtEmail.Text = cart.ShipEmail;
            txtPhoneNumber.Text = cart.ShipPhoneNumber;
            txtDescription.Text = cart.Description;
        }
        public async Task LoadMenuPaging()
        {
            try
            {
                LblIndex.Text = Result.PageIndex.ToString() + "/" + Result.PageCount.ToString();
            }
            catch
            {

            }
        }
        //
        private async Task SetupList()
        {
            var items = await _shoppingService.GetProductInCarts(CartShow.Id);
            if (!items.Any())
            {
                CartShow.ProductInCarts = new();
                CartItems = new();
            }
            else
            {
                CartShow.ProductInCarts = items;
                CartItems = await _shoppingService.GetItemByCartId(CartShow.Id);
            }
            await LoadCartDetail(CartShow);
        }
        private async Task AddPanlFilter()
        {
            #region Design panel Fillter
            MenuFillter.Items.Clear();

            var PanlFilter = new FlowLayoutPanel()
            {
                BackColor = System.Drawing.Color.White,
                MinimumSize = new System.Drawing.Size(1090, 400),
                Size = MinimumSize,
                AutoScroll = true,
            };
            var titles = new List<string>() { "Danh Mục", "Màu Sắc", "Kích Cỡ", "Giá"/*, "Khác" */};
            var data = await _shoppingService.GetDataForFilter();
            var categories = data.Categories.Select(c => c.Name).ToList();
            var colors = data.Colors.Select(c => c.Name).ToList();
            var sizes = data.Sizes.Select(c => c.Id).ToList();
            var prices = new List<string>() { "Dưới 199.000 VNĐ", "199.000 VNĐ - 299.000 VNĐ", "299.000 VNĐ - 399.000 VNĐ", "399.000 VNĐ - 499.000 VNĐ", "499.000 VNĐ - 799.000 VNĐ", "799.000 VNĐ - 999.000", "Trên 999.000 VNĐ" };
            List<List<string>> lstList = new List<List<string>>() { categories, colors, sizes, prices };
            //
            int index = 0;
            foreach (var item in titles)
            {
                //
                var flowLayoutPanel1 = new FlowLayoutPanel();
                flowLayoutPanel1.AutoSize = false;
                flowLayoutPanel1.BackColor = System.Drawing.Color.White;
                flowLayoutPanel1.Dock = DockStyle.Top;
                flowLayoutPanel1.Margin = new Padding(0);
                flowLayoutPanel1.Name = "flowLayoutPanel1";
                flowLayoutPanel1.Padding = new Padding(5);
                flowLayoutPanel1.Size = new System.Drawing.Size(287, 20);
                //
                var vbButton10 = new VBButton();
                vbButton10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
                vbButton10.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
                vbButton10.BorderColor = System.Drawing.Color.PaleVioletRed;
                vbButton10.BorderRadius = 5;
                vbButton10.BorderSize = 0;
                vbButton10.Dock = DockStyle.Fill;
                vbButton10.FlatAppearance.BorderSize = 0;
                vbButton10.FlatStyle = FlatStyle.Flat;
                vbButton10.ForeColor = System.Drawing.Color.White;
                vbButton10.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                vbButton10.IconChar = FontAwesome.Sharp.IconChar.None;
                vbButton10.IconColor = System.Drawing.Color.Black;
                vbButton10.IconFont = FontAwesome.Sharp.IconFont.Auto;
                vbButton10.Margin = new Padding(0);
                vbButton10.Name = "vbButton10";
                vbButton10.Size = new System.Drawing.Size(260, 48);
                vbButton10.Text = item;
                vbButton10.TextColor = System.Drawing.Color.White;
                vbButton10.UseVisualStyleBackColor = false;
                //
                var tableLayoutPanel6 = new TableLayoutPanel();
                tableLayoutPanel6.AutoSize = false;
                tableLayoutPanel6.BackColor = SystemColors.Control;
                tableLayoutPanel6.ColumnCount = 1;
                tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tableLayoutPanel6.Location = new Point(3, 3);
                tableLayoutPanel6.Name = "tableLayoutPanel6";
                tableLayoutPanel6.Padding = new Padding(3);
                tableLayoutPanel6.RowCount = 2;
                tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
                tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutPanel6.Size = new System.Drawing.Size(287, 20);
                //

                foreach (var ctl in lstList[index])
                {
                    var check = new CheckBox()
                    {
                        AutoSize = true,
                        Dock = DockStyle.Top,
                        Name = "checkBox1",
                        Size = new System.Drawing.Size(101, 24),
                        Text = ctl,
                        UseVisualStyleBackColor = true
                    };
                    check.Click += async (o, s) =>
                    {
                        await Check_Click();
                    };
                    flowLayoutPanel1.Controls.Add(check);
                    CheckBoxes.Add(check);
                };
                var heigh = (lstList[index].Count * 30) + 10;
                flowLayoutPanel1.Height = heigh;
                //
                tableLayoutPanel6.Controls.Add(vbButton10, 0, 0);
                tableLayoutPanel6.Controls.Add(flowLayoutPanel1, 0, 1);
                tableLayoutPanel6.Height = heigh + 54;
                //
                PanlFilter.Controls.Add(tableLayoutPanel6);
                flowLayoutPanel1.AutoSize = true;
                tableLayoutPanel6.AutoSize = true;
                index++;
            }
            #endregion
            var hostTool = new ToolStripControlHost(PanlFilter)
            {
                Padding = Padding.Empty,
                Margin = Padding.Empty,
                AutoSize = true,
            };
            MenuFillter.Items.Add(hostTool);
        }
        #region QR code

        #endregion
        private async Task<Panel> AddPanlCart(Cart cart)
        {
            // 
            // pnlCart
            // 
            var BtnSpan = new Button();

            BtnSpan.BackColor = System.Drawing.Color.LightGray;
            BtnSpan.Dock = System.Windows.Forms.DockStyle.Right;
            BtnSpan.FlatAppearance.BorderSize = 0;
            BtnSpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BtnSpan.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            BtnSpan.Name = "BtnSpan";
            BtnSpan.Size = new System.Drawing.Size(2, 44);
            BtnSpan.UseVisualStyleBackColor = false;

            var BtnDeleteCart = new VBButton();

            BtnDeleteCart.BackColor = System.Drawing.Color.Transparent;
            BtnDeleteCart.BackgroundColor = System.Drawing.Color.Transparent;
            BtnDeleteCart.BorderColor = System.Drawing.Color.PaleVioletRed;
            BtnDeleteCart.BorderRadius = 20;
            BtnDeleteCart.BorderSize = 0;
            BtnDeleteCart.Dock = System.Windows.Forms.DockStyle.Right;
            BtnDeleteCart.FlatAppearance.BorderSize = 0;
            BtnDeleteCart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            BtnDeleteCart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            BtnDeleteCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BtnDeleteCart.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BtnDeleteCart.ForeColor = System.Drawing.Color.White;
            BtnDeleteCart.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            BtnDeleteCart.IconColor = System.Drawing.Color.Gainsboro;
            BtnDeleteCart.IconFont = FontAwesome.Sharp.IconFont.Solid;
            BtnDeleteCart.IconSize = 30;
            BtnDeleteCart.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            BtnDeleteCart.Name = "BtnDeleteCart";
            BtnDeleteCart.Size = new System.Drawing.Size(38, 44);
            BtnDeleteCart.TextColor = System.Drawing.Color.White;
            BtnDeleteCart.UseVisualStyleBackColor = false;

            var BtnCart = new Button();

            BtnCart.BackColor = System.Drawing.Color.FromArgb(90, 76, 219);
            BtnCart.Dock = System.Windows.Forms.DockStyle.Fill;
            BtnCart.FlatAppearance.BorderSize = 0;
            BtnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BtnCart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BtnCart.Location = new System.Drawing.Point(3, 3);
            BtnCart.Name = "BtnCart";
            BtnCart.Size = new System.Drawing.Size(154, 44);
            BtnCart.ForeColor = System.Drawing.Color.White;
            BtnCart.Text = "Giỏ Hàng " + cart.CartIndex;
            BtnCart.UseVisualStyleBackColor = false;
            var pnlCart = new Panel();
            pnlCart.BackColor = System.Drawing.Color.FromArgb(90, 76, 219);
            pnlCart.Controls.Add(BtnCart);
            pnlCart.Controls.Add(BtnDeleteCart);

            pnlCart.Controls.Add(BtnSpan);
            pnlCart.Margin = new System.Windows.Forms.Padding(0);
            pnlCart.Name = "pnlCart";
            pnlCart.Padding = new System.Windows.Forms.Padding(5);
            pnlCart.Size = new System.Drawing.Size(200, 50);
            pnlCart.TabIndex = 0;

            //
            TblCartTittles.Controls.Add(pnlCart);
            BtnDeleteCart.Click += async (o, s) =>
            {
                var i = TblCartTittles.Controls.IndexOf(pnlCart); // Vị trí của cart trong ds
                if (await _shoppingService.RemoveCart(cart))
                {
                    TblCartTittles.Controls.Remove(pnlCart);
                    Carts.Remove(cart);
                    if (Carts.Count == 0)
                    {
                        var cart1 = new Cart() { CartIndex = 1, CustomerMoney = 0 };
                        Carts.Add(cart1);
                        await _shoppingService.AddCart(cart1);
                        await AcctiveTitleOder(await AddPanlCart(cart1));
                        CartShow = cart1;
                        await SetupList();
                    }
                    else
                    {
                        if (CartShow == cart)
                        {
                            if (i < Carts.Count - 1)
                            {
                                await AcctiveTitleOder((Panel)TblCartTittles.Controls[i]);
                                CartShow = Carts[i];
                                await SetupList();
                            }
                            else
                            {
                                await AcctiveTitleOder((Panel)TblCartTittles.Controls[i]);
                                CartShow = Carts[i];
                                await SetupList();
                            }
                        }
                    }
                }
            };
            BtnCart.Click += async (o, s) =>
            {
                await SetDetailCartShow();
                await _shoppingService.UpdateCart(CartShow);
                await AcctiveTitleOder(pnlCart);
                CartShow = cart;
                await SetupList();
            };
            BtnAddOrder.SendToBack();//Đẩy button ra sau;
            return pnlCart;
        }
        private async Task ShowAddToCart(int productId,int Discount)
        {
            var form = _serviceProviders.GetRequiredService<AddToCart>();
            var product = Result.Items.FirstOrDefault(c => c.Id == productId);
            form.product = product;
            form.Request.DiscountPercent = Discount;
            form.Pvs = await _shoppingService.GetPvVMByProductId(productId);
            await form.LoadDetail(AddProductToCart);
            form.ShowDialog();
        }
        private async Task AddPanlItemCart(AddToCartRequest request)
        {
            var product = Result.Items.FirstOrDefault(c => c.Id == request.productId);
            // 
            // label4
            // 
            var label4 = new Label();
            label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(181, 17);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(545, 25);
            label4.TabIndex = 3;
            label4.Text = request.productName+" " + request.ColorName+" (Size:"+request.SizeId+")";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            var vbButton1 = new VBButton();

            vbButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            vbButton1.BackColor = System.Drawing.Color.White;
            vbButton1.BackgroundColor = System.Drawing.Color.White;
            vbButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            vbButton1.BorderRadius = 20;
            vbButton1.BorderSize = 0;
            vbButton1.FlatAppearance.BorderSize = 0;
            vbButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            vbButton1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            vbButton1.ForeColor = System.Drawing.Color.White;
            vbButton1.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            vbButton1.IconColor = System.Drawing.Color.Red;
            vbButton1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            vbButton1.IconSize = 40;
            vbButton1.Location = new System.Drawing.Point(3, 10);
            vbButton1.Name = "vbButton1";
            vbButton1.Size = new System.Drawing.Size(38, 40);
            vbButton1.TabIndex = 1;
            vbButton1.TextColor = System.Drawing.Color.White;
            vbButton1.UseVisualStyleBackColor = false;

            var customPanel6 = new CustomPanel();

            customPanel6.BackColor = System.Drawing.SystemColors.Control;
            customPanel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            customPanel6.BorderColor = System.Drawing.Color.White;
            customPanel6.BorderFocusColor = System.Drawing.Color.HotPink;
            customPanel6.BorderRadius = 27;
            customPanel6.BorderSize = 1;
            customPanel6.Location = new System.Drawing.Point(47, 3);
            customPanel6.Name = "customPanel6";
            customPanel6.Size = new System.Drawing.Size(54, 54);
            customPanel6.TabIndex = 2;
            try
            {
                if (!String.IsNullOrEmpty(product.ThumbailImage))
                {
                    customPanel6.BackgroundImage = Image.FromFile(product.ThumbailImage);
                    customPanel6.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }
            catch
            {
            }

            customPanel6.UnderlinedStyle = false;

            var label3 = new Label();

            label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(107, 18);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(43, 23);
            label3.TabIndex = 0;
            label3.Text = "PvId" + request.PvId.ToString();
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            var label5 = new Label();

            label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(740, 18);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(122, 23);
            label5.TabIndex = 4;
            label5.Text = (product.Price * (100 - product.DiscountPercent) / 100).ToString("#,### vnđ");

            var numericUpDown1 = new NumericUpDown();

            numericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.None;
            numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            numericUpDown1.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            numericUpDown1.Location = new System.Drawing.Point(877, 12);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(94, 36);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = request.Quantity;

            var label6 = new Label();

            label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(985, 18);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(122, 23);
            label6.TabIndex = 6;
            label6.Text = (request.Quantity * (product.Price * (100 - product.DiscountPercent) / 100)).ToString("#,### vnđ");

            var button2 = new Button();

            button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(219)))));
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Location = new System.Drawing.Point(0, 60);
            button2.Margin = new System.Windows.Forms.Padding(0);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(1119, 2);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = false;

            var tblItemCart = new TableLayoutPanel();
            tblItemCart.ColumnCount = 7;
            tblItemCart.BackColor = System.Drawing.Color.White;
            tblItemCart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            tblItemCart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tblItemCart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            tblItemCart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tblItemCart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            tblItemCart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tblItemCart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            tblItemCart.Controls.Add(label4, 3, 0);
            tblItemCart.Controls.Add(vbButton1, 0, 0);
            tblItemCart.Controls.Add(customPanel6, 1, 0);
            tblItemCart.Controls.Add(label3, 2, 0);
            tblItemCart.Controls.Add(label5, 4, 0);
            tblItemCart.Controls.Add(numericUpDown1, 5, 0);
            tblItemCart.Controls.Add(label6, 6, 0);
            tblItemCart.Location = new System.Drawing.Point(0, 0);
            tblItemCart.Margin = new System.Windows.Forms.Padding(0);
            tblItemCart.Name = "tblItemCart";
            tblItemCart.RowCount = 1;
            tblItemCart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tblItemCart.Size = new System.Drawing.Size(1119, 60);
            tblItemCart.TabIndex = 0;
            //


            //
            TblItems.Controls.Add(tblItemCart);
            TblItems.Controls.Add(button2);
            //
            var i = TblItems.Controls.IndexOf(tblItemCart);
            // Remove product
            vbButton1.Click += async (o, s) =>
            {
                TblItems.Controls.RemoveAt(i);
                TblItems.Controls.RemoveAt(i); // xóa gạch ngang
                CartItems.RemoveAt(i / 2);
                CartShow.ProductInCarts.RemoveAt(i / 2);
                await LoadBill();
            };
            numericUpDown1.ValueChanged += async (o, s) =>
            {
                CartItems[i / 2].Quantity = Convert.ToInt32(numericUpDown1.Value);
                CartShow.ProductInCarts[i / 2].Quantity = Convert.ToInt32(numericUpDown1.Value);
                label6.Text = (CartItems[i / 2].Quantity * product.Price*(100-product.DiscountPercent)/100).ToString("#,### vnđ");
                await LoadBill();
            };
        }
        private async void AddProductToCart(AddToCartRequest request)
        {
            var product = Result.Items.FirstOrDefault(c => c.Id == request.productId);
            var item = CartShow.ProductInCarts.FirstOrDefault(c => c.ProductVariationId == request.PvId);
            if (item != null)
            {
                item.Quantity += request.Quantity;
                CartItems.FirstOrDefault(c => c.PvId == request.PvId).Quantity += request.Quantity;
                await LoadCartDetail(CartShow);
            }
            else
            {
                CartShow.ProductInCarts.Add(new ProductInCart()
                {
                    CartId = CartShow.Id,
                    ProductVariationId = request.PvId,
                    Quantity = request.Quantity,
                    Discount = request.DiscountPercent
                });
                CartItems.Add(new CartItemViewModel() { CartId = CartShow.Id, ColorId = request.ColorId, SizeId = request.SizeId, ColorName = request.ColorName, Sizename = request.SizeName, ProductId = request.productId, Quantity = request.Quantity, ProductName = request.productName, PvId = request.PvId, Price = product.Price, ThumbailImage = product.ThumbailImage, DiscountPercent=product.DiscountPercent });
                await LoadCartDetail(CartShow);
            }
        }
        // Hiệu ứng
        private async Task AcctiveTitleOder(Panel pnl)
        {
            if (PanlActive.Controls.Count > 0)
            {
                PanlActive.BackColor = System.Drawing.Color.FromArgb(90, 76, 219);
                PanlActive.Controls[0].BackColor = System.Drawing.Color.FromArgb(90, 76, 219);
                PanlActive.Controls[0].ForeColor = System.Drawing.Color.White;
            }
            PanlActive = pnl;
            PanlActive.BackColor = System.Drawing.Color.White;
            PanlActive.Controls[0].ForeColor = System.Drawing.Color.FromArgb(90, 76, 219);
            PanlActive.Controls[0].BackColor = System.Drawing.Color.White;

        }
        // Set data for Create Order and Updatecart
        private async Task SetDetailCartShow()
        {
            CartShow.Description = txtDescription.Text;
            CartShow.CustomerName = txtCustomerName.Text;
            CartShow.CustomerMoney = Convert.ToDecimal(txtCustomerMoney.Text);
            CartShow.ShipEmail = txtEmail.Text;
            CartShow.ShipPhoneNumber = txtPhoneNumber.Text;
            CartShow.ShipAddress = txtAddress.Text;
        }
        private async Task<Order> SetOder()
        {
            var total = CartItems.Select(d => d.Price * d.Quantity).Sum();
            var oder = new Order()
            {
                UserCreatedId = User.Id,
                CustomerId = Customer.Id,
                ShipAddress = txtAddress.Text,
                ShipEmail = txtEmail.Text,
                ShipName = txtCustomerName.Text,
                ShipPhoneNumber = txtPhoneNumber.Text,
                Status = CombOrderstatus.SelectedIndex == 0 ? Data.Ultilities.Enums.OrderStatus.Success : Data.Ultilities.Enums.OrderStatus.Confirmed,
                Created = DateTime.Now,
                IsShipping = CombOrderstatus.SelectedIndex == 0 ? false : true,
                Description = txtDescription.Text,
                Total = total,
                ProductInOrders = CartItems.Select(c => new ProductInOrder() { Created = DateTime.Now, Price = (c.Price*(100-c.DiscountPercent)/100), ProductVariationId = c.PvId, Quantity = c.Quantity }).ToList()
            };
            return oder;
        }
        private async Task<GetPagingShoppingRequest> GetPagingRequest()
        {
            Request.Checks = CheckBoxes.Select(c => c.Checked).ToArray();
            Request.Keyword = Txt_Search.Text;
            Request.OderBy = Comb_OderBy.SelectedIndex;
            return Request;
        }
        #endregion
        #region Events
        //Thanh Toán hoặc đặt hàng
        private async void vbButton12_Click(object sender, EventArgs e)
        {
            if (CombOrderstatus.SelectedIndex == 0)
            {
                if (CartItems.Any())
                {
                    if (MessageBox.Show("Bạn có muốn thanh toán!", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var result = await _shoppingService.AddOrder(await SetOder());
                        if (result)
                        {
                            MessageBox.Show("Thanh toán thành công!");
                            var i = TblCartTittles.Controls.IndexOf(PanlActive); // Vị trí của cart trong ds
                            if (await _shoppingService.RemoveCart(CartShow))
                            {
                                TblCartTittles.Controls.Remove(PanlActive);
                                Carts.Remove(CartShow);
                                if (Carts.Count == 0)
                                {
                                    var cart1 = new Cart() { CartIndex = 1, CustomerMoney = 0 };
                                    Carts.Add(cart1);
                                    await _shoppingService.AddCart(cart1);
                                    await AcctiveTitleOder(await AddPanlCart(cart1));
                                    CartShow = cart1;
                                    await SetupList();
                                }
                                else
                                {
                                    if (i < Carts.Count - 1)
                                    {
                                        await AcctiveTitleOder((Panel)TblCartTittles.Controls[i]);
                                        CartShow = Carts[i];
                                        await SetupList();
                                    }
                                    else
                                    {
                                        await AcctiveTitleOder((Panel)TblCartTittles.Controls[i]);
                                        CartShow = Carts[i];
                                        await SetupList();
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Thanh toán thất bại!");
                        }
                    }
                }
            }
            else
            {
                var txt = "";
                if (String.IsNullOrEmpty(txtAddress.Text) || String.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    txt += "Vui lòng nhập địa chỉ";
                }
                if (String.IsNullOrEmpty(txtPhoneNumber.Text) || String.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                {
                    txt += "Số điện thoại phải đúng định dạng !";
                }
                if (String.IsNullOrEmpty(txtCustomerName.Text) || String.IsNullOrWhiteSpace(txtCustomerName.Text))
                {
                    txt += "Vui lòng nhập tên khách hàng";
                }
                if (txt != "")
                {
                    MessageBox.Show(txt);
                }
                else
                {
                    if (CartItems.Any())
                    {
                        if (MessageBox.Show("Bạn có muốn đặt hàng!", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            var result = await _shoppingService.AddOrder(await SetOder());
                            if (result)
                            {
                                MessageBox.Show("Đặt hàng thành công!");
                            }
                            else
                            {
                                var i = TblCartTittles.Controls.IndexOf(PanlActive); // Vị trí của cart trong ds
                                if (await _shoppingService.RemoveCart(CartShow))
                                {
                                    TblCartTittles.Controls.Remove(PanlActive);
                                    Carts.Remove(CartShow);
                                    if (Carts.Count == 0)
                                    {
                                        var cart1 = new Cart() { CartIndex = 1, CustomerMoney = 0 };
                                        Carts.Add(cart1);
                                        await _shoppingService.AddCart(cart1);
                                        await AcctiveTitleOder(await AddPanlCart(cart1));
                                        CartShow = cart1;
                                        await SetupList();
                                    }
                                    else
                                    {
                                        if (i < Carts.Count - 1)
                                        {
                                            await AcctiveTitleOder((Panel)TblCartTittles.Controls[i]);
                                            CartShow = Carts[i];
                                            await SetupList();
                                        }
                                        else
                                        {
                                            await AcctiveTitleOder((Panel)TblCartTittles.Controls[i]);
                                            CartShow = Carts[i];
                                            await SetupList();
                                        }
                                    }
                                }

                                else
                                {
                                    MessageBox.Show("Đặt hàng thất bại!");
                                }
                            }
                        }
                    }
                }
            }
        }
        private async void ShoppingIndex_Load(object sender, EventArgs e)
        {
            await AddPanlFilter();
            //
            CombOrderstatus.SelectedIndex = 0;
            //
            Result = await _shoppingService.GetProducts(Request);
            await LoadTblProducts();
            Carts = (await _shoppingService.GetAllCarts()).ToList();
            if (!Carts.Any())
            {
                var cart = new Cart() { CartIndex = 1, CustomerMoney = 0 };
                Carts.Add(cart);
                CartShow = cart;
                await _shoppingService.AddCart(cart);
                await AcctiveTitleOder(await AddPanlCart(cart));
                await SetupList();
            }
            else
            {
                foreach (var cart in Carts)
                {
                    await AddPanlCart(cart);
                }
                await AcctiveTitleOder((Panel)TblCartTittles.Controls[0]);
                CartShow = Carts[0];
                await SetupList();
            }
        }
        private async void ShoppingIndex_FormClosing(object sender, FormClosingEventArgs e)
        {
            // lưu giỏ hàng
            await SetDetailCartShow();
            await _shoppingService.UpdateCart(CartShow);
        }
        private async void BtnAddOrder_Click(object sender, EventArgs e)
        {
            var cart = new Cart() { CartIndex = Carts.Last().CartIndex + 1, CustomerMoney = 0 };
            await _shoppingService.AddCart(cart);
            Carts.Add(cart);
            await AddPanlCart(cart);
            var i = cart.Id;
        }
        #endregion
        private async Task Check_Click()
        {
            Request = new();
            Result = await _shoppingService.GetProducts(await GetPagingRequest());
            await LoadTblProducts();
            await LoadMenuPaging();
        }
        int time = 0;
        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private async Task LoadCustomer()
        {
            txtCustomerName.Text = Customer.Name;
            txtEmail.Text = Customer.Email;
            txtPhoneNumber.Text = Customer.PhoneNumber;
            txtAddress.Text = Customer.Address;
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            if (time % 20 == 0)
            {
                time = 0;
                Customers = await _shoppingService.GetByPhoneNumber(txtSearchCustomer.Text);
                MenuCustomers.Items.Clear();
                int index = 0;
                foreach (var item in Customers)
                {
                    var i = index;
                    MenuCustomers.Items.Add(item.Name+item.PhoneNumber);
                    MenuCustomers.Items[i].Click += async (o, s) =>
                    {
                        Customer = Customers.ToList()[i];
                        await LoadCustomer();
                        index++;
                    };
                }
                MenuCustomers.Show(txtSearchCustomer, 0, Txt_Search.Height + 5);
                timer1.Stop();
            }
        }

        private void CombOrderstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnThanhToan.Text = CombOrderstatus.SelectedIndex == 0 ? "Thanh Toán" : "Đặt Hàng";
        }

        private void vbButton6_Click(object sender, EventArgs e)
        {
            MenuFillter.Show(vbButton6, 0, -400);
        }

        private async void Btn_Search_Click(object sender, EventArgs e)
        {
            await Check_Click();
        }

        private async void Comb_OderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Check_Click();
        }

        private async void BtnNext_Click(object sender, EventArgs e)
        {
            if (Result.PageIndex < Result.PageCount)
            {
                Request.PageIndex++;
                await PageIndex_Changed();
            }
            else
            {
                MessageBox.Show("Đã là trang cuối!");
            }
        }

        private async void BtnPrev_Click(object sender, EventArgs e)
        {
            if (Result.PageIndex > 1)
            {
                Request.PageIndex--;
                await PageIndex_Changed();
            }
            else
            {
                MessageBox.Show("Đã là trang đầu tiên!");
            }
        }
        private async Task PageIndex_Changed()
        {
            Result = await _shoppingService.GetProducts(await GetPagingRequest());
            await LoadTblProducts();
            await LoadMenuPaging();
        }

        private void BtnQR_Click(object sender, EventArgs e)
        {
            var form = _serviceProviders.GetRequiredService<QRcode>();
            form.Show();
        }
        // thêm khách hàng
        private async void vbButton4_Click(object sender, EventArgs e)
        {
            var txt = await Validate();
            if (txt != "")
            {
                MessageBox.Show(txt);
            }
            else
            {
                Customer = new()
                {
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    Name = txtCustomerName.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Created = DateTime.Now
                };
                if (await _shoppingService.AddCustomer(Customer))
                {
                    MessageBox.Show("Thêm mới khách hàng thành công !");
                }
                else
                {
                    MessageBox.Show("Thêm mới khách hàng thất !");
                }
            }
        }
        private async Task<string> Validate()
        {
            var txt = "";
            if (String.IsNullOrEmpty(txtAddress.Text) || String.IsNullOrWhiteSpace(txtAddress.Text))
            {
                txt += "Vui lòng nhập địa chỉ";
            }
            if (String.IsNullOrEmpty(txtPhoneNumber.Text) || String.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                txt += "Số điện thoại phải đúng định dạng !";
            }
            else
            {
                txt += await _shoppingService.Validate(txtPhoneNumber.Text);
            }
            if (String.IsNullOrEmpty(txtCustomerName.Text) || String.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                txt += "Vui lòng nhập tên khách hàng";
            }
            return txt;
        }

        private void txtCustomerMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được phép nhập số !");
            }
        }

        private async void txtCustomerMoney_TextChanged(object sender, EventArgs e)
        {
            await LoadBill();
        }
    }
}
