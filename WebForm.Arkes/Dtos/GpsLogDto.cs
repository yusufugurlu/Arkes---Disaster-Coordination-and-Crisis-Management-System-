using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm.Arkes.Dtos
{
    public class GpsLogDto
    {
        public int ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string DeviceName { get; set; }
        public string FullName { get; set; }
        public int DeviceTypeId { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}