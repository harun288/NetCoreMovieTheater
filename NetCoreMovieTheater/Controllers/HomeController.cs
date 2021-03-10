using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreMovieTheater.Models;
using NetCoreMovieTheater.Models.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieRepository movieRepository;

        public HomeController(ILogger<HomeController> logger,IMovieRepository movieRepository)
        {
            _logger = logger;
            this.movieRepository = movieRepository;
        }


        public IActionResult Index()
        {
            
            return View(movieRepository.GetMovies());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
