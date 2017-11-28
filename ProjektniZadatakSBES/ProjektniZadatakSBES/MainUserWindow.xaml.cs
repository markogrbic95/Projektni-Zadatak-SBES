using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        public User loggedUser;
        public ClientProxy clientProxy;

        Timer updateTimer = new Timer();
        public static List<User> usersList = new List<User>();
        public static List<Group> groupsList = new List<Group>();

        public MainUserWindow(User user, ClientProxy proxy)
        {
            InitializeComponent();
            loggedUser = user;
            clientProxy = proxy;

            usersList = clientProxy.AllUsersList();
            groupsList = clientProxy.ReadGroups();

            SetUsersAndGroups();

            updateTimer.Interval = 2000;
            updateTimer.Elapsed += new ElapsedEventHandler(updateTimer_Elpased);
            updateTimer.Start(); 

            ContentArea.Content = new Info(loggedUser,"user");
            ((Info)ContentArea.Content).SetInfo();

            deleteGroupButton.Visibility = Visibility.Hidden;
            changeGroupButton.Visibility = Visibility.Hidden;
        }

        private void updateTimer_Elpased(object sender, ElapsedEventArgs e)
        {
            usersList = clientProxy.AllUsersList();
            groupsList = clientProxy.ReadGroups();

            foreach(var user in usersList)
            {
                if (user.Username == loggedUser.Username)
                {
                    loggedUser = user;
                    break;
                }
            }

            SetUsersAndGroups();
        }

        private void SetUsersAndGroups()
        {
            List<string> usersNotToAdd = new List<string>();
            List<string> groupsNotToAdd = new List<string>();

            this.Dispatcher.Invoke(() =>
            {
                foreach (var user in usersList)
                {
                    foreach (MiniInfo miniInfo in usersStackPanel.Children)
                    {
                        if (miniInfo.Button.Content.ToString() == user.Username)
                            usersNotToAdd.Add(user.Username);
                    }
                }

                foreach (var group in groupsList)
                {
                    if (group.UsersList.Contains(loggedUser.Username) || group.Owner == loggedUser.Username)
                    {
                        if (myGroupsStackPanel.Children.Count > 0)
                        {
                            foreach (MiniInfo miniInfo in myGroupsStackPanel.Children)
                            {
                                if (miniInfo.Button.Content.ToString() == group.GroupName)
                                    groupsNotToAdd.Add(group.GroupName);
                            }
                        }
                    }
                    else
                        groupsNotToAdd.Add(group.GroupName);                       
                }

                foreach (var u in usersList)
                {
                    if (!usersNotToAdd.Contains(u.Username))
                        usersStackPanel.Children.Add(new MiniInfo(u.Username, "user"));
                }

                foreach (var g in groupsList)
                {
                    if (!groupsNotToAdd.Contains(g.GroupName))
                        myGroupsStackPanel.Children.Add(new MiniInfo(g.GroupName, "group"));
                }
            });            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void addGroupButton_Click(object sender, RoutedEventArgs e)
        {
            AddGroupWindow addGroupWindow = new AddGroupWindow(new Point(this.Left, this.Top));
            addGroupWindow.Owner = this;
            addGroupWindow.Show();
        }

        private void deleteGroupButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(MiniInfo mini in myGroupsStackPanel.Children)
            {
                if(mini.Button.Content.ToString() == ((Info)ContentArea.Content).nameLabel.Content.ToString())
                {
                    Audit.GroupDeleteSuccess(loggedUser.Username, mini.Button.Content.ToString());
                    myGroupsStackPanel.Children.Remove(mini);
                    clientProxy.DeleteGroup(mini.Button.Content.ToString(), loggedUser.Username);
                    break;
                }                        
            }            

            ((Info)ContentArea.Content).obj = loggedUser;
            ((Info)ContentArea.Content).type = "user";
            ((Info)ContentArea.Content).SetInfo();

            deleteGroupButton.Visibility = Visibility.Hidden;
            changeGroupButton.Visibility = Visibility.Hidden;
        }

        private void changeGroupButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeGroupWindow changeGroupWindow = new ChangeGroupWindow(new Point(this.Left, this.Top));
            changeGroupWindow.Owner = this;
            changeGroupWindow.SetGroupName();
            changeGroupWindow.Show();
        }

        private void changePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow(new Point(this.Left, this.Top));
            changePasswordWindow.Owner = this;
            changePasswordWindow.Show();
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            clientProxy.Logout(loggedUser.Username);
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Color.FromRgb(247, 119, 99));
            ((Button)sender).Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Color.FromRgb(227, 99, 79));
            ((Button)sender).Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void myGroupsButton_Click(object sender, RoutedEventArgs e)
        {   
            if(usersScrollViewer.ActualHeight != 0)
            {
                if (myGroupsScrollViewer.ActualHeight == 0)
                {
                    myGroupsScrollViewer.Height = 225;
                    myGroupsScrollViewer.Margin = new Thickness(0, 305, 520, 0);
                    myGroupsButton.Margin = new Thickness(0, 265, 520, 225);
                    usersScrollViewer.Height = 225;
                    return;
                }
                else
                {
                    myGroupsScrollViewer.Height = 0;
                    myGroupsScrollViewer.Margin = new Thickness(0, 530, 0, 0);
                    myGroupsButton.Margin = new Thickness(0, 490, 520, 0);
                    usersScrollViewer.Height = 450;
                    return;
                }
            } 
        }

        private void usersButton_Click(object sender, RoutedEventArgs e)
        {
            if (myGroupsScrollViewer.ActualHeight != 0)
            {
                if (usersScrollViewer.ActualHeight == 0)
                {
                    usersScrollViewer.Height = 225;
                    myGroupsScrollViewer.Margin = new Thickness(0, 305, 520, 0);
                    myGroupsButton.Margin = new Thickness(0, 265, 520, 225);
                    usersScrollViewer.Height = 225;
                    return;
                }
                else
                {
                    usersScrollViewer.Height = 0;
                    myGroupsButton.Margin = new Thickness(0, 40, 520, 450);
                    myGroupsScrollViewer.Height = 450;
                    myGroupsScrollViewer.Margin = new Thickness(0, 80, 0, 0);
                    return;
                }
            }
        }
    }
}
