using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameBLL.BLL_Classess;
using GameBLL.GameComponents;
using System.Windows;


namespace GameBLL.GameComponents
{
   
    public class GameEngine
    {
        private GameBL gameBL;
        private bool attackPhase;

      
        public GameEngine(GameBL game)
        {
            this.gameBL = game;
            attackPhase = false;
        }

        public void Update()
        {
            if(attackPhase)
            {
               //attacking time!
            }
            else
            {
                //building time
            }
        }

        


    }


}
