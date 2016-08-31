using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace TvContext
{
    public sealed class BaseRepository<TEntity> where TEntity : IdentificableEntity
    {
        public TvDbContext ContextDb { get; } = new TvDbContext();

        public BaseRepository()
        {

        }

        public BaseRepository(TvDbContext context)
        {
            ContextDb = context;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return ContextDb.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return ContextDb.Set<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            try
            {
                ContextDb.Set<TEntity>().Remove(entity);
                ContextDb.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                MessageBox.Show("Что-то пошло не так при операции АПДЕЙТ!");
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation(
                            "Class: {0}, Property: {1}, Error: {2}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException?.Message, "Error");
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                ContextDb.Entry(entity).State = EntityState.Modified;
                ContextDb.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                MessageBox.Show("Что-то пошло не так при операции АПДЕЙТ!");
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation(
                            "Class: {0}, Property: {1}, Error: {2}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }

        }

        public void Insert(TEntity entity)
        {
            try
            {
                ContextDb.Entry(entity).State = EntityState.Added;
                ContextDb.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                MessageBox.Show("Что-то пошло не так при операции ИНСЕРТ!");

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation(
                            "Class: {0}, Property: {1}, Error: {2}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }


        //todo needs to Rewrite for any TEntity
        public void AddRange(IEnumerable<OrderChannel> channels)
        {
            ContextDb.OrderChannels.AddRange(channels);
            ContextDb.SaveChanges();
        }

        public void RemoveRange(IEnumerable<OrderChannel> deleteChann)
        {
            ContextDb.OrderChannels.RemoveRange(deleteChann);
            ContextDb.SaveChanges();
        }
    }
}