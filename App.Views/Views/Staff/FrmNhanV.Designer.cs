namespace App.Views.Views.Staff
{
    partial class FrmNhanV
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
            this.dgv_ShowNv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cb_HIenThi = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.customPanel1 = new App.Views.Models.Controls.CustomPanel();
            this.tb_Ten = new System.Windows.Forms.TextBox();
            this.Txt_Search = new System.Windows.Forms.TextBox();
            this.Btn_TimKiem = new FontAwesome.Sharp.IconButton();
            this.Btn_Them = new App.Views.Models.Controls.VBButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_TrangThai = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_ChucVu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowNv)).BeginInit();
            this.panel1.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_ShowNv
            // 
            this.dgv_ShowNv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ShowNv.Location = new System.Drawing.Point(299, 99);
            this.dgv_ShowNv.Name = "dgv_ShowNv";
            this.dgv_ShowNv.RowHeadersWidth = 51;
            this.dgv_ShowNv.Size = new System.Drawing.Size(1259, 845);
            this.dgv_ShowNv.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Cb_HIenThi);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.customPanel1);
            this.panel1.Controls.Add(this.Btn_Them);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1558, 80);
            this.panel1.TabIndex = 2;
            // 
            // Cb_HIenThi
            // 
            this.Cb_HIenThi.AutoSize = true;
            this.Cb_HIenThi.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Cb_HIenThi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(164)))), ((int)(((byte)(78)))));
            this.Cb_HIenThi.Location = new System.Drawing.Point(477, 27);
            this.Cb_HIenThi.Name = "Cb_HIenThi";
            this.Cb_HIenThi.Size = new System.Drawing.Size(284, 32);
            this.Cb_HIenThi.TabIndex = 14;
            this.Cb_HIenThi.Text = "Ấn để xem tất cả nhân viên";
            this.Cb_HIenThi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Cb_HIenThi.UseVisualStyleBackColor = true;
            this.Cb_HIenThi.CheckedChanged += new System.EventHandler(this.Cb_HIenThi_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(219)))));
            this.label15.Location = new System.Drawing.Point(9, 9);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(242, 60);
            this.label15.TabIndex = 13;
            this.label15.Text = "Nhân Viên";
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.White;
            this.customPanel1.BorderColor = System.Drawing.Color.Silver;
            this.customPanel1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.customPanel1.BorderRadius = 5;
            this.customPanel1.BorderSize = 1;
            this.customPanel1.Controls.Add(this.tb_Ten);
            this.customPanel1.Controls.Add(this.Txt_Search);
            this.customPanel1.Controls.Add(this.Btn_TimKiem);
            this.customPanel1.Location = new System.Drawing.Point(801, 23);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(280, 44);
            this.customPanel1.TabIndex = 12;
            this.customPanel1.UnderlinedStyle = false;
            // 
            // tb_Ten
            // 
            this.tb_Ten.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tb_Ten.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Ten.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_Ten.Location = new System.Drawing.Point(3, 5);
            this.tb_Ten.Name = "tb_Ten";
            this.tb_Ten.PlaceholderText = "Tên";
            this.tb_Ten.Size = new System.Drawing.Size(228, 32);
            this.tb_Ten.TabIndex = 3;
            // 
            // Txt_Search
            // 
            this.Txt_Search.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Txt_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Search.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Txt_Search.Location = new System.Drawing.Point(2, -40);
            this.Txt_Search.Name = "Txt_Search";
            this.Txt_Search.PlaceholderText = "Id, Tên, ...";
            this.Txt_Search.Size = new System.Drawing.Size(228, 32);
            this.Txt_Search.TabIndex = 2;
            // 
            // Btn_TimKiem
            // 
            this.Btn_TimKiem.BackColor = System.Drawing.Color.Transparent;
            this.Btn_TimKiem.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_TimKiem.FlatAppearance.BorderSize = 0;
            this.Btn_TimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_TimKiem.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.Btn_TimKiem.IconColor = System.Drawing.Color.DimGray;
            this.Btn_TimKiem.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.Btn_TimKiem.IconSize = 30;
            this.Btn_TimKiem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_TimKiem.Location = new System.Drawing.Point(236, 0);
            this.Btn_TimKiem.Name = "Btn_TimKiem";
            this.Btn_TimKiem.Size = new System.Drawing.Size(44, 44);
            this.Btn_TimKiem.TabIndex = 1;
            this.Btn_TimKiem.UseVisualStyleBackColor = false;
            // 
            // Btn_Them
            // 
            this.Btn_Them.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Them.BackgroundColor = System.Drawing.Color.Transparent;
            this.Btn_Them.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Btn_Them.BorderRadius = 5;
            this.Btn_Them.BorderSize = 0;
            this.Btn_Them.FlatAppearance.BorderSize = 0;
            this.Btn_Them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Them.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Them.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(164)))), ((int)(((byte)(78)))));
            this.Btn_Them.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.Btn_Them.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(164)))), ((int)(((byte)(78)))));
            this.Btn_Them.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.Btn_Them.IconSize = 40;
            this.Btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Them.Location = new System.Drawing.Point(294, 16);
            this.Btn_Them.Name = "Btn_Them";
            this.Btn_Them.Size = new System.Drawing.Size(155, 44);
            this.Btn_Them.TabIndex = 11;
            this.Btn_Them.Text = "Thêm Mới";
            this.Btn_Them.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(164)))), ((int)(((byte)(78)))));
            this.Btn_Them.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Them.UseVisualStyleBackColor = false;
            this.Btn_Them.Click += new System.EventHandler(this.Btn_Them_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 80);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 306F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(296, 864);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 223);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cbb_TrangThai);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 127);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(284, 93);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lọc theo trạng thái";
            // 
            // cbb_TrangThai
            // 
            this.cbb_TrangThai.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbb_TrangThai.FormattingEnabled = true;
            this.cbb_TrangThai.Location = new System.Drawing.Point(3, 57);
            this.cbb_TrangThai.Name = "cbb_TrangThai";
            this.cbb_TrangThai.Size = new System.Drawing.Size(278, 33);
            this.cbb_TrangThai.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbb_ChucVu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 93);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lọc theo chức vụ";
            // 
            // cbb_ChucVu
            // 
            this.cbb_ChucVu.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbb_ChucVu.FormattingEnabled = true;
            this.cbb_ChucVu.Location = new System.Drawing.Point(3, 57);
            this.cbb_ChucVu.Name = "cbb_ChucVu";
            this.cbb_ChucVu.Size = new System.Drawing.Size(278, 33);
            this.cbb_ChucVu.TabIndex = 1;
            // 
            // FrmNhanV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1558, 944);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_ShowNv);
            this.Name = "FrmNhanV";
            this.Text = "FrmNhanVien";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowNv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.customPanel1.ResumeLayout(false);
            this.customPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgv_ShowNv;
        private Panel panel1;
        private Models.Controls.VBButton Btn_Them;
        private Models.Controls.CustomPanel customPanel1;
        private TextBox Txt_Search;
        private FontAwesome.Sharp.IconButton Btn_TimKiem;
        private TextBox tb_Ten;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label15;
        private CheckBox Cb_HIenThi;
        private GroupBox groupBox1;
        private Panel panel2;
        private Label label1;
        private ComboBox cbb_ChucVu;
        private Panel panel3;
        private Label label2;
        private ComboBox cbb_TrangThai;
    }
}