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
        private LoadingWindow loadingWindow;


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





        #region פעולות מוכנות על ידי

        /// <summary>
        /// פעולה לטיפול השמת התמונות של המפות לתוך הפקדים המתאימים
        /// </summary>
        /// <param name="userMaps">שרשרת של המפות של כל המשחקים של המשתמש</param>
        private void AddMapsPictureToImageControl(List<MapBL> userMaps)
        {
            switch (userMaps.Count)
            {
                case 3:
                   
                    ImgGame1.Source = GetBitmapImage(userMaps[0].GetMapName());
                    ImgGame2.Source = GetBitmapImage(userMaps[1].GetMapName());
                    ImgGame3.Source = GetBitmapImage(userMaps[2].GetMapName());
                    break;
                case 2:
                    ButtonGame3.IsEnabled = false;
                    ImgGame1.Source = GetBitmapImage(userMaps[0].GetMapName());
                    ImgGame2.Source = GetBitmapImage(userMaps[1].GetMapName());
                    break;
                case 1:
                    ButtonGame3.IsEnabled = false;
                    ButtonGame2.IsEnabled = false;
                    ImgGame1.Source = GetBitmapImage(userMaps[0].GetMapName());
                    break;
                default:
                    ButtonGame3.IsEnabled = false;
                    ButtonGame2.IsEnabled = false;
                    ButtonGame1.IsEnabled = false;
                    LabelNoGame.Content = "IT SEEMS LIKE YOU DONT HAVE ANY SAVE... \n" +
                        " MAYBE IT'S TIME TO MAKE SOME!";
                    break;

            }

           
        }

        /// <summary>
        /// פעולה שמקבלת את השם של המפה  
        /// ומחזירה את המפה כ - bitmapImage
        /// </summary>
        /// <param name="mapName">שם של המפה של המשחק</param>
        /// <returns>הפעולה תחזיר את התמונה  שכדאי שנוכל להכניס אותה לתוך הפקד של התמונה</returns>
        public BitmapImage GetBitmapImage(string mapName)
        {           
            BitmapImage bitMap = new BitmapImage();
            bitMap.BeginInit();
            bitMap.UriSource = new Uri($@"\MapImg\{mapName}.png", UriKind.Relative);
            bitMap.EndInit();
            return bitMap;
        }
        #endregion

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            MakeNewSave makeNewSave = new MakeNewSave();
            this.Hide();
            makeNewSave.Show();
        }

        private void ButtonGame3_Click(object sender, RoutedEventArgs e)
        {
             //this.loadingWindow = new LoadingWindow(this.user.GetGameSave(2));
            this.Hide();
            this.loadingWindow.Show();
        }

        private void ButtonGame2_Click(object sender, RoutedEventArgs e)
        {
           // this.loadingWindow = new LoadingWindow(this.user.GetGameSave(1));
            this.Hide();
            loadingWindow.Show();
        }

        private void ButtonGame1_Click(object sender, RoutedEventArgs e)
        {
            //.loadingWindow = new LoadingWindow(this.user.GetGameSave(0));
            this.Hide();
            this.loadingWindow.Show();
        }
    }
}
