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
    public partial class CreateManufacture : Form
    {
        private readonly IManufactureServices _manufactureServices;
        public Manufacturer Manufacturer { get; set; } = new();
        public CreateManufacture(IManufactureServices manufactureServices)
        {
            InitializeComponent();
            _manufactureServices = manufactureServices;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var txt = await Validate();
            if(txt != "") {
                MessageBox.Show(txt);
            }
            else
            {

                Manufacturer.Details = TxtDetails.Text;
                Manufacturer.Description = txtDescription.Text;
                Manufacturer.Name = txtName.Text;
                Manufacturer.IsDeleted = false;
                if (await _manufactureServices.Add(Manufacturer))
                {
                    MessageBox.Show("Thêm mới nhà sản xuất thành công!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Thêm mới nhà sản xuất thất bại!");
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async Task<string> Validate()
        {
            var txt = "";
            txt += await _manufactureServices.Valiate(txtName.Text);
            if(txtName.Text.Length > 50 ||String.IsNullOrEmpty(txtName.Text))
            {
                txt += "Tên nhà sản xuất phải từ 1 đến 50 ký tự";
            }
            return txt;
        }
    }
}
