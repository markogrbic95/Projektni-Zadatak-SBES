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
    /// Interaction logic for miniGroupInfo.xaml
    /// </summary>
    public partial class miniGroupInfo : UserControl
    {
        public miniGroupInfo(string groupName)
        {
            InitializeComponent();
            groupNameLabel.Content = groupName;
        }
        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Background = new SolidColorBrush(Color.FromRgb(227, 99, 79));
            groupNameLabel.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            userImage.Source = new BitmapImage(new Uri(@"\Resources\groupWhite.png", UriKind.RelativeOrAbsolute));
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
            groupNameLabel.Foreground = new SolidColorBrush(Color.FromRgb(73, 64, 65));
            userImage.Source = new BitmapImage(new Uri(@"\Resources\group.png", UriKind.RelativeOrAbsolute));
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
