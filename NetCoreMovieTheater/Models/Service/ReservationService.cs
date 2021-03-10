using NetCoreMovieTheater.Models.Context;
using NetCoreMovieTheater.Models.Entities;
using NetCoreMovieTheater.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Service
{
    public class ReservationService : IReservationRepository
    {
        private readonly ApplicationDbContext context;

        public ReservationService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
        }

        public void Delete(Reservation reservation)
        {
            context.Reservations.Remove(reservation);
            context.SaveChanges();
        }

        public Reservation GetReservation(int id)
        {
            return context.Reservations.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Reservation> GetReservations()
        {
            return context.Reservations.ToList();
        }

        public void Update(Reservation reservation)
        {
            context.Reservations.Update(reservation);
            context.SaveChanges();
        }
    }
}
