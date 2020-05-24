using GameBLL.GameComponents;
using GameDAL.DAL_Classess;
using System.Windows;
using System.Windows.Controls;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameBLL.BLL_Classess
{
    public enum TowerType
    {
        Fire,
        Water,
        Air,
        Earth,
        defaultType
    }

    public class TowerBL
    {
        
        private int towerID;//מפתח של המגדל בטבלה

        private int damage;//כמות הנזק של מגדל
        private int attackSpeed;//מספר התקיפה שלו
        private int range;//מרחק

        private int cost;//עלות המגדל

        private int damageLevel;//רמת השדרוג של הנזק של המגדל
        private int attackSpeedLevel;//רמת השידרוג של מפשר התקיפות שלו
        private int rangeLevel;// רמת שידרוג של המרחק

        private Point location; // מיקום המגדל
        private TowerType towerType = TowerType.defaultType;// סוג המגדל
        private string TowerImgName;//שם של קובץ המגדל

        private Button towerButton;//ה'תמונה' המגדל

  


        private double coolDown = 0;

        /// <summary>
        /// פעולה בונה של מחלקת מגדל
        /// </summary>
        /// <param name="towerID">מפתח של מגדל</param>
        public TowerBL(int towerID)
        {
            DataTable dtTower = Tower.GetTowerInfo(towerID);

            if(dtTower != null)
            {
                Console.WriteLine(DataTablePrint.BuildTable(dtTower,17));

                this.towerID = towerID;

                this.towerType = this.GetTowerTypeFromString(dtTower.Rows[0][0].ToString());

                this.range = (int)dtTower.Rows[0][1];
                this.damage = (int)dtTower.Rows[0][2];
                this.attackSpeed = (int)dtTower.Rows[0][3];

                this.TowerImgName = (string)dtTower.Rows[0]["Tower_Img"];

                this.location = new Point((int)dtTower.Rows[0][4], (int)dtTower.Rows[0][5]);

                this.cost = (int)dtTower.Rows[0][6];

                //Rows[0][7] - Img

                /**/
                this.rangeLevel = (int)dtTower.Rows[0][8];
                this.damageLevel = (int)dtTower.Rows[0][9];
                this.attackSpeedLevel = (int)dtTower.Rows[0][10];
                

                this.towerButton = new Button();
                Image image = new Image();
                image.Source = GetBitmapImage(this.TowerImgName);
                image.Stretch = Stretch.None;
                image.Width = 50;
                image.Height = 50;

                this.towerButton.Content = image;
                this.towerButton.Width = 50;
                this.towerButton.Height = 50;
                //this.Tex = Content
            }
        }

        /// <summary>
        /// פעולה בונה ריקה של המגדל
        /// </summary>
        public TowerBL()
        {
            
        }

        /// <summary>
        /// פעולה לעדכון התמונה של המגדל לפי סוג המגדל
        /// </summary>
        public void UpdateImage()
        {
            this.TowerImgName = $"Tower_{this.towerType.ToString().ToLower()}.png";
            ((Image)(this.towerButton.Content)).Source = GetBitmapImage(this.TowerImgName);
        }

        /// <summary>
        /// פעולה ליצירת מגדל והכנסתו לבסיס הנתונים
        /// </summary>
        /// <returns></returns>
        public int MakeTower()
        {
            return Tower.CreateDefaultTower();
        }

        /// <summary>
        /// פעולה ליצירת המגדל להכנסתו לבסיס הנתונים
        /// </summary>
        /// <param name="type">סוג המגדל</param>
        /// <param name="x">מיקומו בלוח X</param>
        /// <param name="y">מיקומו הלוח Y</param>
        /// <returns>הפעולה תחזיר את הID של אותו מגדל</returns>
        public int makeTower(string type,int x, int y)
        {
            return Tower.CreateDefaultTower(type,x,y);
        }

        /// <summary>
        /// פעולה לשינוי המחזירה סוג של מגדל לפי הסטריג שהיא קיבלה
        /// </summary>
        /// <param name="input">סריטג שמייצג את סוג במגדל</param>
        /// <returns>מחזירה סוג של מגדל לפי הסטריג שהיא קיבלה</returns>
        private TowerType GetTowerTypeFromString(string input)
        {
            switch (input.ToLower())
            {
                case "water":
                    return TowerType.Water;
                case "fire":
                    return TowerType.Fire;
                case "air":
                    return TowerType.Air;
                case "earth":
                    return TowerType.Earth;
                default:
                    return TowerType.defaultType;
            }
        }

        // =========== פעולות לעדכון המערכים של המגדל ==================
                  /*לכל אחת המפעולות יש צורת חישוב משלה*/
        public void UpgradeDamage()
        {
            this.damageLevel++;
            this.damage = this.damage * this.damageLevel;
            Tower.UpgradeTowerDamage(this.towerID, this.damage);            
            //update damageLevel
        }
        public void UpgradeAttackSpeed()
        {
            this.attackSpeedLevel++;
            this.attackSpeed = this.attackSpeed - 5;
            Tower.UpgradeTowerAttackSpeed(this.towerID, this.attackSpeed);
          
        }
        public void UpgradeRange()
        {
            this.rangeLevel++;
            this.range = this.range + (10*this.rangeLevel);
            Tower.UpgradeTowerRange(this.towerID, this.range);
           
        }
        // =========== פעולות לעדכון המערכים של המגדל סיום =============

        

        // ==================  פעולות לשידרוג הערכים של המגדל ===================                        
        public int GetCostToUpgradeDamage()
        {
            return this.cost * this.damageLevel;
        }
        public int GetCostToUpgradeAttackSpeed()
        {
            return this.cost * this.attackSpeedLevel;
        }
        public int GetCostToUpgradeRange()
        {
            return this.cost * this.rangeLevel;
        }
        // ================== פעולות לשידרוג הערכים של המגדל סיום ===============



        /// <summary>
        /// פעולה לקבלת כמות הסכום התקבל המכירת המגדל הנלל 
        /// </summary>
        /// <param name="gameID">מפתח של המשחק שבו נמצא המגדל</param>
        /// <returns>את כמות הכסף שיקבל המשחקן</returns>
        public int SellTowerCost(int gameID)
        {

            //need to update the database!

            double towerValue =  ((this.rangeLevel + this.damageLevel + this.attackSpeedLevel ) / (double)this.cost);
            if (towerValue.ToString().Count<char>() >= 3 && towerValue.ToString()[0] == '0')
            {
                return (int)Math.Round(towerValue * 100.0);
            }
            return (int)Math.Round(towerValue * 10.0);
        }

        /// <summary>
        /// פעולה למחיקה של המגדל
        /// </summary>
        /// <param name="gameID">מפתח של המשחק</param>
        public void DeleteTower(int gameID)
        {
            GameDAL.DAL_Classess.Game.DeleteGameTower(gameID, this.towerID);
        }


        
        /// <summary>
        /// פעולה לחישוב מרחק הפגיעה של המגדל הנתון
        /// </summary>
        /// <returns>מחזיר עיגול שמייצג את המרחק שבו המגדל יכול לירות על אויבים</returns>
        public Circle GetTowerAttackRange()
        {            
            return new Circle(this.location.X,this.location.Y, this.range);
        }

        /// <summary>
        /// פעולה לבדיקה עם מיקום כלשהו 
        /// </summary>
        /// <param name="postion">מיקום של אויב</param>
        /// <returns>מחזיר אמת אם המיקום נמצא בתוך המעגל אחרת שקר</returns>
        public bool DoesTowerAttackRangeContainsPoint(Point postion)
        {
            return GetTowerAttackRange().ContainsPoint(postion);
        }


        /// <summary>
        /// פעולה לפגיעה באויבים
        /// </summary>
        /// <param name="enemylist">שרשרת של אויבים</param>
        /// <param name="projectilelist">שרשרת של קליעים של אותו מגדל</param>
        /// <param name="elapsedTime">הזמן שעבר מאז שהתחיל המשחק</param>
        /// <returns>שרשרת עם כל הקליעים שצריך "לירות" אותם/returns>
        public List<TowerProjectile> TowerAttack(List<Enemy> enemylist, List<TowerProjectile> projectilelist, double elapsedTime)
        {
            foreach(Enemy enemy in enemylist)
            {
                if (this.GetTowerAttackRange().ContainsPoint(enemy.GetLocation())
                    // the total time of the game - the last time the tower shot  > the amount the tower shoots
                    && (elapsedTime - this.coolDown) > this.attackSpeed)
                {
                    projectilelist.Add(new TowerProjectile(enemy, this.location
                        , this.damage));
                    coolDown = elapsedTime;
                }
            }
            return projectilelist;
        }

        


        /// <summary>
        /// פעולה לשינוי סוג מגדל
        /// </summary>
        /// <param name="towerType">סוג חדש</param>
        public void SetTowerType(TowerType towerType)
        {
            this.towerType = towerType;
            
            GameDAL.DAL_Classess.Game.ChangeTypeTower(this.towerID, this.towerType.ToString());
        }

        /// <summary>
        /// פעולה לקבלת סוג המגדל
        /// </summary>
        /// <returns>את סוג המגדל</returns>
        public TowerType GetTowerType()
        {
            return this.towerType;
        }

        /// <summary>
        /// פעולה לקבלת מיקום המגדל
        /// </summary>
        /// <returns>נקודה שהיא מיקום המגדל</returns>
        public Point GetLocation()
        {
            return this.location;
        }

        /// <summary>
        /// פעולה לקבלת מפתח המגדל
        /// </summary>
        /// <returns>מפתח המגדל</returns>
        public int GetTowerID()
        {
            return this.towerID;
        }  
       
        /// <summary>
        /// פעולה להחזרת עלות המגדל
        /// </summary>
        /// <returns>עלות בניית המגדל</returns>
        public int GetTowerCost()
        {
            return this.cost;
        }
        /// <summary>
        /// פעולה לקבלת הכפתור של המגדל
        /// </summary>
        /// <returns>את הכפתור של המגדל</returns>
        public Button GetTowerButton()
        {
            return this.towerButton;
        }

        // ======= get's for the info of the towers
        public int GetAttackSpeed()
        {
            return this.attackSpeed;
        }
        public int GetDamage()
        {
            return this.damage;
        }
        public int GetRange()
        {
            return this.range;
        }
        public string GetTowerImage()
        {
            return this.TowerImgName;
        }
        public int GetAttackSpeedLevel()
        {
            return this.attackSpeedLevel;
        }
        public int GetDamageLevel()
        {
            return this.damageLevel;
        }
        public int GetRangeLevel()
        {
            return this.rangeLevel;
        }
        // ============= end ========================


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
            bitMap.UriSource = new Uri($@"\MapImg\{mapName}", UriKind.Relative);
            bitMap.EndInit();
            return bitMap;
        }


    }
}
