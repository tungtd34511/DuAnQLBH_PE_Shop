using App.Business.Sevices.Catalogs.Manufactures;
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

namespace App.Views.Views.Catalog.Manufacturers
{
    public partial class CreateManufacture : Form
    {
        private readonly IManufactureServices _manufactureServices;
        public Manufacturer Manufacturer { get; set; } = new();
        public CreateManufacture(IManufactureServices manufactureServices)
        {
            InitializeComponent();
            _manufactureServices = manufactureServices;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            Manufacturer.Details = TxtDetails.Text;
            Manufacturer.Description = txtDescription.Text;
            Manufacturer.Name = txtName.Text;
            Manufacturer.IsDeleted = false;
            await _manufactureServices.Add(Manufacturer);
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
