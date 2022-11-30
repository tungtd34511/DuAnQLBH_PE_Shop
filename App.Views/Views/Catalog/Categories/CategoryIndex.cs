using App.Business.Sevices.Catalogs.Categories;
using App.Data.Entities;
using App.Data.Ultilities.Catalog.Categories;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.Enums;
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
            await LoadMenuPaging();
        }
        private async Task LoadTableView()
        {
            lblResult.Text = Result.TotalRecords.ToString()+" kết quả";
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
                if (item.IsDeleted)
                {
                    BtnHide.IconChar = FontAwesome.Sharp.IconChar.Eye;
                }
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
                if(index%2 == 0)
                {
                    tableLayoutPanel4.BackColor = System.Drawing.SystemColors.Control;
                }
                //
                TblView.Controls.Add(tableLayoutPanel4);
                BtnEdit.Click += async (o, s) =>
                {
                    await BtnEdit_Click(item.Id);
                };
                BtnHide.Click += async (o, s) =>
                {
                    await BtnHide_Click(item.Id);
                };
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
        private async Task BtnEdit_Click(int Id)
        {
            var frmDetail = _serviceProvider.GetRequiredService<UpdateCategory>();
            frmDetail.Category = await _categoryService.GetCategoryById(Id);
            frmDetail.FormClosed += async (o, s) =>
            {
                Result = await _categoryService.GetPaging(Request);
                await LoadTableView();
                await LoadMenuPaging();
            };
            frmDetail.ShowDialog();
        }
        private async Task BtnHide_Click(int Id) { 
            var category = await _categoryService.GetCategoryById(Id);
            if (category.IsDeleted==false)
            {
                if (MessageBox.Show("Bạn có muốn ẩn danh mục ?", "PE-SHOP", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    category.IsDeleted = true;
                    if (await _categoryService.ChangeStatus(category))
                    {
                        MessageBox.Show("Ẩn danh mục thành công !");
                        Result = await _categoryService.GetPaging(Request);
                        await LoadTableView();
                        await LoadMenuPaging();
                    }
                    else
                    {
                        MessageBox.Show("Ẩn danh mục thất bại !");
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn hiện danh mục ?", "PE-SHOP", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    category.IsDeleted = false;
                    if (await _categoryService.ChangeStatus(category))
                    {
                        MessageBox.Show("Hiện danh mục thành công !");
                        Result = await _categoryService.GetPaging(Request);
                        await LoadTableView();
                        await LoadMenuPaging();
                    }
                    else
                    {
                        MessageBox.Show("Hiện danh mục thất bại !");
                    }
                }
            }
        }
        private async Task<GetPagingCategoryRequest> SetRequest()
        {
            Request.Unhide = CheckUnHide.Checked;
            Request.Orderby = Comb_OderBy.SelectedIndex;
            Request.Keyword = Txt_Search.Text;
            return Request;
        }
        private async void vbButton5_Click(object sender, EventArgs e)
        {
            try
            {
                Txt_Search.Text = "";
                Comb_OderBy.SelectedIndex = 0;
                CheckUnHide.Checked = false;
            }
            finally
            {
                Request = new();
                Result = await _categoryService.GetPaging(await GetPagingRequest());
                await LoadTableView();
                await LoadMenuPaging();
            }
        }

        private async void Comb_OderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Result = await _categoryService.GetPaging(await SetRequest());
            await LoadTableView();
            await LoadMenuPaging();
        }

        private async void btn_Prev_Click(object sender, EventArgs e)
        {
            if (Result.PageIndex > 1)
            {
                Request.PageIndex--;
                await PageIndex_Changed();
            }
            else
            {
                MessageBox.Show("Đã là trang đầu tiên!");
            }
        }

        private async  void btn_firt_Click(object sender, EventArgs e)
        {
            if (Result.PageIndex != 1)
            {
                Request.PageIndex = 1;
                await PageIndex_Changed();
            }
            else
            {
                MessageBox.Show("Đã là trang đầu tiên!");
            }
        }

        private void TxtPageIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được phép nhập số !");
            }
        }

        private async void TxtPageIndex_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var index = Convert.ToInt32(TxtPageIndex.Text);
                if (index > 0 && index <= Result.PageCount)
                {
                    Result.PageIndex = index;
                    await PageIndex_Changed();
                }
                else
                {
                    TxtPageIndex.Text = Result.PageIndex.ToString();
                    MessageBox.Show("Số trang phải lớn hơn 0 và nhỏ hơn hoặc bằng tổng số lượng trang!");
                }
            }
            catch
            {
                TxtPageIndex.Text = Result.PageIndex.ToString();
            }
        }

        private async void btn_next_Click(object sender, EventArgs e)
        {
            if (Result.PageIndex < Result.PageCount)
            {
                Request.PageIndex++;
                await PageIndex_Changed();
            }
            else
            {
                MessageBox.Show("Đã là trang cuối!");
            }
        }
        private async Task PageIndex_Changed()
        {
            Result = await _categoryService.GetPaging(await GetPagingRequest());
            await LoadTableView();
            await LoadMenuPaging();
        }
        private async void btn_last_Click(object sender, EventArgs e)
        {
            if (Result.PageIndex < Result.PageCount)
            {
                Request.PageIndex = Result.PageCount;
                await PageIndex_Changed();
            }
            else
            {
                MessageBox.Show("Đã là trang cuối!");
            }
        }
        public async Task LoadMenuPaging()
        {
            try
            {

                TxtPageIndex.Text = Result.PageIndex.ToString();
                LblPageLastIndex.Text = "/" + Result.PageCount.ToString();
            }
            catch
            {

            }
        }
        private async Task<GetPagingCategoryRequest> GetPagingRequest()
        {
            Request.Keyword = Txt_Search.Text;
            Request.Unhide = CheckUnHide.Checked;
            Request.Orderby = Comb_OderBy.SelectedIndex;
            return Request;
        }
        private async  Task Check_Click()
        {
            Request = new();
            Result = await _categoryService.GetPaging(await GetPagingRequest());
            await LoadTableView();
            await LoadMenuPaging();
        }
        private async void Btn_Search_Click(object sender, EventArgs e)
        {
            await Check_Click();
        }

        private async void CheckUnHide_CheckedChanged(object sender, EventArgs e)
        {
            await Check_Click();
        }
    }
}
