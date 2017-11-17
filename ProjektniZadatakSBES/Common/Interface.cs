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
        bool ChangePassword(string username, string oldPassword, string newPassword);

        [OperationContract]
        bool Login(string username, string password);

        [OperationContract]
        bool Logout(string username);

        [OperationContract]
        bool AddGroup(string groupName, string owner);

        [OperationContract]
<<<<<<< HEAD
        List<User> AllUsersList();
=======
        bool DeleteGroup(string groupName, string owner);

        [OperationContract]
        bool AddUsersToGroup(string groupName, string owner,string username);

        [OperationContract]
        bool DeleteUsersFromGroup(string groupName, string owner, string username);

>>>>>>> 4cf355c5197097a5057737d018e4a3282ea72606
    }
}
