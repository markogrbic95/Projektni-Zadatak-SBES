using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace Server
{
    class InterfaceImplementation : Interface
    {
        public bool changePassword(string username, SecureString oldPassword, SecureString newPassword)
        {
            throw new NotImplementedException();
        }

        public bool login(string username, SecureString password)
        {
            throw new NotImplementedException();
        }

        public bool logout(string username)
        {
            throw new NotImplementedException();
        }

        public bool registration(string name, string surname, string email, string phoneNumber, string accNumber, string username, SecureString password)
        {
            throw new NotImplementedException();
        }
    }
}
