using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ShowingTableService
{
    public interface IShowingService
    {
        ShowTableDto GetFullTable(ShowTableDto table);
        ShowTableDto GetTableNames();

    }
}
