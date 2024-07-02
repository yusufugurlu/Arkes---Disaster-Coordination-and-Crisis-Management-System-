using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebForm.Arkes.DataAccess
{
    public static class DataBaseConnectionString
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }
    }
}