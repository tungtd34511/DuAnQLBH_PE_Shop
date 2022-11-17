using App.Views.Views.Product;
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

namespace App.Views.Views.Layout
{
    public partial class _Layout : Form
    {
        private readonly IServiceProvider _serviceProvide;

        public _Layout(IServiceProvider serviceProvide)
        {
            InitializeComponent();
            _serviceProvide = serviceProvide;
            var frm = _serviceProvide.GetRequiredService<ProductIndex>();
            frm.TopLevel = false;
            Tbl_HomeView.Controls.Add(frm);
            frm.Show();
            //frm._btnBack.Click += (o, s) =>
            //{

            //}
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Width.ToString()+this.Height.ToString());
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vbButton10_Click(object sender, EventArgs e)
        {

        }

        private void tbl_Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }
    }
}
