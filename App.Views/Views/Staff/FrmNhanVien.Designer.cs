namespace App.Views.Views.User
{
    partial class FrmNhanVien
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCreate = new App.Views.Models.Controls.VBButton();
            this.customPanel1 = new App.Views.Models.Controls.CustomPanel();
            this.Txt_Search = new System.Windows.Forms.TextBox();
            this.Btn_Search = new FontAwesome.Sharp.IconButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1131, 615);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.customPanel1);
            this.panel1.Controls.Add(this.BtnCreate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 80);
            this.panel1.TabIndex = 2;
            // 
            // BtnCreate
            // 
            this.BtnCreate.BackColor = System.Drawing.Color.Transparent;
            this.BtnCreate.BackgroundColor = System.Drawing.Color.Transparent;
            this.BtnCreate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BtnCreate.BorderRadius = 5;
            this.BtnCreate.BorderSize = 0;
            this.BtnCreate.FlatAppearance.BorderSize = 0;
            this.BtnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCreate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(164)))), ((int)(((byte)(78)))));
            this.BtnCreate.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.BtnCreate.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(164)))), ((int)(((byte)(78)))));
            this.BtnCreate.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.BtnCreate.IconSize = 40;
            this.BtnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCreate.Location = new System.Drawing.Point(294, 16);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(155, 44);
            this.BtnCreate.TabIndex = 11;
            this.BtnCreate.Text = "Thêm Mới";
            this.BtnCreate.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(164)))), ((int)(((byte)(78)))));
            this.BtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCreate.UseVisualStyleBackColor = false;
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.White;
            this.customPanel1.BorderColor = System.Drawing.Color.Silver;
            this.customPanel1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.customPanel1.BorderRadius = 5;
            this.customPanel1.BorderSize = 1;
            this.customPanel1.Controls.Add(this.textBox1);
            this.customPanel1.Controls.Add(this.Txt_Search);
            this.customPanel1.Controls.Add(this.Btn_Search);
            this.customPanel1.Location = new System.Drawing.Point(697, 16);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(280, 44);
            this.customPanel1.TabIndex = 12;
            this.customPanel1.UnderlinedStyle = false;
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
            // Btn_Search
            // 
            this.Btn_Search.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Search.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_Search.FlatAppearance.BorderSize = 0;
            this.Btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Search.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.Btn_Search.IconColor = System.Drawing.Color.DimGray;
            this.Btn_Search.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.Btn_Search.IconSize = 30;
            this.Btn_Search.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Search.Location = new System.Drawing.Point(236, 0);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(44, 44);
            this.Btn_Search.TabIndex = 1;
            this.Btn_Search.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Tên";
            this.textBox1.Size = new System.Drawing.Size(228, 32);
            this.textBox1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 80);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 416F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 535);
            this.tableLayoutPanel1.TabIndex = 3;
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
            // FrmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 615);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmNhanVien";
            this.Text = "FrmNhanVien";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.customPanel1.ResumeLayout(false);
            this.customPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private Models.Controls.VBButton BtnCreate;
        private Models.Controls.CustomPanel customPanel1;
        private TextBox Txt_Search;
        private FontAwesome.Sharp.IconButton Btn_Search;
        private TextBox textBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label15;
    }
}