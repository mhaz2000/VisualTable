using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions);
        void Add(T enitiy);
        void Add<TEnitiy>(TEnitiy enitiy) where TEnitiy : class;
        void Save();
    }
}
