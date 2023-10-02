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
        Cell[,] _field;

        public GameField(string strField)
        {
            _field = new Cell[SIZE, SIZE];
            for (int i = 0; i < _field.GetLength(0); ++i)
            {
                for (int j = 0; j < _field.GetLength(1); ++j)
                {
                    if (strField[i * 10 + j] == '*')
                    {
                        _field[i, j] = new Cell(CellValue.Ship);
                    }
                    else
                    {
                        _field[i, j] = new Cell(CellValue.Empty);
                    }
                }
            }
        }
        public bool Shoot(int x, int y)
        {
            _field[y, x].Is_Hit = true;
            return _field[y, x].Is_Ship;
        }

        public bool IsWin()
        {
            foreach (var cell in _field)
            {
                return !(cell.Is_Ship && !cell.Is_Hit);
            }
            return true;
        }

        public string PrintField()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < _field.GetLength(0); ++i)
            {
                for (int j = 0; j < _field.GetLength(1); ++j)
                {
                    if (_field[i, j].Is_Ship && !_field[i, j].Is_Hit)
                        result.Append('*');
                    else if (!_field[i, j].Is_Ship && !_field[i, j].Is_Hit)
                        result.Append('k');
                    else if (!_field[i, j].Is_Ship && _field[i, j].Is_Hit)
                        result.Append('o');
                    else if (_field[i, j].Is_Ship && _field[i, j].Is_Hit)
                        result.Append('x');
                }
                result.Append('\n');
            }
            return result.ToString();
        }
    }
}
