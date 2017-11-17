using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Group
    {
        private string groupName;
        private string owner;
        private List<string> usersList= new List<string>();

        public Group()
        {
            usersList = new List<string>();
        }

        [DataMember]
        public string GroupName
        {
            get
            {
                return groupName;
            }

            set
            {
                groupName = value;
            }
        }
        [DataMember]
        public string Owner
        {
            get
            {
                return owner;
            }

            set
            {
                owner = value;
            }
        }
        [DataMember]
        public List<string> UsersList
        {
            get
            {
                return usersList;
            }

            set
            {
                usersList = value;
            }
        }
    }
}
