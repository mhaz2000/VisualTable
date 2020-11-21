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
            table.Values = _unitOfWork.ShowingTable.GetFullTable(table.ChosenName);
            return table;
        }

        //Gets all table name.
        public List<string> GetTableNames()
        {
            return _unitOfWork.ShowingTable.GetAllTableName();
        }
    }
}
