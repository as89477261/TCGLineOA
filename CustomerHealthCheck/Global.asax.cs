using System;
using System.Web;
using log4net.Config;

namespace CustomerHealthCheck
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            XmlConfigurator.Configure();
        }
    }
}