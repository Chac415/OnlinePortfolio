using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InClassPractical
{
    class Teams
    {
        public string mTeamName = null;
        public string Enter = null;
        public Player pplayer1;
        public Player pplayer2;
        public Player pplayer3;
        public Player pplayer4;
        public Player pplayer5;
        public Player pplayer6;


        public Teams(Player player1, Player player2, Player player3, Player player4, Player player5, Player player6, SuperPlayer superplayer1, SuperPlayer superplayer2)
    {
        Console.WriteLine("Please enter a Team name");

            pplayer1 = player1;
            pplayer2 = player2;
            pplayer3 = player3;
            pplayer4 = player4;
            pplayer5 = player5;
            pplayer6 = player6;
            
                
    }
        public void teamnameset()
        {
            if (mTeamName == null)
            {
                mTeamName = Console.ReadLine();
                Console.WriteLine("I would just like to confirm that your team name is {0}, to continue press 'Enter'", mTeamName);

                if (Enter == null)
                {
                   Enter = Console.ReadLine();
                }
                if (Enter == "")
                {
                    Console.WriteLine("Your team name is {0}.", mTeamName);
                }
                                
            }
            else Console.WriteLine("You already have a Team name , it is {0}", mTeamName); 
        }
        
    }
}
