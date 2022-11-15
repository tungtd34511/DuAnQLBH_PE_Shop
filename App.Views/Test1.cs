using App.Data.Context;
using App.Data.Repositories.Carts;
using App.Views.Services.Catalog;
using Microsoft.Extensions.DependencyInjection;

namespace App.Views
{
    public partial class Test1 : Form
    {
        private readonly IBaseService _baseService;
        private readonly IServiceProvider _serviceProvide;
        private readonly ICartRepositories _cartRepositories;
        public Test1(IBaseService baseService, IServiceProvider serviceProvider, ICartRepositories cartRepositories) // Dependency Injection
        {
            InitializeComponent();
            _baseService = baseService;
            _serviceProvide = serviceProvider;
            _cartRepositories = cartRepositories;
            _cartRepositories = new CartRepositories(new QLBH_Context()); // test DI : Dependency Injection
        }

        private async void label1_Click(object sender, EventArgs e)
        {
            label1.Text = await _cartRepositories.Hello("MLXGH");
            var frm2 = new Test2();
            for (int i = 0 ; i <100; i++)
            {
                Label t = new Label() { Text = "Ngu" };
                frm2.Controls.Add(t);
            }
            frm2.Show();
        }
    }
}