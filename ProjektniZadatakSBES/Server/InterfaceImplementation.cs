using Common;
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
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Logout(string username)
        {
            throw new NotImplementedException();
        }

        public bool Registration(string name, string lastname, string address, string phoneNumber, string accNumber, string username, string password)
        {
            Dictionary<string,User> users = ReadFile();

            if(users.ContainsKey(username))
            {
                Console.WriteLine("Ovaj user vec postoji");
                return false;
            }
            else
            {
                users.Add(username, new User(name, lastname, address, phoneNumber, accNumber, username, password));
                WriteFile(users);
                return true;
            }
            
        }

        public Dictionary<string,User> ReadFile()
        {
           
            Dictionary<string,User> users = new Dictionary<string, User>();
            try
            {
                
                XmlSerializer ser = new XmlSerializer(typeof(Dictionary<string, User>));
                StreamReader sr = new StreamReader(@"../../../users.xml");
                users = (Dictionary<string, User>)ser.Deserialize(sr);
                sr.Close();

            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return users;
        }


        public void WriteFile(Dictionary<string, User> users)
        {

            
            try
            {

                XmlSerializer ser = new XmlSerializer(typeof(Dictionary<string, User>));
                StreamWriter sw = new StreamWriter(@"../../../users.xml");
                ser.Serialize(sw, users);
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
