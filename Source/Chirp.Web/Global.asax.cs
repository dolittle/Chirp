using System.Web.Routing;
using Bifrost.Configuration;
using Bifrost.Execution;
using Bifrost.Ninject;
using Bifrost.Services.Execution;
using Bifrost.Web;
using Chirp.Application.Modules;
using Ninject;
using Chirp.Web.Services;
using System;
using System.Web;
using Chirp.Views.Streams;
using System.Configuration;

namespace Chirp.Web
{
    public class Global : BifrostHttpApplication
    {
        protected override IContainer CreateContainer()
        {
            var kernel = new StandardKernel(new UsersModule());
            var container = new Container(kernel);

            kernel.Bind<Func<string>>().ToMethod(a => GetDataPath).WhenInjectedInto<StreamRepository>();

            return container;
        }

        string GetDataPath()
        {
            return HttpContext.Current.Server.MapPath("~/Data");
        }

        public override void OnStarted()
        {
            RouteTable.Routes.AddService<Bifrost.Services.ValidationService>();
            RouteTable.Routes.AddService<Bifrost.Services.Commands.CommandCoordinatorService>();
            RouteTable.Routes.AddService<Bifrost.Services.Events.EventService>("Events");
            RouteTable.Routes.AddService<StreamService>();
            base.OnStarted();
        }

        public override void OnConfigure(IConfigure configure)
        {
            var connectionString = ConfigurationManager.AppSettings["Database"];

            var path = Server.MapPath("~/Data");
            configure
                .Sagas.WithoutLibrarian()
                .Serialization.UsingJson()
                .UsingRaven(connectionString)
                .AsSinglePageApplication()
                .WithMimir()
                ;
            base.OnConfigure(configure);
        }

    }
}
