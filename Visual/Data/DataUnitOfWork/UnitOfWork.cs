using Data.Context;
using Data.Models;
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
        private Repository<Table> _tableRepo;
        private readonly VisualDB _db;
        public UnitOfWork()
        {
            _db = new VisualDB();
            TableCreating = new TableCreating(_db);
            AddingValue = new AddingValue(_db);
            ShowingTable = new ShowingTable(_db);
        }
        public ITableCreating TableCreating { get; }

        public IAddingValue AddingValue { get; }

        public IShowingTable ShowingTable { get; }

        public IRepository<Table> TableRepo
        {
            get
            {
                return _tableRepo ?? (_tableRepo = new Repository<Table>(_db));
            }
        }

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
