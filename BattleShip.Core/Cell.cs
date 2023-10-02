using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Core
{
    enum CellValue:short {Empty = 0, Ship = 1,  }
    internal class Cell
    {
        public bool Is_Hit { get; set; } = false;
        public bool Is_Ship { get; set; }

        public Cell(CellValue ship = CellValue.Empty)
        {
            Is_Ship = Convert.ToBoolean(ship);   
        }
    }
}
