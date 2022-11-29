using App.Business.Sevices.Promotions;
using App.Data.Ultilities.Catalog.Categories;
using App.Data.Ultilities.Catalog.Products;
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
    public partial class CreatePromotion : Form
    {
        private readonly IPromotionService _promotionService;
        public List<CategoryForCreate> CategoryForCreates { get; set; }
        public List<DetailForCretatePromotion> Products { get; set; }
        public List<string> categoryIds { get; set; } = new();
        public List<string> productIds { get; set; } = new();
        public Data.Entities.Promotion Promotion { get; set; } = new();
        public CreatePromotion(IPromotionService promotionService)
        {
            InitializeComponent();
            _promotionService = promotionService;
        }
        #region Load view create
        private async Task AddCategories()
        {
            foreach(var category in CategoryForCreates)
            {
                var checkcate = new CheckBox()
                {
                    Name = "cate"+category.Id.ToString(),
                    Text = category.Name,
                    Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point),
                    AutoSize = true,
                };
                TblCategories.Controls.Add(checkcate);
                checkcate.CheckedChanged += (o, s) =>
                {
                    if (checkcate.Checked)
                    {
                        categoryIds.Add(category.Id.ToString());
                    }
                    else
                    {
                        categoryIds.Remove(category.Id.ToString());
                    }
                };
            }
        }
        private async Task AddProducts()
        {
            foreach (var item in Products)
            {
                var checkproduct = new CheckBox()
                {
                    Name = "product" + item.Id.ToString(),
                    Text = $"(id:{item.Id}) " +item.Name,
                    Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point),
                    AutoSize = true,
                };
                TblProduct.Controls.Add(checkproduct);
                checkproduct.CheckedChanged += (o, s) =>
                {
                    if (checkproduct.Checked)
                    {
                        productIds.Add(item.Id.ToString());
                    }
                    else
                    {
                        productIds.Remove(item.Id.ToString());
                    }
                };
            }
        }
        #endregion
        private async void CreatePromotion_Load(object sender, EventArgs e)
        {
            CategoryForCreates = await _promotionService.GetCategories();
            Products= await _promotionService.GetProducts();
            await AddCategories();
            await AddProducts();
        }
        private async Task<string> GetIds(List<string> lstId)
        {
            string ids = "";
            if (categoryIds.Count > 0)
            {
                foreach(var id in lstId)
                {
                    ids +=id+" ";
                }
                return ids;
            }
            return ids;
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var txt = await Validation();
            if (txt != "")
            {
                MessageBox.Show(txt);
            }
            else
            {
                Promotion.Status = Data.Ultilities.Enums.PromotionStatus.Active;
                Promotion.DiscountPercent = Convert.ToInt32(numSalePercent.Value);
                Promotion.Name = TxtName.Text;
                Promotion.Title = TxtTitle.Text;
                Promotion.ApplyForAll = cboxSelectAll.Checked;
                Promotion.DiscountAmount = 0;
                Promotion.FromDate = dateStarted.Value;
                Promotion.ToDate = dateEnded.Value;
                Promotion.ProductIds = await GetIds(productIds);
                Promotion.ProductCategoryIds = await GetIds(categoryIds);
                if (await _promotionService.Create(Promotion))
                {
                    MessageBox.Show("Thêm mới khuyến mãi thành công !");
                    Close();
                }
                else
                {
                    MessageBox.Show("Thêm mới khuyến mãi thất bại !");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                foreach(Control check in TblProduct.Controls)
                {
                    check.Visible = true;
                }
            }
            else
            {
                var text = txtSearch.Text.ToLower();
                foreach (Control check in TblProduct.Controls)
                {
                    check.Visible = check.Name.ToLower().Contains(text);
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async Task<string> Validation()
        {
            var txt = "";
            if (string.IsNullOrEmpty(TxtName.Text) || TxtName.Text.Length > 50)
            {
                txt += "Tên khuyến mãi phải từ 1 đến 50 kí tự!\n";
            }
            else {
                txt += _promotionService.Validation(TxtName.Text);
            }
            if(dateStarted.Value>dateEnded.Value)
            {
                txt += "Ngày bắt đầu phải nhỏ hơn ngày kết thúc\n";
            }
            return txt;
        }
    }
}
