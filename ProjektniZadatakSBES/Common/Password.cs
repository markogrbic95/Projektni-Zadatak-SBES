using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Password
    {
        private string user;
        private string oldPassword;

        public Password(string user, string oldPassword)
        {
            this.user = user;
            this.oldPassword = oldPassword;
        }

        public Password()
        {

        }

        [DataMember]
        public string User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        [DataMember]
        public string OldPassword
        {
            get
            {
                return oldPassword;
            }

            set
            {
                oldPassword = value;
            }
        }
    }
}
