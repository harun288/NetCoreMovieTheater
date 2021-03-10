using Microsoft.AspNetCore.Mvc;
using NetCoreMovieTheater.Models.Entities;
using NetCoreMovieTheater.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Areas.Admin.Controllers
{
    public class WeekController : Controller
    {
        private readonly IWeekRepository weekRepository;

        public WeekController(IWeekRepository weekRepository )
        {
            this.weekRepository = weekRepository;
        }
        public IActionResult Index()
        {
            return View(weekRepository.GetWeeks());
        }

        public IActionResult AddWeek()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWeek(Week week)
        {
            weekRepository.Create(week);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveWeek(Week week)
        {
            weekRepository.Delete(week);
            return RedirectToAction("Index");
        }

        public IActionResult GetWeek(Week week)
        {
            var result = weekRepository.GetWeeks().Where(x => x.Id == week.Id);
            return View(result);
        }

        public IActionResult UpdateWeek(int Id)
        {
            var result = weekRepository.GetWeeks().Where(x => x.Id == Id);
            return View();
        }

        [HttpPost]
        public IActionResult UpdateWeek(Week week)
        {
            weekRepository.Update(week);
            return RedirectToAction("Index");
        }
    }
}
