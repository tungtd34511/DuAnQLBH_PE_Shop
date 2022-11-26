namespace App.Views.Views.Staff
{
    partial class DoiQuyen
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
            this.cbb_ChucVu = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_Doi = new App.Views.Models.Controls.VBButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbb_ChucVu
            // 
            this.cbb_ChucVu.FormattingEnabled = true;
            this.cbb_ChucVu.Location = new System.Drawing.Point(124, 53);
            this.cbb_ChucVu.Name = "cbb_ChucVu";
            this.cbb_ChucVu.Size = new System.Drawing.Size(151, 36);
            this.cbb_ChucVu.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 237);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_Doi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbb_ChucVu);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 233);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đổi quyền";
            // 
            // Btn_Doi
            // 
            this.Btn_Doi.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Btn_Doi.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.Btn_Doi.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Btn_Doi.BorderRadius = 5;
            this.Btn_Doi.BorderSize = 0;
            this.Btn_Doi.FlatAppearance.BorderSize = 0;
            this.Btn_Doi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Doi.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Btn_Doi.ForeColor = System.Drawing.Color.White;
            this.Btn_Doi.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Btn_Doi.IconColor = System.Drawing.Color.Black;
            this.Btn_Doi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Btn_Doi.Location = new System.Drawing.Point(140, 124);
            this.Btn_Doi.Name = "Btn_Doi";
            this.Btn_Doi.Size = new System.Drawing.Size(100, 40);
            this.Btn_Doi.TabIndex = 2;
            this.Btn_Doi.Text = "Đổi";
            this.Btn_Doi.TextColor = System.Drawing.Color.White;
            this.Btn_Doi.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chức vụ";
            // 
            // DoiQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(372, 263);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DoiQuyen";
            this.Text = "DoiQuyen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cbb_ChucVu;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private Label label1;
        public Models.Controls.VBButton Btn_Doi;
    }
}