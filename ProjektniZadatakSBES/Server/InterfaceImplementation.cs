using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Server
{
    public class InterfaceImplementation : Interface
    {
        public static Dictionary<string,User> registeredUsers = new Dictionary<string, User>();
        public static Dictionary<string, List<Group>> listaGrupa = new Dictionary<string, List<Group>>();
        public static List<Group> grupe = new List<Group>();
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

        public string Registration(string name, string lastname, string address, string phoneNumber, string accNumber, string username, string password)
        {
            registeredUsers = ReadFile();

            if(registeredUsers.ContainsKey(username))
            {
                Console.WriteLine("This user already exist!");
                return "This user already exist!";
            }
            else
            {
                registeredUsers.Add(username, new User(name, lastname, address, phoneNumber, accNumber, username, password));
                WriteFile();
                return "Success";
            }
        }

        public Dictionary<string,User> ReadFile()
        {
            try
            {
                    XmlSerializer ser = new XmlSerializer(typeof(List<User>));
                    StreamReader sr = new StreamReader(@"../../../users.xml");
                    var tempList = (List<User>)ser.Deserialize(sr);
                    registeredUsers = tempList.ToDictionary(x => x.Username);

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

        public List<Group> ReadGroups()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Group>));
                StreamReader sr = new StreamReader(@"../../../groups.xml");
                grupe = (List<Group>)ser.Deserialize(sr);
                sr.Close();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return grupe;
        }



        public void WriteFile()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<User>));
                StreamWriter sw = new StreamWriter(@"../../../users.xml");
                var tempList = registeredUsers.Select(kvp => kvp.Value).ToList();
                ser.Serialize(sw, tempList);
                sw.Close();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void WriteGroups()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Group>));
                StreamWriter sw = new StreamWriter(@"../../../groups.xml");
                ser.Serialize(sw, grupe);
                sw.Close();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public bool AddGroup(string groupName, string owner)
        {
            grupe = ReadGroups();

            foreach (var item in grupe)
            {
                if (item.GroupName==groupName)
                {
                    if(item.Owner == owner)
                    {
                        return false;
                    }
                }                
            }            

            Group g = new Group();
            g.GroupName = groupName;
            g.Owner = owner;
            g.ListaKorisnika = null;

            grupe.Add(g);
            WriteGroups();
            return true;
            
            /*
                Group g = new Group();
                g.GroupName = groupName;
                g.ListaKorisnika = null;
                List<Group> pomocna = new List<Group>();
                pomocna.Add(g);
                listaGrupa.Add(owner, pomocna);
                WriteGroups(owner);
                return true;
            
            */
        }

        public bool DeleteGroup(string groupName, string owner)
        {
            grupe = ReadGroups();

            foreach (var item in grupe)
            {
                if (item.GroupName == groupName)
                {
                    if (item.Owner == owner)
                    {
                        grupe.Remove(item);
                        WriteGroups();
                        return true;
                    }
                }
            }

            return false;
        }

        public bool AddUsersToGroup(string groupName, string owner, string username)
        {
            throw new NotImplementedException();
        }
    }
}
