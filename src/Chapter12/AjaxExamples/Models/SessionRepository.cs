using System;
using System.Collections.Generic;

namespace AjaxExamples.Models
{
    public class SessionRepository
    {
        private static readonly Dictionary<Guid, Session> _sessions = new Dictionary<Guid, Session>();

        public IEnumerable<Session> FindAll()
        {
            foreach (var session in _sessions.Values)
                yield return session;
        }

        public void SaveSession(Session session)
        {
            if(session.Id == Guid.Empty)
                session.Id = Guid.NewGuid();

            if (!_sessions.ContainsKey(session.Id))
            {
                _sessions.Add(session.Id, session);
            }
            else
            {
                _sessions[session.Id] = session;
            }
        }

        public void RemoveSession(Guid id)
        {
            _sessions.Remove(id);
        }
    }    
}
