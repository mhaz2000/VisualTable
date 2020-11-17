using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual.DTOs;

namespace Visual.Services.TableAddingValueService
{
    interface IAddValueTableService
    {
        List<string> GetAllTableName();
        Guid[] GetAllFieldNamesID(string tableName);
        List<string> GetAllFieldNames(string tableName);
        void AddValueToTable(AddNewValueDto table);
        void Save();
    }
}
