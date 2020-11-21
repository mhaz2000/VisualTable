using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.TableAddingValue
{
    class AddingValue : Repository<FieldValue>, IAddingValue
    {
        private VisualDB _db;
        public AddingValue()
        {
            _db = new VisualDB();
        }
        //Add value to table.
        public void AddValueToTable(string[] tableValues, string tableName)
        {
            Guid rowID = Guid.NewGuid();
            Guid[] FieldsIDs = GetAllFieldNamesID(tableName);

            for (int i = 0; i < tableValues.Length; i++)
            {
                _db.FieldValues.Add(new Models.FieldValue(tableValues[i], FieldsIDs[i], rowID));
            }
            _db.SaveChanges();
        }

        //Get all field names in a specific table.
        public List<string> GetAllFieldNames(string tableName)
        {
            return _db.FieldNames.Where(w => w.Table.TableName == tableName).Select(s => s.Name).ToList();
        }
        //gets all field names id in specific table.
        public Guid[] GetAllFieldNamesID(string tableName)
        {
            return _db.FieldNames.Where(w => w.Table.TableName == tableName).Select(s => s.FieldNameId).ToArray();
        }
    }
}
