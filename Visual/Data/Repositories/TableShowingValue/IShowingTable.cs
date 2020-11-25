﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IShowingTable:IRepository<FieldValue>
    {
        List<string[]> GetFullTable(string tableName);
    }
}
