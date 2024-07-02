using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm.Arkes.Dtos
{
    public class CreateGpsLogDto
    {
        public int DeviceId { get; set; }
        public double Lang { get; set; }
        public double Lat { get; set; }
    }
}