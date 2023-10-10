using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Interfaces.Layout
{
    /// <summary>
    /// interface qui implémente les méthodes communes  à toutes les classes de datalayer
    /// ce sont ces classes qui accèdent à la base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataLayer<T> where T : class
    {
        public T? GetById(int id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> Find(Expression<Func<T,bool>> predicate);
        public void Add (T entity);
        public void Remove (T entity);
        public void AddRange(IEnumerable<T> entities);
        public void RemoveRange(IEnumerable<T> entities);
        public void Update(T entity);

    }
}
