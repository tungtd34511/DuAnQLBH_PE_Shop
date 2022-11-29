using App.Business.Sevices.Catalogs.Colors;
using App.Business.Sevices.ProductVariations;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Catalog.ProductVariation;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.ViewModels;
using App.Views.Models.Controls;
using App.Views.Views.Catalog.Colors;
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

namespace App.Views.Views.Catalog.ProductVariations
{
    public partial class ProductVariationIndex : Form
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly IProductVariationServices _productVariationServices;
        public GetPagingProductVariationRequest Request { get; set; } = new();
        public PagedResult<ProductVariationVm> Result { get; set; } = new();
        public ProductVariationIndex(IServiceProvider serviceProvider, IProductVariationServices productVariationServices)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _productVariationServices = productVariationServices;
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
        public async Task LoadViewTable()
        {
            TblView.Controls.Clear();
            int index = 0;
            foreach (var item in Result.Items)
            {

                // 
                // label11
                // 
                var label11 = new Label();
                label11.Anchor = System.Windows.Forms.AnchorStyles.None;
                label11.AutoSize = true;
                label11.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label11.ForeColor = System.Drawing.Color.Black;
                label11.Location = new System.Drawing.Point(4, 8);
                label11.Name = "label11";
                label11.Size = new System.Drawing.Size(47, 23);
                label11.TabIndex = 9;
                label11.Text = (++index).ToString();

                var label13 = new Label();

                label13.Anchor = System.Windows.Forms.AnchorStyles.None;
                label13.AutoSize = true;
                label13.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label13.ForeColor = System.Drawing.Color.Black;
                label13.Location = new System.Drawing.Point(1050, 8);
                label13.Name = "label13";
                label13.Size = new System.Drawing.Size(90, 23);
                label13.TabIndex = 4;
                label13.Text = item.IsDeleted?"Ẩn":"Hiển Thị";

                var label16 = new Label();

                label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
                label16.AutoSize = true;
                label16.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label16.ForeColor = System.Drawing.Color.Black;
                label16.Location = new System.Drawing.Point(925, 8);
                label16.Name = "label16";
                label16.Size = new System.Drawing.Size(82, 23);
                label16.TabIndex = 7;
                label16.Text = item.Stock.ToString();

                var label17 = new Label();

                label17.Anchor = System.Windows.Forms.AnchorStyles.None;
                label17.AutoSize = true;
                label17.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label17.ForeColor = System.Drawing.Color.Black;
                label17.Location = new System.Drawing.Point(776, 8);
                label17.Name = "label17";
                label17.Size = new System.Drawing.Size(68, 23);
                label17.TabIndex = 8;
                label17.Text = item.SizeId;

                var label18 = new Label();

                label18.Anchor = System.Windows.Forms.AnchorStyles.None;
                label18.AutoSize = true;
                label18.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label18.ForeColor = System.Drawing.Color.Black;
                label18.Location = new System.Drawing.Point(608, 8);
                label18.Name = "label18";
                label18.Size = new System.Drawing.Size(44, 23);
                label18.TabIndex = 6;
                label18.Text = item.ColorName;

                var label19 = new Label();

                label19.Anchor = System.Windows.Forms.AnchorStyles.None;
                label19.AutoSize = true;
                label19.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label19.ForeColor = System.Drawing.Color.Black;
                label19.Location = new System.Drawing.Point(268, 8);
                label19.Name = "label19";
                label19.Size = new System.Drawing.Size(118, 23);
                label19.TabIndex = 0;
                label19.Text = item.ProductName;

                var label20 = new Label();

                label20.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label20.AutoSize = true;
                label20.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label20.ForeColor = System.Drawing.Color.Black;
                label20.Location = new System.Drawing.Point(59, 8);
                label20.Name = "label20";
                label20.Size = new System.Drawing.Size(27, 23);
                label20.TabIndex = 5;
                label20.Text = item.Id.ToString();

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
                BtnEdit.Location = new System.Drawing.Point(1186, 5);
                BtnEdit.Margin = new System.Windows.Forms.Padding(5);
                BtnEdit.Name = "BtnEdit";
                BtnEdit.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
                BtnEdit.Size = new System.Drawing.Size(30, 30);
                BtnEdit.TabIndex = 10;
                BtnEdit.TextColor = System.Drawing.Color.White;
                BtnEdit.UseVisualStyleBackColor = false;

                var BtnChangeStatus = new VBButton();

                BtnChangeStatus.BackColor = System.Drawing.Color.MediumSlateBlue;
                BtnChangeStatus.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                BtnChangeStatus.BorderColor = System.Drawing.Color.PaleVioletRed;
                BtnChangeStatus.BorderRadius = 5;
                BtnChangeStatus.BorderSize = 0;
                BtnChangeStatus.FlatAppearance.BorderSize = 0;
                BtnChangeStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                BtnChangeStatus.ForeColor = System.Drawing.Color.White;
                BtnChangeStatus.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                if (item.IsDeleted)
                {
                    BtnChangeStatus.IconChar = FontAwesome.Sharp.IconChar.Eye;
                }
                BtnChangeStatus.IconColor = System.Drawing.Color.Black;
                BtnChangeStatus.IconFont = FontAwesome.Sharp.IconFont.Solid;
                BtnChangeStatus.IconSize = 25;
                BtnChangeStatus.Location = new System.Drawing.Point(1226, 5);
                BtnChangeStatus.Margin = new System.Windows.Forms.Padding(5);
                BtnChangeStatus.Name = "BtnChangeStatus";
                BtnChangeStatus.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
                BtnChangeStatus.Size = new System.Drawing.Size(30, 30);
                BtnChangeStatus.TabIndex = 11;
                BtnChangeStatus.TextColor = System.Drawing.Color.White;
                BtnChangeStatus.UseVisualStyleBackColor = false;

                var tableLayoutPanel4 = new TableLayoutPanel();

                tableLayoutPanel4.BackColor = System.Drawing.Color.White;
                tableLayoutPanel4.ColumnCount = 9;
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 418F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel4.Controls.Add(BtnChangeStatus, 8, 0);
                tableLayoutPanel4.Controls.Add(label11, 0, 0);
                tableLayoutPanel4.Controls.Add(label13, 5, 0);
                tableLayoutPanel4.Controls.Add(label16, 5, 0);
                tableLayoutPanel4.Controls.Add(label17, 4, 0);
                tableLayoutPanel4.Controls.Add(label18, 3, 0);
                tableLayoutPanel4.Controls.Add(label19, 2, 0);
                tableLayoutPanel4.Controls.Add(label20, 1, 0);
                tableLayoutPanel4.Controls.Add(BtnEdit, 7, 0);
                tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
                tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
                tableLayoutPanel4.Name = "tableLayoutPanel4";
                tableLayoutPanel4.RowCount = 1;
                tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                tableLayoutPanel4.Size = new System.Drawing.Size(1261, 40);
                tableLayoutPanel4.TabIndex = 12;
                //
                TblView.Controls.Add(tableLayoutPanel4);
                //
                BtnEdit.Click += async (o, s) =>
                {
                    await BtnEdit_Click(item.Id);
                };
                BtnChangeStatus.Click += async (o, s) =>
                {
                    await BtnHide_Click(item.Id, item.IsDeleted);
                };
            }
            lblResult.Text = Result.TotalRecords.ToString() + " Kết quả";
        }
        private async Task BtnEdit_Click(int Id)
        {
            var frmDetail = _serviceProvider.GetRequiredService<UpdateProductVariation>();
            frmDetail.PV = await _productVariationServices.GetById(Id);
            frmDetail.FormClosed += async (o, s) =>
            {
                Result = await _productVariationServices.GetAllPaging(Request);
                await LoadViewTable();
                await LoadMenuPaging();
            };
            frmDetail.ShowDialog();
        }
        private async Task BtnHide_Click(int Id, bool status)
        {
            if (status)
            {
                if (MessageBox.Show("Bạn có muốn hiển thị biến thể?", "PE-SHOP", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var pv = await _productVariationServices.GetById(Id);
                    pv.IsDeleted = false;
                    var result = await _productVariationServices.Update(pv);
                    if (result)
                    {
                        MessageBox.Show("Hiển thị biến thể thành công !");
                        Result = await _productVariationServices.GetAllPaging(Request);
                        await LoadViewTable();
                        await LoadMenuPaging();
                    }
                    else
                    {
                        MessageBox.Show("Hiển thị biến thể thất bại !");
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn ẩn biến thể?", "PE-SHOP", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var pv = await _productVariationServices.GetById(Id);
                    pv.IsDeleted = true;
                    var result = await _productVariationServices.Update(pv);
                    if (result)
                    {
                        MessageBox.Show("Ẩn biến thể thành công !");
                        Result = await _productVariationServices.GetAllPaging(Request);
                        await LoadViewTable();
                        await LoadMenuPaging();
                    }
                    else
                    {
                        MessageBox.Show("Ẩn biến thể thất bại !");
                    }
                }
            }
        }
        public async Task LoadForm()
        {
            await LoadViewTable();
            await LoadMenuPaging();
        }

        private async Task PageIndex_Changed()
        {
            Result = await _productVariationServices.GetAllPaging(await GetPagingRequest());
            await LoadViewTable();
            await LoadMenuPaging();
        }
        private async Task<GetPagingProductVariationRequest> GetPagingRequest()
        {
            Request.Keyword = Txt_Search.Text;
            Request.UnHide = CheckUnHide.Checked;
            return Request;
        }
        private async Task Check_Click()
        {
            Request = new();
            Result = await _productVariationServices.GetAllPaging(await GetPagingRequest());
            await LoadViewTable();
            await LoadMenuPaging();
        }

        private async void ProductVariationIndex_Load(object sender, EventArgs e)
        {
            Result = await _productVariationServices.GetAllPaging(Request);
            await LoadForm();
        }

        private async void TxtPageIndex_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                var index = Convert.ToInt32(TxtPageIndex.Text);
                if (index > 0 && index < Result.PageCount)
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

        private async void TxtPageIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được phép nhập số !");
            }
        }

