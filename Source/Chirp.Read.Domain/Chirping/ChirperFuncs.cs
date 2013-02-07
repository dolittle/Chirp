using System;
using Bifrost.Entities;

namespace Chirp.Read.Domain.Chirping
{
    public class ChirperFuncs : Concepts.Funcs.ChirperFuncs
    {
        readonly IEntityContext<ChirperId> _chirperEntityContext;

        public ChirperFuncs(IEntityContext<ChirperId> chirperEntityContext)
        {
            _chirperEntityContext = chirperEntityContext;
        }

        public override Func<Concepts.ChirperId, bool> ChirperExists()
        {
            return (id) => _chirperEntityContext.GetById(id) != null;
        }
    }
}