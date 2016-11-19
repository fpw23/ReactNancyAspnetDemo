using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Interfaces;

namespace WebApp.Classes
{
    public class WebAppConfigProvider : IConfigProvider
    {
        public string GetAppSetting(string name)
        {
            return System.Configuration.ConfigurationManager.AppSettings[name];
        }

        public string GetConnectionString(string name)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}