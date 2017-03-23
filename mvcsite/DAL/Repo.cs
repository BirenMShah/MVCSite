using mvcsite.data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace mvcsite.DAL
{
    public class Repo<T> : IRepo<T> where T : class
    {
        private CRMContextDB _db = null;
        private DbSet<T> _table;

        public Repo(CRMContextDB dbContext)
        {
            this._db = dbContext;
            _table = _db.Set<T>();
        }
        public void Add(T obj)
        {
            _table.Add(obj);
        }

        public void Delete(object id)
        {
            _table.Remove(_table.Find(id));
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            var query = _table.Where(predicate);
            return query;
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(object id)
        {
            return _table.Find(id);
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }

    }
}