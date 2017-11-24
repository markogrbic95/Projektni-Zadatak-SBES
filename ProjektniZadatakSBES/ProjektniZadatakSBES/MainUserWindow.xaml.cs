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
        public User loggedUser;        
        public ClientProxy clientProxy;

        public MainUserWindow(User user, ClientProxy proxy)
        {
            InitializeComponent();
            loggedUser = user;
            clientProxy = proxy;

            SetUsersAndGroups();
            ContentArea.Content = new Info(loggedUser,"user");
            ((Info)ContentArea.Content).SetInfo();

            deleteGroupButton.Visibility = Visibility.Hidden;
            changeGroupButton.Visibility = Visibility.Hidden;
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

        private void SetUsersAndGroups()
        {
            List<User> users = clientProxy.AllUsersList();
            List<Group> userGroups = clientProxy.GetUserGroups(loggedUser.Username);

            foreach (User user in users)            
                usersStackPanel.Children.Add(new MiniInfo(user.Username, "user"));

            foreach (Group group in userGroups)
                myGroupsStackPanel.Children.Add(new MiniInfo(group.GroupName, "group"));
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
            changeGroupWindow.Show();
            return;            
        }

        private void changePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow(new Point(this.Left, this.Top));
            changePasswordWindow.Owner = this;
            changePasswordWindow.Show();
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

       /* private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            string[] split = ((Info)ContentArea.Content).nameLabel.Content.ToString().Split('-');
            clientProxy.AddUserPermission(loggedUser.Username,split[1].Trim());
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            clientProxy.RemoveUserPermission(loggedUser.Username, ((Info)ContentArea.Content).nameLabel.Content.ToString());
        }
        */
    }
}
