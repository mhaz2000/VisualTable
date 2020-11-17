using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual.DTOs;

namespace Visual.Services.TableShowingService
{
    interface IShowTableService
    {
        List<string> GetAllTableNames();
        ShowTableDto GetFullTable(ShowTableDto table);
    }
}
