using Photography.Infrastructure.DbContext;
using System;
using System.Linq;
using Photography.Infrastructure.Helpers;

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
            return _entities.FirstOrDefault(x => x.Id == id);
        }

        protected virtual TEntity GetByHash(string hash)
        {
            return _entities.FirstOrDefault(x => x.Hash == hash);
        }


        protected virtual TEntity Insert(TEntity entity)
        {
            entity.Created = DateTimeOffset.Now;
            entity.Enabled = true;
            entity.Hash = Guid.NewGuid().ToString().ToMD5();

            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            entity.Id = _context.SaveChanges();

            return entity;
        }
    }
}
