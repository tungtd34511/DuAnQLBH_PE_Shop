using App.Business.Models.Products;
using App.Business.Sevices.Products;
using App.Data.Ultilities.Catalog.Manufacturers;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Enums;
using App.Views.Models.Controls;
using App.Views.Views.Catalog.Categories;
using App.Views.Views.Catalog.Manufacturers;
using App.Views.Views.Catalog.Units;
using FontAwesome.Sharp;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Forms;

namespace App.Views.Views.Product
{
    public partial class CreateProduct : Form
    {
        public AddProductRequest _addProductRequest;
        private readonly IProductServices _productservices;
        private readonly IServiceProvider _serviceProvider;
        public CreateProductView _data { set; get; }
        private List<string> _images { set; get; }
        public CreateProduct(IProductServices productservices, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _productservices = productservices;
            _serviceProvider = serviceProvider;
        }
        public async Task LoadDataToView() //Load các combobox
        {
            _images = new List<string>();
            //
            CombUnits.Items.Clear();
            CboxNsx.Items.Clear();
            //
            foreach(var item in _data.Units) {
                CombUnits.Items.Add(item.Name);
            }
            foreach (var item in _data.Manufacturers)
            {
                CboxNsx.Items.Add(item.Name);
            }
            TblCategories.Controls.AddRange(_data.categories.Select(c => new CheckBox()
            {
                Name = c.Name,
                Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point),
                Text = c.Name

            }).ToArray());
            //
            CboxGender.SelectedIndex= 0;
            CombUnits.SelectedIndex = 0;
            CboxNsx.SelectedIndex = 0;
            CboxStatus.SelectedIndex = 0;
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
                    _images.AddRange(images);
                    foreach (var image in images)
                    {
                        await AddImg(image);
                    };
                    
                }
            }
        }
        /// <summary>
        /// Add Img to table Img
        /// </summary>
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
                _images.Remove(path);
                TblImgs.Controls.Remove(cardImg);
            };
        }
        /// <summary>
        /// Set Data to addproductrequest
        /// </summary>
        public async Task<bool> SetDataForCreate()
        {
            Gender[] genders = { Gender.Male, Gender.Female, Gender.UniSex };
            ProductStatus[] status = { ProductStatus.Active, ProductStatus.InActive };
            //sẽ viết vali date ở dây
            var result = await ValidationToCreate();
            if (result != true)
                return false;
            _addProductRequest = new()
            {
                Description = TxtDescripton.Text,
                Details = TxtDetails.Text,
                ManufacturerId = _data.Manufacturers[CboxNsx.SelectedIndex].Id,
                Status = status[CboxStatus.SelectedIndex],
                UnitId = _data.Units[CombUnits.SelectedIndex].Id,
                Gender = genders[CboxGender.SelectedIndex],
                OriginalPrice = Convert.ToDecimal(TxtOringinalPrice.Text),
                Price = Convert.ToDecimal(TxtOringinalPrice.Text),
                Images = _images,
                Name = TxtNameProduct.Text
            };
            var count = TblCategories.Controls.Count;
            for (int i = 0; i < count; i++)
            {
                if (((CheckBox)TblCategories.Controls[i]).Checked)
                {
                    _addProductRequest.categoryIds.Add(_data.categories[i].Id);
                }
            }
            return true;
        }
        /// <summary>
        /// Validation for form
        /// </summary>
        private string ErorTxt;
        private async Task<bool> ValidationToCreate()
        {
            ErorTxt = "";
            if (String.IsNullOrEmpty(TxtNameProduct.Text)){
                ErorTxt += "Không được bỏ trống tên sản phẩm!\n";
            }
            else
            {
                if (await _productservices.ContainsName(TxtNameProduct.Text)) {
                    ErorTxt += "Không được bỏ trống tên sản phẩm!\n";
                }
            }
            if (String.IsNullOrEmpty(TxtOringinalPrice.Text))
            {
                ErorTxt += "Không được bỏ trống giá nhập!\n";
            }
            else
            {
                if (await _productservices.ContainsName(TxtOringinalPrice.Text))
                {
                    ErorTxt += "Không được bỏ trống tên sản phẩm!\n";
                }
            }
            if (String.IsNullOrEmpty(TxtOringinalPrice.Text))
            {
                ErorTxt += "Không được bỏ trống tên sản phẩm!\n";
            }
            else
            {
                if (await _productservices.ContainsName(TxtOringinalPrice.Text))
                {
                    ErorTxt += "Không được bỏ trống tên sản phẩm!\n";
                }
            }
            if (ErorTxt != "")
            {
                return false;
            }
            return true;
        }
        // Save Product
        private async void vbButton7_Click(object sender, EventArgs e)
        {
            var txt = await Validatton();
            if (txt != "")
            {
                MessageBox.Show(txt);
            }
            else
            {

            if (await SetDataForCreate())
            {
                var result = await _productservices.Create(_addProductRequest,await Dispose());
                if (result) {
                    MessageBox.Show("Thêm mới sản phẩm thành công !","Thông báo",MessageBoxButtons.OK);
                    this.Close();
                }
                else { 
                MessageBox.Show("Thêm mới sản phẩm thất bại !", "Thông báo", MessageBoxButtons.OK);
                }
            }

            }
        }
        //Tắt Provider của Img
        private async Task<bool> Dispose() 
        {
            TblImgs.Controls.Clear();
            return true;
        } 
        private void BtnBack_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn quay lại trang sản phẩm!", "Thông Báo", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void TxtOringinalPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được phép nhập số !");
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
                    _data.Units.Add(new Data.Ultilities.Catalog.Units.UnitForCreate() { Id = form.Unit.Id, Name = form.Unit.Name });
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
                    _data.Manufacturers.Add(new ManufacturerInCreateProduct { Id = form.Manufacturer.Id, Name = form.Manufacturer.Name });
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
                    TblCategories.Controls.Add(new CheckBox() { Text = form.Category.Name,Checked=true,Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point) });
                    _data.categories.Add(new Data.Ultilities.Catalog.Categories.CategoryForCreate() { Id = form.Category.Id, Name = form.Category.Name });
                }
            };
            form.ShowDialog();
        }

        private void vbButton5_Click(object sender, EventArgs e)
        {
            TblImgs.Controls.Clear();
            _images.Clear();
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
            if(String.IsNullOrEmpty(TxtNameProduct.Text)|| String.IsNullOrEmpty(TxtOringinalPrice.Text) || String.IsNullOrEmpty(txtPrice.Text))
            {
                txt += "Không được để trống tên , giá nhập và giá bán !\n";
            }
            else if (Convert.ToDecimal(txtPrice.Text)<Convert.ToDecimal(TxtOringinalPrice.Text))
            {
                txt += "Giá bán phải lớn hơn giá nhật";
            }
            txt += _productservices.Validate(TxtNameProduct.Text);
            return txt;
        }
    }
}
