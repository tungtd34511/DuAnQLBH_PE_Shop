using App.Business.Sevices.Shoppings;
using App.Data.Entities;
using App.Data.Ultilities.Catalog.Carts;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.ViewModels;
using App.Views.Models.Controls;
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
        public List<Cart> Carts { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public Cart CartShow { get; set; }
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
            }
            else
            {
                var total = CartItems.Select(d => d.Price * d.Quantity).Sum();
                LblTotalprice.Text = total.ToString();
                txtTotalBill.Text = (total * 100 / 100).ToString();
            }
        }
        private async Task LoadTblProducts()
        {
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
                LblSale.Text = "- 30%";

                var LblPrice = new Label();

                LblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                LblPrice.AutoSize = true;
                LblPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(219)))));
                LblPrice.ForeColor = System.Drawing.Color.White;
                LblPrice.Margin = new System.Windows.Forms.Padding(0);
                LblPrice.Name = "LblPrice";
                LblPrice.Margin = new Padding(0);
                LblPrice.Size = new System.Drawing.Size(99, 20);
                LblPrice.Text = item.Price.ToString() + " vnđ";

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
                    await ShowAddToCart(item.Id);
                };
                TblProducts.Controls.Add(TblProduct);

            }
        }
        private async Task LoadCartDetail(Cart cart)
        {
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
                        Quantity = item.Quantity
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
                                await AcctiveTitleOder((Panel)TblCartTittles.Controls[i - 1]);
                                CartShow = Carts[i - 1];
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
        private async Task ShowAddToCart(int productId)
        {
            var form = _serviceProviders.GetRequiredService<AddToCart>();
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
            label4.Text = request.productName;
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
            label5.Text = product.Price.ToString() + " vnđ";

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
            label6.Text = (request.Quantity * product.Price).ToString() + " vnđ";

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
                label6.Text = (CartItems[i / 2].Quantity * product.Price).ToString() + " vnđ";
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
                    Quantity = request.Quantity
                });
                CartItems.Add(new CartItemViewModel() { CartId = CartShow.Id, ColorId = request.ColorId, SizeId = request.SizeId, ColorName = request.ColorName, Sizename = request.SizeName, ProductId = request.productId, Quantity = request.Quantity, ProductName = request.productName, PvId = request.PvId, Price = product.Price, ThumbailImage = product.ThumbailImage });
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
                ShipAddress = txtAddress.Text,
                ShipEmail = txtEmail.Text,
                ShipName = txtCustomerName.Text,
                ShipPhoneNumber = txtPhoneNumber.Text,
                Status = CombOrderstatus.SelectedIndex == 0 ? Data.Ultilities.Enums.OrderStatus.Success : Data.Ultilities.Enums.OrderStatus.Confirmed,
                Created = DateTime.Now,
                IsShipping = CombOrderstatus.SelectedIndex == 0 ? false : true,
                Description = txtDescription.Text,
                Total = total,
                ProductInOrders =  CartItems.Select(c=>new ProductInOrder() { Created=DateTime.Now,Price=c.Price,ProductVariationId=c.PvId,Quantity=c.Quantity}).ToList()
            };
            return oder;
        }
        #endregion
        #region Events
        //Thanh Toán hoặc đặt hàng
        private async void vbButton12_Click(object sender, EventArgs e)
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
                                    await AcctiveTitleOder((Panel)TblCartTittles.Controls[i - 1]);
                                    CartShow = Carts[i - 1];
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
        private async void ShoppingIndex_Load(object sender, EventArgs e)
        {
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

        int time = 0;
        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            if (time % 20 == 0)
            {
                time = 0;
                Customers = await _shoppingService.GetByPhoneNumber(txtSearchCustomer.Text);
                MenuCustomers.Items.Clear();
                foreach(var item in Customers)
                {
                    MenuCustomers.Items.Add(item.Name);
                }
                MenuCustomers.Show(txtSearchCustomer, 0, Txt_Search.Height + 5);
                timer1.Stop();
            }
        }

        private void CombOrderstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnAddOrder.Text = CombOrderstatus.SelectedIndex == 0 ? "Thanh Toán" : "Đặt Hàng";
        }
    }
}
