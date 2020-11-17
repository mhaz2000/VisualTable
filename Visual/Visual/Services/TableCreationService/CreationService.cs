using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Visual.Context;
using Visual.DTOs;
using Visual.Models;
using Visual.Common.Messages;

namespace Visual.Services.TableCreationService
{
    public class CreationService : ICreationService
    {
        private VisualDB _db;
        //make an instance of our data base
        public CreationService()
        {
            _db = new VisualDB();
        }
        //Add new table and log it in database.
        public TableStructionDto CheckNewTable(TableStructionDto tableStruction)
        {
            var names=GetAllTableNames();

            //Checks if the given name is repetitive or not.
            if (names.Where(w => w.Contains(tableStruction.tableName)).Any())
            {
                tableStruction.Message = Message.RepetitiveTableName();
                tableStruction.FieldNumber = 0;
                return tableStruction;
            }

            tableStruction.Message = Message.AcceptableName();

            
            return tableStruction;
        }
        //Add field names and types to a table.
        public void AddTable(TableStructionDto tableStruction)
        {
            Table table = new Table(tableStruction.tableName);
            Log log = new Log();
            table.Log = log;

            _db.Logs.Add(log);
            _db.Tables.Add(table);

            for (int i = 0; i < tableStruction.FieldNames.Length; i++)
            {
                _db.FieldNames.Add(new FieldName(tableStruction.FieldNames[i], tableStruction.FieldTypes[i], table.TableId));
            }

            Save();
        }
        //Gets all table names.
        public List<string> GetAllTableNames()
        {
            return _db.Tables.Select(s => s.TableName).ToList();
        }
        //Save all changes.
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}