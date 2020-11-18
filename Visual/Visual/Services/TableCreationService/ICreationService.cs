using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual.DTOs;

namespace Visual.Services.TableCreationService
{
    public interface ICreationService
    {
        List<string> GetAllTableNames();
        TableStructionDto CheckNewTable(TableStructionDto tableStruction);
        void Save();
        void AddTable(TableStructionDto tableStruction);

    }
}
