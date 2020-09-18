using GigHubBC9.Core.Models;
using GigHubBC9.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHubBC9.Persistence.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetArtistsFollowedBY(string userId)
        {
            var followers = _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();

            return followers;
        }

        public IEnumerable<ApplicationUser> GetFollowers(string artistId)
        {
            var followers = _context.Followings
                .Where(f => f.FolloweeId == artistId)
                .Select(f => f.Follower)
                .ToList();

            return followers;
        }
    }
}