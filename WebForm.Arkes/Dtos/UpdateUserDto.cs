using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm.Arkes.Dtos
{
    public class UpdateUserDto
    {
        public string FullName { get; set; }
        public int DeviceId { get; set; }
        public int Id { get; set; }
    }
}