using App.Business.Sevices.ProductVariations;
using App.Data.Entities;
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
    public partial class UpdateProductVariation : Form
    {
        private readonly IProductVariationServices _productVariationServices;
        public ProductVariation PV { get; set; }
        public UpdateProductVariation(IProductVariationServices productVariationServices)
        {
            InitializeComponent();
            _productVariationServices = productVariationServices;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            PV.Stock = Convert.ToInt32(numStock.Value);
            if(await _productVariationServices.Update(PV))
            {
                MessageBox.Show("Cập nhật thành công!");
                Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateProductVariation_Load(object sender, EventArgs e)
        {
            numStock.Value = PV.Stock;
        }
    }
}
