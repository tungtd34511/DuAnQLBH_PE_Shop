using App.Data.Context;
using App.Data.Repositories.Base;
using App.Data.Repositories.Carts;
using App.Views.Services.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App.Views
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        ///

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Test1>());
        }
        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<QLBH_Context>(options =>
                    options.UseSqlServer(@"Data Source=TUNGHACK\SQLEXPRESS;Initial Catalog=DU_AN_QuanLyBanHang_PE_SHOP;Integrated Security=True"));
                    services.AddTransient<IBaseService, BaseService>();
                    services.AddTransient<ICartRepositories, CartRepositories>();
                    services.AddTransient<Test1>();
                    //services.AddTransient<Form2>();
                });
        }
    }
}