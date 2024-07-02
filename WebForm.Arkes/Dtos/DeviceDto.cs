using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm.Arkes.Dtos
{
    public class DeviceDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DeviceTypeName { get; set; }
        public int DeviceTypeId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}