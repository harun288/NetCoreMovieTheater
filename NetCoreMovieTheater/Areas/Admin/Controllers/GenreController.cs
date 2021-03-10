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
    public class GenreController : Controller
    {
        private readonly IGenreRepository genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public IActionResult Index()
        {
            return View(genreRepository.GetGenres());
        }

        public IActionResult AddGenre()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGenre(Genre genre)
        {
            genreRepository.Create(genre);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveGenre(Genre genre)
        {
            genreRepository.Delete(genre);
            return RedirectToAction("Index");
        }

        public IActionResult GetGenre(Genre genre)
        {
            var result = genreRepository.GetGenres().Where(x => x.Id == genre.Id);
            return View(result);
        }

        public IActionResult UpdateGenre(int Id)
        {
            var result = genreRepository.GetGenres().Where(x => x.Id == Id).FirstOrDefault();
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateGenre(Genre genre)
        {
            genreRepository.Update(genre);
            return RedirectToAction("Index");
        }
    }
}
