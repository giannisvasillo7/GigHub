using GigHubBC9.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHubBC9.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public ICollection<Attendance> Attendances { get; private set; }

        protected Gig()
        {
            Attendances = new Collection<Attendance>();
        }
        // string artistId, DateTime dateTime, byte genreId, string venue
        private Gig(GigFormViewModel viewModel, string artistId)
        {
            ArtistId = artistId;
            DateTime = viewModel.GetDateTime();
            GenreId = viewModel.GenreId;
            Venue = viewModel.Venue;
        }

        public static Gig CreateWithNotifications(GigFormViewModel viewModel, string artistId, List<ApplicationUser> followers)
        {
            var gig = new Gig(viewModel, artistId);
            //var artist = new ApplicationUser() { Id = artistId };

            var notification = Notification.GigCreated(gig);

            foreach (var follower in followers)
            {
                follower.Notify(notification);
            }

            return gig;
        }

        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.GigCanceled(this);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Modify(DateTime datetime, string venue, byte genreId)
        {
            var notification = Notification.GigUpdated(this, DateTime, Venue);

            Venue = venue;
            DateTime = datetime;
            GenreId = genreId;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}