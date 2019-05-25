using Photography.Infrastructure.DbContext;
using System;
using System.Linq;
using Photography.Infrastructure.Helpers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Types
{
    public abstract class BaseService<TEntity> where TEntity : class, IBaseEntity
    {
        protected IQueryable<TEntity> _entities;
        protected PhotographyDbContext _context;

        protected BaseService(PhotographyDbContext context, IQueryable<TEntity> entities)
        {
            _context = context;
            _entities = entities.GetFilter();
        }

        protected virtual TEntity GetById(int id)
        {
            var category = GetByIdAsync(id);
            category.Wait();

            return category.Result;
        }

        protected virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        protected virtual TEntity GetByHash(string hash)
        {
            var category = GetByHashAsync(hash);
            category.Wait();

            return category.Result;
        }

        protected virtual async Task<TEntity> GetByHashAsync(string hash)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Hash == hash);
        }


        protected virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            entity.Created = DateTimeOffset.Now;
            entity.Enabled = true;
            entity.Hash = Guid.NewGuid().ToString().ToMD5();

            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            entity.Id = await _context.SaveChangesAsync();

            return entity;
        }
    }
}
