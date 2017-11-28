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
        UserChangePasswordSuccess = 4,
        UserGroupAddFailed = 5,
        UserGroupAddSuccess = 6,
        UserGroupAccess = 7,
        UserGroupDeleteSuccess = 8,
        UserGroupEditSuccess = 9,
        UserGroupEditFailed = 10,
        UserChangePasswordFailed = 11,
        UserAllowedPermision = 12,
        UserDenyPermision = 13,
        UserAddedUserToGroup = 14,
        UserRemoveUserFromGroup = 15
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

        public static string UserChangePasswordSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserChangePasswordSuccess.ToString());
            }
        }

        public static string UserGroupAddFailed
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserGroupAddFailed.ToString());
            }
        }

        public static string UserGroupAddSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserGroupAddSuccess.ToString());
            }
        }

        public static string UserGroupAccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserGroupAccess.ToString());
            }
        }

        public static string UserGroupDeleteSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserGroupDeleteSuccess.ToString());
            }
        }

        public static string UserGroupEditSuccess
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserGroupEditSuccess.ToString());
            }
        }

        public static string UserGroupEditFailed
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserGroupEditFailed.ToString());
            }
        }

        public static string UserChangePasswordFailed
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserChangePasswordFailed.ToString());
            }
        }

        public static string UserAllowedPermision
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserAllowedPermision.ToString());
            }
        }

        public static string UserDenyPermision
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserDenyPermision.ToString());
            }
        }

        public static string UserAddedUserToGroup
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserAddedUserToGroup.ToString());
            }
        }

        public static string UserRemoveUserFromGroup
        {
            get
            {
                return ResourceMgr.GetString(AuditEventTypes.UserRemoveUserFromGroup.ToString());
            }
        }
    }
}
