using NetCoreMovieTheater.Models.Context;
using NetCoreMovieTheater.Models.Entities;
using NetCoreMovieTheater.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Service
{
    public class MovieService : IMovieRepository
    {
        private readonly ApplicationDbContext context;

        public MovieService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }

        public void Delete(Movie movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
        }

        public Movie GetMovie(int id)
        {
            return context.Movies.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Movie> GetMovies()
        {
            return context.Movies.ToList();
        }

        public void Update(Movie movie)
        {
            context.Movies.Update(movie);
            context.SaveChanges();
        }
    }
}
