using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class User
    {
        private string name = string.Empty;
        private string lastName = string.Empty;
        private string address = string.Empty;
        private string phoneNumber = string.Empty;
        // valid bank account : 200000000001234512 ---> 18 numbers;
        // zeros can be removed, like this : 200-12345-12
        private string accountNumber = string.Empty;
        private string username = string.Empty;
        private string password = string.Empty;
        private bool logged = false;

        public User(string name, string lastName, string address, string phoneNumber, string accountNumber, string username, string password)
        {
            this.name = name;
            this.lastName = lastName;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.accountNumber = accountNumber;
            this.username = username;
            this.password = password;
            this.logged = false;
        }

        [DataMember]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        [DataMember]
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        [DataMember]
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        [DataMember]
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }

        [DataMember]
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }

            set
            {
                accountNumber = value;
            }
        }

        [DataMember]
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        [DataMember]
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        [DataMember]
        public bool Logged
        {
            get
            {
                return logged;
            }

            set
            {
                logged = value;
            }
        }
    }
}
