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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : UserControl
    {
        public Registration()
        {
            InitializeComponent();
        }

        public void regGrid_KeyUp(object sender, KeyEventArgs e)
        {
            errorlabel.Foreground = new SolidColorBrush(Color.FromRgb(204, 0, 0));
            errorlabel.Content = "";

            if (e.Key == Key.Enter)
            {
                foreach (Object tb in regGrid.Children)
                {
                    if (tb is TextBox && String.IsNullOrEmpty(((TextBox)tb).Text))
                    {
                        errorlabel.Content = "No fields can be left empty!";
                        return;
                    }

                    if (tb is PasswordBox && ((PasswordBox)tb).Password.Equals("", StringComparison.CurrentCulture))
                    {
                        errorlabel.Content = "You must set a password!";
                        return;
                    }
                }

                string msg = MainWindow.proxy.Registration(nameTextBox.Text, surnameTextBox.Text, addressTextBox.Text, phoneTextBox.Text, bankaccTextBox.Text, usernameTextBox.Text, passwordTextBox.Password);

                if (msg != "Success!")
                {
                    errorlabel.Content = msg;
                    return;
                }

                foreach (Object tb in regGrid.Children)
                {
                    if (tb is TextBox)                    
                        ((TextBox)tb).Text = "";
                    

                    if (tb is PasswordBox)                    
                        ((PasswordBox)tb).Password = null;                    
                }

                errorlabel.Foreground = new SolidColorBrush(Color.FromRgb(75, 181, 67));
                errorlabel.Content = "Success!";
            }
        }
    }
}
