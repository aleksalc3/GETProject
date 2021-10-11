using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GETProject.Config
{
    public class ProjectConnection
    {
        public static string GetConnection() {
            return ConfigurationManager.ConnectionStrings["esc"].ConnectionString;
        }
    }
}