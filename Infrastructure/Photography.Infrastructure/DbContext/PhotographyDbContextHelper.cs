using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photography.Infrastructure.Types;

namespace Photography.Infrastructure.DbContext
{
    public static class PhotographyDbContextHelper
    {
        public static IQueryable<TEntity> GetFilter<TEntity>(this ICollection<TEntity> query, bool includeDisabled = false, bool includeDeleted = false) where TEntity : class, IBaseEntity
        {
            if (query == null)
            {
                return null;
            }

            return GetFilter(query.AsQueryable(), includeDisabled, includeDeleted);
        }

        public static IQueryable<TEntity> GetFilter<TEntity>(this IQueryable<TEntity> query, bool includeDisabled = false, bool includeDeleted = false) where TEntity : class, IBaseEntity
        {
            if (!includeDisabled)
            {
                query = query.Where(x => x.Enabled);
            }
            if (!includeDeleted)
            {
                query = query.Where(x => !x.Deleted.HasValue);
            }

            return query;
        }        
    }
}
