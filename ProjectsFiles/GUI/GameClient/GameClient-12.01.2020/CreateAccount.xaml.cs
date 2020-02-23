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
using System.Windows.Shapes;

namespace GameClient_12._01._2020
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
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

            Password_Label.Visibility = Visibility.Hidden;
            Password_TextBox.Focus();
        }

        private void TopPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();

        }
    }
}
