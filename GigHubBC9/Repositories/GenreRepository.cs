using GigHubBC9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHubBC9.Repositories
{
    public class GenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}