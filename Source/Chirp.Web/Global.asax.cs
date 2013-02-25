using System;
using System.Web.Routing;
using Bifrost.Services.Execution;
using Chirp.Application.Security;
using Chirp.Web.Services;
using System.Web;

namespace Chirp.Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.AddService<DebugInfoService>();
            RouteTable.Routes.AddService<UserService>();
        }
    }
} 
