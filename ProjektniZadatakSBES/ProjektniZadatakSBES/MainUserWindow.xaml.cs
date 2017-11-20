using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektniZadatakSBES
{
    /// <summary>
    /// Interaction logic for MainUserWindow.xaml
    /// </summary>
    public partial class MainUserWindow : Window
    {
        User loggedUser;

        public static NetTcpBinding binding = new NetTcpBinding();
        public static string address = "net.tcp://localhost:25001/InterfaceImplementation";
        public static ClientProxy clientProxy;

        public MainUserWindow(User user, ClientProxy proxy)
        {
            InitializeComponent();
            loggedUser = user;
            clientProxy = proxy;

            SetUsersAndGroups();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void exitBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void exitBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SetUsersAndGroups()
        {
            List<User> users = clientProxy.AllUsersList();

            foreach(User user in users)            
                usersStackPanel.Children.Add(new miniUserInfo(user.Username));            
        }
    }
}
