using System;
using System.Collections.Generic;
using System.Text;

namespace Photography.Infrastructure.Types
{
    public partial interface IBaseSelectService<TEntity> where TEntity : class, IBaseEntity
    {
        TEntity GetById(int id);

        TEntity GetByHash(string hash);
    }
}
