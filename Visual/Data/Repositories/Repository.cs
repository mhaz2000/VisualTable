using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    class Repository<T> : IRepository<T> where T : class
    {
        protected VisualDB _db;

        public Repository()
        {
            _db = new VisualDB();
        }
        //Gets all table names.
        public List<string> GetAllTableName()
        {
            return _db.Tables.Select(s => s.TableName).ToList();
        }

        
    }
}
