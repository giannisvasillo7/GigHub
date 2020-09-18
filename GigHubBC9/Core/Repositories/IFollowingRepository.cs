using GigHubBC9.Core.Models;

namespace GigHubBC9.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string followerId, string followeeId);
    }
}