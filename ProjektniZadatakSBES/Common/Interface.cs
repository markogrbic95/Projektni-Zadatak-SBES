using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface Interface
    {
        [OperationContract]
        string Registration(string name, string lastname, string address, string phoneNumber, string accNumber, string username, string password);

        [OperationContract]
        string ChangePassword(string username, string newPassword);

        [OperationContract]
        User Login(string username, string password);

        [OperationContract]
        bool Logout(string username);

        [OperationContract]
        bool AddGroup(string groupName, string owner);

        [OperationContract]
        List<User> AllUsersList();

        [OperationContract]
        bool DeleteGroup(string groupName, string owner);

        [OperationContract]
        bool AddUsersToGroup(string groupName, string owner,string username);

        [OperationContract]
        bool DeleteUsersFromGroup(string groupName, string owner, string username);

        [OperationContract]
        List<Group> GetUserGroups(string username);

        [OperationContract]
        bool ChangeGroupName(string oldName, string newName, string owner);

        [OperationContract]
        List<Group> ReadGroups();

        [OperationContract]
        void AddUserPermission(string owner, string username);

        [OperationContract]
        void RemoveUserPermission(string owner, string username);

        [OperationContract]
        void AddGroupPermission(string owner, string groupName);

        [OperationContract]
        void RemoveGroupPermission(string owner, string groupName);

        [OperationContract]
        List<string> ReadFromGroup(string groupName);

        [OperationContract]
        Dictionary<string, User> ReadFile();
    }
}
