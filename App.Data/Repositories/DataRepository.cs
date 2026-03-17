using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Repositories
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class
    {
        private readonly OrganikBahceDbContext _db;
        private readonly DbSet<TEntity> _table;

        public DataRepository(OrganikBahceDbContext db)
        {
            _db = db;
            _table = _db.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
