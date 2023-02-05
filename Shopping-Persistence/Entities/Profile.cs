using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shopping_Persistence.Entities
{
    [Table("Profiles")]
    public class Profile
    {
        public Profile()
        {

        }

        public Profile(Guid profileId, string firstName, string lastName, string email, string password, DateTime lastUpdate)
        {
            ProfileId= profileId;
            FirstName= firstName;
            LastName= lastName;
            Email= email;
            Password= password;
            LastUpdate= lastUpdate;
        }

        [Key]
        public Guid ProfileId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(50)]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime LastUpdate { get; set; }

        [JsonIgnore]
        public List<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    }
}
