using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    public class ClientProxy : ChannelFactory<Interface>, Interface, IDisposable
    {
        Interface factory;

        public ClientProxy(NetTcpBinding binding, string address) : base(binding, address)
        {
            factory = this.CreateChannel();
        }

        public bool AddGroup(string groupName, string owner)
        {
            bool result = false;
            try
            {
                result = factory.AddGroup(groupName, owner);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return result;
        }

        public List<User> AllUsersList()
        {
            List<User> users = new List<User>();
            try
            {
                users = factory.AllUsersList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return users;
        }

        public bool AddUsersToGroup(string groupName, string owner, string username)
        {
            return factory.AddUsersToGroup(groupName, owner, username);
        }

        public string ChangePassword(string username, string newPassword)
        {
            string result = "";
            try
            {
                result = factory.ChangePassword(username, newPassword);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                result = "Error: {0}" + e.Message;
            }
            return result;
        }

        public bool DeleteGroup(string groupName, string owner)
        {
            return factory.DeleteGroup(groupName, owner);
        }

        public bool DeleteUsersFromGroup(string groupName, string owner, string username)
        {
            return factory.DeleteUsersFromGroup(groupName, owner, username);
        }

        public User Login(string username, string password)
        {
            User tempUser = new User();
            try
            {
                tempUser = factory.Login(username, password);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return tempUser;
        }

        public bool Logout(string username)
        {
            bool result = false;
            try
            {
                result = factory.Logout(username);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return result;
        }

        public string Registration(string name, string lastname, string address, string phoneNumber, string accNumber, string username, string password)
        {
            string result = "";
            try
            {
                result = factory.Registration(name, lastname, address, phoneNumber, accNumber, username, password);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
                result = String.Format("Error: {0}", e.Message);
            }
            return result;
        }

        public List<Group> GetUserGroups(string username)
        {
            return factory.GetUserGroups(username);
        }

        public bool ChangeGroupName(string oldName, string newName, string owner)
        {
            return factory.ChangeGroupName(oldName, newName, owner);
        }

        public List<Group> ReadGroups()
        {
            return factory.ReadGroups();
        }
    }
}
