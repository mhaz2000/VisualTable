using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class TableCreatingDto
    {
        [Display(Name = "تعداد فیلد ها")]
        public int FieldNumber { get; set; }
        [Display(Name = "نام جدول")]
        public string tableName { get; set; }
        public string Message { get; set; }
        [Display(Name = "نام فیلد")]
        public string[] FieldNames { get; set; }
        [Display(Name = "نوع فیلد")]
        public FieldTypes[] FieldTypes { get; set; }
    }
}
