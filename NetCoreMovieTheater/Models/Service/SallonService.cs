using NetCoreMovieTheater.Models.Context;
using NetCoreMovieTheater.Models.Entities;
using NetCoreMovieTheater.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Service
{
    public class SallonService : ISallonRepository
    {
        private readonly ApplicationDbContext context;

        public SallonService(ApplicationDbContext context )
        {
            this.context = context;
        }
        public void Create(Salloon salloon)
        {
            context.Salloons.Add(salloon);
            context.SaveChanges();
        }

        public void Delete(Salloon salloon)
        {
            context.Salloons.Remove(salloon);
            context.SaveChanges();
        }

        public Salloon GetSalloon(int id)
        {
            return context.Salloons.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Salloon> GetSalloons()
        {
            return context.Salloons.ToList();
        }

        public void Update(Salloon salloon)
        {
            context.Salloons.Update(salloon);
            context.SaveChanges();
        }
    }
}
