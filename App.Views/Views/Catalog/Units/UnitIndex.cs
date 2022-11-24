using App.Business.Sevices.Catalogs.Manufactures;
using App.Business.Sevices.Catalogs.Units;
using App.Data.Entities;
using App.Data.Ultilities.Catalog.Manufacturers;
using App.Data.Ultilities.Catalog.Units;
using App.Data.Ultilities.Common;
using App.Views.Models.Controls;
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

namespace App.Views.Views.Catalog.Units
{
    public partial class UnitIndex : Form
    {
        private readonly IUnitServices _unitServices;
        private readonly IServiceProvider _serviceProvider;
        public PagedResult<Unit> Result { get; set; }
        public GetPagingUnitRequest Request { get; set; } = new();
        public UnitIndex(IUnitServices unitServices, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _unitServices = unitServices;
            _serviceProvider = serviceProvider;
        }
        private async Task LoadViewTable()
        {
            TblView.Controls.Clear();
            int index = 0;
            foreach (var item in Result.Items)
            {
                // 
                // BtnHide
                // 
                var BtnHide = new VBButton();
                BtnHide.BackColor = System.Drawing.Color.MediumSlateBlue;
                BtnHide.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                BtnHide.BorderColor = System.Drawing.Color.PaleVioletRed;
                BtnHide.BorderRadius = 5;
                BtnHide.BorderSize = 0;
                BtnHide.FlatAppearance.BorderSize = 0;
                BtnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                BtnHide.ForeColor = System.Drawing.Color.White;
                BtnHide.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                BtnHide.IconColor = System.Drawing.Color.Black;
                BtnHide.IconFont = FontAwesome.Sharp.IconFont.Solid;
                BtnHide.IconSize = 25;
                BtnHide.Location = new System.Drawing.Point(1224, 3);
                BtnHide.Name = "BtnHide";
                BtnHide.Size = new System.Drawing.Size(34, 34);
                BtnHide.TabIndex = 7;
                BtnHide.TextColor = System.Drawing.Color.White;
                BtnHide.UseVisualStyleBackColor = false;

                var LblStt = new Label();

                LblStt.Anchor = System.Windows.Forms.AnchorStyles.Left;
                LblStt.AutoSize = true;
                LblStt.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                LblStt.ForeColor = System.Drawing.Color.Black;
                LblStt.Location = new System.Drawing.Point(3, 8);
                LblStt.Name = "LblStt";
                LblStt.Size = new System.Drawing.Size(19, 23);
                LblStt.TabIndex = 5;
                LblStt.Text = (++index).ToString();

                var LblId = new Label();

                LblId.Anchor = System.Windows.Forms.AnchorStyles.Left;
                LblId.AutoSize = true;
                LblId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                LblId.ForeColor = System.Drawing.Color.Black;
                LblId.Location = new System.Drawing.Point(59, 8);
                LblId.Name = "LblId";
                LblId.Size = new System.Drawing.Size(19, 23);
                LblId.TabIndex = 0;
                LblId.Text = item.Id.ToString();

                var LblName = new Label();

                LblName.Anchor = System.Windows.Forms.AnchorStyles.None;
                LblName.AutoSize = true;
                LblName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                LblName.ForeColor = System.Drawing.Color.Black;
                LblName.Location = new System.Drawing.Point(576, 8);
                LblName.Name = "LblName";
                LblName.Size = new System.Drawing.Size(146, 23);
                LblName.TabIndex = 4;
                LblName.Text =item.Name;

                var BtnEdit = new VBButton();

                BtnEdit.BackColor = System.Drawing.Color.MediumSlateBlue;
                BtnEdit.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
                BtnEdit.BorderColor = System.Drawing.Color.PaleVioletRed;
                BtnEdit.BorderRadius = 5;
                BtnEdit.BorderSize = 0;
                BtnEdit.FlatAppearance.BorderSize = 0;
                BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                BtnEdit.ForeColor = System.Drawing.Color.White;
                BtnEdit.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
                BtnEdit.IconColor = System.Drawing.Color.Black;
                BtnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
                BtnEdit.IconSize = 25;
                BtnEdit.Location = new System.Drawing.Point(1184, 3);
                BtnEdit.Name = "BtnEdit";
                BtnEdit.Size = new System.Drawing.Size(34, 34);
                BtnEdit.TabIndex = 6;
                BtnEdit.TextColor = System.Drawing.Color.White;
                BtnEdit.UseVisualStyleBackColor = false;

                var tableLayoutPanel4 = new TableLayoutPanel();

                tableLayoutPanel4.BackColor = System.Drawing.Color.White;
                tableLayoutPanel4.ColumnCount = 5;
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
                tableLayoutPanel4.Controls.Add(BtnHide, 4, 0);
                tableLayoutPanel4.Controls.Add(LblStt, 0, 0);
                tableLayoutPanel4.Controls.Add(LblId, 0, 0);
                tableLayoutPanel4.Controls.Add(LblName, 1, 0);
                tableLayoutPanel4.Controls.Add(BtnEdit, 3, 0);
                tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
                tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
                tableLayoutPanel4.Name = "tableLayoutPanel4";
                tableLayoutPanel4.RowCount = 1;
                tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                tableLayoutPanel4.Size = new System.Drawing.Size(1261, 40);
                tableLayoutPanel4.TabIndex = 3;
                //
                TblView.Controls.Add(tableLayoutPanel4);
            }
        }
        private async void UnitIndex_Load(object sender, EventArgs e)
        {
            Result = await _unitServices.GetPaging(Request);
            await LoadViewTable();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<AddUnit>();
            form.FormClosed += async (o, s) =>
            {
                Result = await _unitServices.GetPaging(Request);
                await LoadViewTable();
            };
            form.ShowDialog();
        }
    }
}
