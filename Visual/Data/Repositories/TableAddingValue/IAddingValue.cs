using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IAddingValue:IRepository<FieldValue>
    {
        Guid[] GetAllFieldNamesID(string tableName);
        List<string> GetAllFieldNames(string tableName);
        void AddValueToTable(string[] tableValues, string tableName);

    }
}
