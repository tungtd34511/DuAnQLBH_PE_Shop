using App.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Base
{
    public class BaseRepositories<TEntity> : IBaseRepositories<TEntity> where TEntity : class
    {
        private readonly QLBH_Context _context;
        public DbSet<TEntity> Entities { get; set; }
        public BaseRepositories(QLBH_Context context)
        {
            _context = context;
            Entities = _context.Set<TEntity>();
        }
        public async Task<bool> AddManyAsync(IEnumerable<TEntity> entity)
        {
            Entities.AddRange(entity);
            return await _context.SaveChangesAsync() >0;
        }

        public async Task<bool> AddOneAsync(TEntity entity)
        {
            Entities.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteManyAsync(IEnumerable<TEntity> entity)
        {
            Entities.RemoveRange(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOneAsync(object[] keys)
        {
            var result = await Entities.FindAsync(keys);
            if (result == null)
                return false;
            Entities.Remove(result);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<TEntity> GetAsync(object[] keys)
        {
            var result = await Entities.FindAsync(keys);
            return result;
        }

        public async Task<bool> UpdateManyAsync(IEnumerable<TEntity> entity)
        {
            Entities.UpdateRange(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateOneAsync(TEntity entity)
        {
            Entities.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
