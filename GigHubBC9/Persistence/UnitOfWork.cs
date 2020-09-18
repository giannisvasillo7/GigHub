using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHubBC9.Core;
using GigHubBC9.Core.Repositories;
using GigHubBC9.Persistence.Repositories;

namespace GigHubBC9.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGigRepository Gigs { get; private set; }
        public IAttendanceRepository Attendances { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public IFollowingRepository Followings { get; private set; }
        public IApplicationUserRepository Users { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Attendances = new AttendanceRepository(context);
            Genres = new GenreRepository(context);
            Followings = new FollowingRepository(context);
            Users = new ApplicationUserRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}