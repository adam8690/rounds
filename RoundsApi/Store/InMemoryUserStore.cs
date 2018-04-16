using RoundsApi.Models;
using System;
using System.Collections.Generic;

namespace RoundsApi.Store
{
    public class InMemoryUserStore
    {
        User user1;
        User user2;
        public Dictionary<Guid, User> users { get; set; }

        public InMemoryUserStore()
        {
            user1 = new User() { name = "Adam", drink = "Beer", userId = Guid.NewGuid() };
            user2 = new User() { name = "Louise", drink = "Wine", userId = Guid.NewGuid() };
            users = new Dictionary<Guid, User> { { user1.userId, user1 }, { user2.userId, user2 } };
        }
    }
}
