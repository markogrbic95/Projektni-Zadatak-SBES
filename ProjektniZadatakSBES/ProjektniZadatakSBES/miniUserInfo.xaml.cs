﻿using System;
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
    /// Interaction logic for miniUserInfo.xaml
    /// </summary>
    public partial class miniUserInfo : UserControl
    {
        public miniUserInfo(string uname)
        {
            InitializeComponent();
            unameLabel.Content = uname;        
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Background = new SolidColorBrush(Color.FromRgb(227, 99, 79));
            unameLabel.Foreground = new SolidColorBrush(Color.FromRgb(255,255,255));
            userImage.Source = new BitmapImage(new Uri(@"\Resources\userWhite.png", UriKind.RelativeOrAbsolute)); 
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Background = new SolidColorBrush(Color.FromRgb(236, 240, 241));
            unameLabel.Foreground = new SolidColorBrush(Color.FromRgb(73, 64, 65));
            userImage.Source = new BitmapImage(new Uri(@"\Resources\username.png", UriKind.RelativeOrAbsolute));
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
