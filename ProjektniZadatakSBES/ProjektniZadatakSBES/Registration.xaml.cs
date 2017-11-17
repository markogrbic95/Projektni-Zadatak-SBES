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
            if(e.Key == Key.Enter)
            {
                foreach(Object tb in regGrid.Children)
                {
                    if (tb is TextBox && String.IsNullOrEmpty(((TextBox)tb).Text))
                    {
                        errorlabel.Content = "No fields can be left empty!";
                        return;
                    }

                    if(tb is PasswordBox && ((PasswordBox)tb).Password.Equals("", StringComparison.CurrentCulture))
                    {
                        errorlabel.Content = "You must set a password!";
                        return;
                    }
                }                

                errorlabel.Content = "";

                //string name = nameTextBox.Text;
                //string surname = surnameTextBox.Text;
                //string address = addressTextBox.Text;
                //string phone = phoneTextBox.Text;
                //string bankAcc = bankaccTextBox.Text;
                //string username = usernameTextBox.Text;
                //string pass = passwordTextBox.Password;

                //evo ti gore podaci sibnes to preko wcf-a
            }
        }
    }
}
