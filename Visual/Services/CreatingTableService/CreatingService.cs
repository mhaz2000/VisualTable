using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataUnitOfWork;
using Common.Messages;

namespace Services.CreatingTableService
{
    public class CreatingService : ICreatingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddTable(TableCreatingDto table)
        {
            _unitOfWork.TableCreating.AddNewTable(table.tableName, table.FieldNames, table.FieldTypes);
        }

        public TableCreatingDto CheckNewTable(TableCreatingDto table)
        {
            var names = _unitOfWork.TableCreating.GetAll().Select(t=>t.TableName);

            //Checks if the given name is repetitive or not.
            if (names.Where(w => w.Contains(table.tableName)).Any())
            {
                table.Message = Message.RepetitiveTableName();
                table.FieldNumber = 0;
                return table;
            }
            table.Message = Message.AcceptableName();

            return table;
        }
    }
}
