using Microsoft.AspNetCore.Mvc;
using NetCoreMovieTheater.Models.Entities;
using NetCoreMovieTheater.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;
        private readonly IGenreRepository genreRepository;
        private readonly IMovieGenderRepository movieGenderrRepository;

        public MovieController(IMovieRepository movieRepository,IGenreRepository genreRepository,IMovieGenderRepository movieGenderrRepository)
        {
            this.movieRepository = movieRepository;
            this.genreRepository = genreRepository;
            this.movieGenderrRepository = movieGenderrRepository;
        }
        public IActionResult Index()
        {

            return View(movieRepository.GetMovies());
        }

        public IActionResult AddMovie()
        {
            ViewBag.Genre = genreRepository.GetGenres();
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie, List<int> genresId)
        {
            movieRepository.Create(movie);
            movieGenderrRepository.MovieCategories(movie.Id, genresId);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveMovie(Movie movie)
        {
            movieRepository.Delete(movie);
            return RedirectToAction("Index");
        }

        public IActionResult GetMovie(Movie movie)
        {
            var result = movieRepository.GetMovies().Where(x => x.Id == movie.Id).FirstOrDefault();
            return View(result);
        }

        public IActionResult UpdateMovie(int Id)
        {
            var result = movieRepository.GetMovies().Where(x => x.Id == Id).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public IActionResult UpdateMovie(Movie movie)
        {
            movieRepository.Update(movie);
            return RedirectToAction("Index");
        }
    }
}
