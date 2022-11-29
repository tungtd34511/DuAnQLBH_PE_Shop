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

namespace App.Views.Views.Orders
{
    public partial class OderDetail : Form
    {
        public OrderVm Order { get; set; } = new();
        public OderDetail()
        {
            InitializeComponent();
        }

        private async void OderDetail_Load(object sender, EventArgs e)
        {
            LblName.Text = "Hóa đơn "+Order.Id.ToString();
            LblAddress.Text = Order.ShipAddress;
            LblNguoiTao.Text = Order.UserName;
            LblPhoneNumber.Text = Order.ShipPhoneNumber;
            LblTongTien.Text = Order.Total.ToString() +" vnđ";
            txtNote.Text = Order.Description;
            btnCreated.Text = Order.Created.ToString();
            Btn_Status.Text = Order.Status.ToString();
            Btn_Sale.Text = Order.IsShipping ? "Đặt hàng" : "Bán trực tiếp";
            LblCustomerName.Text = Order.ShipName;
            lblEmail.Text = Order.ShipEmail;
            await LoadProducts();
            await LoadHistories();
        }
        private async Task LoadProducts()
        {
            int i = 0;
            foreach(var item in Order.Products)
            {
                var label18 = new Label();
                label18.Anchor = System.Windows.Forms.AnchorStyles.None;
                label18.AutoSize = true;
                label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label18.ForeColor = System.Drawing.Color.Black;
                label18.Location = new System.Drawing.Point(618, 10);
                label18.Name = "label18";
                label18.Size = new System.Drawing.Size(72, 20);
                label18.TabIndex = 6;
                label18.Text = item.Quantity.ToString();

                var label19 = new Label();

                label19.Anchor = System.Windows.Forms.AnchorStyles.None;
                label19.AutoSize = true;
                label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label19.ForeColor = System.Drawing.Color.Black;
                label19.Location = new System.Drawing.Point(765, 10);
                label19.Name = "label19";
                label19.Size = new System.Drawing.Size(78, 20);
                label19.TabIndex = 5;
                label19.Text = (item.Quantity * item.Price).ToString() + " vnđ";

                var label20 = new Label();

                label20.Anchor = System.Windows.Forms.AnchorStyles.None;
                label20.AutoSize = true;
                label20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label20.ForeColor = System.Drawing.Color.Black;
                label20.Location = new System.Drawing.Point(471, 10);
                label20.Margin = new System.Windows.Forms.Padding(3, 0, 7, 0);
                label20.Name = "label20";
                label20.Size = new System.Drawing.Size(62, 20);
                label20.TabIndex = 4;
                label20.Text = item.Price + " vnđ";

                var label21 = new Label();

                label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label21.AutoSize = true;
                label21.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label21.ForeColor = System.Drawing.Color.Black;
                label21.Location = new System.Drawing.Point(3, 10);
                label21.Name = "label21";
                label21.Size = new System.Drawing.Size(36, 20);
                label21.TabIndex = 3;
                label21.Text = (i++).ToString();

                var label22 = new Label();

                label22.Anchor = System.Windows.Forms.AnchorStyles.None;
                label22.AutoSize = true;
                label22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label22.ForeColor = System.Drawing.Color.Black;
                label22.Location = new System.Drawing.Point(224, 10);
                label22.Name = "label22";
                label22.Size = new System.Drawing.Size(32, 20);
                label22.TabIndex = 2;
                label22.Text = item.Name;
                //

                var tblProduct = new TableLayoutPanel();
                tblProduct.BackColor = System.Drawing.Color.White;
                tblProduct.ColumnCount = 5;
                tblProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
                tblProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tblProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
                tblProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
                tblProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
                tblProduct.Controls.Add(label18, 0, 0);
                tblProduct.Controls.Add(label19, 0, 0);
                tblProduct.Controls.Add(label20, 0, 0);
                tblProduct.Controls.Add(label21, 0, 0);
                tblProduct.Controls.Add(label22, 0, 0);
                tblProduct.ForeColor = System.Drawing.Color.White;
                tblProduct.Location = new System.Drawing.Point(0, 0);
                tblProduct.Margin = new System.Windows.Forms.Padding(0);
                tblProduct.Name = "tblProduct";
                tblProduct.RowCount = 1;
                tblProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tblProduct.Size = new System.Drawing.Size(879, 40);
                tblProduct.TabIndex = 4;

                TblProducts.Controls.Add(tblProduct);
            }
        }

