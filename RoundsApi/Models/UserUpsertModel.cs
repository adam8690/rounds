using System.ComponentModel.DataAnnotations;

namespace RoundsApi.Models
{
    public class UserUpsertModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string drink { get; set; }
    }
}
