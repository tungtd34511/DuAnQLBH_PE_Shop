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
        Task<bool> AddOneAsync(TEntity entity); // thêm 1
        Task<bool> AddManyAsync(IEnumerable<TEntity> entity); // thêm một loạt
        // Các phương thức xóa
        Task<bool> DeleteOneAsync(object[] keys);  // Xóa 1
        Task<bool> DeleteManyAsync(IEnumerable<TEntity> entity); // Xóa 1 loạt
        // Các phương thức sửa
        Task<bool> UpdateOneAsync(TEntity entity); // Sửa 1

    }
}
