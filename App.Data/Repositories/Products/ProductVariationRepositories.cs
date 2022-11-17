using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
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

        public Task<bool> GetPaging(bool status, string keyword, bool[] oder, bool[] oderby)
        {
            throw new NotImplementedException();
        }
    }
}
