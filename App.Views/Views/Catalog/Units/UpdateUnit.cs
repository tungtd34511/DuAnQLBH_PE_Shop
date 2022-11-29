using App.Business.Sevices.Catalogs.Units;
using App.Data.Entities;
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
    public partial class UpdateUnit : Form
    {
        private readonly IUnitServices _unitServices;
        public Unit Unit { get; set; } = new();

        public UpdateUnit(IUnitServices unitServices)
        {
            InitializeComponent();
            _unitServices = unitServices;
        }
        private async Task<string> Validate()
        {
            var eror = "";
            if (await _unitServices.CheckName(LblName.Text))
            {
                eror += "Đơn vị bị trùng tên!\n";
            }
            if (String.IsNullOrEmpty(LblName.Text) || LblName.Text.Length > 15)
            {
                eror += "Tên đơn vị phải có độ dài từ 1 đến 15 ký tự!\n";
            }
            return eror;
        }

        private void UpdateUnit_Load(object sender, EventArgs e)
        {
            LblName.Text = Unit.Name;
        }

        private async void BtnSave_Click_1(object sender, EventArgs e)
        {
            var eror = await Validate();
            if (eror != "")
            {
                MessageBox.Show(eror);
            }
            else
            {
                Unit.Name = LblName.Text;
                Unit.IsDeleted = false;
                if (await _unitServices.Update(Unit))
                {
                    MessageBox.Show("Cập nhật đơn vị thành công!");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Cập nhật đơn vị thất bại!");
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
