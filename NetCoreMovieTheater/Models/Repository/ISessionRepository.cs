using NetCoreMovieTheater.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovieTheater.Models.Repository
{
    public interface ISessionRepository
    {
        List<Session> GetSessions();

        void Create(Session session);

        void Delete(Session session);

        void Update(Session session);

        Session GetSession(int id);
    }
}
