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
        bool Registration(string name, string lastname, string address, string phoneNumber, string accNumber, string username, string password);

        [OperationContract]
        bool ChangePassword(string username, string oldPassword, string newPassword);

        [OperationContract]
        bool Login(string username, string password);

        [OperationContract]
        bool Logout(string username);
    }
}
