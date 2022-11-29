using App.Business.Sevices.Catalogs.Sizes;
using App.Data.Repositories.Catalog.Sizes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Views.Views.Catalog.Sizes
{
    public partial class CreateSize : Form
    {
        private readonly ISizeService _sizeService;
        public Data.Entities.Size Size { get; set; } = new();
        public CreateSize(ISizeService sizeService)
        {
            InitializeComponent();
            _sizeService = sizeService;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var eror = await Validate();
            if(eror != "") {
                MessageBox.Show(eror);
                    }
            else
            {
                Size.Id = txtId.Text; Size.Name = txtName.Text;
                if (await _sizeService.Add(Size))
                {
                    MessageBox.Show("Thêm mới kích cỡ thành công!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Thêm mới kích cỡ thất bại!");
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async Task<string> Validate()
        {
            var eror = "";
            eror += await _sizeService.Validate(txtId.Text, txtName.Text);
            if (String.IsNullOrEmpty(txtId.Text) || txtId.Text.Length > 15|| txtId.Text.Contains(" "))
            {
                eror += "Mã kích cỡ phải từ 1 đến 15 kí tự và không chứa khoảng trắng!\n";
            }
            if (String.IsNullOrEmpty(txtId.Text) || txtId.Text.Length > 25 )
            {
                eror += "Tên kích cỡ phải từ 1 đến 25 kí tự !\n";
            }
            return eror;
        }
    }
}
