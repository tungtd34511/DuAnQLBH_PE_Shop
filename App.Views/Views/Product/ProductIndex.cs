using App.Views.Models.Controls;
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

namespace App.Views.Views.Product
{
    public partial class ProductIndex : Form
    {
        private readonly IServiceProvider _serviceProvide;
        public VBButton _btnBack = new VBButton();
        public ProductIndex(IServiceProvider serviceProvide)
        {
            InitializeComponent();
            _serviceProvide = serviceProvide;
        }
        //Details
        private  void vbButton1_Click(object sender, EventArgs e)
        {
            this.Controls[0].Visible = false;
            var frmDetail = _serviceProvide.GetRequiredService<ProductDetails>();
            frmDetail.TopLevel = false;
            this.Controls.Add(frmDetail);
            frmDetail.Show();
            frmDetail.BtnBack.Click += (o, s) =>
            {
                frmDetail.Hide();
                this.Controls[0].Visible = true;
                frmDetail.Close();
            };
        }

        //UpdateProduct
        private void vbButton2_Click(object sender, EventArgs e)
        {
            this.Controls[0].Visible = false;
            var frmDetail = _serviceProvide.GetRequiredService<UpdateProduct>();
            frmDetail.TopLevel = false;
            this.Controls.Add(frmDetail);
            frmDetail.Show();
            frmDetail.BtnBack.Click += (o, s) =>
            {
                frmDetail.Hide();
                this.Controls[0].Visible = true;
                frmDetail.Close();
            };
        }
        //Create
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            this.Controls[0].Visible = false;
            var frmDetail = _serviceProvide.GetRequiredService<CreateProduct>();
            frmDetail.TopLevel = false;
            this.Controls.Add(frmDetail);
            frmDetail.Show();
            frmDetail.BtnBack.Click += (o, s) =>
            {
                frmDetail.Hide();
                this.Controls[0].Visible = true;
                frmDetail.Close();
            };
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
