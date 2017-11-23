using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");

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
                string textBox = usernameTextBox.Text;

                string msg = MainWindow.proxy.Registration(nameTextBox.Text, surnameTextBox.Text, Encrypt(addressTextBox.Text), Encrypt(phoneTextBox.Text), Encrypt(bankaccTextBox.Text), usernameTextBox.Text, Encrypt(passwordTextBox.Password));

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

                Audit.RegistrationSuccess(textBox);

                errorlabel.Foreground = new SolidColorBrush(Color.FromRgb(75, 181, 67));
                errorlabel.Content = "Success!";
            }
        }

        public static string Encrypt(string originalString)
        {
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException
                       ("The string which needs to be encrypted can not be null.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();

            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }
    }
}
