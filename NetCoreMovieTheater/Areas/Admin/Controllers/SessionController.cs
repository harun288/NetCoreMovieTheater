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
    public class SessionController : Controller
    {
        private readonly ISessionRepository sessionRepository;

        public SessionController(ISessionRepository sessionRepository )
        {
            this.sessionRepository = sessionRepository;
        }
        public IActionResult Index()
        {
            return View(sessionRepository.GetSessions());
        }

        public IActionResult AddSession()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSession(Session session )
        {
            sessionRepository.Create(session);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveSession(Session session)
        {
            sessionRepository.Delete(session);
            return RedirectToAction("Index");
        }

        public IActionResult GetSession(Session session)
        {
            var result = sessionRepository.GetSessions().Where(x => x.Id == session.Id);
            return View(result);
        }

        public IActionResult UpdateSession(int Id)
        {
            var result = sessionRepository.GetSessions().FirstOrDefault(x => x.Id == Id);
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateSession(Session session)
        {
            sessionRepository.Update(session);
            return RedirectToAction("Index");
        }
    }
}
