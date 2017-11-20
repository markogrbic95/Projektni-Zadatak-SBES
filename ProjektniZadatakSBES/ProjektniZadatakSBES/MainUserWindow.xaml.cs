﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
    /// Interaction logic for MainUserWindow.xaml
    /// </summary>
    public partial class MainUserWindow : Window
    {
        User loggedUser;        
        ClientProxy clientProxy;

        public MainUserWindow(User user, ClientProxy proxy)
        {
            InitializeComponent();
            loggedUser = user;
            clientProxy = proxy;

            SetUsersAndGroups();
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

        private void SetUsersAndGroups()
        {
            List<User> users = clientProxy.AllUsersList();
            List<Group> userGroups = clientProxy.GetUserGroups(loggedUser.Username);

            foreach (User user in users)            
                usersStackPanel.Children.Add(new MiniUserInfo(user.Username));

            //foreach (Group group in userGroups)
                //myGroupsStackPanel.Children.Add(new miniGroupInfo(group.GroupName));
        }

        private void addGroupButton_Click(object sender, RoutedEventArgs e)
        {
            AddGroupWindow addGroupWindow = new AddGroupWindow();
            addGroupWindow.ShowDialog();
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

        private void myGroupsButton_Click(object sender, RoutedEventArgs e)
        {   
            if(usersScrollViewer.ActualHeight != 0)
            {
                if (myGroupsScrollViewer.ActualHeight == 0)
                {
                    myGroupsScrollViewer.Height = 225;
                    myGroupsScrollViewer.Margin = new Thickness(0, 305, 520, 0);
                    myGroupsButton.Margin = new Thickness(0, 265, 520, 225);
                    usersScrollViewer.Height = 225;
                    return;
                }
                else
                {
                    myGroupsScrollViewer.Height = 0;
                    myGroupsScrollViewer.Margin = new Thickness(0, 530, 0, 0);
                    myGroupsButton.Margin = new Thickness(0, 490, 520, 0);
                    usersScrollViewer.Height = 450;
                    return;
                }
            } 
        }

        private void usersButton_Click(object sender, RoutedEventArgs e)
        {
            if (myGroupsScrollViewer.ActualHeight != 0)
            {
                if (usersScrollViewer.ActualHeight == 0)
                {
                    usersScrollViewer.Height = 225;
                    myGroupsScrollViewer.Margin = new Thickness(0, 305, 520, 0);
                    myGroupsButton.Margin = new Thickness(0, 265, 520, 225);
                    usersScrollViewer.Height = 225;
                    return;
                }
                else
                {
                    usersScrollViewer.Height = 0;
                    myGroupsButton.Margin = new Thickness(0, 40, 520, 450);
                    myGroupsScrollViewer.Height = 450;
                    myGroupsScrollViewer.Margin = new Thickness(0, 80, 0, 0);
                    return;
                }
            }
        }
    }
}
