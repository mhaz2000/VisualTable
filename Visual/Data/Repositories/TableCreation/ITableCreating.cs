using Common;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ITableCreating : IRepository<Table>
    {
        void AddNewTable(string tableName, string[] FieldNames, FieldTypes[] fieldTypes);
    }
}
