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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        public void loginGrid_KeyUp(object sender, KeyEventArgs e)
        {
            errorlabel.Foreground = new SolidColorBrush(Color.FromRgb(204, 0, 0));
            errorlabel.Content = "";

            if (e.Key == Key.Enter)
            {
                foreach (Object tb in loginGrid.Children)
                {
                    if (tb is TextBox && String.IsNullOrEmpty(((TextBox)tb).Text))
                    {
                        errorlabel.Content = "Username can't be left empty!";
                        return;
                    }

                    if (tb is PasswordBox && ((PasswordBox)tb).Password.Equals("", StringComparison.CurrentCulture))
                    {
                        errorlabel.Content = "Password can't be left empty!";
                        return;
                    }
                }

                errorlabel.Content = "";

                User loggedUser = MainWindow.proxy.Login(usernameTextBox.Text, passwordTextBox.Password);

                if (loggedUser != null)
                {
                    errorlabel.Foreground = new SolidColorBrush(Color.FromRgb(75, 181, 67));
                    errorlabel.Content = "Success!";                   
                    
                    MainUserWindow muw = new MainUserWindow(loggedUser);
                    muw.Show();

                    ((Window)this.Parent).Close();
                    return;
                }

                errorlabel.Content = "Wrong username/password combination!";
            }
        }
    }
}


// Ispravljen login
// Zajebava prozor kad se uloguje korisnik, ostaje register i login
// Prosiri prozor zbog ispisa