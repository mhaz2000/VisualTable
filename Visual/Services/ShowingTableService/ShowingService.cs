using Common.DTOs;
using Data.DataUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ShowingTableService
{
    public class ShowingService : IShowingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShowingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //gets a full table by a given name.
        public ShowTableDto GetFullTable(ShowTableDto table)
        {
            var newTable = GetTableNames();
            newTable.Values = _unitOfWork.ShowingTable.GetFullTable(table.ChosenName);
            return newTable;
        }

        //Gets all table name.
        public ShowTableDto GetTableNames()
        {
            ShowTableDto table = new ShowTableDto(_unitOfWork.ShowingTable.GetAll().Select(s => s.FieldName.Table.TableName).Distinct().ToList());
            return table;
        }
    }
}
