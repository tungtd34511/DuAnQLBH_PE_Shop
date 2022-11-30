using App.Business.Sevices.Catalogs.Sizes;
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

namespace App.Views.Views.Catalog.Sizes
{
    public partial class UpdateSize : Form
    {
        private readonly ISizeService _sizeService;
        public Data.Entities.Size Size { get; set; } = new();
        public UpdateSize(ISizeService sizeService)
        {
            InitializeComponent();
            _sizeService = sizeService;
        }

        private void UpdateSize_Load(object sender, EventArgs e)
        {
            LblName.Text = Size.Name;
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
                Size.Name = LblName.Text;
                if (await _sizeService.Update(Size))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
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
            if (LblName.Text != Size.Name)
            {
                eror += await _sizeService.Validate("", LblName.Text);
            }
            if (String.IsNullOrEmpty(LblName.Text) || LblName.Text.Length > 25)
            {
                eror += "Tên kích cỡ phải từ 1 đến 25 kí tự !\n";
            }
            return eror;
        }
    }
}
