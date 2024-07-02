using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm.Arkes.Dtos
{
    public class Result
    {
        public object Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}