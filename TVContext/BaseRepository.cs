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
    // class provides db interaction functionality
    // Repository pattern was applied here
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
                MessageBox.Show("Something went wrong while REMOVING data!");
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

        public void Update(TEntity entity)
        {
            try
            {
                ContextDb.Entry(entity).State = EntityState.Modified;
                ContextDb.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                MessageBox.Show("Something went wrong while UPDATING data!");
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
                MessageBox.Show("Something went wrong while INSERTING data!");

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
            try
            {
                ContextDb.OrderChannels.AddRange(channels);
                ContextDb.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                MessageBox.Show("Something went wrong while executing AddRange-OrderChannel operation!");

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

        public void RemoveRange(IEnumerable<OrderChannel> deleteChann)
        {
            ContextDb.OrderChannels.RemoveRange(deleteChann);
            ContextDb.SaveChanges();
        }

        public void AddRange(IEnumerable<UserSchedule> userSchedule)
        {
            try
            {
                ContextDb.UserSchedules.AddRange(userSchedule);
                ContextDb.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                MessageBox.Show("Something went wrong while INSERTING data!");

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

        public void RemoveRange(IEnumerable<UserSchedule> deleteUserSchedules)
        {
            ContextDb.UserSchedules.RemoveRange(deleteUserSchedules);
            ContextDb.SaveChanges();
        }

        public void AddRange(IEnumerable<Channel> channels)
        {
            ContextDb.Channels.AddRange(channels);
            ContextDb.SaveChanges();
        }

        public async void AddRange(IEnumerable<TvShow> tvShowList)
        {
            ContextDb.TvShows.AddRange(tvShowList);
            await ContextDb.SaveChangesAsync();
        }

        public void Clear(int userId)
        {
            var oldOrderedChannels = ContextDb.OrderChannels.Where(orCh => orCh.Order == null
                && orCh.User.Id == userId);
            ContextDb.OrderChannels.RemoveRange(oldOrderedChannels);
            ContextDb.SaveChanges();
        }

        
    }
}