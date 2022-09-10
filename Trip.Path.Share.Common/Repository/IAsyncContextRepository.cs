using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Trip.Path.Share.Common.Base;

namespace Trip.Path.Share.Common.Repository
{
    public interface IAsyncContextRepository<TDbContext, TEntity, TIdentity>
        where TEntity : BaseEntity<TIdentity>
        where TDbContext : DbContext
    {
        TEntity GetByIdentity(TIdentity id);
        IQueryable<TEntity> Queryable();
        TEntity Add(TEntity newEntity);
        bool AddRange(IEnumerable<TEntity> newEntity);
        bool UpdateRange(IEnumerable<TEntity> newEntity);
        bool DeleteRange(IEnumerable<TEntity> newEntity);
        TEntity Update(TEntity newEntity);
        TEntity Delete(TEntity identity);

    }
}
