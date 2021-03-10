using Microsoft.AspNetCore.Mvc;
using NetCoreMovieTheater.Models.Entities;
using NetCoreMovieTheater.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Areas.Admin.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationRepository reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        public IActionResult Index()
        {
            return View(reservationRepository.GetReservations());
        }

        public IActionResult AddReservation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddReservation(Reservation reservation)
        {
            reservationRepository.Create(reservation);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveReservation(Reservation reservation)
        {
            reservationRepository.Delete(reservation);
            return RedirectToAction("Index");
        }

        public IActionResult GetReservation(Reservation reservation)
        {
            var result = reservationRepository.GetReservations().Where(x => x.Id == reservation.Id);
            return View(result);
        }

        public IActionResult UpdateReservation(int Id)
        {
            var result = reservationRepository.GetReservations().Where(x => x.Id == Id);
            return View();
        }

        [HttpPost]
        public IActionResult UpdateReservation(Reservation reservation)
        {
            reservationRepository.Update(reservation);
            return RedirectToAction("Index");
        }
    }
}
