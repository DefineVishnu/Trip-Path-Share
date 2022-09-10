using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Trip.Path.Share.Common.Base;

namespace Trip.Path.Share.Common.Repository
{
    internal abstract class AsyncContextRepository<TDbContext, TEntity, TIdentity> :
        IAsyncContextRepository<TDbContext, TEntity, TIdentity>
        where TEntity : BaseEntity<TIdentity>
        where TDbContext : DbContext
    {

        readonly TDbContext _context;
        public AsyncContextRepository(TDbContext context)
        {
            _context = context;
        }

        private DbSet<TEntity> DbSet => _context.Set<TEntity>();
        public virtual  TEntity GetByIdentity(TIdentity id) => DbSet.Find(id);
        public virtual IQueryable<TEntity> Queryable() => DbSet.AsQueryable();
        public virtual  TEntity Add(TEntity newEntity)
        {
            var addedEntity = _context.Add(newEntity);
            return addedEntity.Entity;
        }
        public virtual  bool AddRange(IEnumerable<TEntity> newEntity)
        {
            DbSet.AddRange(newEntity);
            return true;
        }
        public virtual  TEntity Delete(TEntity removeEntity)
        {
            var removedEntity = DbSet.Remove(removeEntity);
            return removedEntity.Entity;
        }
        public virtual  bool DeleteRange(IEnumerable<TEntity> newEntity)
        {
            DbSet.RemoveRange(newEntity);
            return true;
        }
        public virtual  TEntity Update(TEntity updateEntity)
        {
            DbSet.Attach(updateEntity).State = EntityState.Modified;
            return updateEntity;

        }
        public virtual  bool UpdateRange(IEnumerable<TEntity> newEntity)
        {
            foreach (var entity in newEntity)
            {
                Update(entity);
            }

            return true;
        }
    }
}
