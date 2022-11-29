using App.Business.Sevices.Catalogs.Categories;
using App.Business.Sevices.Catalogs.Colors;
using App.Business.Sevices.Catalogs.Manufactures;
using App.Business.Sevices.Catalogs.Sizes;
using App.Business.Sevices.Catalogs.Units;
using App.Business.Sevices.Orders;
using App.Business.Sevices.Products;
using App.Business.Sevices.ProductVariations;
using App.Business.Sevices.Promotions;
using App.Business.Sevices.Shoppings;
using App.Business.Sevices.ThongKes;
using App.Business.Sevices.Users;
using App.Business.Ultilities.Common;
using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Repositories.Carts;
using App.Data.Repositories.Catalog.Categories;
using App.Data.Repositories.Catalog.Colors;
using App.Data.Repositories.Catalog.Images;
using App.Data.Repositories.Catalog.Manufacturers;
using App.Data.Repositories.Catalog.Sizes;
using App.Data.Repositories.Catalog.Units;
using App.Data.Repositories.Customers;
using App.Data.Repositories.Orders;
using App.Data.Repositories.Products;
using App.Data.Repositories.Promotions;
using App.Data.Repositories.Users;
using App.Data.Ultilities.Catalog.Users;
using App.Views.Views.Catalog.Categories;
using App.Views.Views.Catalog.Colors;
using App.Views.Views.Catalog.Manufacturers;
using App.Views.Views.Catalog.ProductVariations;
using App.Views.Views.Catalog.Sizes;
using App.Views.Views.Catalog.Units;
using App.Views.Views.Layout;
using App.Views.Views.Orders;
using App.Views.Views.Product;
using App.Views.Views.Promotion;
using App.Views.Views.Shopping;
using App.Views.Views.ThongKe;
using App.Views.Views.User;
using App.Views.Views.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms.Design;

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

            Application.Run(ServiceProvider.GetRequiredService<_Layout> ());
        }
        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<QLBH_Context>(options =>
                    options.UseSqlServer(@"Data Source=TUNGHACK\SQLEXPRESS;Initial Catalog=DU_AN_QuanLyBanHang_PE_SHOP;Integrated Security=True"));
                    services.AddTransient<IProductVariationRepositories,ProductVariationRepositories>();
                    services.AddTransient<IColorRepositories,ColorRepositories>();
                    services.AddTransient<ISizeRepositories,SizeRepositories>();
                    services.AddTransient<IProductVariationRepositories, ProductVariationRepositories>();
                    services.AddTransient<IProductInCategoryRepositories, ProductInCategoryRepositories>();
                    services.AddTransient<IProductRepositories, ProductRepositories>();
                    services.AddTransient<IProductDetailRepositories, ProductDetailRepositories>();
                    services.AddTransient<IProductImageRepositories, ProductImageRepositories>();
                    services.AddTransient<IUnitRepositories, UnitRepositories>();
                    services.AddTransient<ICategoryRepositories, CategoryRepositories>();
                    services.AddTransient<IStorageService, FileStorageService>();
                    services.AddTransient<IManufacturerRepositories, ManufacturerRepositories>();
                    services.AddTransient<ICartRepositories, CartRepositories>();
                    services.AddTransient<IProductInCartRepositories,ProductInCartRepositories>();
                    services.AddTransient<IOrderRepositories,OrderRepositories>();
                    services.AddTransient<IOrderHistoryRepositories,OrderHistoryRepositories>();
                    services.AddTransient<ICustomerRepositories, CustomerRepositories>();
                    services.AddTransient<IUserRepositories,UserRepositories>();
                    services.AddTransient<IUserDetailRepositories, UserDetailRepositories>();
                    services.AddTransient<IPromotionRepositories, PromotionRepositories>();
                    services.AddTransient<IColorRepositories, ColorRepositories>();
                    services.AddTransient<ISizeRepositories,SizeRepositories>();
                    //
                    services.AddTransient<IShoppingService,ShoppingService>();
                    services.AddTransient<IOrderService, OrderService>();
                    services.AddTransient<IProductServices, ProductServices>();
                    services.AddTransient<IThongKeServices, ThongKeServices>();
                    services.AddTransient<ICategoryService, CategoryService>();
                    services.AddTransient<IManufactureServices, ManufactureService>();
                    services.AddTransient<IUnitServices, UnitService>();
                    services.AddTransient<IUserService, UserService>();
                    services.AddTransient<IPromotionService, PromotionService>();
                    services.AddTransient<IColorService,ColorService>();
                    services.AddTransient<ISizeService,SizeService>();
                    services.AddTransient<IProductVariationServices,ProductVariationServices>();
                    //
                    services.AddTransient<_Layout>();
                    services.AddTransient<ProductIndex>();
                    services.AddTransient<ProductDetails>();
                    services.AddTransient<CreateProduct>();
                    services.AddTransient<UpdateProduct>();
                    services.AddTransient<ShoppingIndex>();
                    services.AddTransient<AddToCart>();
                    services.AddTransient<OrderIndex>();
                    services.AddTransient<OderDetail>();
                    services.AddTransient<EditOrder>();
                    services.AddTransient<ThongKeIndex>();
                    services.AddTransient<CategoryIndex>();
                    services.AddTransient<CreateCategory>();
                    services.AddTransient<ManufactureIndex>();
                    services.AddTransient<CreateManufacture>();
                    services.AddTransient<UnitIndex>();
                    services.AddTransient<AddUnit>();
                    services.AddTransient<QRcode>();
                    services.AddTransient<UserIndex>();
                    services.AddTransient<UserLogin>();
                    services.AddTransient<UserDetails>();
                    services.AddTransient<UpdateUser>();
                    services.AddTransient<ChangePassword>();
                    services.AddTransient<PromotionIndex>();
                    services.AddTransient<CreatePromotion>();
                    services.AddTransient<Updatepromotion>();
                    services.AddTransient<ColorIndex>();
                    services.AddTransient<CreateColor>();
                    services.AddTransient<UpdateColor>();
                    services.AddTransient<SizeIndex>();
                    services.AddTransient<CreateSize>();
                    services.AddTransient<UpdateSize>();
                    services.AddTransient<ProductVariationIndex>();
                    services.AddTransient<CreateProductVariaton>();
                    services.AddTransient<UpdateProductVariation>();
                    services.AddTransient<AddUser>();
                    //
                });
        }
    }
}