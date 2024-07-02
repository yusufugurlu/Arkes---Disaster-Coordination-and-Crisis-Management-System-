using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm.Arkes.Dtos
{
    public class UserDto
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string DeviceName { get; set; }
        public int DeviceId { get; set; }
    }
}