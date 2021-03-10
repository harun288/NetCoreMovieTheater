using NetCoreMovieTheater.Models.Context;
using NetCoreMovieTheater.Models.Entities;
using NetCoreMovieTheater.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Service
{
    public class GenreService : IGenreRepository
    {
        private readonly ApplicationDbContext context;

        public GenreService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Genre genre)
        {
            context.Genres.Add(genre);
            context.SaveChanges();
        }

        public void Delete(Genre genre)
        {
            context.Genres.Remove(genre);
            context.SaveChanges();
        }

        public Genre GetGenre(int id)
        {
            return context.Genres.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Genre> GetGenres()
        {
            return context.Genres.ToList();
        }

        public void Update(Genre genre)
        {
            context.Genres.Update(genre);
            context.SaveChanges();
        }
    }
}
