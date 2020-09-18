using GigHubBC9.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GigHubBC9.Persistence.EntityConfigurations
{
    public class GigConfiguration : EntityTypeConfiguration<Gig>
    {
        public GigConfiguration()
        {
            //keys

            //properties
            Property(g => g.ArtistId)
            .IsRequired();

            Property(g => g.GenreId)
           .IsRequired();

            Property(g => g.Venue)
            .IsRequired()
            .HasMaxLength(255);

            // relations
            HasMany(g => g.Attendances)
                .WithRequired(a => a.Gig)
                .WillCascadeOnDelete(false);
        }
    }
}