using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Core
{
    enum Cell {Empty = 0, Ship = 1 }
    internal class GameField
    {
        uint Size_x { get; set; }
        uint Size_y { get; set; }
        int[,] _field;
        List<IShip> Ships { get; set; }

        void CreateField()
        { 
            
        }

        void SetShip(IShip ship)
        {
            
        }
        bool Is_fieldEmpty(int x, int y)
        {
            return _field[x, y] == 0;
        }
    }
}
