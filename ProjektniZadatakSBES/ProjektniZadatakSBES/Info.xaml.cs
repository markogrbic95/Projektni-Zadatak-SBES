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
            SetInfo();
        }

        public void SetInfo()
        {
            if (type == "user")
            {
                addressLabel.Visibility = Visibility.Visible;
                bankaccLabel.Visibility = Visibility.Visible;
                phoneLabel.Visibility = Visibility.Visible;
                passwordLabel.Visibility = Visibility.Visible;

                image.Source = new BitmapImage(new Uri(@"\Resources\username.png", UriKind.RelativeOrAbsolute));
                nameLabel.Content = ((User)obj).Name + " " + ((User)obj).LastName + " - " + ((User)obj).Username;
                addressLabel.Content = ((User)obj).Address;
                bankaccLabel.Content = ((User)obj).AccountNumber;
                phoneLabel.Content = ((User)obj).PhoneNumber;
                passwordLabel.Content = ((User)obj).Password;
            }
            else
            {
                addressLabel.Visibility = Visibility.Hidden;
                bankaccLabel.Visibility = Visibility.Hidden;
                phoneLabel.Visibility = Visibility.Hidden;
                passwordLabel.Visibility = Visibility.Hidden;

                image.Source = new BitmapImage(new Uri(@"\Resources\group.png", UriKind.RelativeOrAbsolute));
                nameLabel.Content = ((Group)obj).GroupName;
            }
        }
    }
}
