using Microsoft.AspNetCore.Mvc;
using Shopping_Business.Interface;
using Shopping_Domain.Models;

namespace ShoppingAPIv1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProfileDto>>> GetProfiles()
        {
            return Ok(await _profileService.GetProfilesAsync());
        }

        [HttpGet]
        [Route("{profileId}")]
        public async Task<ActionResult<ProfileDto>> GetProfile(Guid profileId)
        {
            if (!await _profileService.ProfileExistsAsync(profileId))
                return NotFound($"The profile with id {profileId} does not exist!");

            return Ok(await _profileService.GetProfileAsync(profileId));
        }

        [HttpPost]
        public async Task<ActionResult<ProfileDto>> AddProfile(ProfileDto profileDto)
        {
            return Ok(await _profileService.AddProfileAsync(profileDto));
        }

        [HttpPut]
        [Route("{profileId}")]
        public async Task<ActionResult<ProfileDto>> UpdateProfile(Guid profileId, ProfileDto profileDto)
        {
            if (!await _profileService.ProfileExistsAsync(profileId))
                return NotFound($"The profile with id {profileId} does not exist!");

            return Ok(await _profileService.UpdateProfileAsync(profileId, profileDto));
        }

        [HttpDelete]
        [Route("{profileId}")]
        public async Task<ActionResult<ProfileDto>> DeleteProfile(Guid profileId)
        {
            if (!await _profileService.ProfileExistsAsync(profileId))
                return NotFound($"The profile with id {profileId} does not exist!");

            return Ok(await _profileService.DeleteProfileAsync(profileId));
        }

    }
}
