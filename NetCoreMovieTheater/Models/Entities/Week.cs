using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Entities
{
    public class Week:BaseEntity
    {
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }

        public virtual List<Reservation> Reservations { get; set; }
    }
}
