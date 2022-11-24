using App.Business.Sevices.Catalogs.Categories;
using App.Data.Entities;
using App.Data.Ultilities.Catalog.Categories;
using App.Data.Ultilities.Common;
using App.Views.Models.Controls;
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

namespace App.Views.Views.Catalog.Categories
{
    public partial class CategoryIndex : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly IServiceProvider _serviceProvider;
        public PagedResult<Category> Result { get; set; }
        public GetPagingCategoryRequest Request { get; set; } = new();
        public CategoryIndex(ICategoryService categoryService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _serviceProvider = serviceProvider;
        }

        private async void CategoryIndex_Load(object sender, EventArgs e)
        {
            Result = await _categoryService.GetPaging(Request);
            await LoadTableView();
        }
        private async Task LoadTableView()
        {
            TblView.Controls.Clear();
            int index = 0;
            foreach(var item in Result.Items)
            {

                // 
                // BtnHide
                // 
                var BtnHide = new VBButton();
                BtnHide.BackColor = System.Drawing.Color.MediumSlateBlue;
                BtnHide.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                BtnHide.BorderColor = System.Drawing.Color.PaleVioletRed;
                BtnHide.BorderRadius = 5;
                BtnHide.BorderSize = 0;
                BtnHide.FlatAppearance.BorderSize = 0;
                BtnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                BtnHide.ForeColor = System.Drawing.Color.White;
                BtnHide.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                BtnHide.IconColor = System.Drawing.Color.Black;
                BtnHide.IconFont = FontAwesome.Sharp.IconFont.Solid;
                BtnHide.IconSize = 25;
                BtnHide.Location = new System.Drawing.Point(1223, 3);
                BtnHide.Name = "BtnHide";
                BtnHide.Size = new System.Drawing.Size(34, 34);
                BtnHide.TabIndex = 7;
                BtnHide.TextColor = System.Drawing.Color.White;
                BtnHide.UseVisualStyleBackColor = false;

                var label7 = new Label();

                label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label7.AutoSize = true;
                label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label7.ForeColor = System.Drawing.Color.Black;
                label7.Location = new System.Drawing.Point(3, 8);
                label7.Name = "label7";
                label7.Size = new System.Drawing.Size(19, 23);
                label7.TabIndex = 5;
                label7.Text = (++index).ToString();

                var label8 = new Label();

                label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label8.AutoSize = true;
                label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label8.ForeColor = System.Drawing.Color.Black;
                label8.Location = new System.Drawing.Point(59, 8);
                label8.Name = "label8";
                label8.Size = new System.Drawing.Size(19, 23);
                label8.TabIndex = 0;
                label8.Text = item.Id.ToString();

                var label9 = new Label();

                label9.Anchor = System.Windows.Forms.AnchorStyles.None;
                label9.AutoSize = true;
                label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label9.ForeColor = System.Drawing.Color.Black;
                label9.Location = new System.Drawing.Point(852, 8);
                label9.Name = "label9";
                label9.Size = new System.Drawing.Size(124, 23);
                label9.TabIndex = 4;
                label9.Text = item.Parent!=null?item.Parent.Name:"";

                var BtnEdit = new VBButton();

                BtnEdit.BackColor = System.Drawing.Color.MediumSlateBlue;
                BtnEdit.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                BtnEdit.BorderColor = System.Drawing.Color.PaleVioletRed;
                BtnEdit.BorderRadius = 5;
                BtnEdit.BorderSize = 0;
                BtnEdit.FlatAppearance.BorderSize = 0;
                BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                BtnEdit.ForeColor = System.Drawing.Color.White;
                BtnEdit.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
                BtnEdit.IconColor = System.Drawing.Color.Black;
                BtnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
                BtnEdit.IconSize = 25;
                BtnEdit.Location = new System.Drawing.Point(1183, 3);
                BtnEdit.Name = "BtnEdit";
                BtnEdit.Size = new System.Drawing.Size(34, 34);
                BtnEdit.TabIndex = 6;
                BtnEdit.TextColor = System.Drawing.Color.White;
                BtnEdit.UseVisualStyleBackColor = false;

                var label10 = new Label();

                label10.Anchor = System.Windows.Forms.AnchorStyles.None;
                label10.AutoSize = true;
                label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label10.ForeColor = System.Drawing.Color.Black;
                label10.Location = new System.Drawing.Point(365, 8);
                label10.Name = "label10";
                label10.Size = new System.Drawing.Size(36, 23);
                label10.TabIndex = 8;
                label10.Text = item.Name;


                var tableLayoutPanel4 = new TableLayoutPanel();

                tableLayoutPanel4.BackColor = System.Drawing.Color.White;
                tableLayoutPanel4.ColumnCount = 6;
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel4.Controls.Add(label10, 0, 0);
                tableLayoutPanel4.Controls.Add(BtnHide, 5, 0);
                tableLayoutPanel4.Controls.Add(label7, 0, 0);
                tableLayoutPanel4.Controls.Add(label8, 0, 0);
                tableLayoutPanel4.Controls.Add(label9, 1, 0);
                tableLayoutPanel4.Controls.Add(BtnEdit, 4, 0);
                tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
                tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
                tableLayoutPanel4.Name = "tableLayoutPanel4";
                tableLayoutPanel4.RowCount = 1;
                tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                tableLayoutPanel4.Size = new System.Drawing.Size(1261, 40);
                tableLayoutPanel4.TabIndex = 3;
                //
                TblView.Controls.Add(tableLayoutPanel4);
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<CreateCategory>();
            form.FormClosed += async (o, s) =>
            {
                Result = await _categoryService.GetPaging(Request);
                await LoadTableView();
            };
            form.ShowDialog();
        }
    }
}
