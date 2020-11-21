using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    class Table
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Table()
        {
            TableId = Guid.NewGuid();
        }
        /// <summary>
        /// Constructor with given table name
        /// </summary>
        /// <param name="name"></param>
        public Table(string name)
        {
            TableId = Guid.NewGuid();
            TableName = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid TableId { get; set; }
        public string TableName { get; set; }

        public virtual List<FieldName> FieldNames { get; set; }
        public virtual Log Log { get; set; }
    }
}
