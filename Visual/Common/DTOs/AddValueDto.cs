using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
   public class AddValueDto
    {
        public AddValueDto()
        {

        }
        public AddValueDto(List<string> tableNames)
        {
            TableNames = tableNames;
        }
        public AddValueDto(List<string> fieldNames, List<string> tableNames)
        {
            TableNames = tableNames;
            FieldNames = fieldNames;
        }
        public List<string> TableNames { get; set; }
        public string ChosenName { get; set; }
        public List<string> FieldNames { get; set; }
        public string[] FieldValues { get; set; }
    }
}
