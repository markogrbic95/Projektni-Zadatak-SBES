using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum AuditEventTypes
    {
        UserAuthenticationSuccess = 0,
        UserAuthenticationFailed = 1,
        UserRegistrationSuccess = 2,
        UserDataAccess = 3,

    }

    public class AuditEvents
    {
        private static ResourceManager resourceManager = null;
        private static object resourceLock = new object();

        private static ResourceManager ResourceMgr
        {
            get
            {
                lock (resourceLock)
                {
                    if (resourceManager == null)
                    {
                        resourceManager = new ResourceManager(typeof(AuditEventsFile).FullName, Assembly.GetExecutingAssembly());
                    }
                    return resourceManager;
                }
            }
        }

        public static string UserAuthenticationSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserAuthenticationSuccess.ToString());
            }
        }

        public static string UserAuthorizationFailed
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserAuthenticationFailed.ToString());
            }
        }

        public static string UserRegistrationSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserRegistrationSuccess.ToString());
            }
        }

        public static string UserDataAccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserDataAccess.ToString());
            }
        }
    }
}