        private async void btn_firt_Click(object sender, EventArgs e)
        {
            if (Result.PageIndex != 1)
            {
                await PageIndex_Changed();
            }
            else
            {
                MessageBox.Show("Đã là trang đầu tiên!");
            }
        }

        private async void btn_Prev_Click(object sender, EventArgs e)
        {
            if (Result.PageIndex > 1)
            {
                await PageIndex_Changed();
            }
            else
            {
                MessageBox.Show("Đã là trang đầu tiên!");
            }
        }

        private async void btn_next_Click(object sender, EventArgs e)
        {
            if (Result.PageIndex < Result.PageCount)
            {
                await PageIndex_Changed();
            }
            else
            {
                MessageBox.Show("Đã là trang cuối!");
            }
        }

        private async void btn_last_Click(object sender, EventArgs e)
        {
            if (Result.PageIndex < Result.PageCount)
            {
                await PageIndex_Changed();
            }
            else
            {
                MessageBox.Show("Đã là trang cuối!");
            }
        }

        private async void Btn_Search_Click_1(object sender, EventArgs e)
        {
            await Check_Click();
        }

        private async void CheckUnHide_CheckedChanged(object sender, EventArgs e)
        {
            await Check_Click();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var frmDetail = _serviceProvider.GetRequiredService<CreateProductVariaton>();
            frmDetail.FormClosed += async (o, s) =>
            {
                Result = await _productVariationServices.GetAllPaging(await GetPagingRequest());
                await LoadViewTable();
                await LoadMenuPaging();
            };
            frmDetail.ShowDialog();
        }
    }
}
