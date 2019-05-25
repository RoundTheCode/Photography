using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Infrastructure.Types
{
    public partial interface IBaseSelectService<TEntity> where TEntity : class, IBaseEntity
    {
        TEntity GetById(int id);

        Task<TEntity> GetByIdAsync(int id);

        TEntity GetByHash(string hash);

        Task<TEntity> GetByHashAsync(string hash);
    }
}
