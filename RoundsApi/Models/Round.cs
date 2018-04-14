using System;
using System.Collections.Generic;

namespace RoundsApi.Models
{
    public class Round
    {
        Guid partyId { get; set; }
        public List<User> users { get; set; }
        public int currentUser { get; set; }
        public string partyName { get; set; }
    }
}
