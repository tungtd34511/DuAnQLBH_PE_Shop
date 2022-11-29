using App.Business.Sevices.Catalogs.Categories;
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

namespace App.Views.Views.Catalog.Categories
{
    public partial class UpdateCategory : Form
    {
        private readonly ICategoryService _categoryService;
        public Category Category { get; set; }
        public UpdateCategory(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
        }
        private async Task<string> Validate()
        {
            var eror = "";
            eror += await _categoryService.Validate(LblName.Text);
            if (String.IsNullOrEmpty(LblName.Text) || LblName.Text.Length > 25)
            {
                eror += "Tên danh mục phải từ 1 đến 25 ký tự!\n";
            }
            return eror;
        }

        private void UpdateCategory_Load(object sender, EventArgs e)
        {
            LblName.Text = Category.Name;
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
                Category.Name = LblName.Text;
                if (await _categoryService.Edit(Category))
                {
                    MessageBox.Show("Cập nhật thành công !");
                    Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại !");
                }
            }
        }
    }
}
