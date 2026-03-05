using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;


namespace ClassLibrary1
{
    public class BaseClass
    {

        public BaseClass()
        {


        }

        protected string GetAppsetting(string configName)
        {
            return ConfigurationManager.AppSettings[configName];
        }
        public string DecodeBase64(string value)
        {
            var valueBytes = System.Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(valueBytes);
        }

    }
}
