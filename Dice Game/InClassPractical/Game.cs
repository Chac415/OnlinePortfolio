using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InClassPractical
{
    class Game
    {
        public string turn = null;
        
        //Methods
        public void startgame()
        {
            
            
            Console.WriteLine("Welcome, and let the games begin.");
            
            //Objects
            Random NumGenerator = new Random();

            Player player1 = new Player(NumGenerator);
            player1.setname();
            player1.teamnum = 2;

            Player player2 = new Player(NumGenerator);
            player2.setname();
            player2.teamnum = 1;

            Player player3 = new Player(NumGenerator);
            player3.setname();
            player3.teamnum = 3;

            Player player4 = new Player(NumGenerator);
            player4.setname();
            player4.teamnum = 3;

            Player player5 = new Player(NumGenerator);
            player5.setname();
            player5.teamnum = 2;

            Player player6 = new Player(NumGenerator);
            player6.setname();
            player6.teamnum = 1;
            
            SuperPlayer Superplayer1 = new SuperPlayer();

            SuperPlayer Superplayer2 = new SuperPlayer();

            Teams Team1 = new Teams(player1, player2, player3, player4, player5, player6, Superplayer1, Superplayer1);
            Team1.teamnameset();

            Teams Team2 = new Teams(player1, player2, player3, player4, player5, player6, Superplayer1, Superplayer1);
            Team2.teamnameset();

            Referee referee = new Referee(Team1, Team2, NumGenerator);
            referee.RunGame();

            if (referee.rannum1 == 1)
            {
                Console.WriteLine("Could the players {0}, {1} please take thier turn", player2.name, player6.name);
                Console.WriteLine("{0} is going first, Please type 'roll' to take your turn.", player6.name);

                if (turn == null)
                {
                    turn = Console.ReadLine();

                }
                if (turn == "roll")
                {
                    Console.WriteLine("you have rolled {0}", player2.rannum2);
                    turn = null;
                }

                if (referee.rannum1 == 2)
                {
                    Console.WriteLine("Could the players {0}, {1} please take thier turn", player5.name, player1.name);
                }
                if (referee.rannum1 == 3)
                {
                    Console.WriteLine("Could the players {0}, {1} please take thier turn", player3.name, player4.name);
                }
            }
        }
            

    }
}
