using System;
using System.Collections.Generic;

namespace RoundsApi.Models
{
    public class Round
    {
        public Guid roundId { get; set; }
        public List<Guid> users { get; set; }
        public Guid? currentUser { get; set; }
        public string partyName { get; set; }
    }
}
