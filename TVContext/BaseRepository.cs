using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TVContext
{
    public class BaseRepository<TEntity> where TEntity : IdentificableEntity
    {
        private readonly TvDBContext _context = new TvDBContext();

        public BaseRepository()
        {
            
        }

        public BaseRepository(TvDBContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            /* Get an error when try to modify _context using the below method*/
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Insert(TEntity entity)
        {
            /* Get an error when try to add entity to the _context using any of the below methods*/
            _context.Entry(entity).State = EntityState.Added;
            /*_context.Set<TEntity>().Add(entity);*/


            _context.SaveChanges();
        }
    }
}