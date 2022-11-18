using App.Data.Ultilities.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Views.Views.Product
{
    public partial class ProductDetails : Form
    {
        public ProductVm Product { get; set; }
        public ProductDetails()
        {
            InitializeComponent();
        }
        public async Task LoadDetail()
        {
            if(Product.Images!=null &&Product.Images.Count>0) {
                panlIMG.BackgroundImage = Image.FromFile(Product.Images[0]);
            }
            LblName.Text = Product.Name;
            LblCreated.Text = Product.DateCreated.ToString();
            LblGender.Text = Product.Gender.ToString();
            LblNsx.Text = Product.ManufacturerName;
            LblOriginPrice.Text = Product.OriginalPrice.ToString();
            LblPrice.Text = Product.Price.ToString();
            LblUnit.Text = Product.UnitName;
            //var text = "";
            
            //TxtCategories.Text = 
            TxtDescription.Text = Product.Description;
            TxtDetail.Text = Product.Details;
            Btn_Status.Text = Product.Status.ToString();
        }
        public async Task LoadMiniImgs()
        {

        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
