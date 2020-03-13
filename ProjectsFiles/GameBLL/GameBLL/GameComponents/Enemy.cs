using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
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
        private Microsoft.Xna.Framework.Point location;
        private TowerType type;
        private Image EnemyImage;
        private List<Microsoft.Xna.Framework.Point> road;
        private int indexInRoad = 0;

       

        private int currentFrame = 0;
        private int frameCount = 4;

        


        public Enemy(int HP,string name, TowerType type)
        {
            this.name = name;
            this.HP = HP;
            //EnemyImage.Source = null /*new BitmapImage(new Uri($@"\MapImg\{this.name}_{this.type}_{this.currentFrame}.png"))*/;
            this.type = type;     
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
        public bool Move()
        {
            if((this.indexInRoad + 1) < this.road.Count())
            {
                Canvas.SetLeft(this.EnemyImage, this.location.X);
                Canvas.SetTop(this.EnemyImage, this.location.Y);
                this.indexInRoad++;
                this.location = this.road[this.indexInRoad];
                return true;
            }
            return false;
        }

        public Microsoft.Xna.Framework.Point GetNextLocation()
        {
            if ((this.indexInRoad + 1) < this.road.Count())
            {                
                return this.road[this.indexInRoad];
            }
            else
            {
                return Microsoft.Xna.Framework.Point.Zero;
            }
        }

        public void Update()
        {
            if(this.HP == 0)
            {   /*האויב שלי מת!*/
                this.EnemyImage.Source = null;
            }
                                 
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
        public Microsoft.Xna.Framework.Point GetLocation()
        {
            return this.location;
        }




    }
}
