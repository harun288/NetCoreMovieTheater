using NetCoreMovieTheater.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Repository
{
    public interface IGenreRepository
    {
        List<Genre> GetGenres();

        void Create(Genre genre);

        void Delete(Genre genre);

        void Update(Genre genre);

        Genre GetGenre(int id);
    }
}
