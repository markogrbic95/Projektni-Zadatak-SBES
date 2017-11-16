using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class InterfaceImplementation : Interface
    {
        public static Dictionary<string,User> registeredUsers = new Dictionary<string, User>();
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            if (registeredUsers.ContainsKey(username))
            {
                if (registeredUsers[username].Password == oldPassword)
                {
                    registeredUsers[username].Password = newPassword;
                    Console.WriteLine("Password has been successfully changed!");

                    return true;
                }
                else
                {
                    Console.WriteLine("Old password is incorrect!");
                    return false;
                }

            }
            else
            {
                Console.WriteLine("User with {0} username does not exist!", username);
                return false;
            }
        }

        public bool Login(string username, string password)
        {
            if (registeredUsers.ContainsKey(username))
            {
                if(registeredUsers[username].Password == password)
                {
                    registeredUsers[username].Logged = true;
                    Console.WriteLine("{0} logged successfully!",username);

                    return true;
                }
                else
                {
                    Console.WriteLine("Incorrect password!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Incorrect username!");
                return false;
            }
        }

        public bool Logout(string username)
        {
            if (registeredUsers[username].Logged)
            {
                registeredUsers[username].Logged = false;
                Console.WriteLine("User {0} successfully logout!", username);
                return true;
            }
            else
            {
                Console.WriteLine("You must be logged!");
                return false;
            }
        }

        public bool Registration(string name, string surname, string email, string phoneNumber, string accNumber, string username, string password)
        {


            return true;
        }
    }
}
