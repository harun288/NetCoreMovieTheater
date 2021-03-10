using NetCoreMovieTheater.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Repository
{
    public interface IWeekRepository
    {
        List<Week> GetWeeks();

        void Create(Week week);

        void Delete(Week week);

        void Update(Week week);

        Week GetWeek(int id);
    }
}
