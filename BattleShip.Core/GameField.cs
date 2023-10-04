using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Core
{
    public class GameField
    {
        const int SIZE = 10;
        public Cell[,] Field { get; private set; }

        public GameField(string strField)
        {
            Field = new Cell[SIZE, SIZE];
            for (int i = 0; i < Field.GetLength(0); ++i)
            {
                for (int j = 0; j < Field.GetLength(1); ++j)
                {
                    if (strField[i * 10 + j] == '*')
                    {
                        Field[i, j] = new Cell(CellValue.Ship);
                    }
                    else
                    {
                        Field[i, j] = new Cell(CellValue.Empty);
                    }
                }
            }
        }
        public bool Shoot(int x, int y)
        {
            Field[y, x].Is_Hit = true;
            return Field[y, x].Is_Ship;
        }

        public bool IsWin()
        {
            foreach (var cell in Field)
            {
                return !(cell.Is_Ship && !cell.Is_Hit);
            }
            return true;
        }
    }
}
