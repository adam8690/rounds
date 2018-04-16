using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoundsApi.Models
{
    public class RoundUpsertModel
    {
        [Required]
        public string partyName { get; set; }

        public List<Guid> users { get; set; }

        [Required]
        public Guid? currentUser { get; set; }
    }
}
