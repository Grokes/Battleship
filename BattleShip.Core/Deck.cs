namespace BattleShip.Core
{
    internal class Deck
    {
        int Coord_x { get;}
        int Coord_y { get;}
        bool Is_dead { get; set; } = false;

        public Deck(int x, int y)
        { 
            Coord_x = x;
            Coord_y = y;
        }
    }
}