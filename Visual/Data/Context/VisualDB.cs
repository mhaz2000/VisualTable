using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class VisualDB : DbContext
    {
        public VisualDB()
        {

        }

        public DbSet<Table> Tables { get; set; }
        public DbSet<FieldName> FieldNames { get; set; }
        public DbSet<FieldValue> FieldValues { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Log.Configuration());
        }
    }
}
