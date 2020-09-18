using GigHubBC9.Core.Repositories;

namespace GigHubBC9.Core
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendances { get; }
        IFollowingRepository Followings { get; }
        IGenreRepository Genres { get; }
        IGigRepository Gigs { get; }
        IApplicationUserRepository Users { get; }

        void Complete();
    }
}