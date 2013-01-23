using System;
using System.Configuration;
using System.Linq;
using System.Web.Routing;
using Bifrost.Configuration;
using Bifrost.Entities;
using Bifrost.Execution;
using Bifrost.Ninject;
using Bifrost.Services.Execution;
using Bifrost.Web;
using Chirp.Application.Modules;
using Chirp.Concepts;
using Chirp.Read.Domain.Chirping;
using Chirp.Read.Domain.Follow;
using Chirp.Read.Streams;
using Chirp.Web.Services;
using Ninject;
using System.Net;
using Chirp.Application.Security;

namespace Chirp.Web
{
    public class Global : BifrostHttpApplication
    {
        protected override IContainer CreateContainer()
        {
            var kernel = new StandardKernel(new UsersModule(), new ChirpingModule());
            var container = new Container(kernel);
            return container;
        }

        public override void OnStarted()
        {
            RouteTable.Routes.AddService<Bifrost.Services.ValidationService>(); 
            RouteTable.Routes.AddService<Bifrost.Services.Commands.CommandCoordinatorService>();
            RouteTable.Routes.AddService<StreamerService>();
            RouteTable.Routes.AddService<UserService>();
            RouteTable.Routes.AddService<DebugInfoService>();

            base.OnStarted();
            EnsureScottAndHannahAreSetup(base.Container);

        }

        public override void OnConfigure(IConfigure configure)
        {
            var connectionString = ConfigurationManager.AppSettings["Database"];
            var userName = ConfigurationManager.AppSettings["RavenUsername"];
            var password = ConfigurationManager.AppSettings["RavenPassword"];

            configure
                .Events.Asynchronous()
                .Events.UsingRavenDB( c =>
                {
                    c.Url = "http://localhost:8080";
                    c.DefaultDatabase = "Chirp";
                    if (!string.IsNullOrEmpty(userName))
                        c.Credentials = new NetworkCredential(userName, password);
                })
                .Serialization.UsingJson()
                .Sagas.WithoutLibrarian()
                .DefaultStorage.UsingRavenDB(connectionString, c =>
                {
                    c.DefaultDatabase = "Chirp";
                    if (!string.IsNullOrEmpty(userName))
                        c.Credentials = new NetworkCredential(userName, password);
                })
                .AsSinglePageApplication()
                .WithMimir();

            base.OnConfigure(configure);

        }

        static Guid hannah = Guid.Parse("{03F1D667-063B-4D15-B892-06F89818E9A8}");
        static Guid scott = Guid.Parse("{A345577C-28AD-4371-87FE-8A57E84BDE2E}");

       void EnsureScottAndHannahAreSetup(IContainer container)
       {
           var chirpersEntityContext = container.Get<IEntityContext<Chirper>>();
           if (!chirpersEntityContext.Entities.Any(c => c.ChirperId.Value == hannah || c.ChirperId.Value == scott))
           {
               chirpersEntityContext.Insert(new Chirper() { ChirperId = scott, DisplayName = "@Scott" });
               chirpersEntityContext.Insert(new Chirper() { ChirperId = hannah, DisplayName = "@Hannah" });
               chirpersEntityContext.Commit();
           }

           var chirperIdsEntityContext = container.Get<IEntityContext<ChirperId>>();
           if (!chirperIdsEntityContext.Entities.Any(c => c.Value == hannah || c.Value == scott))
           {
               chirperIdsEntityContext.Insert(hannah);
               chirperIdsEntityContext.Insert(scott);
               chirperIdsEntityContext.Commit();
           }

           var myChirpsEntityContext = container.Get<IEntityContext<MyChirps>>();
           if (!myChirpsEntityContext.Entities.Any(c => c.Chirper.Value == hannah || c.Chirper.Value == scott))
           {
               myChirpsEntityContext.Insert(new MyChirps(hannah));
               myChirpsEntityContext.Insert(new MyChirps(scott));
               myChirpsEntityContext.Commit();
           }

           var myReadingStreamEntityContext = container.Get<IEntityContext<ReadingStream>>();
           if (!myReadingStreamEntityContext.Entities.Any(c => c.Reader.Value == hannah || c.Reader.Value == scott))
           {
               myReadingStreamEntityContext.Insert(new ReadingStream(scott));
               myReadingStreamEntityContext.Insert(new ReadingStream(hannah));
               myReadingStreamEntityContext.Commit();
           }

           var myFollowersEntityContext = container.Get<IEntityContext<MyFollowers>>();
           if (!myFollowersEntityContext.Entities.Any(c => c.Chirper.Value == hannah || c.Chirper.Value == scott))
           {
               var hannahsFollowers = new MyFollowers(hannah);
               hannahsFollowers.AddFollower(scott);
               var scottsFollowers = new MyFollowers(scott);
               scottsFollowers.AddFollower(hannah);

               myFollowersEntityContext.Insert(hannahsFollowers);
               myFollowersEntityContext.Insert(scottsFollowers);
               myFollowersEntityContext.Commit();
           }
       }
    }
} 
