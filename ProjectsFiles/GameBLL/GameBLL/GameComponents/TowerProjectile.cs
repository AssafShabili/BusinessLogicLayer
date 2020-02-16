using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;


namespace GameBLL.GameComponents
{
    public class TowerProjectile
    {
        private Enemy target;//אויב שהנמצא של המפה
        private Point position;// מיקום שמימנו נורה הקליע
        private Texture2D texture2D;// איך נראה הקליע
        private int damage;// כמות הנזק של אותו קליע
        private int speed = 10;// מהירות הקליע

        /// <summary>
        /// פעולה בונה למחלקת קליע של מגדל
        /// </summary>
        /// <param name="enemy">אויב </param>
        /// <param name="point">מיקום שמימנו נורה הקליע</param>
        /// <param name="texture2D">איך שנראה הקליע</param>
        /// <param name="dmg">כמות שנזק של אותו קליע</param>
        public TowerProjectile(Enemy enemy, Point point, Texture2D texture2D,int dmg)
        {
            this.target = enemy;
            this.position = point;
            this.damage = dmg;
            this.texture2D = texture2D;
        }

        /// <summary>
        /// פעולה להזזת הקליע
        /// </summary>
        /// <returns>אמת אם אפשר לפגוע (ואם כן אז הפעולה מורידה חיים לאותו אויב) ושקר אם לא אפשר לפגוע בקליע</returns>
        public bool Move()
        {
            Vector2 direction = (position - target.GetLocation()).ToVector2();
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }
            position -= (direction * speed).ToPoint();

            if (Vector2.Distance(position.ToVector2(), target.GetLocation().ToVector2()) < 15)
            {
                DamageTarget();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// פעולה המורידה את כמות החיים של האויב לי כמות הנזק של הבניין
        /// </summary>
        public void DamageTarget()
        {
            target.Hit(damage);
        }
    }
}
