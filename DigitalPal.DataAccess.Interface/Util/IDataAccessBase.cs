using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DigitalPal.DataAccess.Interface
{
    public interface IDataAccessBase<T> where T : class
    {
        T[] Add(T[] items);

        void Remove(T item);

        void Update(T item);

        T FindById(Guid id);

        List<T> FindByIds(List<Guid> ids);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindByTempTableIds(string query, IEnumerable<Guid> Ids);

        IEnumerable<T> Find(string query);

        IEnumerable<T> FindAll();

        IEnumerable<dynamic> FindDynamic(string query, object paramValues);

        IEnumerable<T> FindPage(int pageNumber, int pageSize, string sortProperty, bool sortDescending,
            Expression<Func<T, bool>> expression);
    }
}
