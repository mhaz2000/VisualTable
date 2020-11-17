using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Visual.Context;
using Visual.DTOs;

namespace Visual.Services.TableAddingValueService
{
    public class AddValueTableService : IAddValueTableService
    {
        private VisualDB _db;
        //make an instance of our data base
        public AddValueTableService()
        {
            _db = new VisualDB();
        }

        //Adds new values to a table by a given name.
        public void AddValueToTable(AddNewValueDto table)
        {
            Guid rowID = Guid.NewGuid();
            Guid[] FieldsIDs = GetAllFieldNamesID(table.ChosenName);

            for(int i = 0; i < table.FieldValues.Length; i++)
            {
                _db.FieldValues.Add(new Models.FieldValue(table.FieldValues[i], FieldsIDs[i], rowID));
            }
            Save();
        }

        //Gets a list of field names.
        public List<string> GetAllFieldNames(string tableName)
        {
            return _db.FieldNames.Where(w => w.Table.TableName == tableName).Select(s => s.Name).ToList();
        }

        //Gets an array of field names ids
        public Guid[] GetAllFieldNamesID(string tableName)
        {
            return _db.FieldNames.Where(w => w.Table.TableName == tableName).Select(s => s.FieldNameId).ToArray();
        }

        //Gets all table names.
        public List<string> GetAllTableName()
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