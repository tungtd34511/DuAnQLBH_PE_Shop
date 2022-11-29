using App.Business.Sevices.Users;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Catalog.Users;
using App.Data.Ultilities.Common;
using App.Views.Models.Controls;
using App.Views.Views.Users;
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

namespace App.Views.Views.User
{
    public partial class UserIndex : Form
    {
        private readonly IUserService _userService;
        private readonly IServiceProvider _serviceProvider;
        public PagedResult<Data.Entities.User> Result { get; set; }
        public GetUserPagingRequest Request { get; set; } = new();
        public UserIndex(IUserService userService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _userService = userService;
            _serviceProvider = serviceProvider;
        }

        private async void UserIndex_Load(object sender, EventArgs e)
        {
            //await _userService.CreateAdmin();
            //
            Result = await _userService.GetUserPaging(Request);
            await LoadView();
            await LoadMenuPaging();
        }
        private async Task LoadView()
        {
            TblView.Controls.Clear();
            var index = 0;
            foreach(var item in Result.Items)
            {
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
                BtnChangeStatus.IconColor = System.Drawing.Color.Black;
                BtnChangeStatus.IconFont = FontAwesome.Sharp.IconFont.Solid;
                BtnChangeStatus.IconSize = 20;
                BtnChangeStatus.Location = new System.Drawing.Point(1226, 5);
                BtnChangeStatus.Margin = new System.Windows.Forms.Padding(5);
                BtnChangeStatus.Name = "BtnChangeStatus";
                BtnChangeStatus.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
                BtnChangeStatus.Size = new System.Drawing.Size(30, 30);
                BtnChangeStatus.TabIndex = 13;
                BtnChangeStatus.TextColor = System.Drawing.Color.White;
                BtnChangeStatus.UseVisualStyleBackColor = false;

                var label5 = new Label();

                label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label5.AutoSize = true;
                label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label5.ForeColor = System.Drawing.Color.Black;
                label5.Location = new System.Drawing.Point(3, 8);
                label5.Name = "label5";
                label5.Size = new System.Drawing.Size(47, 23);
                label5.TabIndex = 0;
                label5.Text = (++index).ToString();

                var label8 = new Label();

                label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label8.AutoSize = true;
                label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label8.ForeColor = System.Drawing.Color.Black;
                label8.Location = new System.Drawing.Point(59, 8);
                label8.Name = "label8";
                label8.Size = new System.Drawing.Size(27, 23);
                label8.TabIndex = 4;
                label8.Text = item.Id.ToString();

                var label10 = new Label();

                label10.Anchor = System.Windows.Forms.AnchorStyles.None;
                label10.AutoSize = true;
                label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label10.ForeColor = System.Drawing.Color.Black;
                label10.Location = new System.Drawing.Point(242, 8);
                label10.Name = "label10";
                label10.Size = new System.Drawing.Size(41, 23);
                label10.TabIndex = 5;
                label10.Text = item.UserDetail.Name;

                var label11 = new Label();

                label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label11.AutoSize = true;
                label11.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label11.ForeColor = System.Drawing.Color.Black;
                label11.Location = new System.Drawing.Point(417, 8);
                label11.Name = "label11";
                label11.Size = new System.Drawing.Size(72, 23);
                label11.TabIndex = 7;
                label11.Text = item.Role.ToString();

                var label16 = new Label();

                label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label16.AutoSize = true;
                label16.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label16.ForeColor = System.Drawing.Color.Black;
                label16.Location = new System.Drawing.Point(570, 8);
                label16.Name = "label16";
                label16.Size = new System.Drawing.Size(111, 23);
                label16.TabIndex = 8;
                label16.Text = item.UserDetail.PhoneNumber;

                var label17 = new Label();

                label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label17.AutoSize = true;
                label17.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label17.ForeColor = System.Drawing.Color.Black;
                label17.Location = new System.Drawing.Point(752, 8);
                label17.Name = "label17";
                label17.Size = new System.Drawing.Size(51, 23);
                label17.TabIndex = 9;
                label17.Text = item.UserDetail.Email;
                label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                var label18 = new Label();

                label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label18.AutoSize = true;
                label18.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label18.ForeColor = System.Drawing.Color.Black;
                label18.Location = new System.Drawing.Point(1051, 8);
                label18.Name = "label18";
                label18.Size = new System.Drawing.Size(87, 23);
                label18.TabIndex = 11;
                label18.Text = item.Status.ToString();
                
                var BtnInfo = new VBButton();
                
                BtnInfo.BackColor = System.Drawing.Color.MediumSlateBlue;
                BtnInfo.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                BtnInfo.BorderColor = System.Drawing.Color.PaleVioletRed;
                BtnInfo.BorderRadius = 5;
                BtnInfo.BorderSize = 0;
                BtnInfo.FlatAppearance.BorderSize = 0;
                BtnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                BtnInfo.ForeColor = System.Drawing.Color.White;
                BtnInfo.IconChar = FontAwesome.Sharp.IconChar.Info;
                BtnInfo.IconColor = System.Drawing.Color.Black;
                BtnInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
                BtnInfo.IconSize = 20;
                BtnInfo.Location = new System.Drawing.Point(1186, 5);
                BtnInfo.Margin = new System.Windows.Forms.Padding(5);
                BtnInfo.Name = "BtnInfo";
                BtnInfo.Size = new System.Drawing.Size(30, 30);
                BtnInfo.TabIndex = 12;
                BtnInfo.TextColor = System.Drawing.Color.White;
                BtnInfo.UseVisualStyleBackColor = false;
                //
                // 
                // tableLayoutPanel3
                // 
                var tableLayoutPanel3 = new TableLayoutPanel();
                tableLayoutPanel3.BackColor = System.Drawing.Color.White;
                tableLayoutPanel3.ColumnCount = 9;
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 331F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel3.Controls.Add(BtnChangeStatus, 8, 0);
                tableLayoutPanel3.Controls.Add(label5, 0, 0);
                tableLayoutPanel3.Controls.Add(label8, 1, 0);
                tableLayoutPanel3.Controls.Add(label10, 2, 0);
                tableLayoutPanel3.Controls.Add(label11, 3, 0);
                tableLayoutPanel3.Controls.Add(label16, 4, 0);
                tableLayoutPanel3.Controls.Add(label17, 5, 0);
                tableLayoutPanel3.Controls.Add(label18, 6, 0);
                tableLayoutPanel3.Controls.Add(BtnInfo, 7, 0);
                tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
                tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
                tableLayoutPanel3.Name = "tableLayoutPanel3";
                tableLayoutPanel3.RowCount = 1;
                tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                tableLayoutPanel3.Size = new System.Drawing.Size(1261, 40);
                tableLayoutPanel3.TabIndex = 2;
                //
                TblView.Controls.Add(tableLayoutPanel3);
                //
                BtnInfo.Click += async (o, s) =>
                {
                    await BtnInfo_click(item.Id);
                };
                BtnChangeStatus.Click += async (o, s) =>
                {
                    await BtnChaneStatus_click(item.Id);
                };
            }
        }
        private async Task BtnInfo_click(Guid  id)
        {
            var form = _serviceProvider.GetRequiredService<UserDetails>();
            form.User = await _userService.GetById(id);
            form.TopLevel = false;
            await form.IsNotHome();
            form.FormClosed +=  (o, s) =>
            {
                this.Controls[0].Show();
            };
            this.Controls[0].Hide();
            this.Controls.Add(form);
            form.Show();
        }
        private async Task BtnChaneStatus_click(Guid id)
        {
            if(MessageBox.Show("Bạn chắc chắn muốn khóa nhân viên này ?","Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var user = await _userService.GetById(id);
                user.Status = Data.Ultilities.Enums.UserStatus.InActive;
                if(await _userService.ChaneStatus(user))
                {
                    MessageBox.Show("Cập nhật thành công !");
                    Result = await _userService.GetUserPaging(Request);
                    await LoadView();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại !");
                }
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
        // Phân Trang
        private async Task<GetUserPagingRequest> GetPagingRequest()
        {
            Request.Keyword = Txt_Search.Text;
            Request.UnHide = CheckUnHide.Checked;
            return Request;
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
        private async Task PageIndex_Changed()
        {
            Result = await _userService.GetUserPaging(await GetPagingRequest());
            await LoadView();
            await LoadMenuPaging();
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
            Result = await _userService.GetUserPaging(await GetPagingRequest());
            await LoadView();
            await LoadMenuPaging();
        }

        private async void Btn_Search_Click(object sender, EventArgs e)
        {
            await Check_Click();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<AddUser>();
            form.FormClosed += async (o, s) =>
            {
                Result = await _userService.GetUserPaging(Request);
                await LoadView();
            };
            form.ShowDialog();
        }
    }
}
