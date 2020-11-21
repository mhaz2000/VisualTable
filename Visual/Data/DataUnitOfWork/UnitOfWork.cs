using Data.Context;
using Data.Repositories;
using Data.Repositories.TableAddingValue;
using Data.Repositories.TableCreation;
using Data.Repositories.TableShowingValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VisualDB _db;
        public UnitOfWork(VisualDB db)
        {
            _db = db;
            TableCreating = new TableCreating();
            AddingValue = new AddingValue();
            ShowingTable = new ShowingTable();
        }
        public ITableCreating TableCreating { get; }

        public IAddingValue AddingValue { get; }

        public IShowingTable ShowingTable { get; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
