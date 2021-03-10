using NetCoreMovieTheater.Models.Context;
using NetCoreMovieTheater.Models.Entities;
using NetCoreMovieTheater.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Service
{
    public class WeekService : IWeekRepository
    {
        private readonly ApplicationDbContext context;

        public WeekService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Week week)
        {
            context.Weeks.Add(week);
            context.SaveChanges();
        }

        public void Delete(Week week)
        {
            context.Weeks.Remove(week);
            context.SaveChanges();
        }

        public Week GetWeek(int id)
        {
            return context.Weeks.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Week> GetWeeks()
        {
            return context.Weeks.ToList();
        }

        public void Update(Week week)
        {
            context.Weeks.Update(week);
            context.SaveChanges();
        }
    }
}
