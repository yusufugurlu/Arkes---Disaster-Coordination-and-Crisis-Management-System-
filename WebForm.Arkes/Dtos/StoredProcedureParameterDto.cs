using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm.Arkes.Dtos
{
    public class StoredProcedureParameterDto
    {
        public string ParameterName { get; set; }
        public object Value { get; set; }
    }
}