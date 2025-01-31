﻿using OnStore.Chain_Of_Responsibility;
using OnStore.Extension;
using OnStore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace OnStore.View
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        public ObservableCollection<User> UserList = new ObservableCollection<User>();
        public User User { get; set; }
        string stepofchain;
        public bool singupclick = false;
        public SignUp()
        {
            InitializeComponent();
            stepofchain = "SingUp Chain";

        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();



            Helper.Userlist = new ObservableCollection<User>();

            User user1 = new User
            {
                Name = NameTxtBox.Text,
                Email = EmailTxtBox.Text,
                Password = PasswordTxtBox.Text,
                StepsOfChain = stepofchain,
                Surname = SurnameTxtBox.Text

            };
            UserList.Add(user1);
            Helper.Userlist.Add(user1);
            singupclick = true;
            IChain chain = new SignUpChain();
            IChain chain2 = new SignInChain();
            IChain chain3 = new OrderChain();

            chain.setNextChain(chain2);
            chain2.setNextChain(chain3);

            User User1 = new User { Name= NameTxtBox.Text, Surname=SurnameTxtBox.Text, Password= PasswordTxtBox.Text, Email=EmailTxtBox.Text, StepsOfChain= stepofchain };
            chain.Handle(User1);
            Helper.Signin.MainGrid.Children.RemoveAt(1);


        }

        private void NameTxtBox_MouseEnter(object sender, MouseEventArgs e)
        {
            NameTxtBox.Text = string.Empty;
        }

        private void SurnameTxtBox_MouseEnter(object sender, MouseEventArgs e)
        {
            SurnameTxtBox.Text = string.Empty;
        }

        private void EmailTxtBox_MouseEnter(object sender, MouseEventArgs e)
        {
            EmailTxtBox.Text = string.Empty;
        }

        private void PasswordTxtBox_MouseEnter(object sender, MouseEventArgs e)
        {
            PasswordTxtBox.Text = string.Empty;
        }
    }
}
