using System;
using System.Collections.Generic;
using System.Text;

namespace Photography.Infrastructure.Types
{
    public partial interface IBaseInsertService<TEntity> where TEntity : class, IBaseEntity
    {
        TEntity Insert(TEntity entity);
    }
}
