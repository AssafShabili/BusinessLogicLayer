using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameBLL.BLL_Classess;
using GameBLL.GameComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameBLL.GameComponents
{
    /// <summary>
    /// אני לא יודע איך להתחיל אני צריך לחפש יותר מידע
    /// </summary>
    public class GameEngine
    {
        private GameBL gameBL;
        private bool attackPhase;

        private MouseState mouseState;

        public GameEngine(GameBL game)
        {
            this.gameBL = game;
            attackPhase = false;
        }

        public void Update(GameTime gameTime)
        {
            if(attackPhase)
            {
               
            }
        }


    }


}
