using Microsoft.AspNetCore.Mvc;
using NetCoreMovieTheater.Models.Entities;
using NetCoreMovieTheater.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Areas.Admin.Controllers
{
    public class SalloonController : Controller
    {
        private readonly ISallonRepository sallonRepository;

        public SalloonController(ISallonRepository sallonRepository)
        {
            this.sallonRepository = sallonRepository;
        }
        public IActionResult Index()
        {
            return View(sallonRepository.GetSalloons());
        }

        public IActionResult AddSaloon()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSaloon(Salloon salloon )
        {
            sallonRepository.Create(salloon);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveSaloon(Salloon salloon)
        {
            sallonRepository.Delete(salloon);
            return RedirectToAction("Index");
        }

        public IActionResult GetSaloon(Salloon salloon)
        {
            var result = sallonRepository.GetSalloons().Where(x => x.Id == salloon.Id);
            return View(result);
        }

        public IActionResult UpdateSaloon(int Id)
        {
            var result = sallonRepository.GetSalloons().Where(x => x.Id == Id);
            return View();
        }

        [HttpPost]
        public IActionResult UpdateSaloon(Salloon salloon)
        {
            sallonRepository.Update(salloon);
            return RedirectToAction("Index");
        }
    }
}
