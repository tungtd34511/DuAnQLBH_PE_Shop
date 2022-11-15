using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Base
{
    public interface IBaseRepositories<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(object[] keys); // Lấy 1
        Task<IEnumerable<TEntity>> GetAllAsync(); // Lấy tất
        // Các phương thức thêm
        Task<bool> AddOneAsyn(TEntity entity); // thêm 1
        Task<bool> AddManyAsyn(IEnumerable<TEntity> entity); // thêm một loạt
        // Các phương thức xóa
        Task<bool> DeleteOneAsyn(object[] keys);  // Xóa 1
        Task<bool> DeleteManyAsyn(IEnumerable<TEntity> entity); // Xóa 1 loạt
        // Các phương thức sửa
        Task<bool> UpdateOneAsyn(TEntity entity); // Sửa 1
        Task<bool> UpdateManyAsyn(IEnumerable<TEntity> entity); // Sửa 1 loạt

    }
}
