using App.Business.Models.Products;
using App.Business.Sevices.Products;
using App.Data.Ultilities.Catalog.Manufacturers;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Enums;
using App.Data.Ultilities.ViewModels;
using App.Views.Models.Controls;
using App.Views.Views.Catalog.Categories;
using App.Views.Views.Catalog.Manufacturers;
using App.Views.Views.Catalog.Units;
using FontAwesome.Sharp;
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

namespace App.Views.Views.Product
{
    public partial class UpdateProduct : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IProductServices _services;
        public ProductVm Product { get; set; }
        public UpdateProductRequest Request { get; set; } = new();
        public CreateProductView Data { set; get; }

        public UpdateProduct(IProductServices services, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _services = services;
            _serviceProvider = serviceProvider;
        }

        private async Task AddImg(string path)
        {
            //
            var btnDelete = new VBButton();
            btnDelete.BackColor = Color.White;
            btnDelete.BackgroundColor = Color.White;
            btnDelete.BorderColor = Color.PaleVioletRed;
            btnDelete.BorderRadius = 15;
            btnDelete.BorderSize = 0;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.IconChar = IconChar.XmarkCircle;
            btnDelete.IconColor = Color.Red;
            btnDelete.IconFont = IconFont.Solid;
            btnDelete.IconSize = 29;
            btnDelete.Location = new Point(108, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Padding = new Padding(0, 3, 0, 0);
            btnDelete.Size = new Size(31, 31);
            btnDelete.TextColor = Color.White;
            btnDelete.UseVisualStyleBackColor = false;
            //
            var panlImg = new CustomPanel();
            panlImg.BackgroundImage = Image.FromFile(path);
            panlImg.BackgroundImageLayout = ImageLayout.Zoom;
            panlImg.BorderColor = Color.White;
            panlImg.BorderFocusColor = Color.HotPink;
            panlImg.BorderRadius = 5;
            panlImg.BorderSize = 1;
            panlImg.Dock = DockStyle.Fill;
            panlImg.Location = new Point(3, 30);
            panlImg.Name = "panlImg";
            panlImg.Size = new Size(130, 130);
            panlImg.UnderlinedStyle = false;
            //
            var cardImg = new GroupBox();
            cardImg.Controls.Add(panlImg);
            cardImg.Controls.Add(btnDelete);
            cardImg.Name = "cardImg";
            cardImg.Size = new Size(136, 163);
            cardImg.TabStop = false;
            //
            TblImgs.Controls.Add(cardImg);
            // Event sẽ Viết ở dưới cùng
            btnDelete.Click += (o, s) =>
            {
                if (Request.NewImgs.Contains(path))
                {
                    Request.NewImgs.Remove(path);
                }
                if( Product.Images.Contains(path))
                {
                    Request.DeletedImgs.Add(path);
                }
                TblImgs.Controls.Remove(cardImg);
            };
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string ErorTxt;
        private async Task<bool> ValidationToCreate()
        {
            ErorTxt = "";
            if (String.IsNullOrEmpty(TxtNameProduct.Text))
            {
                ErorTxt += "Không được bỏ trống tên sản phẩm!\n";
            }
            else
            {
                if (await _services.ContainsName(TxtNameProduct.Text) && TxtNameProduct.Text!=Product.Name)
                {
                    ErorTxt += "Trùng tên sản phẩm!\n";
                }
            }
            if (String.IsNullOrEmpty(TxtOringinalPrice.Text))
            {
                ErorTxt += "Không được bỏ trống giá nhập!\n";
            }
            if (String.IsNullOrEmpty(TxtOringinalPrice.Text))
            {
                ErorTxt += "Không được bỏ trống tên sản phẩm!\n";
            }
            if (ErorTxt != "")
            {
                return false;
            }
            return true;
        }
        public async Task<bool> SetDataForUpdate()
        {
            Gender[] genders = { Gender.Male, Gender.Female, Gender.UniSex };
            ProductStatus[] status = { ProductStatus.Active, ProductStatus.InActive };
            //sẽ viết vali date ở dây
            var result = await ValidationToCreate();
            if (result != true)
                return false;
            var categoriesSelected = new List<int>();
            for (int i = 0; i < Data.categories.Count; i++)
            {
                if (((CheckBox)TblCategories.Controls[i]).Checked)
                {
                    categoriesSelected.Add(Data.categories[i].Id);
                }
            }
            Request.Id = Product.Id;
            Request.Description = TxtDescripton.Text;
            Request.Details = TxtDetails.Text;
            Request.ManufacturerId = Data.Manufacturers[CboxNsx.SelectedIndex].Id;
            Request.Status = status[CboxStatus.SelectedIndex];
            Request.UnitId = Data.Units[CombUnits.SelectedIndex].Id;
            Request.Gender = genders[CboxGender.SelectedIndex];
            Request.OriginalPrice = Convert.ToDecimal(TxtOringinalPrice.Text);
            Request.Price = Convert.ToDecimal(txtPrice.Text);
            Request.Name = TxtNameProduct.Text;
            Request.DeletedCategories = Product.Categories.Where(c => !categoriesSelected.Contains(c)).ToList();
            Request.NewCategories = categoriesSelected.Where(c => !Product.Categories.Contains(c)).ToList();
            return true;
        }
        public async Task LoadDataToView() //Load các combobox
        {
            //
            Gender[] genders = { Gender.Male, Gender.Female, Gender.UniSex };
            ProductStatus[] status = { ProductStatus.Active, ProductStatus.InActive };
            //
            CombUnits.Items.Clear();
            CboxNsx.Items.Clear();
            //
            foreach (var item in Data.Units)
            {
                CombUnits.Items.Add(item.Name);
            }
            foreach (var item in Data.Manufacturers)
            {
                CboxNsx.Items.Add(item.Name);
            }
            TblCategories.Controls.AddRange(Data.categories.Select(c => new CheckBox()
            {
                Name = c.Name,
                Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point),
                Text = c.Name,
                Checked = Product.Categories.Contains(c.Id)
            }).ToArray());
            //
            CboxGender.SelectedIndex = genders.ToList().IndexOf(Product.Gender);
            CombUnits.Text = Product.UnitName.ToString();
            CboxNsx.Text = Product.ManufacturerName.ToString();
            CboxStatus.SelectedIndex = status.ToList().IndexOf(Product.Status);
            //
            lblTitle.Text = "Sửa Sản Phẩm " + "(ID:" + Product.Id.ToString() + ")";
            TxtNameProduct.Text = Product.Name;
            txtPrice.Text = Product.Price.ToString();
            TxtOringinalPrice.Text = Product.OriginalPrice.ToString();
            TxtDescripton.Text = Product.Description.ToString();
            TxtDetails.Text = Product.Details.ToString();
            //
            foreach(var a in Product.Images)
            {
                await AddImg(a);
            }
        }
        
        private async void UpdateProduct_Load(object sender, EventArgs e)
        {
            Data = await _services.GetDataForCreate();
            await LoadDataToView();
        }
        private async void BtnAddImg_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var images = openFileDialog.FileNames;
                    Request.NewImgs.AddRange(images);
                    foreach (var image in images)
                    {
                        await AddImg(image);
                    };

                }
            }
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var txt = await Validatton();
            if (txt != "") { MessageBox.Show(txt); }
            else {
                if (await SetDataForUpdate())
                {
                    var result = await _services.Update(Request, await Dispose());
                    if (result)
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công !", "Thông báo", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật sản phẩm thất bại !", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Something worng!");
                }
            }
        }
        private async Task<bool> Dispose()
        {
            TblImgs.Controls.Clear();
            return true;
        }
        private async void btnResetImg_Click(object sender, EventArgs e)
        {
            TblImgs.Controls.Clear();
            Request.NewImgs = new();
            Request.DeletedImgs = new();
            foreach (var a in Product.Images)
            {
                await AddImg(a);
            }
        }

        private void vbButton1_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<AddUnit>();
            form.FormClosed += (o, s) =>
            {
                if (form.Unit.Id != 0)
                {
                    CombUnits.Items.Add(form.Unit.Name);
                    Data.Units.Add(new Data.Ultilities.Catalog.Units.UnitForCreate() { Id = form.Unit.Id, Name = form.Unit.Name });
                    CombUnits.SelectedIndex = CombUnits.Items.Count - 1;
                }
            };
            form.ShowDialog();
        }

        private void vbButton2_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<CreateManufacture>();
            form.FormClosed += (o, s) =>
            {
                if (form.Manufacturer.Id != 0)
                {
                    CboxNsx.Items.Add(form.Manufacturer.Name);
                    Data.Manufacturers.Add(new ManufacturerInCreateProduct { Id = form.Manufacturer.Id, Name = form.Manufacturer.Name });
                    CboxNsx.SelectedIndex = CombUnits.Items.Count - 1;
                }
            };
            form.ShowDialog();
        }

        private void vbButton3_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<CreateCategory>();
            form.FormClosed += (o, s) =>
            {
                if (form.Category.Id != 0)
                {
                    TblCategories.Controls.Add(new CheckBox() { Text = form.Category.Name, Checked = true, Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)  });
                    Data.categories.Add(new Data.Ultilities.Catalog.Categories.CategoryForCreate() { Id = form.Category.Id, Name = form.Category.Name });
                }
            };
            form.ShowDialog();
        }

        private void vbButton6_Click(object sender, EventArgs e)
        {
            foreach (var item in TblCategories.Controls)
            {
                ((CheckBox)item).Checked = false;
            }
        }
        private async Task<string> Validatton()
        {
            var txt = "";
            if (String.IsNullOrEmpty(TxtNameProduct.Text) || String.IsNullOrEmpty(TxtOringinalPrice.Text) || String.IsNullOrEmpty(txtPrice.Text))
            {
                txt += "Không được để trống tên , giá nhập và giá bán !\n";
            }
            else if (Convert.ToDecimal(txtPrice.Text) < Convert.ToDecimal(TxtOringinalPrice.Text))
            {
                txt += "Giá bán phải lớn hơn giá nhập";
            }
            if (TxtNameProduct.Text != Product.Name) { 
            txt += await _services.Validate(TxtNameProduct.Text);
            }
            return txt;
        }
    }
}
