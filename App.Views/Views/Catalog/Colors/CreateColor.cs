using App.Business.Sevices.Catalogs.Colors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Views.Views.Catalog.Colors
{
    public partial class CreateColor : Form
    {
        private readonly IColorService _colorService;
        public Data.Entities.Color Color { get; set; } = new();
        public CreateColor(IColorService colorService)
        {
            InitializeComponent();
            _colorService = colorService;
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
                Color.Id = txtId.Text;
                Color.Name = txtName.Text;
                if (await _colorService.Add(Color))
                {
                    MessageBox.Show("Thêm mới màu sắc thành công!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Thêm mới màu sắc thất bại!");
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async Task<string> Validate()
        {
            var txt = "";
            txt += await _colorService.Validate(txtId.Text, txtName.Text);
            if(String.IsNullOrEmpty(txtId.Text) || txtId.Text.Length>15 || txtId.Text.Contains(" "))
            {
                txt += "Mã màu từ 1 đến 15 kí tự và không chứa khoảng trắng \n";
            }
            if (String.IsNullOrEmpty(txtName.Text) || txtId.Text.Length > 25)
            {
                txt += "Tên màu từ 1 đến 25 kí tự và không chứa khoảng trắng \n";
            }
            return txt;
        }
    }
}
