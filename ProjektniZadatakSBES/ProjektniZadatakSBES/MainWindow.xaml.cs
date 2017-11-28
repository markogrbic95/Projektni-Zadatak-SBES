using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

        Login login = new Login();
        Registration reg = new Registration();

        public static NetTcpBinding binding = new NetTcpBinding();
        public static string address = "net.tcp://localhost:26001/InterfaceImplementation";
        public static ClientProxy proxy = new ClientProxy(binding, address);

        public MainWindow()
        {
            InitializeComponent();            
            ContentArea.Content = login;
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
            Application.Current.Shutdown();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            if(activeButton == 0)
            {
                activeButton = 1;

                SetWindowHeight();

                ContentArea.Content = login;

                registerButton.Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
                registerButton.Foreground = new SolidColorBrush(Color.FromRgb(73, 64, 65));
                return;
            }

            ((Login)ContentArea.Content).loginGrid_KeyUp(sender, new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.Enter));
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            if(activeButton == 1)
            {
                activeButton = 0;

                SetWindowHeight();

                ContentArea.Content = reg;

                signInButton.Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
                signInButton.Foreground = new SolidColorBrush(Color.FromRgb(73, 64, 65));
                return;
            }

            ((Registration)ContentArea.Content).regGrid_KeyUp(sender, new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.Enter));
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush(Color.FromRgb(227, 99, 79));
            ((Button)sender).Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
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

        private void SetWindowHeight()
        {
            switch (activeButton)
            {
                case 0:
                    {
                        exitBtn.Margin = new Thickness(670, 10, 10, 510);
                        this.Height = 540;                        

                        signInButton.Margin = new Thickness(350, 490, 0, 0);
                        registerButton.Margin = new Thickness(0, 490, 350, 0);
                        break;
                    }
                case 1:
                    {
                        exitBtn.Margin = new Thickness(670, 10, 10, 400);
                        this.Height = 430;

                        signInButton.Margin = new Thickness(350, 380, 0, 0);
                        registerButton.Margin = new Thickness(0, 380, 350, 0);
                        break;
                    }
            }
        }
    }
}
