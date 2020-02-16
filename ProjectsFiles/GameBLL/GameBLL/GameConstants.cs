using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;


namespace GameBLL
{
    public static class GameConstants
    {
        public const double FireToFire = 0.5;
        public const double FireToWater = 0.5;
        public const double FireToAir = 0.5;
        public const double FireToEarth = 1.5;


        public const double WaterToFire = 1.5;
        public const double WaterToWater = 0.5;
        public const double WaterToAir = 0.5;
        public const double WaterToEarth = 0.5;


        public const int TileWidth = 50;
        public const int TileHeight = 50;
        public const int MapWidth = 16;
        public const int MapHeight = 21;
        public const Texture2D projectileTexture = null;//need to change it! ASAP!

        public const Texture2D Wave_Normal_Unit = null;
        public const Texture2D Wave_Normal_Range = null;
        public const Texture2D Wave_Adv_Unit = null;
        public const Texture2D Wave_Adv_Range = null;
        public const Texture2D Wave_Ultra_Unit = null;
        public const Texture2D Wave_Ultra_Range = null;


        public const Texture2D fireBoss = null;
        public const Texture2D waterBoss = null;
        public const Texture2D airBoss = null;
        public const Texture2D earthBoss = null;







    }
}
