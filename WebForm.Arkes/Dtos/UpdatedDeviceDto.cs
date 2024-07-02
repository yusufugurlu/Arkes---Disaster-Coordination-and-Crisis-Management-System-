using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm.Arkes.Dtos
{
    public class UpdatedDeviceDto
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int ID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
    }
}