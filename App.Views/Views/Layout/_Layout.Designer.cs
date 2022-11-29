using App.Views.Models.Controls;
using FontAwesome.Sharp;

namespace App.Views.Views.Layout
{
    partial class _Layout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Tbl_HomeView = new System.Windows.Forms.TableLayoutPanel();
            this.tbl_Menu = new System.Windows.Forms.TableLayoutPanel();
            this.tbl_Logo = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.vbButton1 = new App.Views.Models.Controls.VBButton();
            this.customPanel1 = new App.Views.Models.Controls.CustomPanel();
            this.button2 = new FontAwesome.Sharp.IconButton();
            this.vbButton2 = new App.Views.Models.Controls.VBButton();
            this.vbButton12 = new App.Views.Models.Controls.VBButton();
            this.vbButton8 = new App.Views.Models.Controls.VBButton();
            this.vbButton7 = new App.Views.Models.Controls.VBButton();
            this.vbButton6 = new App.Views.Models.Controls.VBButton();
            this.vbButton5 = new App.Views.Models.Controls.VBButton();
            this.vbButton4 = new App.Views.Models.Controls.VBButton();
            this.BtnHome = new App.Views.Models.Controls.VBButton();
            this.vbButton9 = new App.Views.Models.Controls.VBButton();
            this.vbButton10 = new App.Views.Models.Controls.VBButton();
            this.PanlDesktop = new System.Windows.Forms.Panel();
            this.MenuCatalog = new App.Views.Models.Controls.RJDropdownMenu(this.components);
            this.danhMụcSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàSảnXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đơnVịSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.màuSắcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kíchCỡToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.biếnThểSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tbl_HomeView.SuspendLayout();
            this.tbl_Menu.SuspendLayout();
            this.tbl_Logo.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.MenuCatalog.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tbl_HomeView
            // 
            this.Tbl_HomeView.BackColor = System.Drawing.Color.White;
            this.Tbl_HomeView.ColumnCount = 2;
            this.Tbl_HomeView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.91667F));
            this.Tbl_HomeView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.08334F));
            this.Tbl_HomeView.Controls.Add(this.tbl_Menu, -1, 0);
            this.Tbl_HomeView.Controls.Add(this.PanlDesktop, 1, 0);
            this.Tbl_HomeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tbl_HomeView.Location = new System.Drawing.Point(0, 0);
            this.Tbl_HomeView.Margin = new System.Windows.Forms.Padding(19, 5, 21, 5);
            this.Tbl_HomeView.Name = "Tbl_HomeView";
            this.Tbl_HomeView.RowCount = 1;
            this.Tbl_HomeView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tbl_HomeView.Size = new System.Drawing.Size(1920, 991);
            this.Tbl_HomeView.TabIndex = 0;
            // 
            // tbl_Menu
            // 
            this.tbl_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.tbl_Menu.ColumnCount = 1;
            this.tbl_Menu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_Menu.Controls.Add(this.tbl_Logo, 0, 0);
            this.tbl_Menu.Controls.Add(this.customPanel1, 0, 1);
            this.tbl_Menu.Controls.Add(this.vbButton12, 0, 12);
            this.tbl_Menu.Controls.Add(this.vbButton8, 0, 7);
            this.tbl_Menu.Controls.Add(this.vbButton7, 0, 6);
            this.tbl_Menu.Controls.Add(this.vbButton6, 0, 5);
            this.tbl_Menu.Controls.Add(this.vbButton5, 0, 4);
            this.tbl_Menu.Controls.Add(this.vbButton4, 0, 3);
            this.tbl_Menu.Controls.Add(this.BtnHome, 0, 2);
            this.tbl_Menu.Controls.Add(this.vbButton9, 0, 8);
            this.tbl_Menu.Controls.Add(this.vbButton10, 0, 9);
            this.tbl_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_Menu.Location = new System.Drawing.Point(0, 0);
            this.tbl_Menu.Margin = new System.Windows.Forms.Padding(0);
            this.tbl_Menu.Name = "tbl_Menu";
            this.tbl_Menu.RowCount = 13;
            this.tbl_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tbl_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tbl_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbl_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbl_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbl_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbl_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbl_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbl_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbl_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbl_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbl_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_Menu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tbl_Menu.Size = new System.Drawing.Size(344, 991);
            this.tbl_Menu.TabIndex = 0;
            // 
            // tbl_Logo
            // 
            this.tbl_Logo.ColumnCount = 2;
            this.tbl_Logo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tbl_Logo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_Logo.Controls.Add(this.label1, 1, 0);
            this.tbl_Logo.Controls.Add(this.vbButton1, 0, 0);
            this.tbl_Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_Logo.Location = new System.Drawing.Point(0, 0);
            this.tbl_Logo.Margin = new System.Windows.Forms.Padding(0);
            this.tbl_Logo.Name = "tbl_Logo";
            this.tbl_Logo.RowCount = 1;
            this.tbl_Logo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl_Logo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl_Logo.Size = new System.Drawing.Size(344, 100);
            this.tbl_Logo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(103, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 54);
            this.label1.TabIndex = 4;
            this.label1.Text = "PE-SHOP";
            // 
            // vbButton1
            // 
            this.vbButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.vbButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.vbButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton1.BorderRadius = 47;
            this.vbButton1.BorderSize = 0;
            this.vbButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vbButton1.FlatAppearance.BorderSize = 0;
            this.vbButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton1.ForeColor = System.Drawing.Color.White;
            this.vbButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.vbButton1.IconColor = System.Drawing.Color.Black;
            this.vbButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.vbButton1.Location = new System.Drawing.Point(3, 3);
            this.vbButton1.Name = "vbButton1";
            this.vbButton1.Size = new System.Drawing.Size(94, 94);
            this.vbButton1.TabIndex = 1;
            this.vbButton1.Text = "vbButton1";
            this.vbButton1.TextColor = System.Drawing.Color.White;
            this.vbButton1.UseVisualStyleBackColor = false;
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.White;
            this.customPanel1.BorderColor = System.Drawing.Color.White;
            this.customPanel1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.customPanel1.BorderRadius = 30;
            this.customPanel1.BorderSize = 1;
            this.customPanel1.Controls.Add(this.button2);
            this.customPanel1.Controls.Add(this.vbButton2);
            this.customPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanel1.Location = new System.Drawing.Point(19, 105);
            this.customPanel1.Margin = new System.Windows.Forms.Padding(19, 5, 21, 5);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.customPanel1.Size = new System.Drawing.Size(304, 60);
            this.customPanel1.TabIndex = 2;
            this.customPanel1.UnderlinedStyle = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semilight", 14.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
            this.button2.IconColor = System.Drawing.Color.Black;
            this.button2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.button2.IconSize = 20;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(62, 3);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.button2.Size = new System.Drawing.Size(239, 54);
            this.button2.TabIndex = 4;
            this.button2.Text = "Duy Tùng";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // vbButton2
            // 
            this.vbButton2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.vbButton2.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.vbButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton2.BorderRadius = 25;
            this.vbButton2.BorderSize = 0;
            this.vbButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.vbButton2.FlatAppearance.BorderSize = 0;
            this.vbButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton2.ForeColor = System.Drawing.Color.White;
            this.vbButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.vbButton2.IconColor = System.Drawing.Color.Black;
            this.vbButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.vbButton2.Location = new System.Drawing.Point(3, 3);
            this.vbButton2.Margin = new System.Windows.Forms.Padding(5);
            this.vbButton2.Name = "vbButton2";
            this.vbButton2.Size = new System.Drawing.Size(54, 54);
            this.vbButton2.TabIndex = 5;
            this.vbButton2.Text = "vbButton2";
            this.vbButton2.TextColor = System.Drawing.Color.White;
            this.vbButton2.UseVisualStyleBackColor = false;
            // 
            // vbButton12
            // 
            this.vbButton12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton12.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton12.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton12.BorderRadius = 5;
            this.vbButton12.BorderSize = 0;
            this.vbButton12.FlatAppearance.BorderSize = 0;
            this.vbButton12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.vbButton12.ForeColor = System.Drawing.Color.White;
            this.vbButton12.IconChar = FontAwesome.Sharp.IconChar.ReplyAll;
            this.vbButton12.IconColor = System.Drawing.Color.White;
            this.vbButton12.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.vbButton12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton12.Location = new System.Drawing.Point(1, 922);
            this.vbButton12.Margin = new System.Windows.Forms.Padding(1);
            this.vbButton12.Name = "vbButton12";
            this.vbButton12.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.vbButton12.Size = new System.Drawing.Size(342, 68);
            this.vbButton12.TabIndex = 12;
            this.vbButton12.Text = "       Đăng Xuất";
            this.vbButton12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton12.TextColor = System.Drawing.Color.White;
            this.vbButton12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.vbButton12.UseVisualStyleBackColor = false;
            this.vbButton12.Click += new System.EventHandler(this.vbButton12_Click);
            // 
            // vbButton8
            // 
            this.vbButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton8.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton8.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton8.BorderRadius = 5;
            this.vbButton8.BorderSize = 0;
            this.vbButton8.FlatAppearance.BorderSize = 0;
            this.vbButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.vbButton8.ForeColor = System.Drawing.Color.White;
            this.vbButton8.IconChar = FontAwesome.Sharp.IconChar.Scroll;
            this.vbButton8.IconColor = System.Drawing.Color.White;
            this.vbButton8.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.vbButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton8.Location = new System.Drawing.Point(1, 521);
            this.vbButton8.Margin = new System.Windows.Forms.Padding(1);
            this.vbButton8.Name = "vbButton8";
            this.vbButton8.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.vbButton8.Size = new System.Drawing.Size(342, 68);
            this.vbButton8.TabIndex = 8;
            this.vbButton8.Text = "       Danh Sách";
            this.vbButton8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton8.TextColor = System.Drawing.Color.White;
            this.vbButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.vbButton8.UseVisualStyleBackColor = false;
            this.vbButton8.Click += new System.EventHandler(this.vbButton8_Click);
            // 
            // vbButton7
            // 
            this.vbButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton7.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton7.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton7.BorderRadius = 5;
            this.vbButton7.BorderSize = 0;
            this.vbButton7.FlatAppearance.BorderSize = 0;
            this.vbButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.vbButton7.ForeColor = System.Drawing.Color.White;
            this.vbButton7.IconChar = FontAwesome.Sharp.IconChar.Shopify;
            this.vbButton7.IconColor = System.Drawing.Color.White;
            this.vbButton7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.vbButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton7.Location = new System.Drawing.Point(1, 451);
            this.vbButton7.Margin = new System.Windows.Forms.Padding(1);
            this.vbButton7.Name = "vbButton7";
            this.vbButton7.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.vbButton7.Size = new System.Drawing.Size(342, 68);
            this.vbButton7.TabIndex = 7;
            this.vbButton7.Text = "       Khuyến Mãi";
            this.vbButton7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton7.TextColor = System.Drawing.Color.White;
            this.vbButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.vbButton7.UseVisualStyleBackColor = false;
            this.vbButton7.Click += new System.EventHandler(this.vbButton7_Click);
            // 
            // vbButton6
            // 
            this.vbButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton6.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton6.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton6.BorderRadius = 5;
            this.vbButton6.BorderSize = 0;
            this.vbButton6.FlatAppearance.BorderSize = 0;
            this.vbButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.vbButton6.ForeColor = System.Drawing.Color.White;
            this.vbButton6.IconChar = FontAwesome.Sharp.IconChar.Coins;
            this.vbButton6.IconColor = System.Drawing.Color.White;
            this.vbButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.vbButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton6.Location = new System.Drawing.Point(1, 381);
            this.vbButton6.Margin = new System.Windows.Forms.Padding(1);
            this.vbButton6.Name = "vbButton6";
            this.vbButton6.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.vbButton6.Size = new System.Drawing.Size(342, 68);
            this.vbButton6.TabIndex = 6;
            this.vbButton6.Text = "       Hóa Đơn";
            this.vbButton6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton6.TextColor = System.Drawing.Color.White;
            this.vbButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.vbButton6.UseVisualStyleBackColor = false;
            this.vbButton6.Click += new System.EventHandler(this.vbButton6_Click);
            // 
            // vbButton5
            // 
            this.vbButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton5.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton5.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton5.BorderRadius = 5;
            this.vbButton5.BorderSize = 0;
            this.vbButton5.FlatAppearance.BorderSize = 0;
            this.vbButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.vbButton5.ForeColor = System.Drawing.Color.White;
            this.vbButton5.IconChar = FontAwesome.Sharp.IconChar.Shapes;
            this.vbButton5.IconColor = System.Drawing.Color.White;
            this.vbButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.vbButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton5.Location = new System.Drawing.Point(1, 311);
            this.vbButton5.Margin = new System.Windows.Forms.Padding(1);
            this.vbButton5.Name = "vbButton5";
            this.vbButton5.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.vbButton5.Size = new System.Drawing.Size(342, 68);
            this.vbButton5.TabIndex = 5;
            this.vbButton5.Text = "       Sản Phẩm";
            this.vbButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton5.TextColor = System.Drawing.Color.White;
            this.vbButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.vbButton5.UseVisualStyleBackColor = false;
            this.vbButton5.Click += new System.EventHandler(this.vbButton5_Click);
            // 
            // vbButton4
            // 
            this.vbButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton4.BorderRadius = 5;
            this.vbButton4.BorderSize = 0;
            this.vbButton4.FlatAppearance.BorderSize = 0;
            this.vbButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.vbButton4.ForeColor = System.Drawing.Color.White;
            this.vbButton4.IconChar = FontAwesome.Sharp.IconChar.CartArrowDown;
            this.vbButton4.IconColor = System.Drawing.Color.White;
            this.vbButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.vbButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton4.Location = new System.Drawing.Point(1, 241);
            this.vbButton4.Margin = new System.Windows.Forms.Padding(1);
            this.vbButton4.Name = "vbButton4";
            this.vbButton4.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.vbButton4.Size = new System.Drawing.Size(342, 68);
            this.vbButton4.TabIndex = 4;
            this.vbButton4.Text = "       Bán Hàng";
            this.vbButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton4.TextColor = System.Drawing.Color.White;
            this.vbButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.vbButton4.UseVisualStyleBackColor = false;
            this.vbButton4.Click += new System.EventHandler(this.vbButton4_Click);
            // 
            // BtnHome
            // 
            this.BtnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.BtnHome.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.BtnHome.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnHome.BorderRadius = 5;
            this.BtnHome.BorderSize = 0;
            this.BtnHome.FlatAppearance.BorderSize = 0;
            this.BtnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHome.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnHome.ForeColor = System.Drawing.Color.White;
            this.BtnHome.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.BtnHome.IconColor = System.Drawing.Color.White;
            this.BtnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHome.Location = new System.Drawing.Point(1, 171);
            this.BtnHome.Margin = new System.Windows.Forms.Padding(1);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.BtnHome.Size = new System.Drawing.Size(342, 68);
            this.BtnHome.TabIndex = 3;
            this.BtnHome.Text = "       Trang Chủ";
            this.BtnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHome.TextColor = System.Drawing.Color.White;
            this.BtnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnHome.UseVisualStyleBackColor = false;
            this.BtnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // vbButton9
            // 
            this.vbButton9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton9.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton9.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton9.BorderRadius = 5;
            this.vbButton9.BorderSize = 0;
            this.vbButton9.FlatAppearance.BorderSize = 0;
            this.vbButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.vbButton9.ForeColor = System.Drawing.Color.White;
            this.vbButton9.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.vbButton9.IconColor = System.Drawing.Color.White;
            this.vbButton9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.vbButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton9.Location = new System.Drawing.Point(1, 591);
            this.vbButton9.Margin = new System.Windows.Forms.Padding(1);
            this.vbButton9.Name = "vbButton9";
            this.vbButton9.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.vbButton9.Size = new System.Drawing.Size(342, 68);
            this.vbButton9.TabIndex = 9;
            this.vbButton9.Text = "       Thống Kê";
            this.vbButton9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton9.TextColor = System.Drawing.Color.White;
            this.vbButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.vbButton9.UseVisualStyleBackColor = false;
            this.vbButton9.Click += new System.EventHandler(this.vbButton9_Click);
            // 
            // vbButton10
            // 
            this.vbButton10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton10.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.vbButton10.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.vbButton10.BorderRadius = 5;
            this.vbButton10.BorderSize = 0;
            this.vbButton10.FlatAppearance.BorderSize = 0;
            this.vbButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbButton10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.vbButton10.ForeColor = System.Drawing.Color.White;
            this.vbButton10.IconChar = FontAwesome.Sharp.IconChar.UniversalAccess;
            this.vbButton10.IconColor = System.Drawing.Color.White;
            this.vbButton10.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.vbButton10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton10.Location = new System.Drawing.Point(1, 661);
            this.vbButton10.Margin = new System.Windows.Forms.Padding(1);
            this.vbButton10.Name = "vbButton10";
            this.vbButton10.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.vbButton10.Size = new System.Drawing.Size(342, 68);
            this.vbButton10.TabIndex = 10;
            this.vbButton10.Text = "       Nhân Viên";
            this.vbButton10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vbButton10.TextColor = System.Drawing.Color.White;
            this.vbButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.vbButton10.UseVisualStyleBackColor = false;
            this.vbButton10.Click += new System.EventHandler(this.vbButton10_Click);
            // 
            // PanlDesktop
            // 
            this.PanlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanlDesktop.Location = new System.Drawing.Point(344, 0);
            this.PanlDesktop.Margin = new System.Windows.Forms.Padding(0);
            this.PanlDesktop.Name = "PanlDesktop";
            this.PanlDesktop.Size = new System.Drawing.Size(1576, 991);
            this.PanlDesktop.TabIndex = 1;
            // 
            // MenuCatalog
            // 
            this.MenuCatalog.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MenuCatalog.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuCatalog.IsMainMenu = false;
            this.MenuCatalog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcSảnPhẩmToolStripMenuItem,
            this.nhàSảnXuấtToolStripMenuItem,
            this.đơnVịSảnPhẩmToolStripMenuItem,
            this.màuSắcToolStripMenuItem,
            this.kíchCỡToolStripMenuItem,
            this.biếnThểSảnPhẩmToolStripMenuItem});
            this.MenuCatalog.MenuItemHeight = 25;
            this.MenuCatalog.MenuItemTextColor = System.Drawing.Color.Empty;
            this.MenuCatalog.Name = "MenuCatalog";
            this.MenuCatalog.PrimaryColor = System.Drawing.Color.Empty;
            this.MenuCatalog.Size = new System.Drawing.Size(275, 196);
            // 
            // danhMụcSảnPhẩmToolStripMenuItem
            // 
            this.danhMụcSảnPhẩmToolStripMenuItem.Name = "danhMụcSảnPhẩmToolStripMenuItem";
            this.danhMụcSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(274, 32);
            this.danhMụcSảnPhẩmToolStripMenuItem.Text = "Danh Mục Sản Phẩm";
            // 
            // nhàSảnXuấtToolStripMenuItem
            // 
            this.nhàSảnXuấtToolStripMenuItem.Name = "nhàSảnXuấtToolStripMenuItem";
            this.nhàSảnXuấtToolStripMenuItem.Size = new System.Drawing.Size(274, 32);
            this.nhàSảnXuấtToolStripMenuItem.Text = "Nhà Sản Xuất";
            // 
            // đơnVịSảnPhẩmToolStripMenuItem
            // 
            this.đơnVịSảnPhẩmToolStripMenuItem.Name = "đơnVịSảnPhẩmToolStripMenuItem";
            this.đơnVịSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(274, 32);
            this.đơnVịSảnPhẩmToolStripMenuItem.Text = "Đơn Vị Sản Phẩm";
            // 
            // màuSắcToolStripMenuItem
            // 
            this.màuSắcToolStripMenuItem.Name = "màuSắcToolStripMenuItem";
            this.màuSắcToolStripMenuItem.Size = new System.Drawing.Size(274, 32);
            this.màuSắcToolStripMenuItem.Text = "Màu Sắc";
            // 
            // kíchCỡToolStripMenuItem
            // 
            this.kíchCỡToolStripMenuItem.Name = "kíchCỡToolStripMenuItem";
            this.kíchCỡToolStripMenuItem.Size = new System.Drawing.Size(274, 32);
            this.kíchCỡToolStripMenuItem.Text = "Kích Cỡ";
            // 
            // biếnThểSảnPhẩmToolStripMenuItem
            // 
            this.biếnThểSảnPhẩmToolStripMenuItem.Name = "biếnThểSảnPhẩmToolStripMenuItem";
            this.biếnThểSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(274, 32);
            this.biếnThểSảnPhẩmToolStripMenuItem.Text = "Biến Thể Sản Phẩm";
            // 
            // _Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1920, 991);
            this.Controls.Add(this.Tbl_HomeView);
            this.Name = "_Layout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "_Layout";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this._Layout_Load);
            this.Tbl_HomeView.ResumeLayout(false);
            this.tbl_Menu.ResumeLayout(false);
            this.tbl_Logo.ResumeLayout(false);
            this.tbl_Logo.PerformLayout();
            this.customPanel1.ResumeLayout(false);
            this.MenuCatalog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel Tbl_HomeView;
        private TableLayoutPanel tbl_Menu;
        private TableLayoutPanel tbl_Logo;
        private Label label1;
        private VBButton vbButton1;
        private CustomPanel customPanel1;
        private VBButton vbButton2;
        private IconButton button2;
        private VBButton vbButton8;
        private VBButton vbButton7;
        private VBButton vbButton6;
        private VBButton vbButton5;
        private VBButton vbButton4;
        private VBButton BtnHome;
        private VBButton vbButton9;
        private VBButton vbButton12;
        private VBButton vbButton10;
        private Panel PanlDesktop;
        private RJDropdownMenu MenuCatalog;
        private ToolStripMenuItem danhMụcSảnPhẩmToolStripMenuItem;
        private ToolStripMenuItem nhàSảnXuấtToolStripMenuItem;
        private ToolStripMenuItem đơnVịSảnPhẩmToolStripMenuItem;
        private ToolStripMenuItem màuSắcToolStripMenuItem;
        private ToolStripMenuItem kíchCỡToolStripMenuItem;
        private ToolStripMenuItem biếnThểSảnPhẩmToolStripMenuItem;
    }
}