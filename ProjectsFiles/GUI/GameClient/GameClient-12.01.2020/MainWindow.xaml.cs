using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
using GameBLL.BLL_Classess;
using GameBLL.GameComponents;

namespace GameClient_12._01._2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserBL currnetUser;

        public MainWindow()
        {
            InitializeComponent();
            this.currnetUser = new UserBL();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            
        }

        private void Email_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            InputErrorLabel.Content = "";
            if (Email_TextBox.Text == "Email")
            {
                Email_TextBox.Text = "";
            }
        }

        private void Email_TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Email_TextBox.Text == "")
            {
                Email_TextBox.Text = "Email";
            }

        }

        private void Password_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Password_Label.Visibility = Visibility.Hidden;
        }

        private void Password_TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            
            if (Password_TextBox.Password.ToString() == "")
            {
                Password_Label.Visibility = Visibility.Visible;
            }

        }

        private void Password_Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            InputErrorLabel.Content = "";
            Password_Label.Visibility = Visibility.Hidden;
            Password_TextBox.Focus();
        }

        private void TopPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
                
        }
        

        private void CreateAccountLbl_MouseEnter(object sender, MouseEventArgs e)
        {
            //#00FFFFFF
            createAccountLbl.Foreground = new SolidColorBrush(Color.FromRgb(26,25, 238));

        }

        private void CreateAccountLbl_GotFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void CreateAccountLbl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            CreateAccount createAccount = new CreateAccount();
            this.Hide();
            createAccount.ShowDialog();
            this.Show();
            

        }

        private void CreateAccountLbl_MouseLeave(object sender, MouseEventArgs e)
        {
            createAccountLbl.Foreground = new SolidColorBrush(Color.FromRgb(29, 100, 253));
        }

        private void CantSignInlbl_MouseEnter(object sender, MouseEventArgs e)
        {
            CantSignInlbl.Foreground = new SolidColorBrush(Color.FromRgb(26, 25, 238));
        }

        private void CantSignInlbl_MouseLeave(object sender, MouseEventArgs e)
        {
            CantSignInlbl.Foreground = new SolidColorBrush(Color.FromRgb(29, 100, 253));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        { 
            if(Regex.Match(Email_TextBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$").Success
               && Password_TextBox.Password.Length > 8 
               && !this.currnetUser.LogIn(Email_TextBox.Text, Password_TextBox.Password))
            {
                currnetUser = new UserBL(Email_TextBox.Text, Password_TextBox.Password);
                
                GameLobby gameLobby = new GameLobby(currnetUser);
                this.Hide();
                gameLobby.Show();
                this.Close();
            }
            else
            {
                InputErrorLabel.Content = "[Error] Email or \n Password \n aren't valid";
            }

        }

        private void CantSignInlbl_MouseEnter(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
