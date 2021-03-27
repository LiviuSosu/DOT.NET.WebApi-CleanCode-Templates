using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DatabaseContext DbContext { get; set; }

        public RepositoryBase(DatabaseContext careerTrackDbContext)
        {
            this.DbContext = careerTrackDbContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.DbContext.Set<T>().AsNoTracking();
        }

        //public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        //{
        //    return this.DbContext.Set<T>().Where(expression).AsNoTracking();
        //}

        //public async Task<T> FindByIdAsync(Guid Id)
        //{
        //    return await this.CareerTrackDbContext.Set<T>().FindAsync(Id);
        //}

        //public void Create(T entity)
        //{
        //    this.CareerTrackDbContext.Set<T>().Add(entity);
        //}

        //public void Update(T entity)
        //{
        //    this.CareerTrackDbContext.Set<T>().Update(entity);
        //}

        //public void Delete(T entity)
        //{
        //    this.CareerTrackDbContext.Set<T>().Remove(entity);
        //}
    }
}
