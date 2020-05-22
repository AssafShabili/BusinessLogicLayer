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
    /// Interaction logic for GameExplaining.xaml
    /// </summary>
    public partial class GameExplaining : Window
    {

        int counter = 0; // הסופר של איזה תמונה לשים בחלון
        string[] explaining = 
        {
            "This is your game board!",
            "This is the amount of health you have",
            "This is where you can buy your towers\nif you have enough money to buy it ...\nyou can see you money,Score, and what wave\nyou on",
            "This is the path\n where your enemies are going to go on",
            "This is your base where you are going\nto need to defend from enemies\nand BOSSES!",
            "You can press on your tower to see it's properties",
            "The tower properties can be seen on\n the (the red arrow) like dmg, attack speed and range\n while (the green arrows) show that you \n can change the tower type and upgrade one of\ntower properties! "
        };


        public GameExplaining()
        {
            InitializeComponent();

            ImageExplaning.Source = GetBitmapImage(0);
            ButtonPre.IsEnabled = false;
        }

       

        /// <summary>
        /// פעולה שמקבלת את השם של התמונה   
        /// ומחזירה את המפה כ - bitmapImage
        /// </summary>
        /// <param name="mapName">שם של התמונה של המשחק</param>
        /// <returns>הפעולה תחזיר את התמונה  שכדאי שנוכל להכניס אותה לתוך הפקד של התמונה</returns>
        public BitmapImage GetBitmapImage(int index)
        {
            BitmapImage bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri($@"\Img\ImageExplaning\{index.ToString()}.png", UriKind.Relative);
            bitMap.EndInit();
            return bitMap;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void TopPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
