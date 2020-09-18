using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHubBC9.Core.Models;

namespace GigHubBC9.Core.ViewModels
{
    public class GigDetailsViewModel
    {
        public Gig Gig { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }
    }
}