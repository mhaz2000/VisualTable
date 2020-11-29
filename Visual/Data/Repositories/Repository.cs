using Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    class Repository<T> : IRepository<T> where T : class
    {
        private VisualDB _db;
        private DbSet<T> _entity;

        public Repository(VisualDB db)
        {
            _db = db;
            _entity = _db.Set<T>();
        }

        public void Add(T entity)
        {
            _entity.Add(entity);
        }

        public void Add<TEnitiy>(TEnitiy enitiy) where TEnitiy:class
        {
            _db.Set<TEnitiy>().Add(enitiy);
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> set = _db.Set<T>();
            foreach (var includeExpression in includeExpressions)
            {
                set = set.Include(includeExpression);
            }
            return set;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
