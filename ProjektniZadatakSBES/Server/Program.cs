using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
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
            bool upitnik1 = i.AddGroup("grupa1", "Dex");
            bool upitnik3 = i.AddGroup("grupa2", "sokiSole");
            bool upitnik4= i.AddGroup("grupa1", "sokiSole");
            /*
            List<User> users = new List<User>();
            users.Add(new User("Nenad", "Grini", "A", "1", "1", "1", "1"));
            i.WriteFile(users);

            i.ReadFile();
            */
            Console.ReadKey();


            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/InterfaceImplementation";

            ServiceHost host = new ServiceHost(typeof(InterfaceImplementation));
            host.AddServiceEndpoint(typeof(Interface), binding, address);

            host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            host.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });

            host.Open();

            Console.WriteLine("Server is started.");
            Console.WriteLine("Press <enter> to stop server...");

            Console.ReadLine();
            host.Close();

        }
    }
}
