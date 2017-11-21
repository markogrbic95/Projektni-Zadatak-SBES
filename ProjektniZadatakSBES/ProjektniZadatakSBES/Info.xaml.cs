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
        public string buttonType = "";

        public Info(string name, string buttonType)
        {
            InitializeComponent();
            this.buttonType = buttonType;

            User u = new User();
            if (name!=null)
                u = (User)FindByName(name);

            SetValues(u);
        }

        public void SetValues(User user)
        {
            if(user != null)
            {
                nameLabel.Content = user.Name + " " + user.LastName + " - " + user.Username;
                addressLabel.Content = user.Address;
                phoneLabel.Content = user.PhoneNumber;
                bankaccLabel.Content = user.AccountNumber;
                passwordLabel.Content = user.Password;
            }
        }

        public User FindByName(string name)
        {
            List<User> users = new List<User>();

            
                users = ((MainUserWindow)((Grid)((DockPanel)((ContentControl)this.Parent).Parent).Parent).Parent).clientProxy.AllUsersList();

                foreach (User user in users)
                {
                    if (user.Username == name)                    
                        return user;                    
                }

                return null;
            
        
        }
    }
}
