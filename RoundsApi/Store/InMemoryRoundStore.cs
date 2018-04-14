using RoundsApi.Models;
using System;
using System.Collections.Generic;

namespace RoundsApi.Store
{
    public class InMemoryRoundStore
    {
        public Dictionary<Guid, Round> rounds { get; set; }

        public InMemoryRoundStore()
        {
            rounds = new Dictionary<Guid, Round>();
        }
    }
}
