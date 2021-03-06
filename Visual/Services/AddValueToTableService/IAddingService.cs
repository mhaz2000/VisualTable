﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs;

namespace Services.AddValueToTableService
{
    public interface IAddingService
    {
        void AddValueToTable(AddValueDto table);
        AddValueDto GetTableNames();
        List<string> GetTableFieldNames(AddValueDto table);
        AddValueDto TableStructure(AddValueDto table);
    }
}
