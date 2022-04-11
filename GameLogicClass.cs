using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class GameLogicClass
    {
        private static Random r = new Random();
       
        public static int computerMove(int length)
        {
            return r.Next(0, length);
        } 
        public static string getWinCodition(int playerM, int computerM, string[] mov)
        {
            int half = ((mov.Length - 1) / 2);
            if (playerM == computerM) return "Draw";
            if (playerM > computerM) 
            {
                if (playerM - half > 0) 
                { 
                   if(computerM < playerM - half) return "Lose"; 
                }
                return "Win";
            }
            else 
            {
                if (playerM + half < mov.Length) 
                {
                    if(computerM > playerM + half) return "Win"; 
                }
                return "Lose";
            }

        }
    }
}
