using GigHubBC9.Core.Dtos;
using GigHubBC9.Core.Models;
using GigHubBC9.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHubBC9.Controllers.api
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext context;

        public FollowingsController()
        {
            context = new ApplicationDbContext();
        }

        //POST api/followings
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();

            if (context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
                return BadRequest("You already follow this artist.");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };

            context.Followings.Add(following);
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Unfollow(string id)
        {
            var userId = User.Identity.GetUserId();

            var following = context.Followings
                .SingleOrDefault(f => f.FollowerId == userId && f.FolloweeId == id);

            if (following == null)
                return NotFound();

            context.Followings.Remove(following);
            context.SaveChanges();

            return Ok(id);
        }
    }
}
