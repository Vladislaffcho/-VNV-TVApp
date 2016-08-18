using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TVContext
{
    public class BaseRepository<TEntity> where TEntity : IdentificableEntity
    {
        public readonly TvDBContext Context = new TvDBContext();

        public BaseRepository()
        {
            
        }

        public BaseRepository(TvDBContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Insert(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
        }
    }
}