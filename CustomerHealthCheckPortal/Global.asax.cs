using CustomerHealthCheckPortal;
using FireflySoft.RateLimit.AspNet;
using FireflySoft.RateLimit.Core.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace CustomerHealthCheck
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // RateLimitContext.RegisterConfig();
            GlobalConfiguration.Configuration.MessageHandlers.Add(
        new RateLimitHandler(
            new FireflySoft.RateLimit.Core.InProcessAlgorithm.InProcessFixedWindowAlgorithm(
                new[] {
                    new FixedWindowRule()
                    {
                        ExtractTarget = context =>
                        {
                            return (context as HttpRequestMessage).RequestUri.AbsolutePath;
                        },
                        CheckRuleMatching = context =>
                        {
                            return true;
                        },
                        Name="default limit rule",
                        LimitNumber=10,
                        StatWindow=TimeSpan.FromSeconds(1)

                    }
                })
        ));


        }
        void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            if (exc is HttpUnhandledException)
            {
                // Pass the error on to the error page.
                //Server.Transfer("~/views/error/index", true);
                Response.Redirect("~/views/error/index", true);
            }
        }
        public static void Register(HttpConfiguration config)
        {
            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);
        }

    }
}