﻿
using App.Business.Sevices.Products;
using App.Views.Models.Controls;
using App.Views.Views.Catalog.Categories;
using App.Views.Views.Catalog.Manufacturers;
using App.Views.Views.Catalog.Units;
using App.Views.Views.Orders;
using App.Views.Views.Product;
using App.Views.Views.Shopping;
using App.Views.Views.ThongKe;
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
        //Fields
        private Form _currentchildForm = new();
        public VBButton _btnAcctive { get; set; } = new();
        public List<VBButton> _ListControls { get; set; }=new() ;
        public _Layout(IServiceProvider serviceProvide)
        {
            InitializeComponent();
            _serviceProvide = serviceProvide;
            
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
                btn.Click += async (o, s) =>
                {
                    await AcctiveBtn(btn);
                };
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

        private async void _Layout_Load(object sender, EventArgs e)
        {
            await AcctiveBtn(BtnHome);
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
                await OpenchildForm(_serviceProvide.GetRequiredService<ShoppingIndex>());
            }
        }

        private async void vbButton6_Click(object sender, EventArgs e)
        {
            if (_btnAcctive != vbButton6)
            {
                await OpenchildForm(_serviceProvide.GetRequiredService<OrderIndex>());
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
    }
}
