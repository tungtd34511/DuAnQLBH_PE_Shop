using App.Business.Sevices.Products;
using App.Data.Ultilities.ViewModels;
using App.Views.Models.Controls;
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
    public partial class ProductDetails : Form
    {
        private readonly IProductServices _services;
        public ProductVm Product { get; set; }
        private int _indexImg = 0;
        public ProductDetails(IProductServices services)
        {
            InitializeComponent();
            _services = services;
        }
        public async Task LoadDetail()
        {
            if(Product.Images!=null &&Product.Images.Count>0) {
                panlIMG.BackgroundImage = Image.FromFile(Product.Images[0]);
            }
            LblName.Text = Product.Name+"(Id:"+Product.Id.ToString()+")";
            LblCreated.Text = Product.DateCreated.ToString();
            LblGender.Text = Product.Gender.ToString();
            LblNsx.Text = Product.ManufacturerName;
            LblOriginPrice.Text = Product.OriginalPrice.ToString();
            LblPrice.Text = Product.Price.ToString();
            LblUnit.Text = Product.UnitName;
            //var text = "";
            
            //TxtCategories.Text = 
            TxtDescription.Text = Product.Description;
            TxtDetail.Text = Product.Details;
            Btn_Status.Text = Product.Status.ToString();
            //
            await LoadMiniImgs();
        }
        public async Task LoadPV()
        {
            TblPV.Controls.Clear();
            var list = await _services.GetPvbyId(Product.Id);
            foreach(var item in list)
            {

                // 
                // label14
                // 
                var label14 = new Label();
                label14.Anchor = System.Windows.Forms.AnchorStyles.None;
                label14.AutoSize = true;
                label14.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label14.ForeColor = System.Drawing.Color.Black;
                label14.Name = "label14";
                label14.Size = new System.Drawing.Size(40, 23);
                label14.Text = "Size";

                var label16 = new Label();

                label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
                label16.AutoSize = true;
                label16.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label16.ForeColor = System.Drawing.Color.Black;
                label16.Margin = new System.Windows.Forms.Padding(3, 0, 7, 0);
                label16.Name = "label16";
                label16.Size = new System.Drawing.Size(37, 23);
                label16.Text = "123";

                var label17 = new Label();

                label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                label17.AutoSize = true;
                label17.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label17.ForeColor = System.Drawing.Color.Black;
                label17.Name = "label17";
                label17.Size = new System.Drawing.Size(45, 23);
                label17.Text = "1";

                var label18 = new Label();

                label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label18.AutoSize = true;
                label18.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label18.ForeColor = System.Drawing.Color.Black;
                label18.Name = "label18";
                label18.Size = new System.Drawing.Size(51, 23);
                label18.Text = "Color";


                var PVitem = new TableLayoutPanel();

                PVitem.BackColor = System.Drawing.Color.White;
                PVitem.ColumnCount = 4;
                PVitem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
                PVitem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 198F));
                PVitem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
                PVitem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
                PVitem.Controls.Add(label14, 0, 0);
                PVitem.Controls.Add(label16, 0, 0);
                PVitem.Controls.Add(label17, 0, 0);
                PVitem.Controls.Add(label18, 0, 0);
                PVitem.ForeColor = System.Drawing.Color.Black;
                PVitem.Margin = new System.Windows.Forms.Padding(0);
                PVitem.Name = "PVitem";
                PVitem.RowCount = 1;
                PVitem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                PVitem.Size = new System.Drawing.Size(410, 38);
                //
                TblPV.Controls.Add(PVitem);
            }
        }
        public async Task LoadMiniImgs()
        {
            if(Product.Images!=null &&Product.Images.Count>0)
            {
                TblminiImgs.Controls.AddRange(Product.Images.Select(c => new VBButton()
                {

                    BackColor = System.Drawing.Color.White,
                    BackgroundColor = System.Drawing.Color.White,
                    BackgroundImage = Image.FromFile(c),
                    BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom,
                    BorderRadius = 5,
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    ForeColor = System.Drawing.Color.White,
                    IconChar = FontAwesome.Sharp.IconChar.None,
                    IconColor = System.Drawing.Color.Black,
                    IconFont = FontAwesome.Sharp.IconFont.Auto,
                    Location = new System.Drawing.Point(3, 3),
                    Name = "PnlMiniImg_",
                    Size = new System.Drawing.Size(94, 94),
                    UseVisualStyleBackColor = false
                }).ToArray());
                var j = TblminiImgs.Controls.Count;
                for (int i = 0; i < j; i++)
                {
                    var t = i;
                    TblminiImgs.Controls[i].Click += async (o, s) =>
                    {
                        await LoadPanlIMG(t);
                    };
                }
            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async Task<bool> CheckIndex(int Index)
        {
            if (Product.Images.Count < 2)
            {
                return false;
            }
            if(Index<Product.Images.Count && Index>=0) {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task LoadPanlIMG(int Index)
        {
            if(await CheckIndex(Index))
            {
                panlIMG.BackgroundImage = Image.FromFile(Product.Images[Index]);
                _indexImg = Index;
            }
        }

        private async void btn_Prev_Click(object sender, EventArgs e)
        {
            await LoadPanlIMG(_indexImg - 1);
        }

        private async void btn_Next_Click(object sender, EventArgs e)
        {
            await LoadPanlIMG(_indexImg + 1);
        }
    }
}
