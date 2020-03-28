using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GameBLL.BLL_Classess;
using GameDAL.DAL_Classess;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace GameBLL.GameComponents
{
  
    public class Enemy
    {
        private int HP;
        private string name;
        private Point location;
        private TowerType type;
        private Image EnemyImage;
        private List<Point> road;

        private int indexInRoad = 0;

       

        private int currentFrame = 0;
        private int frameCount = 3;

        


        public Enemy(int HP,string name, TowerType type, List<Point> road)
        {
            this.name = name;
            this.HP = HP;
            this.EnemyImage = new Image();
            //EnemyImage.Source = null /*new BitmapImage(new Uri($@"\MapImg\{this.name}_{this.type}_{this.currentFrame}.png"))*/;
            this.type = type;
            this.road = road;
            SetImage();
        }

        public void SetRoadMap(List<Point> road)
        {
            this.road = road;
        }


        public void SetImage()
        {
            EnemyImage.Source = GetBitmapImage("sand");
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





        public void Draw()
        {
            if(currentFrame < frameCount)
            { 
               
                this.currentFrame++;
            }
            else
            {
                this.currentFrame = 0;
            }

        }

       
        /// <summary>
        /// פעולת התזוזה של האויב אם האויב יכול להתקדם הוא יתקדם
        /// </summary>
        /// <returns> הפעולה תחזיר אמת אם האויב יכול להתקדם וההתקדמות שלו היא לא סוף המסלול
        /// אחרת אם כן הגיע לסוף המסלול הפעולה תחזיר שקר</returns>
        public bool Move(Canvas gameCanvas)
        {
            
            if((this.indexInRoad + 1) < this.road.Count())
            {
                if(this.indexInRoad == 0)
                {
                    gameCanvas.Children.Add(this.EnemyImage);

                }              
                this.EnemyImage.Width = 50;
                this.EnemyImage.Height = 50;
                
                Canvas.SetLeft(this.EnemyImage, this.location.X);
                Canvas.SetTop(this.EnemyImage, this.location.Y);
                this.indexInRoad++;
               
                this.location = this.road[this.indexInRoad];
                return true;
            }
            return false;
        }

        public Point GetNextLocation()
        {
            if ((this.indexInRoad + 1) < this.road.Count())
            {                
                return this.road[this.indexInRoad];
            }
            else
            {
                return new Point(0.0,0.0);
            }
        }

        public void Update(Canvas gameCanvas,GameBL game)
        {
            if (this.HP <= 0)
            {   /*האויב שלי מת!*/
                this.EnemyImage.Source = null;
                this.EnemyImage.Visibility = Visibility.Hidden;
                gameCanvas.Children.Remove(this.EnemyImage);
            }
            else if(this.indexInRoad  == this.road.Count()-1)
            {
                game.DamageTaken(1);
                this.EnemyImage.Source = null;
                this.EnemyImage.Visibility = Visibility.Hidden;
                gameCanvas.Children.Remove(this.EnemyImage);
            }
                                 
        }

        /// <summary>
        /// פעולה לקבלת המיקום שאותו אויב
        /// </summary>
        /// <returns>אמת אם נמצא בסוף בסוף אחרת הפעולה תחזיר שקר</returns>
        public bool IsAtEnd()
        {
            return (this.indexInRoad == this.road.Count() - 1);
        }

        public void Hit(int dmg)
        {
            this.HP -= dmg;
        }

        /// <summary>
        /// פעולה לחישוב כמות הנזק 
        /// </summary>
        /// <param name="dmg">נזק הנעשה לאויב</param>
        /// <param name="towerType">סוג המגדל התוקף</param>
        public void Hit(int dmg,TowerType towerType)
        {
            if(this.type == TowerType.defaultType && towerType == TowerType.defaultType)
            {
                Hit(dmg);
            }
            else if (this.type == TowerType.defaultType && towerType != TowerType.defaultType)
            {
                Hit(dmg + (int)Math.Round(dmg * 1.5));
            }
            else if (this.type == towerType)
            {
                Hit(dmg);
            }
            else
            {
                /*
                 * fire -> air = 0 - 2 = -2
                 *  water -> earth = 1 - 3 = -2
                 *  earth -> fire = 3 - 0 = 3
                 *  Air -> water = 2 - 1 = 1
                 */
                int modifier = towerType - this.type;
                if(modifier == 1 || modifier == 3 || modifier == -2)
                {
                    Hit(dmg + (int)Math.Round(dmg * 0.5));
                }
            }
        }

        public int GetHp()
        {
            return this.HP;
        }


        /// <summary>
        /// פעולה לקבלת המיקום של האויב
        /// </summary>
        /// <returns>נקודה שמייצג את מיקום האויב</returns>
        public Point GetLocation()
        {
            return this.location;
        }

        /// <summary>
        /// פעולה לקבלת עם האויב מת או לא 
        /// </summary>
        /// <returns>הפעולה מחזירה אמת עם האויב מת ושקר אחרת</returns>
        public bool IsDead()
        {
            return (this.HP <= 0);
        }




    }
}
