using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GameClient_12._01._2020.ServiceReferenceMD5;
using GameBLL.BLL_Classess;

namespace GameClient_12._01._2020
{
    /// <summary>
    /// Interaction logic for UnableToLogin.xaml
    /// </summary>
    public partial class UnableToLogin : Window
    {

        private bool ?option = null;

        public UnableToLogin()
        {
            InitializeComponent();
        }
        private void TopPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

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

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Text = "password";
            this.option = false;        
        }

        private void ChangeEmailButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Text = "email";
            this.option = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            if (Password_TextBox.Password.Length > 8 && 
                Regex.Match(Email_TextBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$").Success)
            {
                using (ServiceMD5Client service = new ServiceMD5Client())
                {
                    try
                    {
                        UserBL user = new UserBL(Email_TextBox.Text, service.GetMd5Hash(Password_TextBox.Password));
                        if(user.GetID() != -1)
                        {
                            if(this.option == true)
                            {                             
                                ChangeUserEmail(user);
                                InputErrorLabel.Content = "Email was \n changed!";
                            }
                            else if(this.option == false)
                            {
                                ChangeUserPassword(user, service.GetMd5Hash(InputTextBox.Text));
                                InputErrorLabel.Content = "Password was \n change!";
                            }
                            else if(this.option == null)
                            {
                                InputErrorLabel.Content = "Please \n pick an\n option \n [Email/Password]";
                                return;
                            }
                        }
                        else
                        {
                            InputErrorLabel.Content = "[Error] \n User not\n found ";
                            return;
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                        InputErrorLabel.Content = "[Error]\n no \n connection\n to the WS. \n try again\n later...";
                        return;
                    }
                }
                
               
            }
            else
            {
                InputErrorLabel.Content = "[Error]\n Email or \n Password \n aren't valid";
            }
        }


        /// <summary>
        /// פעולה לשינוי האימייל הנוכחי של אותו משתמש
        /// </summary>
        /// <param name="user">המשתמש</param>
        public void ChangeUserEmail(UserBL user)
        {
            if(Regex.Match(InputTextBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$").Success)
            {
                user.ChangeUserEmail(InputTextBox.Text);
            }
            else
            {
                InputErrorLabel.Content = "[Error] Email \n address\n isn't valid";
            }
        }

        /// <summary>
        /// פעולה לעדכון הסיסמא של המשתמש בלוח הנוכחי
        /// </summary>
        /// <param name="user">המשתמש</param>
        /// <param name="hashPassword">סיסמאתו המוצפנת</param>
        public void ChangeUserPassword(UserBL user,string hashPassword)
        {
            if(InputTextBox.Text.Length > 8)
            {
                user.ChangeUserPassword(hashPassword);
            }
            else
            {
                InputErrorLabel.Content = "[Error] password \n needs to be longer then 8 characters";
            }
        }
    }
}
