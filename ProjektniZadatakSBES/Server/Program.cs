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
<<<<<<< HEAD
        { 
=======
<<<<<<< HEAD
        {     
=======


        {               




            InterfaceImplementation i = new InterfaceImplementation();
            string nesto = i.PasswordCheck("asdjflkasjdflka");
            string nesto1 = i.PasswordCheck("HOIoih909");
            string nesto2 = i.PasswordCheck("JOIUaf8-..asdf");
            string nesto3 = i.PasswordCheck("as[df46");
            string nesto4 = i.PasswordCheck("asdjflk687414asjdflka");
            string nesto5 = i.PasswordCheck("25235235235...");

            string broj = i.BankingAccountCheck("97641684134644");
            string broj1 = i.BankingAccountCheck("192-1684444444444-65");
            string broj2 = i.BankingAccountCheck("9764-1684134644778-4");

            bool upitnik=i.AddGroup("grupa1", "sokiSole");
            bool upitnik1 = i.AddGroup("grupa1", "Dex");
            bool upitnik3 = i.AddGroup("grupa2", "sokiSole");
            bool upitnik4= i.AddGroup("grupa1", "sokiSole");
            
            i.AddUsersToGroup("grupa2", "sokiSole","grba");
            i.DeleteUsersFromGroup("grupa2", "sokiSole", "grba");
            /*
            List<User> users = new List<User>();
            users.Add(new User("Nenad", "Grini", "A", "1", "1", "1", "1"));
            i.WriteFile(users);

            i.ReadFile();
            */



>>>>>>> 1cd128f447829f1d582d791c4135d5672f700e80
>>>>>>> 4cf355c5197097a5057737d018e4a3282ea72606
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:25001/InterfaceImplementation";

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
