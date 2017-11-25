using Common;
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
    /// Interaction logic for MiniInfo.xaml
    /// </summary>
    public partial class MiniInfo : UserControl
    {
        public string buttonType = "";    

        public MiniInfo(string name, string buttonType)
        {
            InitializeComponent();
            Button.Content = name;
            this.buttonType = buttonType;

            if(buttonType != "user")            
                Image.Source = new BitmapImage(new Uri(@"\Resources\group.png", UriKind.RelativeOrAbsolute));            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Info)((MainUserWindow)((Grid)((ScrollViewer)((StackPanel)this.Parent).Parent).Parent).Parent).ContentArea.Content).type = buttonType;

            if (buttonType == "user")
            {
                ((Info)((MainUserWindow)((Grid)((ScrollViewer)((StackPanel)this.Parent).Parent).Parent).Parent).ContentArea.Content).obj =
                    ((MainUserWindow)((Grid)((ScrollViewer)((StackPanel)this.Parent).Parent).Parent).Parent).clientProxy.AllUsersList().Find(u => u.Username == Button.Content.ToString());

                ((MainUserWindow)((Grid)((ScrollViewer)((StackPanel)this.Parent).Parent).Parent).Parent).deleteGroupButton.Visibility = Visibility.Hidden;
                ((MainUserWindow)((Grid)((ScrollViewer)((StackPanel)this.Parent).Parent).Parent).Parent).changeGroupButton.Visibility = Visibility.Hidden;

                Audit.DataAccess(((MainUserWindow)((Grid)((ScrollViewer)((StackPanel)this.Parent).Parent).Parent).Parent).loggedUser.Username, Button.Content.ToString());
            }
            else
            {
                ((Info)((MainUserWindow)((Grid)((ScrollViewer)((StackPanel)this.Parent).Parent).Parent).Parent).ContentArea.Content).obj =
                    ((MainUserWindow)((Grid)((ScrollViewer)((StackPanel)this.Parent).Parent).Parent).Parent).clientProxy.ReadGroups().Find(g => g.GroupName == Button.Content.ToString());

                ((MainUserWindow)((Grid)((ScrollViewer)((StackPanel)this.Parent).Parent).Parent).Parent).deleteGroupButton.Visibility = Visibility.Visible;
                ((MainUserWindow)((Grid)((ScrollViewer)((StackPanel)this.Parent).Parent).Parent).Parent).changeGroupButton.Visibility = Visibility.Visible;

                Audit.GroupAccess(((MainUserWindow)((Grid)((ScrollViewer)((StackPanel)this.Parent).Parent).Parent).Parent).loggedUser.Username, Button.Content.ToString());
            }

            ((Info)((MainUserWindow)((Grid)((ScrollViewer)((StackPanel)this.Parent).Parent).Parent).Parent).ContentArea.Content).SetInfo();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if(buttonType == "user")
            {
                Image.Source = new BitmapImage(new Uri(@"\Resources\userWhite.png", UriKind.RelativeOrAbsolute));
                StackPanel.Background = new SolidColorBrush(Color.FromRgb(227, 99, 79));
                Button.Background = new SolidColorBrush(Color.FromRgb(227, 99, 79));
                Button.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                return;
            }

            Image.Source = new BitmapImage(new Uri(@"\Resources\groupWhite.png", UriKind.RelativeOrAbsolute));
            StackPanel.Background = new SolidColorBrush(Color.FromRgb(227, 99, 79));
            Button.Background = new SolidColorBrush(Color.FromRgb(227, 99, 79));
            Button.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if(buttonType == "user")
            {
                Image.Source = new BitmapImage(new Uri(@"\Resources\username.png", UriKind.RelativeOrAbsolute));
                StackPanel.Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
                Button.Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
                Button.Foreground = new SolidColorBrush(Color.FromRgb(73, 64, 65));
                return;
            }

            Image.Source = new BitmapImage(new Uri(@"\Resources\group.png", UriKind.RelativeOrAbsolute));
            StackPanel.Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
            Button.Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
            Button.Foreground = new SolidColorBrush(Color.FromRgb(73, 64, 65));
        }        
    }
}
