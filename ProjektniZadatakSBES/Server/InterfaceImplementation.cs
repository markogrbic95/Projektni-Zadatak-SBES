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
<<<<<<< HEAD
        public static List<Group> groupList = new List<Group>();
=======
        public static Dictionary<string, List<Group>> listaGrupa = new Dictionary<string, List<Group>>();
        public static List<Group> grupe = new List<Group>();
        public static List<string> numberList = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public static List<string> interpunctionList = new List<string>() { ".", "?", "!", ",", ";", ":", "-" };

>>>>>>> 4cf355c5197097a5057737d018e4a3282ea72606
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
                groupList = (List<Group>)ser.Deserialize(sr);
                sr.Close();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return groupList;
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
                ser.Serialize(sw, groupList);
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
<<<<<<< HEAD
            groupList = ReadGroups();

            foreach (var item in groupList)
=======
            grupe = ReadGroups();

            foreach (var item in grupe)
>>>>>>> 4cf355c5197097a5057737d018e4a3282ea72606
            {
                if (item.GroupName==groupName)
                {
                    if(item.Owner == owner)
                    {
                        return false;
                    }
<<<<<<< HEAD
                }
                
            }
            Group g = new Group();
            g.GroupName = groupName;
            g.Owner = owner;
            g.UsersList = null;

            groupList.Add(g);
            WriteGroups();

            return true;
        }
=======
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

        public bool AddUsersToGroup(string groupName, string owner,string username)
        {

            grupe = ReadGroups();

            registeredUsers = ReadFile();

            foreach (var item in grupe)
            {
                if (item.GroupName == groupName)
                {
                    if (item.Owner == owner)
                    {
                       
                        foreach (var item1 in registeredUsers.Values)
                        {
                            if(item1.Username==username)
                            {
                                foreach (var item2 in item.ListaKorisnika)
                                {
                                    if (item2 == username)
                                        return false;
                                }
                                item.ListaKorisnika.Add(item1.Username);
                                WriteGroups();
                                return true;
                            }
                        }
                    }
                }

            }
            return false;
>>>>>>> 4cf355c5197097a5057737d018e4a3282ea72606

        public List<User> AllUsersList()
        {
            var tempDict =  ReadFile();
            var tempList = tempDict.Select(kvp => kvp.Value).ToList();

            return tempList;
        }

<<<<<<< HEAD
        public string PasswordCheck(string password)
        {
            string retVal;
            bool check = false;

            if (password.Length < 10)
            {
                retVal = "Password must have at least 10 characters!";

                return retVal;
            }
            else if (password.Length > 20)
            {
                retVal = "Password can't have over 20 characters!";

                return retVal;
            }

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsLower(password[i]))
                {
                    check = true;
                    break;
                }
            }

            if (check == false)
            {
                retVal = "Password must have at least one lower case character!";

                return retVal;
            }

            check = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(password[i]))
                {
                    check = true;
                    break;
                }
            }

            if (check == false)
            {
                retVal = "Password must have at least one upper case character!";

                return retVal;
            }

            check = false;

            foreach (var item in numberList)
            {
                if (password.Contains(item))
                {
                    check = true;
                    break;
                }
            }

            if (check == false)
            {
                retVal = "Password must have at least one number!";

                return retVal;
            }

            check = false;

            foreach (var item in interpunctionList)
            {
                if (password.Contains(item))
                {
                    check = true;
                    break;
                }
            }

            if (check == false)
            {
                retVal = "Password must have at least one interpunction character!";

                return retVal;
            }

            check = false;

            retVal = "Your password is good!";

            return retVal;
        }

        public string BankingAccountCheck(string acc)
        {
            string retVal;
            bool check = false;

            if (acc.Length == 20)
            {
                for (int i = 0; i < acc.Length; i++)
                {
                    if (i == 3 || i == 17)
                    {
                        if (acc[i] == '-')
                        {
                            continue;
                        }
                        else
                        {
                            retVal = "Fourth and Eighteenth character must have be a -";
                            return retVal;
                        }
                    }

                    foreach (var item in numberList)
                    {
                        if (acc[i].ToString() == item)
                        {
                            check = true;
                            break;
                        }
                    }

                    if (check == false)
                    {
                        retVal = i+1 + "." + " digit of yours Banking Account must have be a number";
                        return retVal;
                    }

                    check = false;
                }
                

                retVal = "Your Banking Account is good!";
                return retVal;
            }
            else
            {
                retVal = "Your Banking Account must have 20 characters";
                return retVal;
            }
=======
        public bool DeleteUsersFromGroup(string groupName, string owner, string username)
        {

            grupe = ReadGroups();

            registeredUsers = ReadFile();

            foreach (var item in grupe)
            {
                if (item.GroupName == groupName)
                {
                    if (item.Owner == owner)
                    {

                        foreach (var item1 in registeredUsers.Values)
                        {
                            if (item1.Username == username)
                            {
                                foreach (var item2 in item.ListaKorisnika)
                                {
                                    if (item2 == username)
                                    {
                                        item.ListaKorisnika.Remove(item2);
                                        WriteGroups();
                                        return true;
                                    }
                                    
                                }
                                
                            }
                        }
                    }
                }

            }
            return false;



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
>>>>>>> 8d72d2989348316b8741b7329c01843fb2232905
        }
    }
}
