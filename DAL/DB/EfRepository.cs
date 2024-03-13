using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB
{
    public class EfRepository : IRepository
    {
        private DbContext context;

        public EfRepository(DeeplomContext dbContext)
        {
            this.context = dbContext;
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                    this.context = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void IRepository.AddAndSave<TEntity>(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
            this.context.SaveChanges();
        }

        TEntity IRepository.FirstorDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) =>
           this.context.Set<TEntity>().FirstOrDefault(predicate);

        IEnumerable<TEntity> IRepository.GetFilteredByQuery<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            return this.context.Set<TEntity>().Where<TEntity>(predicate);
        }
        
        void IRepository.RemoveAndSave<TEntity>(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
            this.context.SaveChanges();
        }

        void IRepository.UpdateAndSave<TEntity>(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }


        IEnumerable<TEntity> IRepository.GetWithInclude<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }


        IQueryable<TEntity> Include<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class, IEntity
        {
            IQueryable<TEntity> query = this.context.Set<TEntity>().AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
