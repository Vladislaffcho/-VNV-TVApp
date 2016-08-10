using System;
using System.Linq;
using System.Linq.Expressions;

namespace TVContext
{
    public class BaseRepository<TEntity> where TEntity : IdentificableEntity
    {
        private TvDBContext Context = new TvDBContext();

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            var type = typeof(TEntity);
            return Context.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            var type = typeof(TEntity);
            return Context.Set<TEntity>();
        }
    }
}