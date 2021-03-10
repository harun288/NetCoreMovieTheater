using NetCoreMovieTheater.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Repository
{
    public interface ISallonRepository
    {
        List<Salloon> GetSalloons();

        void Create(Salloon salloon);

        void Delete(Salloon salloon );

        void Update(Salloon salloon);

        Salloon GetSalloon(int id);
    }
}
