using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Visual.DTOs
{
    //This Dto if used for showing a table.
    public class ShowTableDto
    {
        public ShowTableDto()
        {

        }
        public ShowTableDto(List<string> tableNames)
        {
            TableNames = tableNames;
        }
        public List<string> TableNames { get; set; }
        public string ChosenName { get; set; }
        public List<string[]> Values { get; set; }
    }
}