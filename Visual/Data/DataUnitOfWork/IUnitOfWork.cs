using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ITableCreating TableCreating { get; }
        IAddingValue AddingValue { get; }
        IShowingTable ShowingTable { get; }
        void Save();
    }
}
