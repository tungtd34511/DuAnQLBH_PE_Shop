using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Products
{
    public class ProductVariationRepositories : BaseRepositories<ProductVariation>, IProductVariationRepositories
    {
        private readonly QLBH_Context _context;
        public ProductVariationRepositories(QLBH_Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ChangeStatus(int pvId, bool status)
        {
            var pv = Entities.Find(pvId);
            if (pv == null)
                return false;
            pv.IsDeleted = status;
            Entities.Update(pv);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<List<ProductVariation>> GetByProductId(int pId)
        {
            return await Entities.Where(c=>c.ProductId== pId).ToListAsync();
        }
        public async Task<List<ProductVariationVm>> GetVMByProductId(int pId)
        {

            return await (from pv in Entities
                         join cl in _context.Colors on pv.ColorId equals cl.Id
                         join s in _context.Sizes on pv.SizeId equals s.Id
                         join pd in _context.ProductDetails on pv.ProductId equals pd.ProductId
                         where pv.IsDeleted == false && pv.Stock>0 && pv.ProductId == pId
                         select new ProductVariationVm()
                         {
                             SizeId= pv.SizeId,
                             SizeName = s.Name,
                             Stock = pv.Stock,
                             ColorId=pv.ColorId,
                             ColorName = cl.Name,
                             Id =pv.Id,
                             IsDeleted=pv.IsDeleted,
                             ProductId =pv.ProductId
                             ,
                             ProductName = pd.Name
                         }).ToListAsync();
        }
        public Task<bool> GetPaging(bool status, string keyword, bool[] oder, bool[] oderby)
        {
            throw new NotImplementedException();
        }
    }
}
