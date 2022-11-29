
using App.Business.Sevices.ProductVariations;
using App.Data.Entities;
using App.Views.Views.Catalog.Colors;
using App.Views.Views.Catalog.Sizes;
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

namespace App.Views.Views.Catalog.ProductVariations
{
    public partial class CreateProductVariaton : Form
    {
        private readonly IProductVariationServices _productVariationService;
        private readonly IServiceProvider _serviceProvider;
        public IEnumerable<Data.Entities.Color> Colors { get; set; }
        public IEnumerable<Data.Entities.Size> Sizes { get; set; }
        public IEnumerable<ProductDetail> Products { get; set; }
        public ProductVariation PV { get; set; } = new();
        public CreateProductVariaton(IProductVariationServices productVariationService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _productVariationService = productVariationService;
            _serviceProvider = serviceProvider;
        }

        private async void CreateProductVariaton_Load(object sender, EventArgs e)
        {
            Colors = await _productVariationService.GetAllColor();
            Sizes = await _productVariationService.GetAllSize();
            Products = await _productVariationService.GetAllProductDetail();
            //
            CmbProduct.Items.AddRange(Products.Select(c=>c.Name).ToArray());
            ComColor.Items.AddRange(Colors.Select(c => c.Name).ToArray());
            comnSize.Items.AddRange(Sizes.Select(c=>c.Name).ToArray());
            //
            CmbProduct.SelectedIndex = 0;
            ComColor.SelectedIndex = 0;
            comnSize.SelectedIndex = 0;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            PV.IsDeleted = false;
            PV.ColorId = (Colors.ToArray())[ComColor.SelectedIndex].Id;
            PV.SizeId = (Sizes.ToArray())[comnSize.SelectedIndex].Id;
            PV.ProductId = (Products.ToArray())[CmbProduct.SelectedIndex].ProductId;
            PV.Stock = Convert.ToInt32(numSoluong.Value);
            if (await _productVariationService.Contain(PV))
            {
                MessageBox.Show("Biến thể đã tồn tại !");
            }
            else
            {
                if (await _productVariationService.Create(PV))
                {
                    MessageBox.Show("Thêm mới biến thể thành công !");
                    Close();
                }
                else
                {
                    Close();
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCreateColor_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<CreateColor>();
            form.FormClosed += async (o, s) =>
            {
                Colors = await _productVariationService.GetAllColor();
                ComColor.Items.Clear();
                ComColor.Items.Add(Colors.Select(c => c.Name).ToArray());
                ComColor.SelectedIndex = 0;
            };
            form.ShowDialog();
        }

        private void BtnCreateSize_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<CreateSize>();
            form.FormClosed += async (o, s) =>
            {
                Sizes = await _productVariationService.GetAllSize();
                comnSize.Items.Clear();
                comnSize.Items.Add(Sizes.Select(c => c.Name).ToArray());
                comnSize.SelectedIndex = 0;
            };
            form.ShowDialog();
        }
    }
}
