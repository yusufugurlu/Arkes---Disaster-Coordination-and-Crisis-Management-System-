using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm.Arkes.Dtos
{
    public class CreateUserDto
    {
        public string FullName { get; set; }
        public int DeviceID { get; set; }
    }
}