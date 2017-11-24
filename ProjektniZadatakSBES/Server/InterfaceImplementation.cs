using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Server
{
    public class InterfaceImplementation : Interface
    {
        public static Dictionary<string, User> registeredUsers = new Dictionary<string, User>();
        public static List<Group> groupList = new List<Group>();
        public static List<Password> passwordList = new List<Password>();
        
        public static List<string> numberList = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public static List<string> interpunctionList = new List<string>() { ".", "?", "!", ",", ";", ":", "-" };

        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");

        public string ChangePassword(string username, string newPassword)
        {
            registeredUsers = ReadFile();
            passwordList = ReadPasswords();
            string retVal = string.Empty;
            string decryptedPassword = Decrypt(newPassword);

            retVal = PasswordCheck(decryptedPassword);
            if (retVal != "Success!")
                return retVal;

            if (registeredUsers.ContainsKey(username))
            {
                List<string> userPasswords = new List<string>();

                foreach (var item in passwordList)
                {
                    if (item.User == username)
                        userPasswords.Add(item.OldPassword);
                }

                foreach (var item in userPasswords)
                {
                    if(item == decryptedPassword)
                    {
                        Console.WriteLine("You cant use previous passwords");
                        return "You cant use previous passwords";
                    }
                }

                Password pass = new Password(username, decryptedPassword);
                passwordList.Add(pass);
                registeredUsers[username].Password = decryptedPassword;

                WriteFile();
                WritePasswords();

                Console.WriteLine("Password changed successfuly");

                return "Success";

            }
            else
            {
                Console.WriteLine("User with {0} username does not exist!", username);
                return "User with " + username + " username does not exist!";
            }
        }

        public User Login(string username, string password)
        {
            registeredUsers = ReadFile();

            string decryptedPassword = Decrypt(password);

            if (registeredUsers.ContainsKey(username))
            {
                if(registeredUsers[username].Password == decryptedPassword)
                {
                    registeredUsers[username].Logged = true;
                    Console.WriteLine("{0} logged successfully!",username);

                    return registeredUsers[username];
                }
                else
                {
                    Console.WriteLine("Incorrect password!");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Incorrect username!");
                return null;
            }
        }

        public bool Logout(string username)
        {
            registeredUsers = ReadFile();

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
            string retVal = string.Empty;
            passwordList = ReadPasswords();
            registeredUsers = ReadFile();

            string decryptedAddress = Decrypt(address);
            string decryptedPhoneNumber = Decrypt(phoneNumber);
            string decryptedAccNumber = Decrypt(accNumber);
            string decryptedPassword = Decrypt(password);

            if (registeredUsers.ContainsKey(username))
            {
                Console.WriteLine("This user already exist!");
                return "This user already exist!";
            }
            else
            {
                retVal = PasswordCheck(decryptedPassword);
                if (retVal != "Success!")
                    return retVal;

                retVal = BankingAccountCheck(decryptedAccNumber);
                if (retVal != "Success!")
                    return retVal;

                if(decryptedPhoneNumber.Length < 9 || decryptedPhoneNumber.Length > 10)
                {
                    return "Phone number must contain 9 or 10 numbers!";
                }

                try
                {
                    Convert.ToInt32(decryptedPhoneNumber);
                }
                catch (Exception)
                {
                    return "Phone number can't contain letters!";
                }

                registeredUsers.Add(username, new User(name, lastname, decryptedAddress, decryptedPhoneNumber, decryptedAccNumber, username, decryptedPassword));

                WriteFile();

                Password pass = new Password(username, decryptedPassword);
                passwordList.Add(pass);
                WritePasswords();

                return "Success!";
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

        public List<Password> ReadPasswords()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Password>));
                StreamReader sr = new StreamReader(@"../../../passwords.xml");
                passwordList = (List<Password>)ser.Deserialize(sr);
                sr.Close();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return passwordList;
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

        public void WritePasswords()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Password>));
                StreamWriter sw = new StreamWriter(@"../../../passwords.xml");
                ser.Serialize(sw, passwordList);
                sw.Close();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public List<Group> GetUserGroups(string username)
        {
            var tempList = ReadGroups();
            List<Group> userGroupList = new List<Group>();

            foreach (var item in tempList)
            {
                if (item.Owner == username)
                {
                    userGroupList.Add(item);
                }
            }
            return userGroupList;
        }

        public bool AddGroup(string groupName, string owner)
        {
            groupList = ReadGroups();

            foreach (var item in groupList)
            {
                if (item.GroupName == groupName && item.Owner == owner)
                {
                    return false;
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

        public bool AddUsersToGroup(string groupName, string owner, string username)
        {
            groupList = ReadGroups();
            registeredUsers = ReadFile();

            foreach (var item in groupList)
            {
                if (item.GroupName == groupName && item.Owner == owner)
                {
                    foreach (var item1 in registeredUsers.Values)
                    {
                        if (item1.Username == username)
                        {
                            foreach (var item2 in item.UsersList)
                            {
                                if (item2 == username)
                                    return false;
                            }

                            item.UsersList.Add(item1.Username);
                            WriteGroups();
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public List<User> AllUsersList()
        {
            var tempDict =  ReadFile();
            var tempList = tempDict.Select(kvp => kvp.Value).ToList();

            return tempList;
        }

        public bool DeleteUsersFromGroup(string groupName, string owner, string username)
        {
            groupList = ReadGroups();
            registeredUsers = ReadFile();

            foreach (var item in groupList)
            {
                if (item.GroupName == groupName && item.Owner == owner)
                {
                    foreach (var item1 in registeredUsers.Values)
                    {
                        if (item1.Username == username)
                        {
                            foreach (var item2 in item.UsersList)
                            {
                                if (item2 == username)
                                {
                                    item.UsersList.Remove(item2);
                                    WriteGroups();
                                    return true;
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
            groupList = ReadGroups();

            foreach (var item in groupList)
            {
                if (item.GroupName == groupName && item.Owner == owner)
                {
                    groupList.Remove(item);
                    WriteGroups();
                    return true;
                }
            }

            return false;
        }

        public bool ChangeGroupName(string oldName, string newName, string owner)
        {
            groupList = ReadGroups();

            foreach (var item in groupList)
            {
                if (item.GroupName == newName && item.Owner == owner)
                {
                    Console.WriteLine("You already have group with this name");
                    return false;
                }
            }

            foreach (var item in groupList)
            {
                if (item.GroupName == oldName && item.Owner == owner)
                {
                    item.GroupName = newName;
                    WriteGroups();
                    return true;
                }
            }

            return false;
        }

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

            retVal = "Success!";

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
                        retVal = i + 1 + "." + " digit of yours Banking Account must have be a number";
                        return retVal;
                    }

                    check = false;
                }

                registeredUsers = ReadFile();
                foreach (var item in registeredUsers)
                {
                    if (item.Value.AccountNumber == acc)
                    {
                        retVal = "Banking Account already exist!";
                        return retVal;
                    }
                }
                retVal = "Success!";
                return retVal;
            }
            else
            {
                retVal = "Your Banking Account must have 20 characters";
                return retVal;
            }
        }

        public static string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException
                   ("The string which needs to be decrypted can not be null.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);

            return reader.ReadToEnd();
        }
    }
}
