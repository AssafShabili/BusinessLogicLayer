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
using GameBLL.BLL_Classess;

namespace GameClient_12._01._2020
{
    /// <summary>
    /// Interaction logic for GameLobby.xaml
    /// </summary>
    public partial class GameLobby : Window
    {
        private UserBL user;
        public GameLobby(UserBL user)
        {
            this.user = user;
            InitializeComponent();
            NameLbl.Content = "Hi, " + user.GetNameByEmail();
            AddMapsPictureToImageControl(user.GetUserGamesMaps());
            
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



        private void AddMapsPictureToImageControl(List<MapBL> userMaps)
        {
            LabelNoGame.Content = "IT SEEMS LIKE YOU DONT HAVE ANY SAVE... \n" +
                        " MAYBE IT'S TIME TO MAKE SOME!";

            switch (userMaps.Count)
            {
                case 3:
                    ImgGame1.Source = GetBitmapImage(userMaps[0].GetMapName());
                    ImgGame2.Source = GetBitmapImage(userMaps[1].GetMapName());
                    ImgGame3.Source = GetBitmapImage(userMaps[2].GetMapName());
                    break;
                case 2:
                    ImgGame1.Source = GetBitmapImage(userMaps[0].GetMapName());
                    ImgGame2.Source = GetBitmapImage(userMaps[1].GetMapName());
                    break;
                case 1:
                    ImgGame1.Source = GetBitmapImage(userMaps[0].GetMapName());
                    break;
                default:
                    LabelNoGame.Content = "IT SEEMS LIKE YOU DONT HAVE ANY SAVE... \n" +
                        " MAYBE IT'S TIME TO MAKE SOME!";
                    break;



            }

           
        }

        public BitmapImage GetBitmapImage(string mapName)
        {           
            BitmapImage bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri($@"\MapImg\{mapName}.png", UriKind.Relative);
            bitMap.EndInit();
            return bitMap;
        }

    }
}
