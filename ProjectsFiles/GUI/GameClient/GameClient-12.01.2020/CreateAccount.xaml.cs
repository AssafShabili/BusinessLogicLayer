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
using GameBLL.BLL_Classess;
using GameClient_12._01._2020.ServiceReferenceMD5;


namespace GameClient_12._01._2020
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        private UserBL currnetUser;

        public CreateAccount()
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
            if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Minimized;
            }
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

        /// <summary>
        /// פעולה להצפנת הסיסמא ל
        /// base64
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encode(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }



        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {

            string Hashedpassword = "";
            if (Password_TextBox.Password.Length > 8)
            {
                using (ServiceMD5Client service = new ServiceMD5Client())
                {
                    Hashedpassword = service.GetMd5Hash(Base64Encode(Password_TextBox.Password));
                }

                if (Regex.Match(Email_TextBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$").Success)
                {
                    if (!this.currnetUser.DoesEmailExist(Email_TextBox.Text))
                    {
                        this.currnetUser.SighIn(Email_TextBox.Text, Hashedpassword);
                        MessageBox.Show("Redirecting to the Login page so you could login in");
                        this.Close();
                    }
                    else
                    {
                        InputErrorLabel.Content = "[Error] Found a User \n with this E-maill \n address.";
                    }
                }
                else
                {
                    InputErrorLabel.Content = "[Error] Email or \n Password \n aren't valid";
                }
            }
            else
            {
                InputErrorLabel.Content = "[Error] Password aren't valid";
            }

        }
    }
}
