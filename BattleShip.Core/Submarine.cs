using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Core
{
    internal class Submarine: IShip
    {
        Deck[] Decks { get; set; }
        const int deck_count = 1;

        public Submarine(int x, int y)
        { 
            Decks = new Deck[deck_count];
            Decks[0] = new Deck(x, y);
        }
        
    }
}
