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
    public partial class CreateCategory : Form
    {
        private readonly ICategoryService _categoryService;
        public Category Category { get; set; } = new();
        public IEnumerable<Category> Categories { get; set; }
        public CreateCategory(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (CombParent.SelectedIndex != -1)
            {

                Category.ParentId = Categories.ToList()[CombParent.SelectedIndex].Id;
            }
            Category.IsDeleted = false;
            Category.Name = LblName.Text;
            await _categoryService.Add(Category);
            Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void CreateCategory_Load(object sender, EventArgs e)
        {
            Categories = await _categoryService.GetAll();
            CombParent.Items.AddRange(Categories.Select(c => c.Name).ToArray());
        }
    }
}
