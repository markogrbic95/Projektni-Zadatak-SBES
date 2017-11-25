using Common;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for AddUserToGroupWindow.xaml
    /// </summary>
    public partial class AddUserToGroupWindow : Window
    {
        public AddUserToGroupWindow(Point p)
        {
            InitializeComponent();

            this.Left = p.X + 720;
            this.Top = p.Y + 90;            
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
            this.Close();
        }

        private void addUserToGroupButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> usernamesToAdd = new List<string>();

            foreach (UserChecker uc in usersStackPanel.Children)
            {
                if ((bool)uc.checkBox.IsChecked)
                    usernamesToAdd.Add(uc.nameLabel.Content.ToString());
            }

            foreach (Group g in ((MainUserWindow)this.Owner).clientProxy.ReadGroups())
            {
                if (g.Owner == ((MainUserWindow)this.Owner).loggedUser.Username && g.GroupName == ((Info)((MainUserWindow)this.Owner).ContentArea.Content).nameLabel.Content.ToString())
                {
                    foreach(string usersInGroup in ((MainUserWindow)this.Owner).clientProxy.ReadFromGroup(g.GroupName))
                        ((MainUserWindow)this.Owner).clientProxy.DeleteUsersFromGroup(g.GroupName, g.Owner, usersInGroup);

                    foreach (string s in usernamesToAdd)
                        ((MainUserWindow)this.Owner).clientProxy.AddUsersToGroup(g.GroupName, g.Owner, s);

                    ((Info)((MainUserWindow)this.Owner).ContentArea.Content).listBox.ItemsSource = usernamesToAdd;
                    this.Close();
                }
            }     
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

        public void SetUsers()
        {
            foreach(Group g in ((MainUserWindow)this.Owner).clientProxy.ReadGroups())
            {
                if (g.Owner == ((MainUserWindow)this.Owner).loggedUser.Username && g.GroupName == ((Info)((MainUserWindow)this.Owner).ContentArea.Content).nameLabel.Content.ToString())
                {
                    foreach (User u in ((MainUserWindow)this.Owner).clientProxy.AllUsersList())
                    {
                        if(u.Username != g.Owner)
                        {
                            UserChecker uc = new UserChecker();
                            uc.nameLabel.Content = u.Username;

                            if (g.UsersList.Contains(u.Username))
                                uc.checkBox.IsChecked = true;

                            usersStackPanel.Children.Add(uc);
                        }
                    }
                }
            }
        }
    }
}
