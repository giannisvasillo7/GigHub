using System.Collections.Generic;
using GigHubBC9.Core.Models;

namespace GigHubBC9.Core.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}