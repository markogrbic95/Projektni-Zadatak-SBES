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
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
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
            if (oldPasswordTextBox.Text == "" || ((MainUserWindow)this.Owner).loggedUser.Password != oldPasswordTextBox.Text)
            {
                errorLabel.Content = "Current password is wrong!";
                return;
            }

            if (newPasswordTextBox.Text == "")
            {
                errorLabel.Content = "Please enter a valid password.";
                return;
            }

            ((MainUserWindow)this.Owner).loggedUser.Password = newPasswordTextBox.Text;
            ((MainUserWindow)this.Owner).clientProxy.ChangePassword(((MainUserWindow)this.Owner).loggedUser.Username, ((MainUserWindow)this.Owner).loggedUser.Password, newPasswordTextBox.Text);
            this.Close();
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
    }
}
