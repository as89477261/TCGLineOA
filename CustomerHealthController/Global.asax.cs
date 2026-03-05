using System;
using System.Web;
using log4net.Config;

namespace CustomerHealthController
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            XmlConfigurator.Configure();
        }
    }
}