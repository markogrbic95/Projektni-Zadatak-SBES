﻿using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        public bool Registration(string name, string lastname, string address, string phoneNumber, string accNumber, string username, string password)
        {
            registeredUsers = ReadFile();

            if(registeredUsers.ContainsKey(username))
            {
                Console.WriteLine("This user already exist!");
                return false;
            }
            else
            {
                registeredUsers.Add(username, new User(name, lastname, address, phoneNumber, accNumber, username, password));
                WriteFile();
                return true;
            }
        }

        public Dictionary<string,User> ReadFile()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Dictionary<string, User>));
                StreamReader sr = new StreamReader(@"../../../users.xml");
                registeredUsers = (Dictionary<string, User>)ser.Deserialize(sr);
                sr.Close();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return registeredUsers;
        }


        public void WriteFile()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Dictionary<string, User>));
                StreamWriter sw = new StreamWriter(@"../../../users.xml");
                ser.Serialize(sw, registeredUsers);
                sw.Close();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}