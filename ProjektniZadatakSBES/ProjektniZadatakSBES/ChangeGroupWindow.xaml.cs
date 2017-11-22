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
    /// Interaction logic for ChangeGroupWindow.xaml
    /// </summary>
    public partial class ChangeGroupWindow : Window
    {
        public ChangeGroupWindow(Point p)
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

        private void changeGroupButton_Click(object sender, RoutedEventArgs e)
        {
            if (groupNameTextBox.Text == "")
            {
                errorLabel.Content = "Please enter a group name.";
                return;
            }

            foreach (MiniInfo b in ((MainUserWindow)this.Owner).myGroupsStackPanel.Children)
            {
                if (b.Button.Content.ToString() == groupNameTextBox.Text)
                {
                    errorLabel.Content = "Group already exists!";
                    return;
                }
            }

            ((MainUserWindow)this.Owner).clientProxy.ChangeGroupName(((Info)((MainUserWindow)this.Owner).ContentArea.Content).nameLabel.Content.ToString(), groupNameTextBox.Text, ((MainUserWindow)this.Owner).loggedUser.Username);
            
            foreach (MiniInfo b in ((MainUserWindow)this.Owner).myGroupsStackPanel.Children)
            {
                if (b.Button.Content.ToString() == ((Info)((MainUserWindow)this.Owner).ContentArea.Content).nameLabel.Content.ToString())
                    b.Button.Content = groupNameTextBox.Text;
            }

            ((Info)((MainUserWindow)this.Owner).ContentArea.Content).nameLabel.Content = groupNameTextBox.Text;
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

        private void groupNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            errorLabel.Content = "";
            if (e.Key == Key.Enter)
                changeGroupButton_Click(null, null);
        }
    }
}
