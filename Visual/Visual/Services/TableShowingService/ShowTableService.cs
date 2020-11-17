using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Visual.Context;
using Visual.DTOs;

namespace Visual.Services.TableShowingService
{
    public class ShowTableService : IShowTableService
    {
        private VisualDB _db;
        //make an instance of our data base
        public ShowTableService()
        {
            _db = new VisualDB();
        }
        //Gets a list of table names.
        public List<string> GetAllTableNames()
        {
            return _db.Tables.Select(s => s.TableName).ToList();
        }
        //Gets a full table according to its name.
        public ShowTableDto GetFullTable(ShowTableDto table)
        {
            table.Values = new List<string[]>();
            //get all row ids
            var rowIds = _db.FieldValues.OrderBy(o => o.FieldName.Name).Where(w => w.FieldName.Table.TableName == table.ChosenName).Select(s => s.RowID).Distinct().ToList();

            //add field names
            table.Values.Add(_db.FieldNames.OrderBy(o => o.Name).Where(w => w.Table.TableName == table.ChosenName).Select(s => s.Name).ToArray());

            //add field values
            foreach (var index in rowIds)
            {
                table.Values.Add(_db.FieldValues.OrderBy(o => o.FieldName.Name).Where(w => w.RowID == index && w.FieldName.Table.TableName == table.ChosenName)
                    .Select(s => s.Value).ToArray());
            }

            return table;
        }
    }
}