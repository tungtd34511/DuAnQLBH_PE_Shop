
using App.Business.Ultilities.Common;
using App.Data.Entities;
using App.Data.Repositories.Catalog.Images;
using App.Data.Repositories.Customers;
using App.Data.Repositories.Products;
using App.Data.Ultilities.Catalog.Product;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.PagingModels;
using App.Data.Ultilities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Products
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepositories _productRepositories;
        private readonly IProductDetailRepositories _productDetailRepositories;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "Images";
        private readonly IProductImageRepositories _productImageRepositories;
        public ProductServices(IProductRepositories productRepositories, IProductDetailRepositories productDetailRepositories, IStorageService storageService, IProductImageRepositories productImageRepositories)
        {
            _productRepositories = productRepositories;
            _productDetailRepositories = productDetailRepositories;
            _storageService = storageService;
            _productImageRepositories = productImageRepositories;
        }

        public async Task<bool> ChangeStatus(ChangeStatusProductRequest request)
        {
            var item = await _productRepositories.GetAsync(new object[] { request.Id });
            item.Status = request.Status;
            return await _productRepositories.UpdateOneAsync(item);
        }

        public async Task<bool> Create(AddProductRequest request)
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
            }
            return await _productRepositories.AddOneAsync(product);
        }

        public async Task<PagedResult<ProductInPaging>> GetAllPaging(GetPagingProductRequest request) // sẽ lấy query trong repo cho nhanh :)))
        {
            return await _productRepositories.GetAllPaging1(request);
        }

        public async Task<ProductVm> GetById(int Id) // GetDetails by Id
        {
            return await _productRepositories.GetById(Id);
        }

        public async Task<bool> Update(UpdateProductRequest request)
        {
            var productdetail = new ProductDetail()
            {
                ProductId = request.Id,
                Description = request.Description,
                Details = request.Details,
                Gender = request.Gender,
                ManufacturerId = request.ManufacturerId,
                Name = request.Name,
                UnitId = request.UnitId
            };
            var product = new Product()
            {
                Id = request.Id,
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Status = request.Status,
                DateCreated = DateTime.Now,
                ProductDetail = productdetail
            };
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
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                    };
                }
            }
            //Save image
            var imgCount = request.NewImgs.Count;
            if (imgCount > 0)
            {
                product.ProductImages = new List<ProductImage>();
                var lstimg = new List<ProductImage>();
                for (int i = 0; i < imgCount; i++)
                {
                    lstimg.Add(new ProductImage()
                    {
                        ImagePath = await SaveFile(request.NewImgs[i])
                    });
                };
            }
            return await _productRepositories.UpdateOneAsync(product);
        }
        public async Task<string> SaveFile(string path)
        {
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                var originalFileName = Path.GetFileName(path);
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
                await _storageService.SaveFileAsync(stream, fileName);
                return @"C:\Users\taduy\Desktop\DuAnQLBH_PE_Shop\App.Business\" + USER_CONTENT_FOLDER_NAME + @"\" + fileName;
            }
        }
    }
}
