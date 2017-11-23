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
            bool result = false;
            try
            {
                result = factory.AddUsersToGroup(groupName, owner, username);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return result;
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
            bool result = false;
            try
            {
                result = factory.DeleteGroup(groupName, owner);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return result;
        }

        public bool DeleteUsersFromGroup(string groupName, string owner, string username)
        {
            bool result = false;
            try
            {
                result = factory.DeleteUsersFromGroup(groupName, owner, username);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return result;
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
            List<Group> groups = new List<Group>();
            try
            {
                groups = factory.GetUserGroups(username);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return groups;
        }

        public bool ChangeGroupName(string oldName, string newName, string owner)
        {
            bool result = false;
            try
            {
                result = factory.ChangeGroupName(oldName, newName, owner);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return result;
        }

        public List<Group> ReadGroups()
        {
            List<Group> groups = new List<Group>();
            try
            {
                groups = factory.ReadGroups();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return groups;
        }

        public void AddUserPermission(string owner, string username)
        {
            try
            {
                factory.AddUserPermission(owner, username);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void RemoveUserPermission(string owner, string username)
        {
            try
            {
                factory.RemoveUserPermission(owner, username);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void AddGroupPermission(string owner, string groupName)
        {
            try
            {
                factory.AddGroupPermission(owner, groupName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void RemoveGroupPermission(string owner, string groupName)
        {
            try
            {
                factory.RemoveGroupPermission(owner, groupName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
    }
}
