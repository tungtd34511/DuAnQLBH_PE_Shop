using App.Business.Sevices.Promotions;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Catalog.Promotion;
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

namespace App.Views.Views.Promotion
{
    public partial class PromotionIndex : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IPromotionService _promotionService;
        public PagedResult<Data.Entities.Promotion> Result { get; set; }
        public GetPromotionPagingRequest Request { get; set; } = new();
        public PromotionIndex(IServiceProvider serviceProvider, IPromotionService promotionService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _promotionService = promotionService;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<CreatePromotion>();
            form.TopLevel = false;
            form.FormClosed += async (o, s) =>
            {
                this.Controls[0].Show();
                await this.LoadForm();
            };
            this.Controls[0].Hide();
            this.Controls.Add(form);
            form.Show();
        }

        private async Task LoadView()
        {
            TblProducts.Controls.Clear();
            var index = 0;
            foreach (var item in Result.Items) {

                // 
                // BtnChageStatus
                // 
                var BtnChageStatus = new VBButton();
                BtnChageStatus.BackColor = System.Drawing.Color.MediumSlateBlue;
                BtnChageStatus.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                BtnChageStatus.BorderColor = System.Drawing.Color.PaleVioletRed;
                BtnChageStatus.BorderRadius = 5;
                BtnChageStatus.BorderSize = 0;
                BtnChageStatus.FlatAppearance.BorderSize = 0;
                BtnChageStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                BtnChageStatus.ForeColor = System.Drawing.Color.White;
                BtnChageStatus.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                if (item.Status == Data.Ultilities.Enums.PromotionStatus.InActive)
                {
                    BtnChageStatus.IconChar = FontAwesome.Sharp.IconChar.Eye;
                }
                BtnChageStatus.IconColor = System.Drawing.Color.Black;
                BtnChageStatus.IconFont = FontAwesome.Sharp.IconFont.Solid;
                BtnChageStatus.IconSize = 24;
                BtnChageStatus.Location = new System.Drawing.Point(1227, 6);
                BtnChageStatus.Margin = new System.Windows.Forms.Padding(6);
                BtnChageStatus.Name = "BtnChageStatus";
                BtnChageStatus.Size = new System.Drawing.Size(28, 28);
                BtnChageStatus.TabIndex = 13;
                BtnChageStatus.TextColor = System.Drawing.Color.White;
                BtnChageStatus.UseVisualStyleBackColor = false;

                var label5 = new Label();

                label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                label5.AutoSize = true;
                label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label5.ForeColor = System.Drawing.Color.Black;
                label5.Location = new System.Drawing.Point(3, 8);
                label5.Name = "label5";
                label5.Size = new System.Drawing.Size(50, 23);
                label5.TabIndex = 0;
                label5.Text = (++index).ToString();

                var label10 = new Label();

                label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                label10.AutoSize = true;
                label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label10.ForeColor = System.Drawing.Color.Black;
                label10.Location = new System.Drawing.Point(1083, 8);
                label10.Name = "label10";
                label10.Size = new System.Drawing.Size(95, 23);
                label10.TabIndex = 8;
                label10.Text = item.Status.ToString();

                var label11 = new Label();

                label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label11.AutoSize = true;
                label11.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label11.ForeColor = System.Drawing.Color.Black;
                label11.Location = new System.Drawing.Point(59, 8);
                label11.Name = "label11";
                label11.Size = new System.Drawing.Size(27, 23);
                label11.TabIndex = 4;
                label11.Text = item.Id.ToString();

                var label12 = new Label();

                label12.Anchor = System.Windows.Forms.AnchorStyles.None;
                label12.AutoSize = true;
                label12.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label12.ForeColor = System.Drawing.Color.Black;
                label12.Location = new System.Drawing.Point(344, 8);
                label12.Name = "label12";
                label12.Size = new System.Drawing.Size(41, 23);
                label12.TabIndex = 5;
                label12.Text = item.Title;

                var label16 = new Label();

                label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label16.AutoSize = true;
                label16.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label16.ForeColor = System.Drawing.Color.Black;
                label16.Location = new System.Drawing.Point(622, 8);
                label16.Name = "label16";
                label16.Size = new System.Drawing.Size(116, 23);
                label16.TabIndex = 11;
                label16.Text = item.FromDate.ToString("dd/MM/yyyy");

                var label17 = new Label();

                label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label17.AutoSize = true;
                label17.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label17.ForeColor = System.Drawing.Color.Black;
                label17.Location = new System.Drawing.Point(802, 8);
                label17.Name = "label17";
                label17.Size = new System.Drawing.Size(122, 23);
                label17.TabIndex = 7;
                label17.Text = item.ToDate.ToString("dd/MM/yyyy");

                var label18 = new Label();

                label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                label18.AutoSize = true;
                label18.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label18.ForeColor = System.Drawing.Color.Black;
                label18.Location = new System.Drawing.Point(982, 8);
                label18.Name = "label18";
                label18.Size = new System.Drawing.Size(95, 23);
                label18.TabIndex = 9;
                label18.Text = item.DiscountPercent.ToString() + "%";
                label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

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
                BtnEdit.IconSize = 24;
                BtnEdit.Location = new System.Drawing.Point(1187, 6);
                BtnEdit.Margin = new System.Windows.Forms.Padding(6);
                BtnEdit.Name = "BtnEdit";
                BtnEdit.Size = new System.Drawing.Size(28, 28);
                BtnEdit.TabIndex = 12;
                BtnEdit.TextColor = System.Drawing.Color.White;
                BtnEdit.UseVisualStyleBackColor = false;


                var tableLayoutPanel3 = new TableLayoutPanel();

                tableLayoutPanel3.BackColor = System.Drawing.Color.White;
                tableLayoutPanel3.ColumnCount = 9;
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel3.Controls.Add(BtnChageStatus, 8, 0);
                tableLayoutPanel3.Controls.Add(label5, 0, 0);
                tableLayoutPanel3.Controls.Add(label10, 6, 0);
                tableLayoutPanel3.Controls.Add(label11, 1, 0);
                tableLayoutPanel3.Controls.Add(label12, 2, 0);
                tableLayoutPanel3.Controls.Add(label16, 3, 0);
                tableLayoutPanel3.Controls.Add(label17, 4, 0);
                tableLayoutPanel3.Controls.Add(label18, 5, 0);
                tableLayoutPanel3.Controls.Add(BtnEdit, 7, 0);
                tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
                tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
                tableLayoutPanel3.Name = "tableLayoutPanel3";
                tableLayoutPanel3.RowCount = 1;
                tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                tableLayoutPanel3.Size = new System.Drawing.Size(1261, 40);
                tableLayoutPanel3.TabIndex = 2;
                //
                TblProducts.Controls.Add(tableLayoutPanel3);
                BtnEdit.Click += async (o, s) =>
                {
                    await BtnEdit_Click(item.Id);
                };
                BtnChageStatus.Click += async (o, s) =>
                {
                    if(item.Status== Data.Ultilities.Enums.PromotionStatus.Active) {
                    if (MessageBox.Show("Bạn chắc chắn muốn hủy khuyến mãi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        item.Status = Data.Ultilities.Enums.PromotionStatus.InActive;
                        if (await _promotionService.Update(item))
                        {
                            MessageBox.Show("Cập nhật thành công !");
                            await LoadForm();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại !");
                        }
                    }
                    }
                    else { 
                    if (MessageBox.Show("Bạn chắc chắn muốn kích hoạt khuyến mãi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        item.Status = Data.Ultilities.Enums.PromotionStatus.Active;
                        if (await _promotionService.Update(item))
                        {
                            MessageBox.Show("Cập nhật thành công !");
                            await LoadForm();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại !");
                        }
                    }
                    }
                };
            }
        }
        private async Task BtnEdit_Click(int id)
        {
            var form = _serviceProvider.GetRequiredService<Updatepromotion>();
            form.TopLevel = false;
            form.Promotion = await _promotionService.GetById(id);
            form.FormClosed += async(o, s) =>
            {
                this.Controls[0].Show();
                await this.LoadForm();
            };
            this.Controls[0].Hide();
            this.Controls.Add(form);
            form.Show();
        }
        private async void PromotionIndex_Load(object sender, EventArgs e)
        {
            Result = await _promotionService.GetPaging(Request);
            await LoadForm();
        }
        public async Task LoadForm()
        {
            await LoadView();
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
        private async Task<GetPromotionPagingRequest> GetPagingRequest()
        {
            Request.Keyword = Txt_Search.Text;
            Request.Unhide = CheckUnHide.Checked;
            return Request;
        }
        private async Task PageIndex_Changed()
        {
            Result = await _promotionService.GetPaging(await GetPagingRequest());
            await LoadView();
            await LoadMenuPaging();
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
        private async Task Check_Click()
        {
            Request = new();
            Result = await _promotionService.GetPaging(await GetPagingRequest());
            await LoadView();
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

        private void TxtPageIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được phép nhập số !");
            }
        }
    }
}
