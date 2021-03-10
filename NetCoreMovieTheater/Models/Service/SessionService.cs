using NetCoreMovieTheater.Models.Context;
using NetCoreMovieTheater.Models.Entities;
using NetCoreMovieTheater.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Service
{
    public class SessionService : ISessionRepository
    {
        private readonly ApplicationDbContext context;

        public SessionService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Create(Session session)
        {
            context.Sessions.Add(session);
            context.SaveChanges();
        }

        public void Delete(Session session)
        {
            context.Sessions.Remove(session);
            context.SaveChanges();
        }

        public Session GetSession(int id)
        {
            return context.Sessions.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Session> GetSessions()
        {
            return context.Sessions.ToList();
        }

        public void Update(Session session)
        {
            context.Sessions.Update(session);
            context.SaveChanges();
        }
    }
}
