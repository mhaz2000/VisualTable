using Common;
using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.TableCreation
{
    class TableCreating : Repository<Table>, ITableCreating
    {
        private VisualDB _db;

        public TableCreating()
        {
            _db = new VisualDB();
        }
        // Adds new table into data base.
        public void AddNewTable(string tableName, string[] FieldNames, FieldTypes[] fieldTypes)
        {
            Table table = new Table(tableName);
            Log log = new Log();
            table.Log = log;

            _db.Logs.Add(log);
            _db.Tables.Add(table);

            for (int i = 0; i < FieldNames.Length; i++)
            {
                _db.FieldNames.Add(new FieldName(FieldNames[i], fieldTypes[i], table.TableId));
            }

            _db.SaveChanges();
        }
    }
}
