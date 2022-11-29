using App.Business.Sevices.Catalogs.Manufactures;
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

namespace App.Views.Views.Catalog.Manufacturers
{
    public partial class UpdateManufacture : Form
    {
        private readonly IManufactureServices _manufactureServices;
        public Manufacturer Manufacturer { get; set; }
        public UpdateManufacture(IManufactureServices manufactureServices)
        {
            InitializeComponent();
            _manufactureServices = manufactureServices;
        }
        private async Task<string> Validate()
        {
            var txt = "";
            txt += await _manufactureServices.Valiate(txtName.Text);
            if (txtName.Text.Length > 50 || String.IsNullOrEmpty(txtName.Text))
            {
                txt += "Tên nhà sản xuất phải từ 1 đến 50 ký tự";
            }
            return txt;
        }

        private void UpdateManufacture_Load(object sender, EventArgs e)
        {
            txtName.Text = Manufacturer.Name;
            TxtDetails.Text = Manufacturer.Details;
            txtDescription.Text = Manufacturer.Description;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var txt = await Validate();
            if (txt != "")
            {
                MessageBox.Show(txt);
            }
            else
            {
                Manufacturer.Name = txtName.Text;
                Manufacturer.Details = TxtDetails.Text;
                Manufacturer.Description= txtDescription.Text;
                if(await _manufactureServices.Update(Manufacturer))
                {
                    MessageBox.Show("Cập nhật thành công !");
                    Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
        }
    }
}
