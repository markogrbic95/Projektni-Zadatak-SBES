using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            


            InterfaceImplementation i = new InterfaceImplementation();
            bool upitnik=i.AddGroup("grupa1", "sokiSole");
            /*
            List<User> users = new List<User>();
            users.Add(new User("Nenad", "Grini", "A", "1", "1", "1", "1"));
            i.WriteFile(users);

            i.ReadFile();
            */
            Console.ReadKey();
        }
    }
}
