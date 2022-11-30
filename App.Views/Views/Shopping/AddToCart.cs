using App.Data.Ultilities.Catalog.Carts;
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

namespace App.Views.Views.Shopping
{
    public partial class AddToCart : Form
    {
        public List<ProductVariationVm> Pvs { get; set; } = new();
        public AddToCartRequest Request { get; set; } = new();
        public ProductInShoppingVm product { get; set; }
        public AddToCart()
        {
            InitializeComponent();
        }

        public async Task LoadDetail(ShoppingIndex.AddToCarts addToCart)
        {
            LblName.Text = Pvs.First().ProductName;
            foreach(var item in Pvs)
            {
                var label3 = new Label();

                label3.Anchor = System.Windows.Forms.AnchorStyles.None;
                label3.AutoSize = true;
                label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label3.ForeColor = System.Drawing.Color.Black;
                label3.Location = new System.Drawing.Point(456, 10);
                label3.Name = "label3";
                label3.Size = new System.Drawing.Size(36, 20);
                label3.TabIndex = 5;
                label3.Text = item.SizeId;

                var label5 = new Label();

                label5.Anchor = System.Windows.Forms.AnchorStyles.None;
                label5.AutoSize = true;
                label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label5.ForeColor = System.Drawing.Color.Black;
                label5.Location = new System.Drawing.Point(207, 10);
                label5.Name = "label5";
                label5.Size = new System.Drawing.Size(45, 20);
                label5.TabIndex = 3;
                label5.Text = item.ColorName;

                var label6 = new Label();

                label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label6.AutoSize = true;
                label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label6.ForeColor = System.Drawing.Color.Black;
                label6.Location = new System.Drawing.Point(3, 10);
                label6.Name = "label6";
                label6.Size = new System.Drawing.Size(17, 20);
                label6.TabIndex = 2;
                label6.Text = item.Id.ToString();

                var numericUpDown1 = new NumericUpDown();

                numericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
                numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                numericUpDown1.Location = new System.Drawing.Point(556, 7);
                numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
                numericUpDown1.Name = "numericUpDown1";
                numericUpDown1.Size = new System.Drawing.Size(150, 30);
                numericUpDown1.TabIndex = 6;

                var BtnAdd = new VBButton();

                BtnAdd.BackColor = System.Drawing.Color.White;
                BtnAdd.BackgroundColor = System.Drawing.Color.White;
                BtnAdd.BorderColor = System.Drawing.Color.PaleVioletRed;
                BtnAdd.BorderRadius = 0;
                BtnAdd.BorderSize = 0;
                BtnAdd.FlatAppearance.BorderSize = 0;
                BtnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                BtnAdd.ForeColor = System.Drawing.Color.White;
                BtnAdd.IconChar = FontAwesome.Sharp.IconChar.CartArrowDown;
                BtnAdd.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(219)))));
                BtnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
                BtnAdd.IconSize = 35;
                BtnAdd.Location = new System.Drawing.Point(725, 3);
                BtnAdd.Name = "BtnAdd";
                BtnAdd.Size = new System.Drawing.Size(41, 34);
                BtnAdd.TabIndex = 7;
                BtnAdd.TextColor = System.Drawing.Color.White;
                BtnAdd.UseVisualStyleBackColor = false;
                //
                var tableLayoutPanel2 = new TableLayoutPanel();
                //
                tableLayoutPanel2.BackColor = System.Drawing.Color.White;
                tableLayoutPanel2.ColumnCount = 5;
                tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
                tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 358F));
                tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
                tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
                tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
                tableLayoutPanel2.Controls.Add(label3, 0, 0);
                tableLayoutPanel2.Controls.Add(label5, 0, 0);
                tableLayoutPanel2.Controls.Add(label6, 0, 0);
                tableLayoutPanel2.Controls.Add(numericUpDown1, 3, 0);
                tableLayoutPanel2.Controls.Add(BtnAdd, 4, 0);
                tableLayoutPanel2.ForeColor = System.Drawing.Color.White;
                tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
                tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
                tableLayoutPanel2.Name = "tableLayoutPanel2";
                tableLayoutPanel2.RowCount = 1;
                tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tableLayoutPanel2.Size = new System.Drawing.Size(769, 40);
                tableLayoutPanel2.TabIndex = 5;
                //
                TblPVs.Controls.Add(tableLayoutPanel2);
                //
                BtnAdd.Click += (o, s) =>
                {
                    if (numericUpDown1.Value > 0) { 
                    Request.ColorName = item.ColorName;
                    Request.ColorId = item.ColorId;
                    Request.PvId = item.Id;
                    Request.Quantity = Convert.ToInt32(numericUpDown1.Value);
                    Request.productId = item.ProductId;
                    Request.SizeId = item.SizeId;
                    Request.SizeName = item.SizeName;
                    Request.productName = item.ProductName;
                        Request.DiscountPercent = product.DiscountPercent;
                    addToCart(Request);//Call Delegate
                    }
                    else { MessageBox.Show("Số lượng phải lớn hơn 0!"); }
                };
            }
        }


        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
