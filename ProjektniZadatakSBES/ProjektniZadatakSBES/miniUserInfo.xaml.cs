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
    /// Interaction logic for MiniUserInfo.xaml
    /// </summary>
    public partial class MiniUserInfo : UserControl
    {
        public MiniUserInfo(string username)
        {
            InitializeComponent();
            userButton.Content = username;
        }

        private void userButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(this.Parent.ToString());
        }

        private void userButton_MouseEnter(object sender, MouseEventArgs e)
        {
            userImage.Source = new BitmapImage(new Uri(@"\Resources\userWhite.png", UriKind.RelativeOrAbsolute));
            userStackPanel.Background = new SolidColorBrush(Color.FromRgb(227, 99, 79));
            userButton.Background = new SolidColorBrush(Color.FromRgb(227, 99, 79));
            userButton.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        }

        private void userButton_MouseLeave(object sender, MouseEventArgs e)
        {
            userImage.Source = new BitmapImage(new Uri(@"\Resources\username.png", UriKind.RelativeOrAbsolute));
            userStackPanel.Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
            userButton.Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
            userButton.Foreground = new SolidColorBrush(Color.FromRgb(73, 64, 65));
        }
    }
}
