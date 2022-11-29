using App.Business.Sevices.Catalogs.Colors;
using App.Business.Sevices.Catalogs.Sizes;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Catalog.Sizes;
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

namespace App.Views.Views.Catalog.Sizes
{
    public partial class SizeIndex : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISizeService _sizeService;
        public GetSizePagingRequest Request { get; set; } = new();
        public PagedResult<Data.Entities.Size> Result { get; set; } = new();

        public SizeIndex(IServiceProvider serviceProvider, ISizeService sizeService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _sizeService = sizeService;
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
                // BtnChangeStatus
                // 
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
                BtnChangeStatus.TabIndex = 8;
                BtnChangeStatus.TextColor = System.Drawing.Color.White;
                BtnChangeStatus.UseVisualStyleBackColor = false;

                var label7 = new Label();

                label7.Anchor = System.Windows.Forms.AnchorStyles.None;
                label7.AutoSize = true;
                label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label7.ForeColor = System.Drawing.Color.Black;
                label7.Location = new System.Drawing.Point(10, 8);
                label7.Name = "label7";
                label7.Size = new System.Drawing.Size(36, 23);
                label7.TabIndex = 6;
                label7.Text = (++index).ToString();

                var label10 = new Label();

                label10.Anchor = System.Windows.Forms.AnchorStyles.None;
                label10.AutoSize = true;
                label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label10.ForeColor = System.Drawing.Color.Black;
                label10.Location = new System.Drawing.Point(486, 8);
                label10.Name = "label10";
                label10.Size = new System.Drawing.Size(87, 23);
                label10.TabIndex = 4;
                label10.Text = item.Name;

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
                BtnEdit.TabIndex = 7;
                BtnEdit.TextColor = System.Drawing.Color.White;
                BtnEdit.UseVisualStyleBackColor = false;

                var label9 = new Label();

                label9.Anchor = System.Windows.Forms.AnchorStyles.None;
                label9.AutoSize = true;
                label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label9.ForeColor = System.Drawing.Color.Black;
                label9.Location = new System.Drawing.Point(1131, 8);
                label9.Name = "label9";
                label9.Size = new System.Drawing.Size(47, 23);
                label9.TabIndex = 0;
                label9.Text = item.IsDeleted ? "Ẩn" : "Hiển thị";

                var label8 = new Label();

                label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label8.AutoSize = true;
                label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label8.ForeColor = System.Drawing.Color.Black;
                label8.Location = new System.Drawing.Point(59, 8);
                label8.Name = "label8";
                label8.Size = new System.Drawing.Size(27, 23);
                label8.TabIndex = 5;
                label8.Text = item.Id;


                var tableLayoutPanel4 = new TableLayoutPanel();

                tableLayoutPanel4.BackColor = System.Drawing.Color.White;
                tableLayoutPanel4.ColumnCount = 6;
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.67679F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.32321F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel4.Controls.Add(BtnChangeStatus, 5, 0);
                tableLayoutPanel4.Controls.Add(label7, 0, 0);
                tableLayoutPanel4.Controls.Add(label10, 1, 0);
                tableLayoutPanel4.Controls.Add(BtnEdit, 4, 0);
                tableLayoutPanel4.Controls.Add(label9, 2, 0);
                tableLayoutPanel4.Controls.Add(label8, 1, 0);
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
        private async Task BtnEdit_Click(string Id)
        {
            var frmDetail = _serviceProvider.GetRequiredService<UpdateSize>();
            frmDetail.Size = await _sizeService.GetById(Id);
            frmDetail.FormClosed += async (o, s) =>
            {
                Result = await _sizeService.GetPaging(Request);
                await LoadViewTable();
                await LoadMenuPaging();
            };
            frmDetail.ShowDialog();
        }
        private async Task BtnHide_Click(string Id, bool status)
        {
            if (status)
            {
                if (MessageBox.Show("Bạn có muốn hiển thị kích cỡ?", "PE-SHOP", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var color = await _sizeService.GetById(Id);
                    color.IsDeleted = false;
                    var result = await _sizeService.Update(color);
                    if (result)
                    {
                        MessageBox.Show("Hiển thị kích cỡ thành công !");
                        Result = await _sizeService.GetPaging(Request);
                        await LoadViewTable();
                        await LoadMenuPaging();
                    }
                    else
                    {
                        MessageBox.Show("Hiển thị kích cỡ thất bại !");
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn ẩn kích cỡ?", "PE-SHOP", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var color = await _sizeService.GetById(Id);
                    color.IsDeleted = true;
                    var result = await _sizeService.Update(color);
                    if (result)
                    {
                        MessageBox.Show("Ẩn kích cỡ thành công !");
                        Result = await _sizeService.GetPaging(Request);
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
        public async Task LoadForm()
        {
            await LoadViewTable();
            await LoadMenuPaging();
        }

        private async Task PageIndex_Changed()
        {
            Result = await _sizeService.GetPaging(await GetPagingRequest());
            await LoadViewTable();
            await LoadMenuPaging();
        }
        private async void CheckUnHide_CheckedChanged(object sender, EventArgs e)
        {
            await Check_Click();
        }

        private async void Btn_Search_Click(object sender, EventArgs e)
        {
            await Check_Click();
        }
        private async Task<GetSizePagingRequest> GetPagingRequest()
        {
            Request.Keyword = Txt_Search.Text;
            Request.UnHide = CheckUnHide.Checked;
            return Request;
        }
        private async Task Check_Click()
        {
            Request = new();
            Result = await _sizeService.GetPaging(await GetPagingRequest());
            await LoadViewTable();
            await LoadMenuPaging();
        }

        private async void SizeIndex_Load(object sender, EventArgs e)
        {
            Result = await _sizeService.GetPaging(Request);
            await LoadForm();
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

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var frmDetail = _serviceProvider.GetRequiredService<CreateSize>();
            frmDetail.FormClosed += async (o, s) =>
            {
                Result = await _sizeService.GetPaging(Request);
                await LoadViewTable();
                await LoadMenuPaging();
            };
            frmDetail.ShowDialog();
        }
    }
}
