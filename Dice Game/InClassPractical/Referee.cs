using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InClassPractical
{
    class Referee
    {
        public Teams team1;
        public Teams team2;
        public Random numgenerator;
        public int rannum1 = 1;
        
        public Referee(Teams Team1, Teams Team2, Random NumGenerator)
        {
            team1 = Team1;
            team2 = Team2;
            numgenerator = NumGenerator;
        }

        

        public void RunGame()
        {
            //rannum1 = numgenerator.Next(1, 4);          

            Console.WriteLine("Can the player that was given the number {0} please take there turn.", rannum1);

        }
        

        public void declarewinner()
        {


        }

    }
}
