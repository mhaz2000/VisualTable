using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Common;

namespace Visual.Models
{
    public class FieldName
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FieldName()
        {
            FieldNameId = Guid.NewGuid();
        }
        /// <summary>
        /// Constructor with given name,type and tableId
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="tableID"></param>
        public FieldName(string name, FieldTypes type, Guid tableID)
        {
            FieldNameId = Guid.NewGuid();
            TableID = tableID;
            Name = name;
            Type = type;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid FieldNameId { get; set; }
        public string Name { get; set; }
        public FieldTypes Type { get; set; }
        [ForeignKey("Table")]
        public Guid TableID { get; set; }

        public virtual Table Table { get; set; }
        public virtual List<FieldValue> FieldValues { get; set; }
    }
}