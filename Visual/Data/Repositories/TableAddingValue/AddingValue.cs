using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.TableAddingValue
{
    class AddingValue : Repository<FieldName>, IAddingValue
    {
        public AddingValue(VisualDB db):base(db)
        {

        }
        //Add value to table.
        public void AddValueToTable(string[] tableValues, string tableName)
        {
            Guid rowID = Guid.NewGuid();
            Guid[] FieldsIDs = GetAll().Where(w=>w.Table.TableName==tableName).Select(t=>t.FieldNameId).ToArray();

            for (int i = 0; i < tableValues.Length; i++)
            {
                Add<FieldValue>(new Models.FieldValue(tableValues[i], FieldsIDs[i], rowID));
                //_db.FieldValues.Add(new Models.FieldValue(tableValues[i], FieldsIDs[i], rowID));
            }
            Save();
        }
    }
}
