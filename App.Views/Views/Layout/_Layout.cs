
using App.Business.Sevices.Products;
using App.Business.Sevices.Users;
using App.Views.Models.Controls;
using App.Views.Views.Catalog.Categories;
using App.Views.Views.Catalog.Colors;
using App.Views.Views.Catalog.Manufacturers;
using App.Views.Views.Catalog.ProductVariations;
using App.Views.Views.Catalog.Sizes;
using App.Views.Views.Catalog.Units;
using App.Views.Views.Orders;
using App.Views.Views.Product;
using App.Views.Views.Promotion;
using App.Views.Views.Shopping;
using App.Views.Views.ThongKe;
using App.Views.Views.User;
using App.Views.Views.Users;
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

namespace App.Views.Views.Layout
{
    public partial class _Layout : Form
    {
        private readonly IServiceProvider _serviceProvide;
        private readonly IUserService _userService;
        //Fields
        private Form _currentchildForm = new();
        public Data.Entities.User User { get; set; }
        public Data.Entities.UserDetail UserDetail { get; set; }
        public VBButton _btnAcctive { get; set; } = new();
        public List<VBButton> _ListControls { get; set; } = new();
        public _Layout(IServiceProvider serviceProvide, IUserService userService)
        {
            InitializeComponent();
            _serviceProvide = serviceProvide;
            _userService = userService;
        }
        private async Task OpenchildForm(Form form)
        {
            if (_currentchildForm != form)
            {
                _currentchildForm.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                _currentchildForm = form;
                _currentchildForm.TopLevel = false;
                _currentchildForm.FormBorderStyle = FormBorderStyle.None;
                _currentchildForm.Dock = DockStyle.Fill;
                PanlDesktop.Controls.Add(_currentchildForm);
                PanlDesktop.Tag = _currentchildForm;
                _currentchildForm.BringToFront();
                _currentchildForm.Visible = true;
            }
        }
        private async Task LoadCustomControl()
        {
            // đổ dữ liệu cho list panel
            for (int i = 2; i < tbl_Menu.Controls.Count; i++)
            {
                var btn = (VBButton)tbl_Menu.Controls[i];
                _ListControls.Add(btn);
                if (btn != vbButton12)
                {
                    btn.Click += async (o, s) =>
                    {
                        await AcctiveBtn(btn);
                    };
                }
            }
        }
        private async Task AcctiveBtn(VBButton btn)
        {
            _btnAcctive.BackColor = Color.FromArgb(22, 27, 34);
            _btnAcctive.ForeColor = Color.White;
            _btnAcctive.IconColor = Color.White;
            _btnAcctive = btn;
            _btnAcctive.BackColor = Color.White;
            _btnAcctive.ForeColor = Color.FromArgb(90, 76, 219);
            _btnAcctive.IconColor = Color.FromArgb(90, 76, 219);
        }
        private async Task LoadUser()
        {
            if (!String.IsNullOrEmpty(UserDetail.ImagePath))
            {
                panlImG.BackgroundImage = Image.FromFile(UserDetail.ImagePath);
            }
            txtName.Text = UserDetail.Name;
        }
        private async void _Layout_Load(object sender, EventArgs e)
        {
            this.Hide();
            var login = _serviceProvide.GetRequiredService<UserLogin>();

            login.FormClosed += async (o, s) =>
            {
                if (login.IsAuthenticate)
                {
                    User = login.User;
                    UserDetail = await _userService.GetDetailById(User.Id);
                    await IsAdmin();
                    await LoadUser();
                    //
                    await AcctiveBtn(BtnHome);
                    var form = _serviceProvide.GetRequiredService<UserDetails>();
                    User.UserDetail = UserDetail;
                    form.User = User;
                    await OpenchildForm(form);
                    //
                    await LoadCustomControl();
                    MenuCatalog.IsMainMenu = true;
                    MenuCatalog.Items[0].Click += async (o, s) =>
                    {
                        await AcctiveBtn(vbButton8);
                        await OpenchildForm(_serviceProvide.GetRequiredService<CategoryIndex>());
                    };
                    MenuCatalog.Items[1].Click += async (o, s) =>
                    {
                        await AcctiveBtn(vbButton8);
                        await OpenchildForm(_serviceProvide.GetRequiredService<ManufactureIndex>());
                    };
                    MenuCatalog.Items[2].Click += async (o, s) =>
                    {
                        await AcctiveBtn(vbButton8);
                        await OpenchildForm(_serviceProvide.GetRequiredService<UnitIndex>());
                    };
                    MenuCatalog.Items[3].Click += async (o, s) =>
                    {
                        await AcctiveBtn(vbButton8);
                        await OpenchildForm(_serviceProvide.GetRequiredService<ColorIndex>());
                    };
                    MenuCatalog.Items[4].Click += async (o, s) =>
                    {
                        await AcctiveBtn(vbButton8);
                        await OpenchildForm(_serviceProvide.GetRequiredService<SizeIndex>());
                    };
                    MenuCatalog.Items[5].Click += async (o, s) =>
                    {
                        await AcctiveBtn(vbButton8);
                        await OpenchildForm(_serviceProvide.GetRequiredService<ProductVariationIndex>());
                    };
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            };
            login.ShowDialog();

        }

        private async void vbButton5_Click(object sender, EventArgs e)
        {
            if (_btnAcctive != vbButton5)
            {
                await OpenchildForm(_serviceProvide.GetRequiredService<ProductIndex>());
            }
        }

        private async void vbButton4_Click(object sender, EventArgs e)
        {
            if (_btnAcctive != vbButton4)
            {
                var form = _serviceProvide.GetRequiredService<ShoppingIndex>();
                form.User = User;
                await OpenchildForm(form);
            }
        }

        private async void vbButton6_Click(object sender, EventArgs e)
        {
            if (_btnAcctive != vbButton6)
            {
                var form = _serviceProvide.GetRequiredService<OrderIndex>();
                form.User = User;
                await OpenchildForm(form);
            }
        }

        private async void vbButton9_Click(object sender, EventArgs e)
        {
            if (_btnAcctive != vbButton9)
            {
                await OpenchildForm(_serviceProvide.GetRequiredService<ThongKeIndex>());
            }
        }
        private void vbButton8_Click(object sender, EventArgs e)
        {
            MenuCatalog.Show(vbButton8, vbButton8.Width, 0);
        }

        private async void vbButton10_Click(object sender, EventArgs e)
        {
            if (_btnAcctive != vbButton10)
            {
                await OpenchildForm(_serviceProvide.GetRequiredService<UserIndex>());
            }
        }

        private async void BtnHome_Click(object sender, EventArgs e)
        {
            if (_btnAcctive != BtnHome)
            {
                var form = _serviceProvide.GetRequiredService<UserDetails>();
                User.UserDetail = UserDetail;
                form.User = User;
                await OpenchildForm(form);
            }
        }

        private void vbButton12_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = _serviceProvide.GetRequiredService<UserLogin>();

            login.FormClosed += async (o, s) =>
            {
                if (login.IsAuthenticate)
                {
                    User = login.User;
                    UserDetail = await _userService.GetDetailById(User.Id);
                    await IsAdmin();
                    await LoadUser();
                    //
                    var form = _serviceProvide.GetRequiredService<UserDetails>();
                    User.UserDetail = UserDetail;
                    form.User = User;
                    await OpenchildForm(form);
                    //
                    this.Show();
                    await AcctiveBtn(BtnHome);
                }
                else
                {
                    this.Close();
                }
            };
            login.ShowDialog();
        }

        private async void vbButton7_Click(object sender, EventArgs e)
        {
            if (_btnAcctive != vbButton7)
            {
                var form = _serviceProvide.GetRequiredService<PromotionIndex>();
                await OpenchildForm(form);
            }
        }
        private async Task IsAdmin()
        {
            if (User.Role == Data.Ultilities.Enums.Role.Admin)
            {
                vbButton7.Visible= true;
                vbButton9.Visible= true;
                vbButton10.Visible = true;
            }
            else
            {
                vbButton7.Visible = false;
                vbButton9.Visible = false;
                vbButton10.Visible = false;
            }
        }
    }
}
