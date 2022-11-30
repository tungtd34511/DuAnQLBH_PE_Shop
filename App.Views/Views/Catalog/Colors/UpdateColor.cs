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
using System.Xml.Linq;

namespace App.Views.Views.Catalog.Colors
{
    public partial class UpdateColor : Form
    {
        private readonly IColorService _colorService;
        public Data.Entities.Color Color { get; set; }
        public UpdateColor(IColorService colorService)
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
                Color.Name = LblName.Text;
                if (await _colorService.Update(Color))
                {
                    MessageBox.Show("Cập nhật màu sắc thành công!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật  màu sắc thất bại!");
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateColor_Load(object sender, EventArgs e)
        {
            LblName.Text = Color.Name;
        }
        private async Task<string> Validate()
        {
            var txt = "";
            if (Color.Name != LblName.Text)
            {
                txt += await _colorService.Validate("", LblName.Text);
            }
            if (String.IsNullOrEmpty(LblName.Text) || LblName.Text.Length > 25)
            {
                txt += "Tên màu từ 1 đến 25 kí tự và không chứa khoảng trắng \n";
            }
            return txt;
        }
    }
}
