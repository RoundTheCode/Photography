using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Infrastructure.Types
{
    public partial interface IBaseInsertService<TEntity> where TEntity : class, IBaseEntity
    {
        Task<TEntity> InsertAsync(TEntity entity);
    }
}
