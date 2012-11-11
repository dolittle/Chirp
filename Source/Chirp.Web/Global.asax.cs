using System.Configuration;
using System.Web.Routing;
using Bifrost.Configuration;
using Bifrost.Execution;
using Bifrost.Ninject;
using Bifrost.Services.Execution;
using Bifrost.Web;
using Chirp.Application.Modules;
using Chirp.Web.Services;
using Ninject;

namespace Chirp.Web
{
    public class Global : BifrostHttpApplication
    {
        protected override IContainer CreateContainer()
        {
            var kernel = new StandardKernel(new UsersModule());
            var container = new Container(kernel);
            return container;
        }

        public override void OnStarted()
        {
            RouteTable.Routes.AddService<Bifrost.Services.ValidationService>();
            RouteTable.Routes.AddService<Bifrost.Services.Commands.CommandCoordinatorService>();
            RouteTable.Routes.AddService<Bifrost.Services.Events.EventService>("Events");
            RouteTable.Routes.AddService<StreamService>();
            RouteTable.Routes.AddService<DebugInfoService>();
            base.OnStarted();
        }

        public override void OnConfigure(IConfigure configure)
        {
            var connectionString = ConfigurationManager.AppSettings["Database"];
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
