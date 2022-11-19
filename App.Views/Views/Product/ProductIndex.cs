using App.Business.Sevices.Products;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.Enums;
using App.Data.Ultilities.PagingModels;
using App.Views.Models.Controls;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Documents;
using System.Windows.Forms;

namespace App.Views.Views.Product
{
    public partial class ProductIndex : Form
    {
        private readonly IServiceProvider _serviceProvide;
        private readonly IProductServices _productServices;
        public GetPagingProductRequest Request { get; set; } = new();
        public PagedResult<ProductInPaging> Result { get; set; } = new();

        public VBButton _btnBack = new VBButton();
        public ProductIndex(IServiceProvider serviceProvide, IProductServices productServices)
        {
            InitializeComponent();
            _serviceProvide = serviceProvide;
            _productServices = productServices;
        }

        #region LoadForm
        public async Task LoadForm()
        {
            await LoadFilters();
            await LoadViewTable();
            await LoadMenuPaging();
        }
        //Load Filter
        public List<CheckBox> CheckBoxes { get; set; } = new(); // List check box trong View
        public async Task LoadFilters()
        {
            var titles = new List<string>() { "Danh Mục", "Kích Cỡ", "Màu Sắc", "Giá"/*, "Khác" */};
            var data = await _productServices.GetDataForFilter();
            var categories = data.Categories.Select(c => c.Name).ToList();
            var colors = data.Colors.Select(c => c.Name).ToList();
            var sizes = data.Sizes.Select(c => c.Id).ToList();
            var prices = new List<string>() { "Dưới 199.000 VNĐ", "199.000 VNĐ - 299.000 VNĐ", "299.000 VNĐ - 399.000 VNĐ", "399.000 VNĐ - 499.000 VNĐ", "499.000 VNĐ - 799.000 VNĐ", "799.000 VNĐ - 999.000", "Trên 999.000 VNĐ" };
            List<List<string>> lstList = new List<List<string>>() { categories, colors, sizes, prices };
            //
            int index = 0;
            foreach (var item in titles)
            {
                //
                var flowLayoutPanel1 = new FlowLayoutPanel();
                flowLayoutPanel1.AutoSize = false;
                flowLayoutPanel1.BackColor = Color.White;
                flowLayoutPanel1.Dock = DockStyle.Top;
                flowLayoutPanel1.Margin = new Padding(0);
                flowLayoutPanel1.Name = "flowLayoutPanel1";
                flowLayoutPanel1.Padding = new Padding(5);
                flowLayoutPanel1.Size = new Size(287, 20);
                //
                var vbButton10 = new VBButton();
                vbButton10.BackColor = Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
                vbButton10.BackgroundColor = Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
                vbButton10.BorderColor = Color.PaleVioletRed;
                vbButton10.BorderRadius = 5;
                vbButton10.BorderSize = 0;
                vbButton10.Dock = DockStyle.Fill;
                vbButton10.FlatAppearance.BorderSize = 0;
                vbButton10.FlatStyle = FlatStyle.Flat;
                vbButton10.ForeColor = Color.White;
                vbButton10.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                vbButton10.IconChar = FontAwesome.Sharp.IconChar.None;
                vbButton10.IconColor = Color.Black;
                vbButton10.IconFont = FontAwesome.Sharp.IconFont.Auto;
                vbButton10.Margin = new Padding(0);
                vbButton10.Name = "vbButton10";
                vbButton10.Size = new Size(260, 48);
                vbButton10.Text = item;
                vbButton10.TextColor = Color.White;
                vbButton10.UseVisualStyleBackColor = false;
                //
                var tableLayoutPanel6 = new TableLayoutPanel();
                tableLayoutPanel6.AutoSize = false;
                tableLayoutPanel6.BackColor = SystemColors.Control;
                tableLayoutPanel6.ColumnCount = 1;
                tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tableLayoutPanel6.Location = new Point(3, 3);
                tableLayoutPanel6.Name = "tableLayoutPanel6";
                tableLayoutPanel6.Padding = new Padding(3);
                tableLayoutPanel6.RowCount = 2;
                tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
                tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutPanel6.Size = new Size(287, 20);
                //

                foreach (var ctl in lstList[index])
                {
                    var check = new CheckBox()
                    {
                        AutoSize = true,
                        Dock = DockStyle.Top,
                        Name = "checkBox1",
                        Size = new Size(101, 24),
                        Text = ctl,
                        UseVisualStyleBackColor = true
                    };
                    check.Click += async (o, s) =>
                    {
                        await Check_Click();
                    };
                    flowLayoutPanel1.Controls.Add(check);
                    CheckBoxes.Add(check);
                };
                var heigh = (lstList[index].Count * 30) + 10;
                flowLayoutPanel1.Height = heigh;
                //
                tableLayoutPanel6.Controls.Add(vbButton10, 0, 0);
                tableLayoutPanel6.Controls.Add(flowLayoutPanel1, 0, 1);
                tableLayoutPanel6.Height = heigh + 54;
                //
                PanlFilter.Controls.Add(tableLayoutPanel6);
                index++;
            }
        }
        // Load data to viewtable
        public async Task LoadViewTable()
        {
            TblProducts.Controls.Clear();
            int index = 0;
            foreach (var item in Result.Items)
            {
                var id = item.Id.ToString();
                var id1 = item.Id;
                // vbButton3 chane status
                // 
                var vbButton3 = new VBButton();
                vbButton3.BackColor = Color.MediumSlateBlue;
                vbButton3.BackgroundColor = Color.MediumSlateBlue;
                vbButton3.BorderColor = Color.PaleVioletRed;
                vbButton3.BorderRadius = 5;
                vbButton3.BorderSize = 0;
                vbButton3.FlatAppearance.BorderSize = 0;
                vbButton3.FlatStyle = FlatStyle.Flat;
                vbButton3.ForeColor = Color.White;
                if (item.Status == ProductStatus.Active)
                {
                    vbButton3.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                }
                else
                {
                    vbButton3.IconChar = FontAwesome.Sharp.IconChar.Eye;
                }
                vbButton3.IconColor = Color.Black;
                vbButton3.IconFont = FontAwesome.Sharp.IconFont.Solid;
                vbButton3.IconSize = 27;
                vbButton3.Name = "vbButton_" + id;
                vbButton3.Padding = new Padding(0, 3, 0, 0);
                vbButton3.Size = new Size(34, 34);
                vbButton3.TextColor = Color.White;
                vbButton3.UseVisualStyleBackColor = false;
                vbButton3.Click += async (o, s) =>
                {
                    await BtnHide_Click(id1,item.Status);
                };
                //
                var vbButton2 = new VBButton();
                vbButton2.BackColor = Color.MediumSlateBlue;
                vbButton2.BackgroundColor = Color.MediumSlateBlue;
                vbButton2.BorderColor = Color.PaleVioletRed;
                vbButton2.BorderRadius = 5;
                vbButton2.BorderSize = 0;
                vbButton2.FlatAppearance.BorderSize = 0;
                vbButton2.FlatStyle = FlatStyle.Flat;
                vbButton2.ForeColor = Color.White;
                vbButton2.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
                vbButton2.IconColor = Color.Black;
                vbButton2.IconFont = FontAwesome.Sharp.IconFont.Solid;
                vbButton2.IconSize = 27;
                vbButton2.Name = "vbButton2_" + id;
                vbButton2.Padding = new Padding(0, 3, 0, 0);
                vbButton2.Size = new Size(34, 34);
                vbButton2.TextColor = Color.White;
                vbButton2.UseVisualStyleBackColor = false;
                vbButton2.Click += async (o, s) =>
                {
                    await BtnEdit_Click(id1);
                };
                //
                var label4 = new Label
                {
                    Anchor = AnchorStyles.None,
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point),
                    ForeColor = Color.Black,
                    Name = "label4",
                    Text = (index + 1).ToString()
                };

                var label5 = new Label
                {
                    Anchor = AnchorStyles.Left,
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point),
                    ForeColor = Color.Black,
                    Name = "label5",
                    Text = item.Id.ToString()
                };
                //
                var label8 = new Label();
                label8.Anchor = AnchorStyles.None;
                label8.AutoSize = true;
                label8.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
                label8.ForeColor = Color.Black;
                label8.Name = "label8";
                label8.Size = new Size(239, 20);
                label8.Text = item.Name;
                //
                var label10 = new Label();
                label10.Anchor = AnchorStyles.Left;
                label10.AutoSize = true;
                label10.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
                label10.ForeColor = Color.Black;
                label10.Name = "label10";
                label10.Size = new Size(111, 20);
                label10.Text = item.Price.ToString();
                //
                var label11 = new Label();
                label11.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                label11.AutoSize = true;
                label11.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
                label11.ForeColor = Color.Black;
                label11.Name = "label11";
                label11.Size = new Size(132, 20);
                label11.Text = item.Status.ToString();
                //
                var label12 = new Label();
                label12.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                label12.AutoSize = true;
                label12.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
                label12.ForeColor = Color.Black;
                label12.Name = "label12";
                label12.Size = new Size(334, 20);
                label12.Text = item.Description;
                label12.TextAlign = ContentAlignment.MiddleCenter;
                //
                var vbButton1 = new VBButton();
                vbButton1.BackColor = Color.MediumSlateBlue;
                vbButton1.BackgroundColor = Color.MediumSlateBlue;
                vbButton1.BorderColor = Color.PaleVioletRed;
                vbButton1.BorderRadius = 5;
                vbButton1.BorderSize = 0;
                vbButton1.FlatAppearance.BorderSize = 0;
                vbButton1.FlatStyle = FlatStyle.Flat;
                vbButton1.ForeColor = Color.White;
                vbButton1.IconChar = FontAwesome.Sharp.IconChar.Info;
                vbButton1.IconColor = Color.Black;
                vbButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
                vbButton1.IconSize = 27;
                vbButton1.Name = "vbButton1_" + id;
                vbButton1.Padding = new Padding(0, 3, 0, 0);
                vbButton1.Size = new Size(34, 34);
                vbButton1.TextColor = Color.White;
                vbButton1.UseVisualStyleBackColor = false;
                vbButton1.Click += async (o, s) =>
                {
                    await BtnDetail_Click(id1);
                };
                //
                var tableLayoutPanel4 = new TableLayoutPanel();
                tableLayoutPanel4.BackColor = Color.White;
                tableLayoutPanel4.ColumnCount = 9;
                tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
                tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 71F));
                tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 399F));
                tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 137F));
                tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 138F));
                tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
                tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
                tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
                tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
                tableLayoutPanel4.Controls.Add(vbButton3, 8, 0);
                tableLayoutPanel4.Controls.Add(vbButton2, 7, 0);
                tableLayoutPanel4.Controls.Add(label4, 0, 0);
                tableLayoutPanel4.Controls.Add(label5, 1, 0);
                tableLayoutPanel4.Controls.Add(label8, 2, 0);
                tableLayoutPanel4.Controls.Add(label10, 3, 0);
                tableLayoutPanel4.Controls.Add(label11, 4, 0);
                tableLayoutPanel4.Controls.Add(label12, 5, 0);
                tableLayoutPanel4.Controls.Add(vbButton1, 6, 0);
                tableLayoutPanel4.Margin = new Padding(0);
                tableLayoutPanel4.Name = "tableLayoutPanel4";
                tableLayoutPanel4.RowCount = 1;
                tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
                tableLayoutPanel4.Size = new Size(1261, 40);
                //
                TblProducts.Controls.Add(tableLayoutPanel4);
                //
                index++;
            }
            lblResult.Text = Result.TotalRecords.ToString() + " Kết quả";
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
        #endregion
        #region Details Event cho button Detail;
        private async Task BtnDetail_Click(int Id)
        {
            var frmDetail = _serviceProvide.GetRequiredService<ProductDetails>();
            frmDetail.TopLevel = false;
            frmDetail.Product = await _productServices.GetById(Id);
            await frmDetail.LoadDetail();
            this.Controls.Add(frmDetail);
            frmDetail.FormClosed += (o, s) =>
            {
                this.Controls[0].Visible = true;
            };
            this.Controls[0].Visible = false;
            frmDetail.Show();
        }
        private async Task BtnEdit_Click(int Id)
        {
            var frmDetail = _serviceProvide.GetRequiredService<UpdateProduct>();
            frmDetail.TopLevel = false;
            frmDetail.Product = await _productServices.GetById(Id);
            this.Controls.Add(frmDetail);
            frmDetail.FormClosed += async (o, s) =>
            {
                Result = await _productServices.GetAllPaging(Request);
                await LoadViewTable();
                await LoadMenuPaging();
                this.Controls[0].Visible = true;
            };
            this.Controls[0].Visible = false;
            frmDetail.Show();
        }
        private async Task BtnHide_Click(int Id,ProductStatus status)
        {
            if (status == ProductStatus.Active)
            {
                if (MessageBox.Show("Bạn có muốn ẩn sản phẩm ?", "PE-SHOP", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var result = await _productServices.ChangeStatus(new ChangeStatusProductRequest() { Id = Id, Status = ProductStatus.InActive });
                    if (result)
                    {
                        MessageBox.Show("Ẩn sản phẩm thành công !");
                        Result = await _productServices.GetAllPaging(Request);
                        await LoadViewTable();
                        await LoadMenuPaging();
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn hiện sản phẩm ?", "PE-SHOP", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var result = await _productServices.ChangeStatus(new ChangeStatusProductRequest() { Id = Id, Status = ProductStatus.Active });
                    if (result)
                    {
                        MessageBox.Show("Hiện sản phẩm thành công !");
                        Result = await _productServices.GetAllPaging(Request);
                        await LoadViewTable();
                        await LoadViewTable();
                    }
                }
            }
        }
        private async Task Check_Click()
        {
            Request = new();
            Result = await _productServices.GetAllPaging(await GetPagingRequest());
            await LoadViewTable();
            await LoadMenuPaging();
        }
        #endregion

        private async Task<GetPagingProductRequest> GetPagingRequest()
        {
            Request.Checks = CheckBoxes.Select(c => c.Checked).ToArray();
            Request.Keyword = Txt_Search.Text;
            Request.UnHide = CheckUnHide.Checked;
            Request.OderBy = Comb_OderBy.SelectedIndex;
            return Request;
        }
        //Create
        private async void BtnCreate_Click(object sender, EventArgs e)
        {
            var frmDetail = _serviceProvide.GetRequiredService<CreateProduct>();
            frmDetail.TopLevel = false;
            frmDetail._data = await _productServices.GetDataForCreate();
            await frmDetail.LoadDataToView();
            this.Controls.Add(frmDetail);
            frmDetail.FormClosed += async (o, s) =>
            {
                Result = await _productServices.GetAllPaging(Request);
                await LoadViewTable();
                await LoadMenuPaging();
                this.Controls[0].Visible = true;
            };
            this.Controls[0].Visible = false;
            frmDetail.Show();
        }
        private async void ProductIndex_Load(object sender, EventArgs e)
        {
            Result = await _productServices.GetAllPaging(Request);

            await LoadForm();
        }
        #region Paging
        private async void CheckUnHide_CheckedChanged(object sender, EventArgs e)
        {
            await Check_Click();
        }
        private async void Btn_Search_Click(object sender, EventArgs e)
        {
            await Check_Click();
        }
        private async void Comb_OderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Check_Click();
        }
        private async Task PageIndex_Changed()
        {
            Result = await _productServices.GetAllPaging(await GetPagingRequest());
            await LoadViewTable();
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
                if (index > 0 && index < Result.PageSize)
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
            if (Result.PageIndex < Result.PageSize)
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
            if (Result.PageIndex < Result.PageSize)
            {
                await PageIndex_Changed();
            }
            else
            {
                MessageBox.Show("Đã là trang cuối!");
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
        #endregion

    }
}
