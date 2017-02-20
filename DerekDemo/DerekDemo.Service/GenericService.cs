using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DerekDemo.Service
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        // Should be private
        public DbContext _context;

        public GenericService(DbContext context)
        {
            this._context = context;
        }
        
        public virtual ICollection<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            IQueryable<T> dbQuery = _context.Set<T>().Where(predicate);

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .ToList<T>();
            return list;
        }

        public virtual ICollection<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            // This hangs don't know why

            IQueryable<T> dbQuery = _context.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            return dbQuery.AsNoTracking().ToList();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Set<T>().Add(entity);
            }
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
    public interface IGenericService<T> where T : class
    {
        ICollection<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        ICollection<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties);
        void Add(T entity);
        void Update(T entity);
        void SaveChanges();
    }
}
