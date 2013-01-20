using System;
using Bifrost.Entities;
using Bifrost.Serialization;
using Chirp.Concepts;
using Chirp.Domain.Chirping.Commands;
using Ninject;
using Ninject.Modules;

namespace Chirp.Application.Modules
{
    public class ChirpingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Func<ChirperId, ChirpId, bool>>().ToMethod(a => ChirpHasBeenChirpedByChirper).WhenInjectedInto<DeleteChirpBusinessValidator>();
            Bind<Func<ChirperId, bool>>().ToMethod(a => ChirperExists).WhenInjectedInto<DeleteChirpBusinessValidator>();
            Bind<Func<ChirperId, ChirpId, bool>>().ToMethod(a => ChirpIsNotADuplicate).WhenInjectedInto<ChirpMessageBusinessValidator>();
            Bind<Func<ChirperId, bool>>().ToMethod(a => ChirperExists).WhenInjectedInto<ChirpMessageBusinessValidator>();

            Bind(typeof(IEntityContext<>)).To(typeof(Bifrost.RavenDB.EntityContext<>)).InRequestScope();
            Bind<ISerializer>().To<Bifrost.JSON.Serialization.Serializer>().InSingletonScope();
        }

        bool ChirpHasBeenChirpedByChirper(ChirperId chirper, ChirpId chirp)
        {
            var funcs = Kernel.Get<Read.Domain.Chirping.ChirpingFuncs>();
            return funcs.ChirpHasBeenChirpedByChirper().Invoke(chirper, chirp);
        }

        bool ChirpIsNotADuplicate(ChirperId chirper, ChirpId chirp)
        {
            var funcs = Kernel.Get<Read.Domain.Chirping.ChirpingFuncs>();
            return funcs.ChirpIsNotADuplicate().Invoke(chirper, chirp);
        }

        bool ChirperExists(ChirperId chirper)
        {
            var funcs = Kernel.Get<Read.Domain.Chirping.ChirpingFuncs>();
            return funcs.ChirperExists().Invoke(chirper);
        }
    }
}