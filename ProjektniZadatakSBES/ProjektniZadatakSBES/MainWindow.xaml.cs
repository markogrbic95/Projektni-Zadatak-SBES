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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int activeButton = 1;

        public MainWindow()
        {
            InitializeComponent();
            ContentArea.Content = new Login();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            activeButton = 1;

            ContentArea.Content = new Login();

            registerButton.Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
            registerButton.Foreground = new SolidColorBrush(Color.FromRgb(73, 64, 65));
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            activeButton = 0;

            ContentArea.Content = new Registration();

            signInButton.Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
            signInButton.Foreground = new SolidColorBrush(Color.FromRgb(73, 64, 65));
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Color.FromRgb(227, 99, 79));
            ((Button)sender).Foreground = new SolidColorBrush(Color.FromRgb(255,255,255));
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (((Button)sender).Name == "signInButton" && activeButton == 0)
            {
                ((Button)sender).Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
                ((Button)sender).Foreground = new SolidColorBrush(Color.FromRgb(73, 64, 65));
                return;
            }
            else if (((Button)sender).Name == "registerButton" && activeButton == 1)
            {
                ((Button)sender).Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
                ((Button)sender).Foreground = new SolidColorBrush(Color.FromRgb(73, 64, 65));
            }
        }
    }
}
