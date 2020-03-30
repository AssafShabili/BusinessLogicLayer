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
using System.Data;

namespace GameClient_12._01._2020
{
    /// <summary>
    /// Interaction logic for MakeNewSave.xaml
    /// </summary>
    public partial class MakeNewSave : Window
    {
        //שומר את כל המידע שקשור למפות
        List<MapBL> MapsList;
        GameBL game;
        UserBL UserBL;
        int currentIndex = 0;// המיקום של המשתמש בשרשרת של המפה

        public MakeNewSave(UserBL userBL)
        {
            InitializeComponent();
            game = new GameBL();
            UserBL = userBL;
        }

        public MakeNewSave()
        {
            InitializeComponent();
            game = new GameBL();
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
        private void CycleToTheNextMap()
        {
            ++currentIndex;
            if (MapsList.Count > currentIndex)
            {
                MapImage.Source = GetBitmapImage(MapsList[currentIndex].GetMapName());
               

            }
           
        }

        /// <summary>
        /// פעולה לטיפול השמת התמונות של המפות לתוך הפקדים המתאימים
        /// </summary>
        /// <param name="userMaps">שרשרת של המפות של כל המשחקים של המשתמש</param>
        private void CycleToThePreviousMap()
        {
            --currentIndex;
            if (MapsList.Count > currentIndex && currentIndex >= 0)
            {
                MapImage.Source = GetBitmapImage(MapsList[currentIndex].GetMapName());  
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

        private void Window_Initialized(object sender, EventArgs e)
        {
            MapBL mapBL = new MapBL();
            MapsList = mapBL.GetAllMapsInfo();
            MapImage.Source = GetBitmapImage(MapsList[0].GetMapName());
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            CycleToTheNextMap();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            CycleToThePreviousMap();
        }

        private void choosingButton_Click(object sender, RoutedEventArgs e)
        {
            int gameID = game.MakeANewGame(MapsList[currentIndex].GetMapID());
            UserBL.AddGameSave(new GameBL(gameID));
            MessageBox.Show("Save added...\n return to the Game Lobby");
            this.Close();
        }
    }
}
