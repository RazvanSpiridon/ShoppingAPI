using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Domain.Models
{
    public class ProfileDto
    {
        public Guid ProfileId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime LastUpdate { get; set; }

        public ProfileDto(Guid profileId, string firstName, string lastName, string email, string password, DateTime lastUpdate)
        {
            ProfileId = profileId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            LastUpdate = lastUpdate;
        }
    }

}
