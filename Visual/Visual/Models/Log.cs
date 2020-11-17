using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Visual.Models
{
    public class Log
    {
        internal class Configuration : EntityTypeConfiguration<Log>
        {
            //set foriegn key
            public Configuration()
            {
                HasKey(c => c.TableID);

                HasRequired(c => c.Table).WithOptional(c => c.Log).WillCascadeOnDelete(true);
            }
        }
        /// <summary>
        /// default constructor
        /// </summary>
        public Log()
        {
            LogID = Guid.NewGuid();
            TableCreationTime = DateTime.Now;
        }

        public Guid LogID { get; set; }
        public DateTime TableCreationTime { get; set; }


        public Guid TableID { get; set; }
        public virtual Table Table { get; set; }
    }
}