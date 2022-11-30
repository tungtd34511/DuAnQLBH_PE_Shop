using App.Business.Sevices.Catalogs.Categories;
using App.Business.Sevices.Catalogs.Manufactures;
using App.Data.Entities;
using App.Data.Ultilities.Catalog.Categories;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Catalog.Manufacturers;
using App.Data.Ultilities.Common;
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

namespace App.Views.Views.Catalog.Manufacturers
{
    public partial class ManufactureIndex : Form
    {
        private readonly IManufactureServices _manufactureServices;
        private readonly IServiceProvider _serviceProvider;
        public PagedResult<Manufacturer> Result { get; set; }
        public GetPagingManufactureRequest Request { get; set; } = new();
        public ManufactureIndex(IManufactureServices manufactureServices, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _manufactureServices = manufactureServices;
            _serviceProvider = serviceProvider;
        }
        private async Task LoadViewTable()
        {
            lblResult.Text = Result.TotalRecords.ToString() + " kết quả";
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
                BtnHide.Location = new System.Drawing.Point(1224, 3);
                BtnHide.Name = "BtnHide";
                BtnHide.Size = new System.Drawing.Size(34, 34);
                BtnHide.TabIndex = 7;
                BtnHide.TextColor = System.Drawing.Color.White;
                BtnHide.UseVisualStyleBackColor = false;

                var LblStt = new Label();

                LblStt.Anchor = System.Windows.Forms.AnchorStyles.Left;
                LblStt.AutoSize = true;
                LblStt.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                LblStt.ForeColor = System.Drawing.Color.Black;
                LblStt.Location = new System.Drawing.Point(3, 8);
                LblStt.Name = "LblStt";
                LblStt.Size = new System.Drawing.Size(19, 23);
                LblStt.TabIndex = 5;
                LblStt.Text = (++index).ToString();

                var LblId = new Label();

                LblId.Anchor = System.Windows.Forms.AnchorStyles.Left;
                LblId.AutoSize = true;
                LblId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                LblId.ForeColor = System.Drawing.Color.Black;
                LblId.Location = new System.Drawing.Point(59, 8);
                LblId.Name = "LblId";
                LblId.Size = new System.Drawing.Size(19, 23);
                LblId.TabIndex = 0;
                LblId.Text = item.Id.ToString();

                var LblName = new Label();

                LblName.Anchor = System.Windows.Forms.AnchorStyles.None;
                LblName.AutoSize = true;
                LblName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                LblName.ForeColor = System.Drawing.Color.Black;
                LblName.Location = new System.Drawing.Point(576, 8);
                LblName.Name = "LblName";
                LblName.Size = new System.Drawing.Size(146, 23);
                LblName.TabIndex = 4;
                LblName.Text = item.Name;

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
                BtnEdit.Location = new System.Drawing.Point(1184, 3);
                BtnEdit.Name = "BtnEdit";
                BtnEdit.Size = new System.Drawing.Size(34, 34);
                BtnEdit.TabIndex = 6;
                BtnEdit.TextColor = System.Drawing.Color.White;
                BtnEdit.UseVisualStyleBackColor = false;

                var tableLayoutPanel4 = new TableLayoutPanel();

                tableLayoutPanel4.BackColor = System.Drawing.Color.White;
                tableLayoutPanel4.ColumnCount = 5;
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel4.Controls.Add(BtnHide, 4, 0);
                tableLayoutPanel4.Controls.Add(LblStt, 0, 0);
                tableLayoutPanel4.Controls.Add(LblId, 0, 0);
                tableLayoutPanel4.Controls.Add(LblName, 1, 0);
                tableLayoutPanel4.Controls.Add(BtnEdit, 3, 0);
                tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
                tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
                tableLayoutPanel4.Name = "tableLayoutPanel4";
                tableLayoutPanel4.RowCount = 1;
                tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                tableLayoutPanel4.Size = new System.Drawing.Size(1261, 40);
                tableLayoutPanel4.TabIndex = 3;
                if (index % 2 == 0)
                {
                    tableLayoutPanel4.BackColor = SystemColors.Control;
                }
                //
                TblView.Controls.Add(tableLayoutPanel4);
                BtnEdit.Click += async (o, s) =>
                {
                    await BtnEdit_Click(item.Id);
                };
                BtnHide.Click += async (o, s) =>
                {
                    await BtnHide_Click(item.Id,item.IsDeleted);
                };
            }
        }
        private async Task BtnEdit_Click(int Id)
        {
            var frmDetail = _serviceProvider.GetRequiredService<UpdateManufacture>();
            frmDetail.Manufacturer = await _manufactureServices.GetManufacturerById(Id);
            frmDetail.FormClosed += async (o, s) =>
            {
                Result = await _manufactureServices.GetPaging(Request);
                await LoadViewTable();
                await LoadMenuPaging();
            };
            frmDetail.ShowDialog();
        }
        private async Task BtnHide_Click(int Id, bool status)
        {
            if (status)
            {
                if (MessageBox.Show("Bạn có muốn hiển thị nhà sản xuất?", "PE-SHOP", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var color = await _manufactureServices.GetManufacturerById(Id);
                    color.IsDeleted = false;
                    var result = await _manufactureServices.Update(color);
                    if (result)
                    {
                        MessageBox.Show("Hiển thị nhà sản xuất thành công !");
                        Result = await _manufactureServices.GetPaging(Request);
                        await LoadViewTable();
                        await LoadMenuPaging();
                    }
                    else
                    {
                        MessageBox.Show("Hiển thị nhà sản xuất thất bại !");
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn ẩn nhà sản xuất?", "PE-SHOP", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var color = await _manufactureServices.GetManufacturerById(Id);
                    color.IsDeleted = true;
                    var result = await _manufactureServices.Update(color);
                    if (result)
                    {
                        MessageBox.Show("Ẩn màu sắc thành công !");
                        Result = await _manufactureServices.GetPaging(Request);
                        await LoadViewTable();
                        await LoadMenuPaging();
                    }
                    else
                    {
                        MessageBox.Show("Ẩn  màu sắc thất bại !");
                    }
                }
            }
        }
        private async void ManufactureIndex_Load(object sender, EventArgs e)
        {
            Result = await _manufactureServices.GetPaging(Request);
            await LoadForm();
        }
        public async Task LoadForm()
        {
            await LoadViewTable();
            await LoadMenuPaging();
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
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<CreateManufacture>();
            form.FormClosed += async(o, s) =>
            {
                Result = await _manufactureServices.GetPaging(Request);
                await LoadViewTable();
            };
            form.ShowDialog();
        }

        private async void CheckUnHide_CheckedChanged(object sender, EventArgs e)
        {
            await Check_Click();
        }

        private async void Btn_Search_Click(object sender, EventArgs e)
        {
            await Check_Click();
        }
        private async Task Check_Click()
        {
            Request = new();
            Result = await _manufactureServices.GetPaging(await GetPagingRequest());
            await LoadViewTable();
            await LoadMenuPaging();
        }
        private async Task<GetPagingManufactureRequest> GetPagingRequest()
        {
            Request.Keyword = Txt_Search.Text;
            Request.UnHide = CheckUnHide.Checked;
            Request.OrderBy = Comb_OderBy.SelectedIndex;
            return Request;
        }

        private async void Comb_OderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Result = await _manufactureServices.GetPaging(await GetPagingRequest());
            await LoadViewTable();
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
                Result = await _manufactureServices.GetPaging(await GetPagingRequest());
                await LoadViewTable();
                await LoadMenuPaging();
            }
        }
        private async Task PageIndex_Changed()
        {
            Result = await _manufactureServices.GetPaging(await GetPagingRequest());
            await LoadViewTable();
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
    }
}
