using System;
using Bifrost.Configuration;
using Bifrost.Entities;
using Bifrost.Execution;
using Bifrost.Ninject;
using Bifrost.RavenDB;
using Bifrost.Services.Execution;
using Bifrost.Web;
using Chirp.Application.Modules;
using Chirp.Concepts;
using Chirp.Events.Follow;
using Chirp.Read;
using Chirp.Read.Domain.Chirping;
using Chirp.Read.Domain.Follow;
using Chirp.Read.Follow;
using Chirp.Read.Streams;
using Chirp.Web.Services;
using Ninject;
using System.Net;
using Chirp.Application.Security;
using Chirp = Chirp.Read.Streams.Chirp;
using ChirperId = Chirp.Concepts.ChirperId;
using viewFollow = Chirp.Read.Follow;
using domainFollow = Chirp.Read.Domain.Follow;
using System.Configuration;

namespace Chirp.Web
{
    public class Configuration : ICanConfigure, ICanCreateContainer
    {
        public IContainer CreateContainer()
        {
            var kernel = new StandardKernel(new UsersModule(), new ChirpingModule());
            var container = new Container(kernel);
            return container;
        }

        public void Configure(IConfigure configure)
        {
            var connectionString = ConfigurationManager.AppSettings["Database"];
            var userName = ConfigurationManager.AppSettings["RavenUsername"];
            var password = ConfigurationManager.AppSettings["RavenPassword"];

            var entityIds = new EntityIdPropertyRegister();
            entityIds.RegisterIdProperty<ReadingStream, ReaderId>(rs => rs.Reader);
            entityIds.RegisterIdProperty<MyChirps, ChirperId>(c => c.Chirper);
            entityIds.RegisterIdProperty<Read.Streams.Chirp, ChirpId>(c => c.Id);
            entityIds.RegisterIdProperty<Chirper, ChirperId>(c => c.ChirperId);
            entityIds.RegisterIdProperty<Follower, FollowerId>(c => c.FollowerId);
            entityIds.RegisterIdProperty<Read.Domain.Chirping.ChirperId, ChirperId>(c => c.Id);
            entityIds.RegisterIdProperty<ChirpersFollowers, ChirperId>(c => c.Chirper);
            entityIds.RegisterIdProperty<FollowerFollows, FollowerId>(c => c.Follower);
            entityIds.RegisterIdProperty<MyFollowers, ChirperId>(c => c.ChirperId);
            entityIds.RegisterIdProperty<MyFollows, FollowerId>(c => c.FollowerId);

            configure
                .Events.Asynchronous()
                .Events.UsingRavenDB(c =>
                {
                    c.Url = "http://localhost:8080";
                    c.DefaultDatabase = "Chirp";
                    if (!string.IsNullOrEmpty(userName))
                        c.Credentials = new NetworkCredential(userName, password);
                })
                .Serialization.UsingJson()
                .DefaultStorage.UsingRavenDB(connectionString, c =>
                {
                    c.DefaultDatabase = "Chirp";
                    if (!string.IsNullOrEmpty(userName))
                        c.Credentials = new NetworkCredential(userName, password);
                    c.IdPropertyRegister = entityIds;

                })
                .Frontend.Web(w => w.AsSinglePageApplication());
            //.WithMimir();
        }
    }
}