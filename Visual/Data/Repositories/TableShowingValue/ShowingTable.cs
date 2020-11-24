using Data.Context;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.TableShowingValue
{
    class ShowingTable : Repository<Table>, IShowingTable
    {
        
        public List<string[]> GetFullTable(string tableName)
        {
            List<string[]> Values = new List<string[]>();
            //get all row ids
            var rowIds = _db.FieldValues.OrderBy(o => o.FieldName.Name).Where(w => w.FieldName.Table.TableName == tableName).Select(s => s.RowID).Distinct().ToList();

            //add field names
            Values.Add(_db.FieldNames.OrderBy(o => o.Name).Where(w => w.Table.TableName == tableName).Select(s => s.Name).ToArray());

            //add field values
            foreach (var index in rowIds)
            {
                Values.Add(_db.FieldValues.OrderBy(o => o.FieldName.Name).Where(w => w.RowID == index && w.FieldName.Table.TableName == tableName)
                    .Select(s => s.Value).ToArray());
            }

            return Values;
        }
    }
}
