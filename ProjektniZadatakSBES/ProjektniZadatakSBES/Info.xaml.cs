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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektniZadatakSBES
{
    /// <summary>
    /// Interaction logic for Info.xaml
    /// </summary>
    public partial class Info : UserControl
    {
        public string type = "";
        public object obj;

        public Info(object obj, string type)
        {
            InitializeComponent();
            this.type = type;
            this.obj = obj;
            //SetInfo();
        }

        public void SetInfo()
        {
            if (type == "user")
            {
                Dictionary<string, User> users = MainWindow.proxy.ReadFile();
                User u = new User();
                u = ((User)obj);

                if (u.AllowedUsers.Count > 0 && u.AllowedUsers.Contains(((MainUserWindow)((Grid)((DockPanel)((ContentControl)this.Parent).Parent).Parent).Parent).loggedUser.Username))
                {
                    addressLabel.Visibility = Visibility.Visible;
                    bankaccLabel.Visibility = Visibility.Visible;
                    phoneLabel.Visibility = Visibility.Visible;
                    passwordLabel.Visibility = Visibility.Visible;
                    listBox.Visibility = Visibility.Hidden;
                    addUserBtn.Visibility = Visibility.Hidden;
                    delUserBtn.Visibility = Visibility.Hidden;
                    addLabel.Visibility = Visibility.Hidden;
                    delLabel.Visibility = Visibility.Hidden;

                    image.Source = new BitmapImage(new Uri(@"\Resources\username.png", UriKind.RelativeOrAbsolute));
                    buttonImage.Source = new BitmapImage(new Uri(@"\Resources\permissionsNotAllowed.png", UriKind.RelativeOrAbsolute));
                    perLabel.Content = "Deny Permisson";
                    nameLabel.Content = ((User)obj).Name + " " + ((User)obj).LastName + " - " + ((User)obj).Username;
                    addressLabel.Content = "Adresa: " + ((User)obj).Address;
                    bankaccLabel.Content = "Broj racuna: " + ((User)obj).AccountNumber;
                    phoneLabel.Content = "Telefon: " + ((User)obj).PhoneNumber;
                    passwordLabel.Content = "Lozinka: " + ((User)obj).Password;
                }
                else
                {
                    addressLabel.Visibility = Visibility.Visible;
                    bankaccLabel.Visibility = Visibility.Hidden;
                    phoneLabel.Visibility = Visibility.Hidden;
                    passwordLabel.Visibility = Visibility.Hidden;
                    listBox.Visibility = Visibility.Hidden;
                    addUserBtn.Visibility = Visibility.Hidden;
                    delUserBtn.Visibility = Visibility.Hidden;
                    addLabel.Visibility = Visibility.Hidden;
                    delLabel.Visibility = Visibility.Hidden;

                    nameLabel.Content = ((User)obj).Name + " " + ((User)obj).LastName + " - " + ((User)obj).Username;
                    buttonImage.Source = new BitmapImage(new Uri(@"\Resources\permissionsAllowed.png", UriKind.RelativeOrAbsolute));
                    perLabel.Content = "Allow Permission";
                    addressLabel.Content = "You dont have permissions to view this profile";
                    image.Source = new BitmapImage(new Uri(@"\Resources\group.png", UriKind.RelativeOrAbsolute));
                }

            }
            else
            {
                addressLabel.Visibility = Visibility.Hidden;
                bankaccLabel.Visibility = Visibility.Hidden;
                phoneLabel.Visibility = Visibility.Hidden;
                passwordLabel.Visibility = Visibility.Hidden;
                listBox.Visibility = Visibility.Visible;
                addUserBtn.Visibility = Visibility.Visible;
                delUserBtn.Visibility = Visibility.Visible;
                addLabel.Visibility = Visibility.Visible;
                delLabel.Visibility = Visibility.Visible;

                image.Source = new BitmapImage(new Uri(@"\Resources\group.png", UriKind.RelativeOrAbsolute));
                addressLabel.Content = ((Group)obj).Owner;
                nameLabel.Content = ((Group)obj).GroupName;
                listBox.ItemsSource = ((Group)obj).UsersList;
            }
        }
        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUserToGroupWindow addUsersToGroupWindow =
                new AddUserToGroupWindow(new Point(((MainUserWindow)((Grid)((DockPanel)((ContentControl)this.Parent).Parent).Parent).Parent).Left, 
                ((MainUserWindow)((Grid)((DockPanel)((ContentControl)this.Parent).Parent).Parent).Parent).Top));
            addUsersToGroupWindow.Owner = ((MainUserWindow)((Grid)((DockPanel)((ContentControl)this.Parent).Parent).Parent).Parent);
            addUsersToGroupWindow.SetUsers();
            addUsersToGroupWindow.Show();
        }
        private void delUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if(listBox.SelectedIndex != -1)
            {
                ((MainUserWindow)((Grid)((DockPanel)((ContentControl)this.Parent).Parent).Parent).Parent).clientProxy.DeleteUsersFromGroup(nameLabel.Content.ToString(), addressLabel.Content.ToString(), listBox.SelectedItem.ToString());
                listBox.ItemsSource = ((MainUserWindow)((Grid)((DockPanel)((ContentControl)this.Parent).Parent).Parent).Parent).clientProxy.ReadFromGroup(nameLabel.Content.ToString());
            }
        }

        private void permissionsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (perLabel.Content.ToString() == "Allow Permission")
            {
                perLabel.Content = "Deny Permisson";
                buttonImage.Source = new BitmapImage(new Uri(@"\Resources\permissionsNotAllowed.png", UriKind.RelativeOrAbsolute));
                
                ((MainUserWindow)((Grid)((DockPanel)((ContentControl)this.Parent).Parent).Parent).Parent).clientProxy.AddUserPermission(((MainUserWindow)((Grid)((DockPanel)((ContentControl)this.Parent).Parent).Parent).Parent).loggedUser.Username, nameLabel.Content.ToString().Split(' ')[3]);               

                return;
            }

            perLabel.Content = "Allow Permission";
            buttonImage.Source = new BitmapImage(new Uri(@"\Resources\permissionsAllowed.png", UriKind.RelativeOrAbsolute));
                ((MainUserWindow)((Grid)((DockPanel)((ContentControl)this.Parent).Parent).Parent).Parent).clientProxy.RemoveUserPermission(((MainUserWindow)((Grid)((DockPanel)((ContentControl)this.Parent).Parent).Parent).Parent).loggedUser.Username, nameLabel.Content.ToString().Split(' ')[3]); 
        }
    }
}
