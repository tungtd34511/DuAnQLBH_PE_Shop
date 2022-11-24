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
    public partial class AddUnit : Form
    {
        private readonly IUnitServices _unitServices;
        public Unit Unit { get; set; } = new();

        public AddUnit(IUnitServices unitServices)
        {
            InitializeComponent();
            _unitServices = unitServices;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            Unit.Name = LblName.Text;
            Unit.IsDeleted = false;
            await _unitServices.Add(Unit);
            this.Close();
        }
    }
}
