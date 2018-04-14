using RoundsApi.Models;
using System;
using System.Collections.Generic;

namespace RoundsApi.Store
{
    public class InMemoryStore
    {
        User user1;
        User user2;
        public Dictionary<Guid, User> users { get; set; }

        public InMemoryStore()
        {
            user1 = new User() { name = "Adam", drink = "Beer", id = Guid.NewGuid() };
            user2 = new User() { name = "Louise", drink = "Wine", id = Guid.NewGuid() };
            users = new Dictionary<Guid, User> { { user1.id, user1 }, { user2.id, user2 } };
        }
    }
}
