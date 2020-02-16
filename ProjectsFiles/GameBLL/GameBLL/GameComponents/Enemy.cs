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

namespace GameBLL.GameComponents
{
    //TODO more reasech on the  
    public class Enemy
    {
        private int HP;
        private Color color;
        private Point location;
        private TowerType type;
        
        private List<Point> road;
        private int indexInRoad = 0;

        private Texture2D Tex;
        private int spriteHeight;
        private int spriteWidth;

        private int currentFrame = 0;
        private int frameCount = 0;
        private int frameTotalDuration = 200;
        private int frameDuration = 0;


        public Enemy(int HP, Texture2D tex,TowerType type,int spriteHeight, int spriteWidth)
        {
            this.HP = HP;
            this.Tex = tex;
            this.type = type;
            this.color = Color.White;
            this.spriteHeight = spriteWidth;
            this.spriteWidth = spriteWidth;
        }

        public Enemy(int HP, Texture2D tex, TowerType type, int spriteHeight, int spriteWidth,Color color)
        {
            this.HP = HP;
            this.Tex = tex;
            this.type = type;
            this.color = Color.White;
            this.spriteHeight = spriteWidth;
            this.spriteWidth = spriteWidth;
            this.color = color;
        }


        public void Draw(SpriteBatch batch)
        {            
            batch.Draw(Tex, this.location.ToVector2(), new Rectangle(new Point(currentFrame * this.spriteWidth, 1 * this.spriteHeight), new Point(this.spriteWidth, this.spriteHeight)), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
        }

        public void Move()
        {
            if((this.indexInRoad + 1) < this.road.Count())
            {
                this.indexInRoad++;
                this.location = this.road[this.indexInRoad];
            }
            else
            {
                // he reached the end what to do now ?
            }
        }

        public Point GetNextLocation()
        {
            if ((this.indexInRoad + 1) < this.road.Count())
            {                
                return this.road[this.indexInRoad];
            }
            else
            {
                return Point.Zero;
            }
        }

        public void Update(GameTime gameTime)
        {
            if (HP <= 0)
            {
                color.R -= 15;
                color.G -= 15;
                color.B -= 15;
                
            }

            if (this.location != this.GetNextLocation())
            {
                Move();
            }                       
        }

        public void Hit(int dmg)
        {
            this.HP -= dmg;
        }

        /// <summary>
        /// פעולה לחישוב כמות הנזק 
        /// צריך לתקן את צורת החישוב + איך ששני סוגים נפגשים
        /// </summary>
        /// <param name="dmg">נזק הנעשה לאויב</param>
        /// <param name="towerType">סוג המגדל התוקף</param>
        public void Hit(int dmg,TowerType towerType)
        {
            if (this.type == towerType)
            {
                this.HP = (int)(dmg * (0.5));
            }
            else if (this.type == TowerType.Air && this.type == TowerType.Water)
            {
                
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




    }
}
