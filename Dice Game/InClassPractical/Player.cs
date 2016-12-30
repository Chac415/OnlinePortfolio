using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InClassPractical
{
    class Player
    {
        public string name = null;
        public int teamnum = 0;
        public Random numgenerator;
        public int rannum2 = 0;

    public Player(Random NumGenerator)
    {
        Console.WriteLine("Please enter a player name");
        numgenerator = NumGenerator;
    }

    public int RanNum
    {
        get { return rannum2;}
        set { rannum2 = value;}
    }
    public void setname()
    {
        if (name == null)
        {
            name = Console.ReadLine();
        }
        else Console.WriteLine("You already have a name set, it is {0}", name);
    }

    public void roll()
    {
        numgenerator.Next(1, 21);
        rannum2 = numgenerator.Next(1, 21);
    }

    
    }
}