        private async Task LoadHistories()
        {
            int i = 0;
            foreach(var item in Order.Histories)
            {
                var label23 = new Label();
                
                label23.Anchor = System.Windows.Forms.AnchorStyles.None;
                label23.AutoSize = true;
                label23.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label23.ForeColor = System.Drawing.Color.Black;
                label23.Location = new System.Drawing.Point(492, 10);
                label23.Name = "label23";
                label23.Size = new System.Drawing.Size(136, 20);
                label23.TabIndex = 5;
                label23.Text = item.Status.ToString();

                var vbButton1 = new VBButton();
                
                vbButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
                vbButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
                vbButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                vbButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
                vbButton1.BorderRadius = 5;
                vbButton1.BorderSize = 0;
                vbButton1.FlatAppearance.BorderSize = 0;
                vbButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                vbButton1.ForeColor = System.Drawing.Color.White;
                vbButton1.IconChar = FontAwesome.Sharp.IconChar.Info;
                vbButton1.IconColor = System.Drawing.Color.Black;
                vbButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
                vbButton1.IconSize = 23;
                vbButton1.Location = new System.Drawing.Point(807, 3);
                vbButton1.Name = "vbButton1";
                vbButton1.Size = new System.Drawing.Size(34, 34);
                vbButton1.TabIndex = 5;
                vbButton1.TextColor = System.Drawing.Color.White;
                vbButton1.UseVisualStyleBackColor = false;
                vbButton1.Click += (o, s) =>
                {
                    MessageBox.Show(item.Details);
                };
                var label24 = new Label();
                
                label24.Anchor = System.Windows.Forms.AnchorStyles.None;
                label24.AutoSize = true;
                label24.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label24.ForeColor = System.Drawing.Color.Black;
                label24.Location = new System.Drawing.Point(235, 10);
                label24.Margin = new System.Windows.Forms.Padding(3, 0, 7, 0);
                label24.Name = "label24";
                label24.Size = new System.Drawing.Size(71, 20);
                label24.TabIndex = 4;
                label24.Text = item.Edited.ToString();
                
                var label25 = new Label();
                
                label25.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label25.AutoSize = true;
                label25.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label25.ForeColor = System.Drawing.Color.Black;
                label25.Location = new System.Drawing.Point(3, 10);
                label25.Name = "label25";
                label25.Size = new System.Drawing.Size(36, 20);
                label25.TabIndex = 3;
                label25.Text = (i++).ToString();
                
                var label26 = new Label();
                
                label26.Anchor = System.Windows.Forms.AnchorStyles.Left;
                label26.AutoSize = true;
                label26.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label26.ForeColor = System.Drawing.Color.Black;
                label26.Location = new System.Drawing.Point(54, 10);
                label26.Name = "label26";
                label26.Size = new System.Drawing.Size(78, 20);
                label26.TabIndex = 2;
                label26.Text = item.EditorName;

                // 
                // tableLayoutPanel12
                // 
                var tableLayoutPanel12 = new TableLayoutPanel();
                tableLayoutPanel12.BackColor = System.Drawing.Color.White;
                tableLayoutPanel12.ColumnCount = 5;
                tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
                tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
                tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
                tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 417F));
                tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
                tableLayoutPanel12.Controls.Add(label23, 2, 0);
                tableLayoutPanel12.Controls.Add(vbButton1, 4, 0);
                tableLayoutPanel12.Controls.Add(label25, 0, 0);
                tableLayoutPanel12.Controls.Add(label24, 3, 0);
                tableLayoutPanel12.Controls.Add(label26, 1, 0);
                tableLayoutPanel12.ForeColor = System.Drawing.Color.White;
                tableLayoutPanel12.Location = new System.Drawing.Point(0, 0);
                tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
                tableLayoutPanel12.Name = "tableLayoutPanel12";
                tableLayoutPanel12.RowCount = 1;
                tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                tableLayoutPanel12.Size = new System.Drawing.Size(879, 40);
                tableLayoutPanel12.TabIndex = 4;

                TblOrderHistories.Controls.Add(tableLayoutPanel12);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
