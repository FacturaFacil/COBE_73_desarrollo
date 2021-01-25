using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Admin.AccesoDatos.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        //T Get(int folio, int id_sucursal, decimal id_dist);

        //T GetD(int id,decimal id_dist);

        //T GetM(decimal id);

        //T GetS(string id);

        T Get(decimal id_dist);
        IEnumerable<T> GetAll(        
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        void Add(T entity);

        void Remove(int id, int id_dist);

        void RemoveD(int folio, string id_clase_movimiento, int id_dist);

        void Remove(T entity);

    }
}
