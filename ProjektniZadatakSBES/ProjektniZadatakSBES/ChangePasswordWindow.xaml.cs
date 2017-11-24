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
using System.Windows.Shapes;

namespace ProjektniZadatakSBES
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");

        public ChangePasswordWindow(Point p)
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

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            errorLabel.Foreground = new SolidColorBrush(Color.FromRgb(204, 0, 0));
            errorLabel.Content = "";

            if (oldPasswordTextBox.Password == "" || ((MainUserWindow)this.Owner).loggedUser.Password != oldPasswordTextBox.Password)
            {
                errorLabel.Content = "Current password wrong.";
                return;
            }

            if (newPasswordTextBox.Password == "")
            {
                errorLabel.Content = "Please enter a valid password.";
                return;
            }

            string message = ((MainUserWindow)this.Owner).clientProxy.ChangePassword(((MainUserWindow)this.Owner).loggedUser.Username, Encrypt(newPasswordTextBox.Password));

            if(message != "Success")
            {
                errorLabel.Content = message;
                return;
            }

            ((MainUserWindow)this.Owner).loggedUser.Password = newPasswordTextBox.Password;

            errorLabel.Foreground = new SolidColorBrush(Color.FromRgb(75, 181, 67));
            errorLabel.Content = "Success!";
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

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            errorLabel.Content = "";
            if (e.Key == Key.Enter)
                okButton_Click(null, null);
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
