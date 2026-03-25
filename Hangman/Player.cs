using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    internal class Player
    {
        //a player should know their 
        public string Name { get; private set;  }
        
        public Player (string name)
        {
            Name = name;
        }
                
    }
}
