using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm.Arkes.Dtos
{
    public class GpsMarkerDto
    {
        public string title { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        
    }
}