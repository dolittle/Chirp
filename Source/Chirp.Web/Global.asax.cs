﻿using System;
using System.Configuration;
using System.Web;
using System.Web.Routing;
//using Bifrost.Configuration;
//using Bifrost.Entities;
//using Bifrost.Execution;
//using Bifrost.Ninject;
//using Bifrost.RavenDB;
//using Bifrost.Services.Execution;
//using Bifrost.Web;
//using Chirp.Application.Modules;
//using Chirp.Concepts;
//using Chirp.Events.Follow;
//using Chirp.Read;
//using Chirp.Read.Domain.Chirping;
//using Chirp.Read.Domain.Follow;
//using Chirp.Read.Follow;
//using Chirp.Read.Streams;
//using Chirp.Web.Services;
//using Ninject;
//using System.Net;
//using Chirp.Application.Security;
//using Chirp = Chirp.Read.Streams.Chirp;
//using ChirperId = Chirp.Concepts.ChirperId;
//using viewFollow = Chirp.Read.Follow;
//using domainFollow = Chirp.Read.Domain.Follow;
//using System.Web;

namespace Chirp.Web
{
    public class Global : HttpApplication
    {

       

        
//       // public override void OnStarted()
//       // {
//       //     RouteTable.Routes.AddService<StreamerService>();
//       //     RouteTable.Routes.AddService<UserService>();
//       //     RouteTable.Routes.AddService<DebugInfoService>();

//       //     base.OnStarted();
//       //     EnsureScottAndHannahAreSetup(base.Container);
//       // }

//       // #region Just For Pav
//       // static Guid hannah = Guid.Parse("{03F1D667-063B-4D15-B892-06F89818E9A8}");
//       // static Guid scott = Guid.Parse("{A345577C-28AD-4371-87FE-8A57E84BDE2E}");

//       //void EnsureScottAndHannahAreSetup(IContainer container)
//       //{
//       //    SignUp(container,hannah, "@hannah");
//       //    SignUp(container,scott, "@scott");
//       //    Follow(container,hannah, scott);
//       //    Follow(container,scott, hannah);
//       //}

//       // void SignUp(IContainer container, Guid id, string userName)
//       // {
//       //     var chirpersEntityContext = container.Get<IEntityContext<Chirper>>();
//       //     var chirperIdsEntityContext = container.Get<IEntityContext<Read.Domain.Chirping.ChirperId>>();
//       //     var myChirpsEntityContext = container.Get<IEntityContext<MyChirps>>();
//       //     var myReadingStreamEntityContext = container.Get<IEntityContext<ReadingStream>>();
//       //     var followersEntityContext = container.Get<IEntityContext<ChirpersFollowers>>();
//       //     var myFollowersEntityContext = container.Get<IEntityContext<MyFollowers>>();
//       //     var followsEntityContext= container.Get<IEntityContext<FollowerFollows>>();
//       //     var myFollowsEntityContext = container.Get<IEntityContext<MyFollows>>();
//       //     var followerEntityContext = container.Get<IEntityContext<Follower>>();

//       //     ChirperId chirperId = id;
//       //     FollowerId followerId = id;
//       //     ReaderId readerId = id;
//       //     var domainChirperId = new Read.Domain.Chirping.ChirperId() {Id = chirperId};
//       //     var chirper = new Chirper() { ChirperId = chirperId, DisplayName = userName };
//       //     var follower = new Follower { FollowerId = followerId, DisplayName = userName };
//       //     var follows = new FollowerFollows(followerId);
//       //     var followers = new ChirpersFollowers(chirperId);
//       //     var myFollows = new MyFollows(followerId){ Follower = follower };
//       //     var myFollowers = new MyFollowers(chirperId){ Chirper = chirper };
//       //     var myChirps = new MyChirps(chirperId);
//       //     var myReadingStream = new ReadingStream(readerId);

//       //     myReadingStreamEntityContext.DeleteById(readerId);
//       //     myReadingStreamEntityContext.Insert(myReadingStream);
//       //     myReadingStreamEntityContext.Commit();

//       //     myChirpsEntityContext.DeleteById(chirperId);
//       //     myChirpsEntityContext.Insert(myChirps);
//       //     myChirpsEntityContext.Commit();

//       //     myFollowersEntityContext.DeleteById(chirperId);
//       //     myFollowersEntityContext.Insert(myFollowers);
//       //     myFollowersEntityContext.Commit();

//       //     myFollowsEntityContext.DeleteById(followerId);
//       //     myFollowsEntityContext.Insert(myFollows);
//       //     myFollowsEntityContext.Commit();

//       //     followersEntityContext.DeleteById(chirperId);
//       //     followersEntityContext.Insert(followers);
//       //     followersEntityContext.Commit();

//       //     followsEntityContext.DeleteById(followerId);
//       //     followsEntityContext.Insert(follows);
//       //     followsEntityContext.Commit();

//       //     followerEntityContext.DeleteById(followerId);
//       //     followerEntityContext.Insert(follower);
//       //     followerEntityContext.Commit();

//       //     chirpersEntityContext.DeleteById(chirperId);
//       //     chirpersEntityContext.Insert(chirper);
//       //     chirpersEntityContext.Commit();

//       //     chirperIdsEntityContext.DeleteById(chirperId);
//       //     chirperIdsEntityContext.Insert(domainChirperId);
//       //     chirperIdsEntityContext.Commit();
//       // }

//       // void Follow(IContainer container, FollowerId follower, ChirperId chirperId)
//       // {
//       //     var chirperFollowed = new ChirperFollowed()
//       //                               {
//       //                                   EventSourceId = follower,
//       //                                   Chirper = chirperId
//       //                               };

//       //     var domainSubscriber = container.Get<domainFollow.FollowSubscriber>();
//       //     domainSubscriber.Process(chirperFollowed);
//       //     var viewSubscriber = container.Get<viewFollow.FollowSubscriber>();
//       //     viewSubscriber.Process(chirperFollowed);
//       // }
//       // #endregion
    }
} 
