using System.Collections.Generic;
using GigHubBC9.Core.Models;

namespace GigHubBC9.Core.Repositories
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetArtistsFollowedBY(string userId);
        IEnumerable<ApplicationUser> GetFollowers(string artistId);
    }
}