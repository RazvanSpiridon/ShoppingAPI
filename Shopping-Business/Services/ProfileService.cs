using Microsoft.EntityFrameworkCore;
using Shopping_Business.Interface;
using Shopping_Domain.Models;
using Shopping_Persistence.Context;
using Shopping_Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Business.Services
{
    public class ProfileService : IProfileService
    {
        private readonly AppDbContext _dbContext;

        public ProfileService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProfileDto> AddProfileAsync(ProfileDto profileDto)
        {
            var profile = new Profile
            {
                ProfileId = new Guid(),
                FirstName = profileDto.FirstName,
                LastName = profileDto.LastName,
                Email = profileDto.Email,
                Password = profileDto.Password,
                LastUpdate = DateTime.Now
            };

            await _dbContext.Profiles.AddAsync(profile);
            await _dbContext.SaveChangesAsync();

            return new ProfileDto(profile.ProfileId, profile.FirstName, profile.LastName, profile.Email, profile.Password, profile.LastUpdate);

        }

        public async Task<ProfileDto> DeleteProfileAsync(Guid profileId)
        {
            var profile = await _dbContext.Profiles.Where(p => p.ProfileId == profileId).FirstOrDefaultAsync() ?? new Profile();

            _dbContext.Profiles.Remove(profile);
            await _dbContext.SaveChangesAsync();

            return new ProfileDto(profile.ProfileId, profile.FirstName, profile.LastName, profile.Email, profile.Password, profile.LastUpdate);
        }

        public async Task<ProfileDto> GetProfileAsync(Guid profileId)
        {
            var profile = await _dbContext.Profiles.FirstOrDefaultAsync(p => p.ProfileId == profileId) ?? new Profile();

            return new ProfileDto(profile.ProfileId, profile.FirstName, profile.LastName, profile.Email, profile.Password, profile.LastUpdate);
        }

        public async Task<List<ProfileDto>> GetProfilesAsync()
        {
            var profiles = await _dbContext.Profiles.ToListAsync();

            return profiles.Select(p => new ProfileDto(
                p.ProfileId,
                p.FirstName,
                p.LastName,
                p.Email,
                p.Password,
                p.LastUpdate
                )).ToList();
        }

       
        public async Task<bool> ProfileExistsAsync(Guid profileId)
        {
            return await _dbContext.Profiles.AnyAsync(p => p.ProfileId == profileId);
        }

        public async Task<ProfileDto> UpdateProfileAsync(Guid profileId, ProfileDto profileDto)
        {
            var profile = await _dbContext.Profiles.FirstOrDefaultAsync(p => p.ProfileId == profileId) ?? new Profile();
            profile.FirstName = profileDto.FirstName;
            profile.LastName = profileDto.LastName;
            profile.Email = profileDto.Email;
            profile.Password = profileDto.Password;
            profile.LastUpdate = DateTime.Now;

            await _dbContext.SaveChangesAsync();
            return new ProfileDto(profile.ProfileId, profile.FirstName, profile.LastName, profile.Email, profile.Password, profile.LastUpdate);
        }
    }
}
