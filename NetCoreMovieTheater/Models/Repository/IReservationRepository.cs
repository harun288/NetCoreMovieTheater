using NetCoreMovieTheater.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Repository
{
    public interface IReservationRepository
    {
        List<Reservation> GetReservations();

        void Create(Reservation reservation);
                    
        void Delete(Reservation reservation);
                    
        void Update(Reservation reservation);

        Reservation GetReservation(int id);
    }
}
