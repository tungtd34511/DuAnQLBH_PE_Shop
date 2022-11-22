using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Products
{
    public interface IProductVariationRepositories : IBaseRepositories<ProductVariation>
    {
        Task<bool> ChangeStatus(int pvId, bool status);
        Task<bool> GetPaging(bool status, string keyword,bool[] oder, bool[] oderby);// trạng thái, từ khóa, sắp xếp tăng giảm, sắp xếp theo
        Task<List<ProductVariation>> GetByProductId(int pId);
        Task<List<ProductVariationVm>> GetVMByProductId(int pId);
    }
}
