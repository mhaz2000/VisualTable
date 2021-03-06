﻿using Common;
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
        public TableCreating(VisualDB db) : base(db)
        {

        }
        // Adds new table into data base.
        public void AddNewTable(string tableName, string[] FieldNames, FieldTypes[] fieldTypes)
        {
            Table table = new Table(tableName);
            Log log = new Log();
            table.Log = log;


            Add<Log>(log);
            //_db.Logs.Add(log);
            Add(table);
            //_db.Tables.Add(table);

            for (int i = 0; i < FieldNames.Length; i++)
            {
                Add<FieldName>(new FieldName(FieldNames[i], fieldTypes[i], table.TableId));
                //_db.FieldNames.Add(new FieldName(FieldNames[i], fieldTypes[i], table.TableId));
            }

            Save();
        }
    }
}
