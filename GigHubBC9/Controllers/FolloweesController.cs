using GigHubBC9.Core;
using GigHubBC9.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigHubBC9.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public FolloweesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: Followees
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var artists = unitOfWork.Users.GetArtistsFollowedBY(userId);

            return View(artists);
        }
    }
}