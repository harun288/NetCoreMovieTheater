using NetCoreMovieTheater.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Repository
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();

        void Create(Movie movie);

        void Delete(Movie movie);

        void Update(Movie movie);

        Movie GetMovie(int id);
    }
}
