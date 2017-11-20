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
    /// Interaction logic for UserInfo.xaml
    /// </summary>
    public partial class UserInfo : UserControl
    {
        public UserInfo(User user)
        {
            InitializeComponent();
            nameLabel.Content = user.Name + " " + user.LastName + " - " + user.Username;
            addressLabel.Content = user.Address;
            phoneLabel.Content = user.PhoneNumber;
            bankaccLabel.Content = user.AccountNumber;
            passwordLabel.Content = user.Password; 
        }
    }
}
