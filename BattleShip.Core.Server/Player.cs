using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using BattleShip.Core;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BattleShip.Core.Server
{
    public class Player:IDisposable
    {
        public GameField field;
        TcpClient player;
        public bool Is_your_move { get; set; } = false;
        public StreamReader Reader { get; private set; }
        public StreamWriter Writer { get; private set; }
        public BinaryWriter WriterBin { get; private set; }

        public Player(TcpClient player_arg)
        {
            player = player_arg;
            var stream = player.GetStream();
            Reader = new StreamReader(stream);
            Writer = new StreamWriter(stream);
            WriterBin = new BinaryWriter(stream);
        }

        public void RequestField() //Генерация/Запрос поля 
        {
            string? fieldData = Reader.ReadLine();
            field = new GameField(fieldData);
        }

        public void Shoot(Player enemy) //Добавить ссылку на сервер в поля класса и через него(сервер) получать 2 игрока
        {
            int x = int.Parse(Reader.ReadLine());
            int y = int.Parse(Reader.ReadLine());

            enemy.field.Shoot(x, y);
            this.Is_your_move = !this.Is_your_move;
            enemy.Is_your_move = !enemy.Is_your_move;
        }

        public string GetFieldData()
        {
            StringBuilder result = new StringBuilder(100); // 10*10 str_field_size
            foreach (var cell in field.Field)
            {
                if (cell.Is_Ship && !cell.Is_Hit)
                    result.Append('■');
                else if (!cell.Is_Ship && !cell.Is_Hit)
                    result.Append(' ');
                else if (!cell.Is_Ship && cell.Is_Hit)
                    result.Append('O');
                else if (cell.Is_Ship && cell.Is_Hit)
                    result.Append('x');
            }
            result.Append('\n');
            return result.ToString();
        }
        public string GetFieldDataHidden()
        {
            StringBuilder result = new StringBuilder(100); // 10*10 str_field_size
            foreach (var cell in field.Field)
            {
                if (!cell.Is_Hit)
                    result.Append(' ');
                else if (!cell.Is_Ship)
                    result.Append('O');
                else if (cell.Is_Ship)
                    result.Append('x');
            }
            result.Append('\n');
            return result.ToString();
        }

        public void Dispose()
        {
            player.Close();
            player.Dispose();
        }

        ~Player() => Dispose();
    }
}
