using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Repository.Implemetations
{
    public class SessionSingleton
    {
        static readonly Lazy<SessionSingleton> LazyInstance = new Lazy<SessionSingleton>(() => new SessionSingleton(), true);

        static SessionSingleton() { }

        private SessionSingleton() { }

        public static SessionSingleton GetSessionSingleton() => LazyInstance.Value;

        private ISession session = SessionGenerator.Instance.GetSession();

        public ISession GetSession
        {
            get {
                if (session.IsOpen)
                {
                    return session;
                }
                session = SessionGenerator.Instance.GetSession();
                return session;
            }
        }
    }
}