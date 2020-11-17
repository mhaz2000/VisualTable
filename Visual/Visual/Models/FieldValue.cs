using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Visual.Models
{
    public class FieldValue
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FieldValue()
        {
            FieldValueId = Guid.NewGuid();
        }
        /// <summary>
        /// Constructor with given value,fieldnameID,row id
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldNameID"></param>
        /// <param name="rowID"></param>
        public FieldValue(string value, Guid fieldNameID, Guid rowID)
        {
            FieldValueId = Guid.NewGuid();
            FieldNameID = fieldNameID;
            Value = value;
            RowID = rowID;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid FieldValueId { get; set; }
        public string Value { get; set; }
        public Guid RowID { get; set; }
        public Guid FieldNameID { get; set; }

        public virtual FieldName FieldName { get; set; }

    }
}