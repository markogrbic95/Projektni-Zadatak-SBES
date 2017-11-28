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

        public static void DataAccess(string userName, string viewedUser)
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

        public static void ChangePasswordSuccess(string userName)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserChangePasswordSuccess;

                string s = String.Format(newLog, userName, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserChangePasswordSuccess));
            }
        }

        public static void GroupAddFailed(string userName, string groupName)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserGroupAddFailed;

                string s = String.Format(newLog, userName, groupName, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserGroupAddFailed));
            }
        }

        public static void GroupAddSuccess(string userName, string groupName)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserGroupAddSuccess;

                string s = String.Format(newLog, userName, groupName, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserGroupAddSuccess));
            }
        }

        public static void GroupAccess(string userName, string groupName)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserGroupAccess;

                string s = String.Format(newLog, userName, groupName, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserGroupAccess));
            }
        }

        public static void GroupDeleteSuccess(string userName, string groupName)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserGroupDeleteSuccess;

                string s = String.Format(newLog, userName, groupName, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserGroupDeleteSuccess));
            }
        }

        public static void GroupEditSuccess(string userName, string oldGroupName, string newGroupName)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserGroupEditSuccess;

                string s = String.Format(newLog, userName, oldGroupName, newGroupName,DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserGroupEditSuccess));
            }
        }

        public static void GroupEditFailed(string userName, string groupName)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserGroupEditFailed;

                string s = String.Format(newLog, userName, groupName, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserGroupEditFailed));
            }
        }

        public static void ChangePasswordFailed(string userName)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserChangePasswordFailed;

                string s = String.Format(newLog, userName, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserChangePasswordFailed));
            }
        }

        public static void AllowedPermision(string userName, string newUser)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserAllowedPermision;

                string s = String.Format(newLog, userName, newUser, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserAllowedPermision));
            }
        }

        public static void DenyPermision(string userName, string newUser)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserDenyPermision;

                string s = String.Format(newLog, userName, newUser, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserDenyPermision));
            }
        }

        public static void AddedUserToGroup(string userName, string newUser, string groupName)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserAddedUserToGroup;

                string s = String.Format(newLog, userName, newUser, groupName, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserAddedUserToGroup));
            }
        }

        public static void RemoveUserFromGroup(string userName, string newUser, string groupName)
        {
            if (customLog != null)
            {
                string newLog = AuditEvents.UserRemoveUserFromGroup;

                string s = String.Format(newLog, userName, newUser, groupName, DateTime.Now.ToString());

                customLog.WriteEntry(s);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserRemoveUserFromGroup));
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
