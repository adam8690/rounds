﻿using System;
using System.Collections.Generic;

namespace RoundsApi.Models
{
    public class Round
    {
        public Guid partyId { get; set; }
        public List<User> users { get; set; }
        public Guid currentUser { get; set; }
        public string partyName { get; set; }
    }
}
