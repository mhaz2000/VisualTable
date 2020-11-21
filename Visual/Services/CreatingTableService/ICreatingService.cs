using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CreatingTableService
{
    public interface ICreatingService
    {
        TableCreatingDto CheckNewTable(TableCreatingDto table);
        void AddTable(TableCreatingDto table);
    }
}
