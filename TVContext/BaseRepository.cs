using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace TvContext
{
    public sealed class BaseRepository<TEntity> where TEntity : IdentificableEntity
    {
        //private static TvDBContext _context { get; } = new TvDBContext();

        private static TvDbContext _context;

        private static TvDbContext ContextInstance
        {
            get
            {
                if(_context == null)
                    _context = new TvDbContext();
                return _context;
            }
            //set { _context = value; }
        }

        public BaseRepository()
        {

        }


        //public BaseRepository(TvDBContext context)
        //{
        //    _context = context;
        //}

        public static IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            //return _context.Set<TEntity>().Where(predicate);
            return ContextInstance.Set<TEntity>().Where(predicate);
        }

        public static IQueryable<TEntity> GetAll()
        {
            //return _context.Set<TEntity>();
            return ContextInstance.Set<TEntity>();
        }

        public static void Remove(TEntity entity)
        {
            try
            {
                //_context.Set<TEntity>().Remove(entity);
                ContextInstance.Set<TEntity>().Remove(entity);
                ContextInstance.SaveChanges();
                //_context.SaveChanges();
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

        public static void Update(TEntity entity)
        {
            try
            {
                //_context.Entry(entity).State = EntityState.Modified;
                ContextInstance.Entry(entity).State = EntityState.Modified;
                ContextInstance.SaveChanges();
                //_context.SaveChanges();
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

        public static void Insert(TEntity entity)
        {
            try
            {
                //_context.Entry(entity).State = EntityState.Added;
                ContextInstance.Entry(entity).State = EntityState.Added;
                ContextInstance.SaveChanges();
                //_context.SaveChanges();
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
        public static void AddRange(List<OrderChannel> channels)
        {
            //_context.OrderChannels.AddRange(channels);
            ContextInstance.OrderChannels.AddRange(channels);
            ContextInstance.SaveChanges();
            //_context.SaveChanges();
        }

        public static void RemoveRange(List<OrderChannel> deleteChann)
        {
            //_context.OrderChannels.RemoveRange(deleteChann);
            ContextInstance.OrderChannels.RemoveRange(deleteChann);
            ContextInstance.SaveChanges();
            //_context.SaveChanges();
        }
    }
}