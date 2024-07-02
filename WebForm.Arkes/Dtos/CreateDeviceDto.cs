using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm.Arkes.Dtos
{
    public class CreateDeviceDto
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Id { get; set; }
    }
}