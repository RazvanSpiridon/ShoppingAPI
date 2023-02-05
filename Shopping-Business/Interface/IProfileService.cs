using Shopping_Domain.Models;
using Shopping_Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Business.Interface
{
    public interface IProfileService
    {
        Task<bool> ProfileExistsAsync(Guid profileId);
        Task<List<ProfileDto>> GetProfilesAsync();
        Task<ProfileDto> GetProfileAsync(Guid profileId);
        Task<ProfileDto> AddProfileAsync(ProfileDto profileDto);
        Task<ProfileDto> UpdateProfileAsync(Guid profileId, ProfileDto profile);
        Task<ProfileDto> DeleteProfileAsync(Guid profileId);
        
    }
}
