using Admin.AccesoDatos.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Admin.AccesoDatos.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        //public T Get(int folio, int id_sucursal, decimal id_dist)
        //{
        //    return dbSet.Find(folio, id_sucursal, id_dist);
        //}

        //public T GetD(int id, decimal id_dist )
        //{           
        //        return dbSet.Find(id, id_dist);            
        //}

        //public T GetM(decimal id)
        //{
        //    return dbSet.Find(id);
        //}
        //public T GetS(string id)
        //{
        //    return dbSet.Find(id);
        //}

        public T Get(decimal id_dist)
        {
            return dbSet.Find(id_dist);
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
          
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //include properties separadas por comas
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //include properties separadas por comas
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(int id, int id_dist)
        {
            T entitiyToRemove = dbSet.Find(id, id_dist);
            Remove(entitiyToRemove);
        }

        public void RemoveD(int folio, string id_clase_movimiento, int id_dist)
        {
            T entitiyToRemove = dbSet.Find(folio, id_clase_movimiento, id_dist);
            Remove(entitiyToRemove);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
