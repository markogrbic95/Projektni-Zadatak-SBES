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
        bool registration(string name, string surname, string email, string phoneNumber, string accNumber, string username, SecureString password);

        [OperationContract]
        bool changePassword(string username, SecureString oldPassword, SecureString newPassword);

        [OperationContract]
        bool login(string username, SecureString password);

        [OperationContract]
        bool logout(string username);
    }
}
