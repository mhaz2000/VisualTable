using Common.DTOs;
using Data.DataUnitOfWork;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AddValueToTableService
{
    public class AddingService : IAddingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //add values to a table.
        public void AddValueToTable(AddValueDto table)
        {
            _unitOfWork.AddingValue.AddValueToTable(table.FieldValues, table.ChosenName);
        }

        //Gets Fields name.
        public List<string> GetTableFieldNames(AddValueDto table)
        {
            return _unitOfWork.AddingValue.GetAll().Where(t=>t.Table.TableName==table.ChosenName).Select(t=>t.Name).ToList();
        }

        //Gets all table names.
        public List<string> GetTableNames()
        {
            var names=_unitOfWork.TableCreating.GetAll();
            return names.Select(s => s.TableName).Distinct().ToList();
        }
    }
}
