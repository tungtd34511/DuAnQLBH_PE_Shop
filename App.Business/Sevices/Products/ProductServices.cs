
using App.Business.Models.Products;
using App.Business.Ultilities.Common;
using App.Data.Entities;
using App.Data.Repositories.Catalog.Images;
using App.Data.Repositories.Catalog.Categories;
using App.Data.Repositories.Catalog.Manufacturers;
using App.Data.Repositories.Products;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.PagingModels;
using App.Data.Ultilities.ViewModels;
using App.Data.Repositories.Catalog.Units;
using App.Data.Repositories.Catalog.Sizes;
using App.Data.Repositories.Catalog.Colors;

namespace App.Business.Sevices.Products
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepositories _productRepositories;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "Images";
        private readonly IProductImageRepositories _productImageRepositories;
        private readonly ICategoryRepositories _categoryRepositories;
        private readonly IManufacturerRepositories _manufacturerRepositories;
        private readonly IUnitRepositories _unitRepositories;
        private readonly IProductInCategoryRepositories _productInCategoryRepositories;
        private readonly IProductDetailRepositories _detailRepositories;
        private readonly ISizeRepositories _sizeRepositories;
        private readonly IColorRepositories _colorRepositories;
        private readonly IProductVariationRepositories _productVariationRepositories;
        public ProductServices(IProductRepositories productRepositories, IProductDetailRepositories productDetailRepositories, IStorageService storageService, IProductImageRepositories productImageRepositories, ICategoryRepositories categoryRepositories, IManufacturerRepositories manufacturerRepositories, IUnitRepositories unitRepositories, IProductInCategoryRepositories productInCategoryRepositories, ISizeRepositories sizeRepositories = null, IColorRepositories colorRepositories = null, IProductVariationRepositories productVariationRepositories = null)
        {
            _productRepositories = productRepositories;
            _storageService = storageService;
            _productImageRepositories = productImageRepositories;
            _categoryRepositories = categoryRepositories;
            _manufacturerRepositories = manufacturerRepositories;
            _unitRepositories = unitRepositories;
            _productInCategoryRepositories = productInCategoryRepositories;
            _detailRepositories = productDetailRepositories;
            _sizeRepositories = sizeRepositories;
            _colorRepositories = colorRepositories;
            _productVariationRepositories = productVariationRepositories;
        }
        public async Task<DataForProductFilter> GetDataForFilter()
        {
            return new DataForProductFilter()
            {
                Colors = await _colorRepositories.GetAllForCreate(),
                Sizes = await _sizeRepositories.GetAllForCreate(),
                Categories = await _categoryRepositories.GetAllForCreate(),
            };
        }
        public async Task<bool> ChangeStatus(ChangeStatusProductRequest request)
        {
            var item = await _productRepositories.GetAsync(new object[] { request.Id });
            item.Status = request.Status;
            return await _productRepositories.UpdateOneAsync(item);
        }

        public async Task<bool> Create(AddProductRequest request, bool dispose)
        {
            var productdetail = new ProductDetail()
            {
                Description = request.Description,
                Details = request.Details,
                Gender = request.Gender,
                ManufacturerId = request.ManufacturerId,
                Name = request.Name,
                UnitId = request.UnitId
            };
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Status = request.Status,
                DateCreated = DateTime.Now,
                ProductDetail = productdetail
            };
            //Save image
            if (request.Images != null)
            {
                var imgCount = request.Images.Count;
                if (imgCount > 0)
                {
                    product.ProductImages = new List<ProductImage>();
                    var lstimg = new List<ProductImage>();
                    for (int i = 0; i < imgCount; i++)
                    {
                        lstimg.Add(new ProductImage()
                        {
                            ImagePath = await SaveFile(request.Images[i])
                        });
                    };
                    product.ProductImages.AddRange(lstimg);
                }
            }
            await _productRepositories.AddOneAsync(product);

            return await _productInCategoryRepositories.AddManyAsync(request.categoryIds.Select(c => new ProductInCategory()
            {
                CategoryId = c,
                Product = product
            }));
        }

        public async Task<PagedResult<ProductInPaging>> GetAllPaging(GetPagingProductRequest request) // sẽ lấy query trong repo cho nhanh :)))
        {
            return await _productRepositories.GetAllPaging1(request);
        }

        public async Task<ProductVm> GetById(int Id) // GetDetails by Id
        {
            return await _productRepositories.GetById(Id);
        }

        public async Task<bool> Update(UpdateProductRequest request, bool dispose)
        {
            try
            {
                var productdetail = await _detailRepositories.GetAsync(new object[] { request.Id });
                productdetail.ManufacturerId = request.ManufacturerId;
                productdetail.UnitId = request.UnitId;
                productdetail.Name = request.Name;
                productdetail.Details = request.Details;
                productdetail.Description = request.Description;
                productdetail.Gender = request.Gender;
                await _detailRepositories.UpdateOneAsync(productdetail);
                var product = await _productRepositories.GetAsync(new object[] { request.Id });
                product.Status = request.Status;
                product.OriginalPrice = request.OriginalPrice;
                product.Price = request.Price;
                await _productRepositories.UpdateOneAsync(product);
                //DeleteImage
                var deletedimgCount = request.DeletedImgs.Count;
                if (deletedimgCount > 0)
                {
                    if (await _productImageRepositories.DeleteManyByRequest(new DeleteImageRequest()
                    {
                        ProductId = request.Id,
                        Paths = request.DeletedImgs.ToArray()
                    }))
                    {
                        for (int i = 0; i < deletedimgCount; i++)
                        {
                            var path = request.DeletedImgs[i];
                            await _storageService.DeleteFileAsync(path);
                        };
                    }
                }
                //Save image
                var imgCount = request.NewImgs.Count;
                if (imgCount > 0)
                {
                    var lstimg = new List<ProductImage>();
                    for (int i = 0; i < imgCount; i++)
                    {
                        lstimg.Add(new ProductImage()
                        {
                            ImagePath = await SaveFile(request.NewImgs[i]),
                            ProductId = request.Id
                        });
                    };
                    await _productImageRepositories.AddManyAsync(lstimg);
                }

                await _productInCategoryRepositories.AddManyAsync(request.NewCategories.Select(c => new ProductInCategory()
                {
                    CategoryId = c,
                    ProductId = product.Id,
                }));
                await _productInCategoryRepositories.DeleteManyAsync(request.DeletedCategories.Select(c => new ProductInCategory()
                {
                    CategoryId = c,
                    ProductId = product.Id,
                }));
                return true;
            }
            catch 
            {

                return false;
            }
        }
        public async Task<string> SaveFile(string path)
        {
            Stream stream = File.OpenRead(path);
            var originalFileName = Path.GetFileName(path);
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(stream, fileName);
            return "C:\\Users\\taduy\\source\\repos\\DuAnQLBH_PE_Shop\\App.Business\\" + USER_CONTENT_FOLDER_NAME + @"\" + fileName;
        }

        public async Task<CreateProductView> GetDataForCreate()
        {
            var categories = await _categoryRepositories.GetAllForCreate();
            var Manufacturers = await _manufacturerRepositories.GetAllForCreate();
            var Units = await _unitRepositories.GetAllForCreate();
            var products = new List<Product>();
            return new CreateProductView()
            {
                categories = categories,
                Manufacturers = Manufacturers,
                Units = Units
            };
        }

        public async Task<bool> ContainsName(string name)
        {
            return await _detailRepositories.ContainsName(name);
        }
        public async Task<List<ProductVariation>> GetPvbyId (int productid)
        {
            return await _productVariationRepositories.GetByProductId(productid);
        }
    }
}
