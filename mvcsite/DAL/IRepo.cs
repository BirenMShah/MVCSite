using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mvcsite.DAL
{
    public interface IRepo<T> where T: class
    {
        void Add(T obj); //C
        T GetById(object id); //R
        IEnumerable<T> GetAll(); //R
        IQueryable<T> Find(Expression<Func<T, bool>> predicate); //R
        void Update(T obj); //U
        void Delete(object id); //D
    }
}
