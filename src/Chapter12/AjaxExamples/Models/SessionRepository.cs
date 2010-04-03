using System;
using System.Collections.Generic;
using System.Linq;

namespace AjaxExamples.Models
{
    public class SessionRepository
    {
        private static readonly List<Session> _sessions = new List<Session>();

        public IEnumerable<Session> FindAll()
        {
            return _sessions;
        }

        public void SaveSession(Session session)
        {
            if (session.Id == Guid.Empty)
                session.Id = Guid.NewGuid();

            _sessions.Add(session);
        }

        public void RemoveSession(Guid id)
        {
            Session item = _sessions.Single(session => session.Id == id);
            _sessions.Remove(item);
        }
    }
}