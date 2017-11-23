using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Audit : IDisposable
    {
        private static EventLog customLog = null;
        const string SourceName = "blablaSourceName";
        const string LogName = "blablaLogName";

        static Audit()
        {
            try
            {
                if (!EventLog.SourceExists(SourceName))
                {
                    EventLog.CreateEventSource(SourceName, LogName);
                }

                customLog = new EventLog(LogName, Environment.MachineName, SourceName);
            }
            catch (Exception e)
            {
                customLog = null;
                Console.WriteLine("Error while trying to create log handle. Error = {0}", e.Message);
            }
        }


        public static void AuthenticationSuccess(string userName)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserAuthenticationSuccess;

                string s = String.Format(newLog, userName, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserAuthenticationSuccess));
            }
        }

        public static void AuthenticationFailed(string userName)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserAuthorizationFailed;

                string s = String.Format(newLog, userName, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserAuthenticationFailed));
            }
        }

        public static void RegistrationSuccess(string userName)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserRegistrationSuccess;

                string s = String.Format(newLog, userName, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserRegistrationSuccess));
            }
        }

        public static void DataAccess(string userName,string viewedUser)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserDataAccess;

                string s = String.Format(newLog, userName, viewedUser, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserDataAccess));
            }
        }

        public void Dispose()
        {
            if (customLog != null)
            {
                customLog.Dispose();
                customLog = null;
            }
        }
    }
}
