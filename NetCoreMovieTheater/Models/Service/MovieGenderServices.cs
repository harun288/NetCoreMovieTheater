using NetCoreMovieTheater.Models.Context;
using NetCoreMovieTheater.Models.Entities;
using NetCoreMovieTheater.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Service
{
    public class MovieGenderServices : IMovieGenderRepository
    {
        private readonly ApplicationDbContext context;

        public MovieGenderServices(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void MovieCategories(int movieId, List<int> categoriesId)
        {
            foreach (var genreId in categoriesId)
            {
               context.MovieGenres.Add( new MovieGenre { MovieId = movieId, GenreId = genreId,CreatedDate=DateTime.Now });
               context.SaveChanges();
            }            
        }
    }
}
