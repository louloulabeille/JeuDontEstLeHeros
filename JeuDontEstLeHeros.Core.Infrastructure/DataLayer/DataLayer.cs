using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Core.Interfaces.Layout;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontEstLeHeros.Core.Infrastructure.DataLayer
{
    /// <summary>
    /// DataLayer générique - il accède à la base à partir de entity Framework
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DataLayer<T> : IDataLayer<T> where T : class
    {
        #region propriété
        protected DbSet<T> _dbSet;
        #endregion

        #region constructeur
        public DataLayer(HerosDbcontext dbcontext)
        {
            _dbSet = dbcontext.Set<T>();
        }
        #endregion

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
